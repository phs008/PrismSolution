using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VRCAT.DataModel;
using VRCAT.Infrastructure;
using VRCAT.Infrastructure.DragDrop;
using WPFXCommand;

namespace VRCAT.InspectorModule
{
    public class ScriptViewModel : BindableBase
    {
        public readonly MContainer OwnerContainer;
        public readonly MContainerComponent OwnerComponent;
        ObservableCollection<ScriptVM> _VRParams;
        public ObservableCollection<ScriptVM> VRParams
        {
            get
            {
                if (_VRParams == null)
                    _VRParams = new ObservableCollection<ScriptVM>();
                return _VRParams;
            }
            set { _VRParams = value; }
        }
        public ScriptViewModel(MPropertyGroup prpGroup,MScriptComponent scriptComponent, MContainer ownerobject = null)
        {
            if (ownerobject != null)
                this.OwnerContainer = ownerobject;
            if (scriptComponent != null)
                this.OwnerComponent = scriptComponent;
            VRParams.Add(new ScriptVM(prpGroup, scriptComponent));
        }
        public string PropertyGroupname
        {
            get { return "Script"; }
        }
        ICommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                    _DeleteCommand = new RelayCommand(DeleteBehavior);
                return _DeleteCommand;
            }
        }

        private void DeleteBehavior(object obj)
        {
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<DeleteComponentEvent>>().Publish(new DeleteComponentEvent() { DeletePropertyGroup = this });
        }
    }

    public class ScriptVM : BindableBase
    {
        MScriptComponent _ScriptComponent;
        ObservableCollection<ScriptSourceVM> _ScriptSourceParams;
        ObservableCollection<PropertyGroupViewModel> _VRParams;
        public ObservableCollection<PropertyGroupViewModel> VRParams
        {
            get
            {
                if (_VRParams == null)
                    _VRParams = new ObservableCollection<PropertyGroupViewModel>();
                return _VRParams;
            }
            set { _VRParams = value; }
        }

        public ObservableCollection<ScriptSourceVM> ScriptSourceParams
        {
            get
            {
                if (_ScriptSourceParams == null)
                    _ScriptSourceParams = new ObservableCollection<ScriptSourceVM>();
                return _ScriptSourceParams;
            }
            set { _ScriptSourceParams = value; }
        }

        public ScriptVM(MPropertyGroup prpGroup,MScriptComponent ScriptComponent)
        {
            _ScriptComponent = ScriptComponent;
            ScriptSourceVM scriptSource = new ScriptSourceVM(ScriptComponent, prpGroup, this);
            ScriptSourceParams.Add(scriptSource);
            ActorPropertiesRefresh();
        }
        internal void ActorPropertiesRefresh()
        {
            _ScriptComponent.RefreshProperties();
            VRParams.Clear();
            PropertyGroupViewModel groupVM = new PropertyGroupViewModel(_ScriptComponent.GetActorProperties());
            groupVM.PropertyGroupname = "Script Properties";
            VRParams.Add(groupVM);
        }
    }
    public class ScriptSourceVM : BindableBase, IDropTarget
    {
        ScriptVM _ParentVM;
        MScriptComponent _ScriptComponent = null;
        MPropertyGroup _ScriptPropertyGroup = null;
        public ScriptSourceVM(MScriptComponent scriptComponent,MPropertyGroup scriptPropertyGroup ,ScriptVM parentVM)
        {
            _ScriptComponent = scriptComponent;
            _ScriptPropertyGroup = scriptPropertyGroup;
            _ParentVM = parentVM;
        }
        public string Value
        {
            get { return (string)_ScriptPropertyGroup.GetAt(0).Value; }
            set
            {
                _ScriptComponent.SetScript(value);
                _ParentVM.ActorPropertiesRefresh();
                OnPropertyChanged("Value");
            }
        }
        

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data == dropInfo.TargetItem)
                return;
            if (dropInfo.Data is FileModel)
            {
                if (((FileModel)dropInfo.Data).FileExtension.Equals("cs"))
                {
                    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                    dropInfo.Effects = System.Windows.DragDropEffects.Copy;
                }
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is FileModel)
            {
                if (((FileModel)dropInfo.Data).FileExtension.Equals("cs"))
                {
                    string fullPath = ((FileModel)dropInfo.Data).FullPath;
                    Value = fullPath;
                }
            }
        }
    }

}
