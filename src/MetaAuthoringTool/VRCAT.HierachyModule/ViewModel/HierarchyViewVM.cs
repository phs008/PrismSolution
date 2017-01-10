using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVRWrapper;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.ObjectModel;
using VRCAT.Infrastructure;
using VRCAT.DataModel.Event;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.Infrastructure.DragDrop;
using System.Windows.Input;
using WPFXCommand;
using VRCAT.DataModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Windows.Controls;

namespace VRCAT.HierarchyModule
{
    public class HierarchyViewVM : BindableBase, IDropTarget
    {
        /// 멀티셀릭트 뷰 작업중
        public Infrastructure.MultiSelectTreeView _MultiSelectTreeView;
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

        public MContainer BeforeSelectedObj = null;
        HierarchyVM rootNodeVM;
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
        ICommand _SelectNodeObject;
        ICommand _SelectedObjectLBDown;
        ICommand _DeleteObject;
        ICommand _KeyDownCommand;
        ICommand _CopyCommand;
        ICommand _PasteCommand;
        public DelegateCommand<RoutedEventArgs> CreateObject { get; private set; }
        /// <summary>
        /// MouseLeftBtn Down 이벤트 Command
        /// </summary>
        public ICommand SelectedObjectLBDown
        {
            get
            {
                if (_SelectedObjectLBDown == null)
                    _SelectedObjectLBDown = new RelayCommand(TreeNodeItemClick);
                return _SelectedObjectLBDown;
            }
        }

        public ICommand DeleteObject
        {
            get
            {
                if (_DeleteObject == null)
                    _DeleteObject = new RelayCommand(DeleteObjectClick);
                return _DeleteObject;
            }
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

        public ICommand CopyCommand
        {
            get
            {
                if (_CopyCommand == null)
                    _CopyCommand = new RelayCommand(CopyBehavior);
                return _CopyCommand;
            }
        }
        public ICommand PasteCommand
        {
            get
            {
                if (_PasteCommand == null)
                    _PasteCommand = new RelayCommand(PasteBehavior);
                return _PasteCommand;
            }
        }
        
        public void CopyBehavior(object obj)
        {
            if (BeforeSelectedObj != null)
                MMemFile.GetInstance().MContainerCopy(BeforeSelectedObj);
        }

        public void PasteBehavior(object obj)
        {
            MContainer pasteObj = MMemFile.GetInstance().MContainerPasty();
            if (pasteObj != null)
            {
                if (BeforeSelectedObj != null)
                    BeforeSelectedObj.AddChild(pasteObj);
                else
                    MWorld.GetInstance().AddChild(pasteObj);
                RefreshNodeView();
            }
        }

        private void FocusObjectClick(object obj)
        {
            if (BeforeSelectedObj != null)
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.FocusToObject, BeforeSelectedObj));
        }

        public ICommand SelectNodeObject
        {
            get
            {
                if (_SelectNodeObject == null)
                    _SelectNodeObject = new RelayCommand(SelectNodeClick);
                return _SelectNodeObject;
            }
        }
        public ICommand KeyDownCommand
        {
            get
            {
                if (_KeyDownCommand == null)
                    _KeyDownCommand = new RelayCommand(HierarchyKeyDownExecute, HierarchyKeyDownCanExecute);
                return _KeyDownCommand;
            }
        }

        ICommand _TestBehavior;
        public ICommand TestBehavior
        {
            get
            {
                if (_TestBehavior == null)
                    _TestBehavior = new RelayCommand(delegate (object o)
                    {
                        RefreshNodeView();
                    });
                return _TestBehavior;
            }
        }

        private bool HierarchyKeyDownCanExecute(object obj)
        {
            if (((KeyEventArgs)obj).Key == Key.F2)
            {
                return true;
            }
            else
                return false;
        }
        private void HierarchyKeyDownExecute(object obj)
        {
            if(obj is IList<SelectedItemsCollection>)
            {

            }
            else if(obj is HierarchyVM)
            {
                ((HierarchyVM)obj).IsEditMode = true;
            }
        }

        private void SelectNodeClick(object obj)
        {
            if (obj != null)
            {
                if (obj is SelectedItemsCollection)
                {
                    foreach(var container in (SelectedItemsCollection)obj)
                    {
                    }
                }
                else if (obj is MContainer)
                {
                    BeforeSelectedObj = (MContainer)obj;
                }
            }
            else
                BeforeSelectedObj = null;
        }

        private void DeleteObjectClick(object obj)
        {
            if (BeforeSelectedObj != null)
            {
                MGizmoHandler.GetInstance().SetEnable(false);
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
                BeforeSelectedObj.RemoveThis();
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
        internal void TreeNodeItemClick(object obj)
        {
            MGizmoHandler.GetInstance().DetachAllGizmo();
            if (null != obj)
            {
                if (BeforeSelectedObj != null)
                    BeforeSelectedObj.Selected(false);
                BeforeSelectedObj = (MContainer)obj;
                BeforeSelectedObj.Selected(true);
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = BeforeSelectedObj });
                MGizmoHandler.GetInstance().SetObject(BeforeSelectedObj);
                MGizmoHandler.GetInstance().SetEnable(true);

            }
            else
            {
                if (BeforeSelectedObj != null)
                    BeforeSelectedObj.Selected(false);
                BeforeSelectedObj = null;
                MGizmoHandler.GetInstance().SetEnable(false);
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
            }
        }
        void getchildContainer(MContainer getContainer)
        {
            for (int i = 0; i < getContainer.GetChildrenCount(); i++)
                getchildContainer(getContainer.GetChild(i));
        }
        public HierarchyViewVM()
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

            CreateObject = new DelegateCommand<RoutedEventArgs>(delegate (RoutedEventArgs e)
            {
                MContainer parentContainer = null;
                MContainer childContainer = null;
                
                if (BeforeSelectedObj != null)
                    parentContainer = BeforeSelectedObj;
                else
                    parentContainer = (MContainer)rootNodeVM.NodeObject;
                
                MenuItem mi = e.Source as MenuItem;

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
                else if (mi.Header.ToString().Equals("UIImage"))
                {
                    childContainer = new MUITest();
                    ((MUITest)childContainer).setTexture(@"D:\EVRAT\tool\bin\debug.x86\Assets\Cyberdemon_Tangent_FBX\Cyberdemon_Tangent_FBX\cyberdemon.jpg");
                }
                if (childContainer != null)
                    parentContainer.AddChild(childContainer);
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

            KeyBinding CopyKey = new KeyBinding(CopyCommand, new KeyGesture(Key.C, ModifierKeys.Control));
            if (!Application.Current.MainWindow.InputBindings.Contains(CopyKey))
                Application.Current.MainWindow.InputBindings.Add(CopyKey);
            KeyBinding PasteKey = new KeyBinding(PasteCommand, new KeyGesture(Key.V, ModifierKeys.Control));
            if (!Application.Current.MainWindow.InputBindings.Contains(PasteKey))
                Application.Current.MainWindow.InputBindings.Add(PasteKey);
            KeyBinding DeleteKey = new KeyBinding(DeleteObject, new KeyGesture(Key.Delete));
            if (!Application.Current.MainWindow.InputBindings.Contains(DeleteKey))
                Application.Current.MainWindow.InputBindings.Add(DeleteKey);
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

                //if (childNode.IsExpanded)
                //{
                //    childVM.IsExpanded = true;
                //    childVM.IsSelected = true;
                //}
                //childNode.IsExpanded = false;

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
                    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                    dropInfo.Effects = System.Windows.DragDropEffects.Copy;
                }
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            /// HierarchyView 내에서 Node 간 이동처리
            if(dropInfo.Data is NodeVM)
            {
                MContainer DropTargetData;
                MContainer DropSourceData = (MContainer)((NodeVM)dropInfo.Data).NodeObject;
                if (dropInfo.TargetItem == null)
                    DropTargetData = DropSourceData.Root;
                else
                    DropTargetData = (MContainer)((NodeVM)dropInfo.TargetItem).NodeObject;


                ///TODO : UnDO , ReDO StateManager 테스트 용
                //StateManager.Instance.ChangeSet(
                //    new UndoCommand(() =>
                //    {
                //        DropTargetData.AddChild(DropSourceData);
                //        RefreshNodeView();
                //    },
                //    () =>
                //    {
                //        DropTargetData = DropSourceData.GetParent();
                //        DropTargetData.AddChild(DropSourceData);
                //        RefreshNodeView();
                //    }));
                DropSourceData.SetParent(DropTargetData);
                //DropTargetData.IsExpanded = true;
                RefreshNodeView();
            }
            else if(dropInfo.Data is FileModel)
            {
                string path = ((FileModel)dropInfo.Data).FullPath;
                //string removePath = VRWorld.Instance.AssetsDir.Replace("\\", "/");
                //removePath += "/";
                //path = path.Replace(removePath, "");

                MFbx f = null;
                if (null != dropInfo.TargetItem)
                    f = new MFbx(path, (MContainer)((NodeVM)dropInfo.TargetItem).NodeObject);
                else
                    f = new MFbx(path);

                f.Name = ((FileModel)dropInfo.Data).Name;

                RefreshNodeView();

                ///TODO : UnDO , ReDO StateManager 테스트 용
                //StateManager.Instance.ChangeSet(
                //    new UndoCommand(() =>
                //    {
                //        f.Name = ((FileModel)dropInfo.Data).Name;
                //        f.SetAnimationIdx(0);
                //        RefreshNodeView();
                //    },
                //    () =>
                //    {
                //        f.RemoveThis();
                //        RefreshNodeView();
                //    }));
            }

        }
    }
}
