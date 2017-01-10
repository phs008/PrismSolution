using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;
using VRCAT.DataModel;
using System.IO;
using System.Collections;
using VRCAT.Infrastructure.DragDrop;
using System.Windows.Input;
using WPFXCommand;
using System.Windows;
using System;

namespace VRCAT.InspectorModule
{
    public class InspectorViewModel : BindableBase ,IDropTarget
    {
        private ObservableCollection<UserControl> _SubControls;
        /// <summary>
        /// SelectedObject 에 따라 생성되는 SubControlView Collection
        /// </summary>
        public ObservableCollection<UserControl> SubControls
        {
            get
            {
                if (_SubControls == null)
                    _SubControls = new ObservableCollection<UserControl>();
                return _SubControls;
            }
            set { SetProperty(ref _SubControls, value); }
        }

        private object _BeforeSelectedObject;

        private UserControl _PreviewControl;

        public UserControl PreviewControl
        {
            get { return _PreviewControl; }
            set { SetProperty(ref _PreviewControl, value); }
        }

        public ICommand AddComponentCommand
        {
            get
            {
                if (_AddComponentCommand == null)
                    _AddComponentCommand = new RelayCommand(AddComponentClick);
                return _AddComponentCommand;
            }
        }
        private void AddComponentClick(object obj)
        {
            if (SelectedObject == null)
                return;
            string compareVal = (string)obj;
            SelectedObject.AddNewComponent(compareVal);
            SetSubControls(SelectedObject);
        }

        private ICommand _AddComponentCommand;
        /// <summary>
        /// Inspector 에 선택된 Obejct
        /// </summary>
        private MContainer SelectedObject;

        public InspectorViewModel()
        {
            //MLog.E += InspectorViewModel_E;


            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Subscribe(param =>
                    {
                        SubControlDispose();
                        if (param.SelectedObject == null)
                        {
                            PreviewControl = null;
                            SubControls.Clear();
                            _BeforeSelectedObject = null;
                            return;
                        }
                        if (_BeforeSelectedObject != null)
                        {
                            if (_BeforeSelectedObject is MContainer)
                            {

                                if (param.SelectedObject is FileModel)
                                    SetSubControls(param.SelectedObject);
                                else if (((MContainer)_BeforeSelectedObject).UID != ((MContainer)param.SelectedObject).UID)
                                    SetSubControls(param.SelectedObject);
                            }
                            else if (_BeforeSelectedObject is FileModel)
                                SetSubControls(param.SelectedObject);
                        }
                        else
                            SetSubControls(param.SelectedObject);
                    });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<InspectorViewRefreshEvent>>().Subscribe(param =>
            {
                if (param.RefreshViewTargetObj != null)
                {
                    SetSubControls(param.RefreshViewTargetObj);
                }
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ScriptEvent>>().Subscribe(param =>
                {
                    PropertyGroupViewModel vm = (PropertyGroupViewModel)param.val;
                    PropertyGroupView propGroupView = new PropertyGroupView();
                    propGroupView.DataContext = vm;
                    this.SubControls.Add(propGroupView);
                });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Subscribe(param =>
            {
                if(param.ClickMenuHeader.Equals("ProjectSetting"))
                {
                    SubControls.Clear();
                    PropertyGroupViewModel vm = new PropertyGroupViewModel(MEngineConfig.GetInstance().GetConfigPropertyGroup(), MEngineConfig.GetInstance());
                    PropertyGroupView propGroupView = new PropertyGroupView();
                    propGroupView.DataContext = vm;
                    this.SubControls.Add(propGroupView);
                }
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<DeleteComponentEvent>>().Subscribe(param =>
            {
                if(param.DeletePropertyGroup != null)
                {
                    if (param.DeletePropertyGroup is PropertyGroupViewModel)
                    {
                        long uid = ((PropertyGroupViewModel)param.DeletePropertyGroup).OwnerComponent.UID;
                        int removeComponentIdx = ((PropertyGroupViewModel)param.DeletePropertyGroup).OwnerContainer.GetComponentIdx(uid);
                        ((PropertyGroupViewModel)param.DeletePropertyGroup).OwnerContainer.DeleteComponent(removeComponentIdx);
                    }
                    else if(param.DeletePropertyGroup is ScriptViewModel)
                    {
                        long uid = ((ScriptViewModel)param.DeletePropertyGroup).OwnerComponent.UID;
                        int removeComponentIdx = ((ScriptViewModel)param.DeletePropertyGroup).OwnerContainer.GetComponentIdx(uid);
                        ((ScriptViewModel)param.DeletePropertyGroup).OwnerContainer.DeleteComponent(removeComponentIdx);
                    }
                    this.SetSubControls(((PropertyGroupViewModel)param.DeletePropertyGroup).OwnerContainer);
                }
            });

        }

        private void InspectorViewModel_E(string s)
        {
            //Console.WriteLine(s);
        }

        private void SubControlDispose()
        {
            foreach(UserControl uc in SubControls)
            {
                if (uc.DataContext is PropertyGroupViewModel)
                    ((PropertyGroupViewModel)uc.DataContext).Dispose();
            }
        }

        private void SetSubControls(object param)
        {
            this._BeforeSelectedObject = param;
            SubControlDispose();
            SubControls.Clear();
            this.PreviewControl = null;
            if(param is MContainer)
            {
                MContainer obj = param as MContainer;
                this.SelectedObject = obj;
                for (int i = 0; i < obj.GetComponentsCount(); ++i)
                {
                    MContainerComponent component = obj.GetComponent(i);
                    component.RefreshProperties();
                    for(int c = 0; c< component.GetPropertyGroupCount(); c++)
                    {
                        MPropertyGroup prpGroup = component.GetPropertyGroup(c);
                        PropertyGroupView propGroupView = new PropertyGroupView();
                        
                        PropertyGroupViewModel propGroupVM = null;
                        if (prpGroup.GroupName().Equals("Instance"))
                            continue;
                        else if(prpGroup.GroupName().Equals("Transform"))
                        {
                            propGroupVM = new PropertyGroupViewModel(prpGroup, component, obj);
                            propGroupView.DataContext = propGroupVM;
                        }
                        //else if (prpGroup.GroupName().Equals("Script"))
                        //{
                        //    ScriptViewModel scriptVM = new ScriptViewModel(prpGroup, (MScriptComponent)component, obj);
                        //    propGroupView.DataContext = scriptVM;
                        //    CustomMenuItem menuItem = new CustomMenuItem(scriptVM);
                        //    ContextMenu contextmenu = new ContextMenu();
                        //    contextmenu.Items.Add(menuItem);
                        //    propGroupView.Expander.ContextMenu = contextmenu;
                        //}
                        else
                        {
                            propGroupVM = new PropertyGroupViewModel(prpGroup, component, obj);
                            propGroupView.DataContext = propGroupVM;
                            CustomMenuItem menuItem = new CustomMenuItem(propGroupVM);
                            ContextMenu contextmenu = new ContextMenu();
                            contextmenu.Items.Add(menuItem);
                            propGroupView.Expander.ContextMenu = contextmenu;
                        }
                        //if (!prpGroup.GroupName().Equals("Script") && !prpGroup.GroupName().Equals("Animation Files"))
                        //if (!prpGroup.GroupName().Equals("Script"))
                        this.SubControls.Add(propGroupView);
                    }
                    /// Material 변경을 위한 별도 UI
                    if (component is MFbxComponent)
                    {
                        if (((MFbxComponent)component).GetMaterialSize() > 0)
                        {
                            PropertyGroupView propGroupView = new PropertyGroupView();
                            MaterialViewModel mtlVM = new MaterialViewModel((MFbxComponent)component);
                            propGroupView.DataContext = mtlVM;
                            this.SubControls.Add(propGroupView);
                        }
                        //if (((MFbxComponent)component).GetAnimationSize() > 0)
                        //{
                        //    PropertyGroupView aniGroupView = new PropertyGroupView();
                        //    AnimationViewModel aniVM = new AnimationViewModel((MFbxComponent)component);
                        //    aniGroupView.DataContext = aniVM;
                        //    this.SubControls.Add(aniGroupView);
                        //}
                    }
                }
            }
            else if(param is FileModel)
            {
                FileModel fm = param as FileModel;
                if (fm.FileExtension.Equals("ffbx"))
                {
                    string path = fm.FullPath;
                    MFbx fbx = new MFbx(path);
                    fbx.DetachFromParent();
                    this.SelectedObject = fbx;
                    for (int i = 0; i < fbx.GetComponentsCount(); ++i)
                    {
                        MContainerComponent component = fbx.GetComponent(i);
                        for (int c = 0; c < component.GetPropertyGroupCount(); c++)
                        {
                            MPropertyGroup prpGroup = component.GetPropertyGroup(c);
                            PropertyGroupView propGroupView = new PropertyGroupView();
                            if (prpGroup.GroupName().Equals("Instance"))
                                continue;
                            PropertyGroupViewModel propGroupVM = new PropertyGroupViewModel(prpGroup, component, fbx);
                            propGroupView.DataContext = propGroupVM;
                            this.SubControls.Add(propGroupView);
                        }
                        /// Material 변경을 위한 별도 UI
                        if (component is MFbxComponent)
                        {
                            if (((MFbxComponent)component).GetMaterialSize() > 0)
                            {
                                PropertyGroupView propGroupView = new PropertyGroupView();
                                MaterialViewModel mtlVM = new MaterialViewModel((MFbxComponent)component);
                                propGroupView.DataContext = mtlVM;
                                this.SubControls.Add(propGroupView);
                            }
                            //if (((MFbxComponent)component).GetAnimationSize() > 0)
                            //{
                            //    PropertyGroupView aniGroupView = new PropertyGroupView();
                            //    AnimationViewModel aniVM = new AnimationViewModel((MFbxComponent)component);
                            //    aniGroupView.DataContext = aniVM;
                            //    this.SubControls.Add(aniGroupView);
                            //}
                        }
                    }
                    this.PreviewControl = new Preview3DControl(path);
                }
                else if (fm.FileExtension.Equals("bmp") | fm.FileExtension.Equals("jpg") | fm.FileExtension.Equals("jpeg") | fm.FileExtension.Equals("png") | fm.FileExtension.Equals("tga") | fm.FileExtension.Equals("hdr"))
                {
                    PropertyGroupView propGroupView = new PropertyGroupView();
                    MPropertyGroup pGroup = MResTexture.GetInstance().GetTextureInfo(fm.FullPath);
                    PropertyGroupViewModel propGroupVM = new PropertyGroupViewModel(pGroup, MResTexture.GetInstance());
                    //MResTexture.TestTextureInfo(propGroupVM.PropertyGroup);
                    propGroupView.DataContext = propGroupVM;
                    this.SubControls.Add(propGroupView);
                    this.PreviewControl = new Preview2DControl(fm);
                }
                else if (fm.FileExtension.Equals("mp3"))
                    this.PreviewControl = new PreviewSoundControl(fm.FullPath);
                else if (fm.FileExtension.Equals("fmat"))
                {
                    string path = fm.FullPath;
                    MResourceMaterial mat = new MResourceMaterial();
                    mat.SetMatFileResource(path);
                    PropertyGroupView propGroupView = new PropertyGroupView();
                    PropertyGroupViewModel propGroupVM;
                    propGroupVM = new PropertyGroupViewModel(mat.GetMatPropertyGroup(), mat);
                    propGroupView.DataContext = propGroupVM;
                    this.SubControls.Add(propGroupView);
                    this.PreviewControl = new Preview3DControl(path, true);
                }
                else if (fm.FileExtension.Equals("fani"))
                {
                    string path = fm.FullPath;
                    this.PreviewControl = new Preview3DControl(path, false, true);
                }
                else if (fm.FileExtension.Equals("cs"))
                {
                    ScriptView TextscriptView = new ScriptView();
                    TextScriptViewModel TextscriptVM = new TextScriptViewModel(fm.FullPath);
                    TextscriptView.DataContext = TextscriptVM;
                    this.SubControls.Add(TextscriptView);
                }
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data != null)
            {
                if (dropInfo.Data is FileModel)
                {
                    FileModel fm = (FileModel)dropInfo.Data;
                    if (fm.FileExtension.Equals("cs") || fm.FileExtension.Equals("fani"))
                    {
                        dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                        dropInfo.Effects = System.Windows.DragDropEffects.Copy;
                    }
                }
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            if(dropInfo.Data is FileModel)
            {
                FileModel fm = (FileModel)dropInfo.Data;
                if(fm.FileExtension.Equals("cs"))
                {
                    if(SelectedObject != null)
                    {
                        MScriptComponent scriptCom = (MScriptComponent)SelectedObject.AddNewComponent("ScriptComponent");
                        scriptCom.SetScript(fm.FullPath);
                        SetSubControls(SelectedObject);
                        //PropertyGroupView scriptGroupView = new PropertyGroupView();
                        //ScriptViewModel scriptVM = new ScriptViewModel(scriptCom.GetPropertyGroup(0), scriptCom, SelectedObject);
                        //scriptGroupView.DataContext = scriptVM;
                        //CustomMenuItem menuItem = new CustomMenuItem(scriptVM);
                        //ContextMenu contextmenu = new ContextMenu();
                        //contextmenu.Items.Add(menuItem);
                        //scriptGroupView.Expander.ContextMenu = contextmenu;
                        //this.SubControls.Add(scriptGroupView);
                    }
                }
                else if(fm.FileExtension.Equals("fani"))
                {
                    if(SelectedObject != null)
                    {
                        if(SelectedObject.HasComponent("Fbx"))
                        {
                            MFbxComponent fbxComponent = SelectedObject.GetComponent<MFbxComponent>(ComponentEnum.Fbx);
                            fbxComponent.AddNewAnimation(fm.FileName);
                            SetSubControls(SelectedObject);
                        }
                    }
                }
            }
        }
    }
}
