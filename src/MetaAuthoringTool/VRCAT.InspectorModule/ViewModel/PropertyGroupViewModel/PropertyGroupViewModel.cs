using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVRWrapper;
using System.Collections.ObjectModel;
using VRCAT.Infrastructure.DragDrop;
using VRCAT.Infrastructure;
using System.Windows.Input;
using WPFXCommand;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.DataModel;

namespace VRCAT.InspectorModule
{
    public class PropertyGroupViewModel : BindableBase , IDisposable
    {
        string _PropertyGroupname;

        public string PropertyGroupname
        {
            get { return _PropertyGroupname; }
            set { _PropertyGroupname = value; }
        }
        public readonly MContainerComponent OwnerComponent;
        public readonly MPropertyGroup PropertyGroup;
        public readonly MContainer OwnerContainer;
        ObservableCollection<PropertyViewModel> _VRParams = new ObservableCollection<PropertyViewModel>();
        public ObservableCollection<PropertyViewModel> VRParams
        {
            get { return _VRParams; }
            set { _VRParams = value; }
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
        public PropertyGroupViewModel(MPropertyGroup param)
        {
            if (param != null)
            {
                this.PropertyGroup = param;
                SetProperty(param);
            }
        }
        public PropertyGroupViewModel(MPropertyGroup param,MEngineConfig config)
        {
            if (param != null)
            {
                this.PropertyGroup = param;
                SetProperty(param, config);
            }
        }
        public PropertyGroupViewModel(MPropertyGroup param, MContainerComponent ownerComponent, MContainer ownerObject)
        {
            if (param != null)
            {
                this.PropertyGroup = param;
                OwnerContainer = ownerObject;
                OwnerComponent = ownerComponent;
                SetProperty(param, ownerObject);
            }
        }
        public PropertyGroupViewModel(MPropertyGroup param, MResourceMaterial mtlObject)
        {
            if (param != null)
            {
                this.PropertyGroup = param;
                SetProperty(param, mtlObject);
            }
        }
        public PropertyGroupViewModel(MPropertyGroup param,MResTexture textureObject)
        {
            if(param != null)
            {
                this.PropertyGroup = param;
                SetProperty(param, textureObject);
            }
        }

        private void SetProperty(MPropertyGroup param, object ParentObj = null)
        {
            this._PropertyGroupname = param.GroupName();
            MProperty[] transformUPWARD = new MProperty[3];
            List<MProperty> sortList = new List<MProperty>();
            if (this._PropertyGroupname.Equals("Transform"))
            {
                for (int i = 0; i < this.PropertyGroup.PropertyCount(); i++)
                {
                    if (this.PropertyGroup.GetAt(i).Name.Equals("Position"))
                        transformUPWARD[0] = this.PropertyGroup.GetAt(i);
                    else if (this.PropertyGroup.GetAt(i).Name.Equals("Rotation"))
                        transformUPWARD[1] = this.PropertyGroup.GetAt(i);
                    else if (this.PropertyGroup.GetAt(i).Name.Equals("Scale"))
                        transformUPWARD[2] = this.PropertyGroup.GetAt(i);
                    else
                        sortList.Add(this.PropertyGroup.GetAt(i));
                }
                for (int i = 0; i < 3; i++)
                    AddParam(transformUPWARD[i], ParentObj);
            }
            else
                for (int i = 0; i < this.PropertyGroup.PropertyCount(); i++)
                    sortList.Add(this.PropertyGroup.GetAt(i));


            foreach (MProperty val in sortList.OrderBy(a => a.Name))
            {
                AddParam(val, ParentObj);
            }
        }
        public virtual void AddParam(MProperty param,object ParentObj = null)
        {
            switch(param.EnumType)
            {
                case MPropertyEnum.MBool:
                    this.VRParams.Add(new VRBoolVM(param, ParentObj));
                    break;
                case MPropertyEnum.MString:
                    this.VRParams.Add(new VRStringVM(param, ParentObj));
                    break;
                case MPropertyEnum.MInt:
                    this.VRParams.Add(new VRIntVM(param, ParentObj));
                    break;
                case MPropertyEnum.MFloat:
                    this.VRParams.Add(new VRFloatVM(param, ParentObj));
                    break;
                case MPropertyEnum.MVector2:
                    this.VRParams.Add(new VRVector2VM(param, ParentObj));
                    break;
                case MPropertyEnum.MVector3:
                    this.VRParams.Add(new VRVector3VM(param, ParentObj));
                    break;
                case MPropertyEnum.MVecotr4:
                    this.VRParams.Add(new VRVector4VM(param, ParentObj));
                    break;
                case MPropertyEnum.MColor:
                    this.VRParams.Add(new VRColorVM(param, ParentObj));
                    break;
                case MPropertyEnum.MQuaternion:
                    this.VRParams.Add(new VRQuaternionVM(param, ParentObj));
                    break;
                case MPropertyEnum.MObjectEnum:
                    this.VRParams.Add(new VREnumVM(param, ParentObj));
                    break;
                case MPropertyEnum.MAnimationFile:
                    this.VRParams.Add(new VRAnimationVM(param, ParentObj));
                    break;
                case MPropertyEnum.MPath:
                case MPropertyEnum.MFbxFile:
                case MPropertyEnum.MMaterialFile:
                    this.VRParams.Add(new VRFilePathVM(param, ParentObj));
                    break;
                case MPropertyEnum.MTextureFile:
                    this.VRParams.Add(new VRTextureFilePathVM(param, ParentObj));
                    break;
                //case MPropertyEnum.MScriptFIle:
                //    this.VRParams.Add(new VRScriptFilePathVM(param, (MContainer)ParentObj));
                //    break;
                case MPropertyEnum.MEnumTypeComponent:
                    this.VRParams.Add(new VRContainerObjectVM(param,ParentObj));
                    break;
            }
        }

        public void Dispose()
        {
            foreach (PropertyViewModel vm in VRParams)
                vm.Dispose();
        }
    }
}
