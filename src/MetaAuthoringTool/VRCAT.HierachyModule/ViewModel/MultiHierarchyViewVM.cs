using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VRCAT.DataModel;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;
using VRCAT.Infrastructure.DragDrop;
using WPFXCommand;

namespace VRCAT.HierarchyModule
{
    public class MultiHierarchyViewVM : BindableBase, IDropTarget
    {
        public bool IsFocused = false;
        HierarchyVM rootNodeVM;
        List<MMemFile> CopyFileList = new List<MMemFile>();
        ObservableCollection<HierarchyVM> _SelectedItems;
        public ObservableCollection<HierarchyVM> SelectedItems
        {
            get
            {
                if (_SelectedItems == null)
                    _SelectedItems = new ObservableCollection<HierarchyVM>();
                return _SelectedItems;
            }
            set { SetProperty(ref _SelectedItems, value); }
        }
        ObservableCollection<HierarchyVM> _SceneObject;
        public ObservableCollection<HierarchyVM> SceneObject
        {
            get
            {
                if (_SceneObject == null)
                    _SceneObject = new ObservableCollection<HierarchyVM>();
                return _SceneObject;
            }
            set { SetProperty(ref _SceneObject, value); }
        }
        ICommand _TestBehavior;
        public ICommand TestBehavior
        {
            get
            {
                if (_TestBehavior == null)
                    _TestBehavior = new RelayCommand(new Action<object>(TestFucntion));
                return _TestBehavior;
            }
        }

        private void TestFucntion(object obj)
        {
            
        }

        ICommand _CreateObject;
        public ICommand CreateObject
        {
            get
            {
                if (_CreateObject == null)
                    _CreateObject = new RelayCommand(CreateObjectBehavior);
                return _CreateObject;
            }
        }
        private void CreateObjectBehavior(object obj)
        {
            MContainer parentContainer = null;
            MContainer childContainer = null;

            if (VRWorld.Instance.LasetedSelectedContainer != null)
                parentContainer = (MContainer)VRWorld.Instance.LasetedSelectedContainer;
            else
                parentContainer = (MContainer)rootNodeVM.NodeObject;

            RoutedEventArgs re = (RoutedEventArgs)obj;

            MenuItem mi = re.Source as MenuItem;

            if (mi.Header.ToString().Equals("Camera"))
                childContainer = new MCamera(false);
            else if (mi.Header.ToString().Equals("Light"))
                childContainer = new MLight();
            else if (mi.Header.ToString().Equals("Cube"))
                childContainer = new MCube();
            else if (mi.Header.ToString().Equals("Container"))
                childContainer = new MContainer();
            else if (mi.Header.ToString().Equals("Sphere"))
                childContainer = new MSphere();
            else if (mi.Header.ToString().Equals("2D Texture"))
                new MGUITexture();
            if (childContainer != null)
                parentContainer.AddChild(childContainer);
            RefreshNodeView();
        }
        ICommand _ItemSelected;
        public ICommand SelectedItemChange
        {
            get
            {
                if (_ItemSelected == null)
                    _ItemSelected = new RelayCommand(SelectedItemChangeBehavior);
                return _ItemSelected;
            }
        }
        private void SelectedItemChangeBehavior(object obj)
        {
            if (obj != null)
            {
                ObservableCollection<HierarchyVM> vmList = (ObservableCollection<HierarchyVM>)obj;
                if (vmList.Count == 0)
                {
                    if (VRWorld.Instance.LasetedSelectedContainer != null)
                    {
                        //    MGizmoHandler.GetInstance().SetEnable(false);
                        //    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
                        VRWorld.Instance.LasetedSelectedContainer = null;
                    //    MGizmoHandler.GetInstance().DetachAllGizmo();
                    //    MWorld.GetInstance().ChildContainerSelect(false);
                    //    return;
                    }
                }
                else if (vmList.Count > 1)
                {
                    MContainer templateContainer = new MContainer();
                    templateContainer.ContiguousContainerList.Clear();
                    foreach (HierarchyVM v in vmList)
                    {
                        templateContainer.ContiguousContainerList.Add((MContainer)v.NodeObject);
                        ((MContainer)v.NodeObject).Selected(true);
                    }
                    if (VRWorld.Instance.LasetedSelectedContainer != null && VRWorld.Instance.LasetedSelectedContainer == templateContainer)
                        return;
                    MGizmoHandler.GetInstance().DetachAllGizmo();
                    MWorld.GetInstance().ChildContainerSelect(false);
                    VRWorld.Instance.LasetedSelectedContainer = templateContainer;
                    //MGizmoHandler.GetInstance().SetObject(templateContainer);
                    //MGizmoHandler.GetInstance().SetEnable(true);
                    //Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = templateContainer });
                }
                else
                {
                    HierarchyVM firstVM = vmList.FirstOrDefault();
                    MContainer container = (MContainer)firstVM.NodeObject;
                    if (VRWorld.Instance.LasetedSelectedContainer != null && VRWorld.Instance.LasetedSelectedContainer == container)
                        return;
                    MGizmoHandler.GetInstance().DetachAllGizmo();
                    MWorld.GetInstance().ChildContainerSelect(false);
                    container.Selected(true);
                    VRWorld.Instance.LasetedSelectedContainer = container;
                    //if (container.Transform != null)
                    //{
                    //    MGizmoHandler.GetInstance().SetObject(container);
                    //    MGizmoHandler.GetInstance().SetEnable(true);
                    //}
                    //Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = container });
                }
            }
        }
        ICommand _SendSelectedItemToInspector;
        public ICommand SendSelectedItemToInspector
        {
            get
            {
                if (_SendSelectedItemToInspector == null)
                    _SendSelectedItemToInspector = new RelayCommand(SendSelectedItemToInspectorBehavior);
                return _SendSelectedItemToInspector;
            }
        }
        private void SendSelectedItemToInspectorBehavior(object obj)
        {
            if (VRWorld.Instance.LasetedSelectedContainer is MContainer && VRWorld.Instance.LasetedSelectedContainer != null)
            {
                MContainer o = (MContainer)VRWorld.Instance.LasetedSelectedContainer;
                MGizmoHandler.GetInstance().SetObject(o);
                MGizmoHandler.GetInstance().SetEnable(true);
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = o });
            }
            else if(VRWorld.Instance.LasetedSelectedContainer == null)
            {
                MGizmoHandler.GetInstance().SetEnable(false);
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
                MGizmoHandler.GetInstance().DetachAllGizmo();
                MWorld.GetInstance().ChildContainerSelect(false);
            }
        }

        ICommand _KeyDownCommand;
        public ICommand KeyDownCommand
        {
            get
            {
                if (_KeyDownCommand == null)
                    _KeyDownCommand = new RelayCommand(KeyDownExecute, KeyDownCanExecute);
                return _KeyDownCommand;
            }
        }
        private bool KeyDownCanExecute(object obj)
        {
            if (((KeyEventArgs)obj).Key == Key.F2)
                return true;
            return false;
        }
        private void KeyDownExecute(object obj)
        {
            ((HierarchyVM)((TreeViewItem)obj).Header).IsEditMode = true;
        }
        ICommand _FocusObject;
        public ICommand FocusObject
        {
            get
            {
                if (_FocusObject == null)
                    _FocusObject = new RelayCommand(FocusObjectClick);
                return _FocusObject;
            }
        }
        private void FocusObjectClick(object obj)
        {
            if (VRWorld.Instance.LasetedSelectedContainer != null)
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.FocusToObject, VRWorld.Instance.LasetedSelectedContainer));
        }
        ICommand _DeleteObject;
        public ICommand DeleteObject
        {
            get
            {
                if (_DeleteObject == null)
                    _DeleteObject = new RelayCommand(DeleteObjectClick);
                return _DeleteObject;
            }
        }
        private void DeleteObjectClick(object obj)
        {
            if (IsFocused)
            {
                if (VRWorld.Instance.LasetedSelectedContainer != null)
                {
                    MGizmoHandler.GetInstance().SetEnable(false);
                    if (((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList.Count > 0)
                        foreach (MContainer innerContainer in ((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList)
                            innerContainer.RemoveThis();
                    else
                        ((MContainer)VRWorld.Instance.LasetedSelectedContainer).RemoveThis();
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
                    RefreshNodeView();

                    //StateManager.Instance.ChangeSet(new UndoCommand
                    //    (() =>
                    //    {

                    //    },
                    //    () =>
                    //    {
                    //        if (null != BeforeSelectedObj.Parent)
                    //            BeforeSelectedObj.Parent.AddChild(BeforeSelectedObj);
                    //        else
                    //            MWorld.GetInstance().AddChild(BeforeSelectedObj);
                    //        RefreshNodeView();
                    //        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = BeforeSelectedObj });
                    //    }));
                }
            }
        }
        ICommand _CopyCommand;
        public ICommand CopyCommand
        {
            get
            {
                if (_CopyCommand == null)
                    _CopyCommand = new RelayCommand(CopyBehavior);
                return _CopyCommand;
            }
        }
        ICommand _PasteCommand;
        public ICommand PasteCommand
        {
            get
            {
                if (_PasteCommand == null)
                    _PasteCommand = new RelayCommand(PasteBehavior);
                return _PasteCommand;
            }
        }
        private ICommand _TextChanged;
        public ICommand TextChanged
        {
            get
            {
                if (_TextChanged == null)
                    _TextChanged = new RelayCommand(new Action<object>(TextChangedFunction));
                return _TextChanged;
            }
            set
            {
                _TextChanged = value;
            }
        }
        private void TextChangedFunction(object param)
        {
            TextBox text = (TextBox)param;
            if (text.Text != "")
            {
                searchElement(text.Text.ToString());
            }
            else
                RefreshNodeView();
        }
        public void CopyBehavior(object obj)
        {
            if (VRWorld.Instance.LasetedSelectedContainer != null)
            {
                CopyFileList.Clear();
                if (((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList.Count > 0)
                {
                    foreach (MContainer innerContainer in ((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList)
                    {
                        MMemFile f = new MMemFile();
                        f.MContainerCopy(innerContainer);
                        CopyFileList.Add(f);
                    }
                }
                else
                {
                    MMemFile f = new MMemFile();
                    f.MContainerCopy(((MContainer)VRWorld.Instance.LasetedSelectedContainer));
                    CopyFileList.Add(f);
                }
                //MMemFile.GetInstance().MContainerCopy(BeforeSelectedObj);
            }
        }
        public void PasteBehavior(object obj)
        {
            //MContainer pasteObj = MMemFile.GetInstance().MContainerPasty();
            //if (pasteObj != null)
            //{
            //    if (BeforeSelectedObj != null)
            //        BeforeSelectedObj.AddChild(pasteObj);
            //    else
            //        MWorld.GetInstance().AddChild(pasteObj);
            //    RefreshNodeView();
            //}
            bool IsChangeNodeView = false;
            foreach (MMemFile mFile in CopyFileList)
            {
                if(VRWorld.Instance.LasetedSelectedContainer != null && ((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList.Count == 0)
                {
                    MContainer pastyContainer = mFile.MContainerPasty();
                    ((MContainer)VRWorld.Instance.LasetedSelectedContainer).AddChild(pastyContainer);
                    IsChangeNodeView = true;
                }
                else 
                {
                    MWorld.GetInstance().AddChild(mFile.MContainerPasty());
                    IsChangeNodeView = true;
                }
            }
            if (IsChangeNodeView)
            {
                RefreshNodeView();
            }
        }
        public MultiHierarchyViewVM()
        {
            /// RenderWindow 가 생성되었음을 확인하는 이벤트
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<EngineEvent>>().Subscribe(param =>
            {
                switch (param.eventArg)
                {
                    /// RenderWindow 가  생성되었으면
                    case EngineEventArg.RenderWindowCreated:
                        {
                            /// World 를 생성하고 난 후에
                            MWorld _Scene = MWorld.GetInstance();
                            rootNodeVM = new HierarchyVM(_Scene);
                            /// World 를 생성했다고 메세지를 보냄
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<EngineEvent>>().Publish(new EngineEvent() { eventArg = EngineEventArg.WorldCreated });
                            break;
                        }
                }
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(param =>
            {
                if (param == "RefreshNode")
                    RefreshNodeView();
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(param =>
            {
                if (param.Equals("SceneLoading"))
                {
                    rootNodeVM = new HierarchyVM(MWorld.GetInstance());
                    RefreshNodeView();
                }
            });

            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<DeleteContainerFromRenderView>>().Subscribe(param =>
            {
                IsFocused = true;
                DeleteObjectClick(null);
                IsFocused = false;
            });

            KeyBinding CopyKey = new KeyBinding(CopyCommand, new KeyGesture(Key.C, ModifierKeys.Control));
            if (!Application.Current.MainWindow.InputBindings.Contains(CopyKey))
                Application.Current.MainWindow.InputBindings.Add(CopyKey);
            KeyBinding PasteKey = new KeyBinding(PasteCommand, new KeyGesture(Key.V, ModifierKeys.Control));
            if (!Application.Current.MainWindow.InputBindings.Contains(PasteKey))
                Application.Current.MainWindow.InputBindings.Add(PasteKey);

            //KeyBinding DeleteKey = new KeyBinding(DeleteObject, new KeyGesture(Key.Delete));
            //if (!Application.Current.MainWindow.InputBindings.Contains(DeleteKey))
            //    Application.Current.MainWindow.InputBindings.Add(DeleteKey);
            KeyBinderMultiCommand.Instance.AddKeyBinderMultiCommand(new KeyGesture(Key.Delete), DeleteObject);

            KeyBinding TestKey = new KeyBinding(TestBehavior, new KeyGesture(Key.T, ModifierKeys.Control));
            Application.Current.MainWindow.InputBindings.Add(TestKey);
        }
        private void RefreshNodeView()
        {
            rootNodeVM.ChildObject.Clear();
            SceneObject.Clear();
            GetNodeRecursive(rootNodeVM);
            foreach (HierarchyVM v in rootNodeVM.ChildObject)
            {
                SceneObject.Add(v);
            }
        }
        private void GetNodeRecursive(NodeVM ParentVM)
        {
            for (int i = 0; i < ((MContainer)ParentVM.NodeObject).GetChildrenCount(); i++)
            {
                MContainer childNode = ((MContainer)ParentVM.NodeObject).GetChild(i);
                HierarchyVM childVM = new HierarchyVM(childNode) { Name = childNode.Name };
                childVM.ParentObject = ParentVM;
                ParentVM.ChildObject.Add(childVM);
                if (childNode.GetChildrenCount() > 0)
                    GetNodeRecursive(childVM);
            }
        }
        public void DragOver(IDropInfo dropInfo)
        {
            
            if (dropInfo.Data == dropInfo.TargetItem)
                return;
            if (dropInfo.Data is NodeVM || dropInfo.Data is FileModel)
            {
                if (dropInfo.Data is FileModel)
                {
                    string ext = ((FileModel)dropInfo.Data).FileExtension;
                    if (ext.Equals("ffbx") || ext.Equals("FFBX"))
                    {
                        dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                        dropInfo.Effects = System.Windows.DragDropEffects.Copy;
                    }
                }
                else
                {
                    /// 마우스로 선택한 데이터
                    //object data = dropInfo.Data;
                    //object target = dropInfo.TargetItem;

                    foreach(var selectedObj in ((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList) {
                        HierarchyVM parent = ((HierarchyVM)dropInfo.TargetItem);
                        while (parent != null)
                        {
                            if (parent.NodeObject == selectedObj)
                                return;
                            parent = (HierarchyVM)parent.ParentObject;
                        }
                    }
                    
                    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                    dropInfo.Effects = System.Windows.DragDropEffects.Copy;
                }
            }
        }
        public void Drop(IDropInfo dropInfo)
        {
            /// HierarchyView 내에서 Node 간 이동처리
            //if (dropInfo.Data is NodeVM)
            //{
            //    MContainer DropTargetData;
            //    MContainer DropSourceData = (MContainer)((NodeVM)dropInfo.Data).NodeObject;
            //    if (dropInfo.TargetItem == null)
            //        DropTargetData = DropSourceData.Root;
            //    else
            //        DropTargetData = (MContainer)((NodeVM)dropInfo.TargetItem).NodeObject;


            //    ///TODO : UnDO , ReDO StateManager 테스트 용
            //    //StateManager.Instance.ChangeSet(
            //    //    new UndoCommand(() =>
            //    //    {
            //    //        DropTargetData.AddChild(DropSourceData);
            //    //        RefreshNodeView();
            //    //    },
            //    //    () =>
            //    //    {
            //    //        DropTargetData = DropSourceData.GetParent();
            //    //        DropTargetData.AddChild(DropSourceData);
            //    //        RefreshNodeView();
            //    //    }));
            //    DropSourceData.SetParent(DropTargetData);
            //    //DropTargetData.IsExpanded = true;
            //    RefreshNodeView();
            //    PickingEvent.Instance.PickElements.Clear();
            //    PickingEvent.Instance.PickElements.Add(DropTargetData);
            //    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);
            //}

            if(VRWorld.Instance.LasetedSelectedContainer != null && !(dropInfo.Data is FileModel))
            {
                MContainer DropTargetData;
                if (dropInfo.TargetItem == null)
                    DropTargetData = MWorld.GetInstance();
                else
                    DropTargetData = (MContainer)((NodeVM)dropInfo.TargetItem).NodeObject;

                
                MContainer preParentContainer = ((MContainer)VRWorld.Instance.LasetedSelectedContainer).Parent;
                List<MContainer> preParentContainers = new List<MContainer>();
                if(((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList.Count > 0)
                {
                    foreach (MContainer container in ((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList)
                        preParentContainers.Add(container.Parent);
                }

                MContainer LastContainer = ((MContainer)VRWorld.Instance.LasetedSelectedContainer);

                StateManager.Instance.ChangeSet(
                    new UndoCommand(() =>
                    {
                        if (((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList.Count > 0)
                            foreach (MContainer c in ((MContainer)VRWorld.Instance.LasetedSelectedContainer).ContiguousContainerList)
                                c.SetParent(DropTargetData);
                        else
                            ((MContainer)VRWorld.Instance.LasetedSelectedContainer).SetParent(DropTargetData);
                        RefreshNodeView();
                        PickingEvent.Instance.PickElements.Clear();
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);
                        
                    },
                    () =>
                    {
                        if (LastContainer.ContiguousContainerList.Count > 0)
                        {
                            for (int i = 0; i < LastContainer.ContiguousContainerList.Count; i++)
                            {
                                MContainer c = LastContainer.ContiguousContainerList[i];
                                c.SetParent(preParentContainers.ElementAt(i));
                            }
                        }
                        else
                            LastContainer.SetParent(preParentContainer);
                        RefreshNodeView();
                        PickingEvent.Instance.PickElements.Clear();
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);
                    }));

                //if (_lastSelectedContainer.ContiguousContainerList.Count > 0)
                //    foreach (MContainer c in _lastSelectedContainer.ContiguousContainerList)
                //        c.SetParent(DropTargetData);
                //else
                //    _lastSelectedContainer.SetParent(DropTargetData);



                //RefreshNodeView();
                //PickingEvent.Instance.PickElements.Clear();
                //Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);
            }

            else if (dropInfo.Data is FileModel)
            {
                //string path = ((FileModel)dropInfo.Data).FullPath;
                //MFbx f = null;
                //if (null != dropInfo.TargetItem)
                //    f = new MFbx(path, (MContainer)((NodeVM)dropInfo.TargetItem).NodeObject);
                //else
                //    f = new MFbx(path);

                //f.Name = ((FileModel)dropInfo.Data).Name;

                //RefreshNodeView();
                //PickingEvent.Instance.PickElements.Clear();
                //PickingEvent.Instance.PickElements.Add(f);
                //Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);

                MFbx f = new MFbx();
                ///TODO : UnDO , ReDO StateManager 테스트 용
                StateManager.Instance.ChangeSet(
                    new UndoCommand(() =>
                    {
                        string path = ((FileModel)dropInfo.Data).FullPath;
                        f.SetFBX(path);
                        if (null != dropInfo.TargetItem)
                            f.SetParent((MContainer)((NodeVM)dropInfo.TargetItem).NodeObject);
                        //f = new MFbx(path, (MContainer)((NodeVM)dropInfo.TargetItem).NodeObject);
                        else
                            f.SetParent(MWorld.GetInstance());
                        //f = new MFbx(path);
                        f.Name = ((FileModel)dropInfo.Data).Name;
                        PickingEvent.Instance.PickElements.Clear();
                        PickingEvent.Instance.PickElements.Add(f);
                        RefreshNodeView();
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);
                        MLog.GetInstance().SetLog("Model Resource Added : " + f.Name);
                    },
                    () =>
                    {
                        MLog.GetInstance().SetLog("Model Resource Add Cancel : " + f.Name);
                        f.RemoveThis();
                        PickingEvent.Instance.PickElements.Clear();
                        RefreshNodeView();
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);
                    }));
            }
        }
        public void searchElement(string name)
        {
            
            _SceneObject.Clear();
            //if (rootNodeVM == null)
            //{
            //    rootNodeVM = new HierarchyVM();
            //    rootNodeVM.Name = "root";
            //}

            Func<HierarchyVM, IEnumerable<HierarchyVM>> flattener = null;
            flattener = t => new[] { t }
                .Concat(t.ChildObject == null
                        ? Enumerable.Empty<HierarchyVM>()
                        : t.ChildObject.SelectMany(child => flattener((HierarchyVM)child)));
            IEnumerable<HierarchyVM> sortVM = flattener(rootNodeVM).Skip(1);
            //var result = flattener(rootNodeVM).Where(n => n.Name.Contains(name)).OrderBy(n => n.Name);
            var result = sortVM.Where(n => n.Name.Contains(name)).OrderBy(n => n.Name);
            //Console.WriteLine("탐색시간 : " + timestamp.ElapsedMilliseconds.ToString() + "ms");

            foreach (var j in result)
                _SceneObject.Add((HierarchyVM)j);
        }
    }
}
