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
using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace VRCAT.InspectorModule
{
    public class AnimationViewModel
    {
        public readonly MFbxComponent fbxComponent;
        ObservableCollection<AnimationSourceVM> _VRParams;
        public ObservableCollection<AnimationSourceVM> VRParams
        {
            get { if (_VRParams == null) _VRParams = new ObservableCollection<AnimationSourceVM>(); return _VRParams; }
            set { _VRParams = value; }
        }
        public AnimationViewModel(MFbxComponent obj)
        {
            this.fbxComponent = obj;
            Refresh();
        }
        internal void Refresh()
        {
            VRParams.Clear();
            for (int i = 0; i < fbxComponent.GetAnimationSize(); i++)
            {
                AnimationSourceVM sourceVM = new AnimationSourceVM(this, fbxComponent.GetResourceAni(i), i + 1);
                VRParams.Add(sourceVM);
            }
        }
        public string PropertyGroupname
        {
            get { return "Animations"; }
        }
    }

    public class AnimationSourceVM : BindableBase , IDropTarget
    {
        int _RealIdx;
        string _IDX;
        MResourceAnimation _ParamModel;
        AnimationViewModel _ParentVM;
        public AnimationSourceVM(AnimationViewModel parentVM , MResourceAnimation param,int idx)
        {
            this.IDX = idx.ToString();
            this._RealIdx = idx - 1;
            _ParamModel = param;
            _ParentVM = parentVM;
        }

        public string IDX
        {
            get { return _IDX; }
            set { _IDX = value; }
        }
        public string Value
        {
            get { return _ParamModel.GetAnimationFileResource(); }
            set
            {
                _ParamModel.SetAnimationFileResource(value);
                string FileName = Path.GetFileName(value);
                _ParentVM.fbxComponent.ChangeAnimation(FileName, _RealIdx);
                _ParentVM.fbxComponent.SaveToFile();
                OnPropertyChanged("Value");
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data == dropInfo.TargetItem)
                return;
            if (dropInfo.Data is FileModel)
            {
                if (((FileModel)dropInfo.Data).FileExtension.Equals("fani"))
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
                if (((FileModel)dropInfo.Data).FileExtension.Equals("fani"))
                {
                    string fullPath = ((FileModel)dropInfo.Data).FullPath;
                    Value = fullPath;
                }
            }
        }
    }
}
