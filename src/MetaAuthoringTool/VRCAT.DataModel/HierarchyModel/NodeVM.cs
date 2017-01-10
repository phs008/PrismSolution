using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCAT.Infrastructure.DragDrop;
using System.Collections.ObjectModel;

namespace VRCAT.DataModel
{
    public class NodeVM : BindableBase
    {
        string _Name;
        public virtual string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        object _NodeObject;
        public object NodeObject
        {
            get { return _NodeObject; }
        }
        bool _IsEditMode = false;
        public bool IsEditMode
        {
            get { return _IsEditMode; }
            set { SetProperty(ref _IsEditMode, value); }
        }
        bool _IsSelectedValue;
        public bool IsSelectedValue
        {
            get { return _IsSelectedValue; }
            set { SetProperty(ref _IsSelectedValue, value); }
        }
        ObservableCollection<NodeVM> _ChildObject;
        public ObservableCollection<NodeVM> ChildObject
        {
            get 
            {
                if (_ChildObject == null)
                    _ChildObject = new ObservableCollection<NodeVM>();
                return _ChildObject; 
            }
            set { _ChildObject = value; }
        }
        NodeVM _ParentObject;
        public NodeVM ParentObject
        {
            get { return _ParentObject; }
            set { SetProperty(ref _ParentObject, value); }
        }

        

        public NodeVM(object WrapperObject)
        {
            _NodeObject = WrapperObject;
        }
    }

}
