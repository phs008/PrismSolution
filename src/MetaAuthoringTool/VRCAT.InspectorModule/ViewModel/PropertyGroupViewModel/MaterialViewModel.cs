using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
using VRCAT.DataModel;
using VRCAT.Infrastructure;
using VRCAT.Infrastructure.DragDrop;
using System.IO;

namespace VRCAT.InspectorModule
{
    public class MaterialViewModel : BindableBase
    {
        ObservableCollection<MaterialVM> _VRParams;
        public ObservableCollection<MaterialVM> VRParams
        {
            get { if (_VRParams == null) _VRParams = new ObservableCollection<MaterialVM>(); return _VRParams; }
            set { _VRParams = value; }
        }

        public MaterialViewModel(MFbxComponent component)
        {
            VRParams.Add(new MaterialVM(component));
        }
        public string PropertyGroupname
        {
            get { return "Materials"; }
        }
    }
    /// <summary>
    /// Material 의 MainViewModel
    /// </summary>
    public class MaterialVM : BindableBase
    {
        ObservableCollection<PropertyGroupViewModel> _VRParams;
        ObservableCollection<MaterialSourceVM> _MaterialParams;
        public readonly MFbxComponent fbxComponent;
        public MaterialVM(MFbxComponent obj)
        {
            this.fbxComponent = obj;
            Refresh();
        }
        internal void Refresh()
        {
            VRParams.Clear();
            MaterialParams.Clear();

            for (int i = 0; i < fbxComponent.GetMaterialSize(); i++)
            {
                PropertyGroupViewModel groupVM = new PropertyGroupViewModel(fbxComponent.GetResourceMtl(i).GetMatPropertyGroup(), fbxComponent.GetResourceMtl(i));
                VRParams.Add(groupVM);
                MaterialSourceVM sourceVM = new MaterialSourceVM(this, fbxComponent.GetResourceMtl(i), i + 1);
                MaterialParams.Add(sourceVM);
            }
        }
        public ObservableCollection<PropertyGroupViewModel> VRParams
        {
            get { if (_VRParams == null) _VRParams = new ObservableCollection<PropertyGroupViewModel>(); return _VRParams; }
            set { _VRParams = value; }
        }

        public ObservableCollection<MaterialSourceVM> MaterialParams
        {
            get { if (_MaterialParams == null) _MaterialParams = new ObservableCollection<MaterialSourceVM>(); return _MaterialParams; }
            set { _MaterialParams = value; }
        }
    }
    /// <summary>
    /// Material Property 자체 ViewModel
    /// </summary>
    
    /// <summary>
    /// Material 의 경로용 ViewModel
    /// </summary>
    public class MaterialSourceVM : BindableBase , IDropTarget 
    {
        int _RealIdx;
        string _IDX;
        MResourceMaterial _ParamModel;
        MaterialVM _ParentVM;
        public MaterialSourceVM(MaterialVM parentVM, MResourceMaterial param ,int idx)
        {
            _ParentVM = parentVM;
            _ParamModel = param;
            _IDX = idx.ToString();
            _RealIdx = idx - 1;
        }
        public string IDX
        {
            get { return _IDX; }
            set { _IDX = value; }
        }

        public string Value
        {
            get { return _ParamModel.GetMatFileResource(); }
            set
            {
                _ParamModel.SetMatFileResource(value);
                string FileName = Path.GetFileName(value);
                _ParentVM.fbxComponent.ChangeMaterial(FileName, _RealIdx);
                _ParentVM.fbxComponent.SaveToFile();
                OnPropertyChanged("Value");
                _ParentVM.Refresh();
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data == dropInfo.TargetItem)
                return;
            if (dropInfo.Data is FileModel)
            {
                if (((FileModel)dropInfo.Data).FileExtension.Equals("fmat"))
                {
                    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                    dropInfo.Effects = System.Windows.DragDropEffects.Copy;
                }
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            if(dropInfo.Data is FileModel)
            {
                if (((FileModel)dropInfo.Data).FileExtension.Equals("fmat"))
                {
                    string fullPath = ((FileModel)dropInfo.Data).FullPath;
                    Value = fullPath;
                }
            }
        }
    }
}
