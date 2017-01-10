using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCAT.Infrastructure.DragDrop;
using MVRWrapper;
using System.Collections.ObjectModel;
using VRCAT.DataModel;

namespace VRCAT.HierarchyModule
{
    public class HierarchyVM : NodeVM
    {
        public override string Name
        {
            get
            {
                if (NodeObject != null)
                    base.Name = ((MContainer)NodeObject).Name;
                return base.Name;
            }
            set
            {
                ((MContainer)NodeObject).Name = value;
            }
        }
        bool _IsExpanded;
        public bool IsExpanded
        {
            get
            {
                if (NodeObject != null)
                    return ((MContainer)NodeObject).IsExpanded;
                else
                    return false;
            }
            set
            {
                ((MContainer)NodeObject).IsExpanded = value;
            }
        }
        bool _IsItemSelected;
        public bool IsItemSelected
        {
            get
            {
                if (NodeObject != null)
                    return ((MContainer)NodeObject).IsSelected;
                else
                    return false;
            }
            set
            {
                ((MContainer)NodeObject).IsSelected = value;
            }
        }
        public HierarchyVM(MContainer obj)
            : base(obj)
        { }
    }
}
