using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCAT.Infrastructure.MonitoredUndo;

namespace VRCAT.DataModel
{
  abstract public class AbstructObjectBase : BindableBase
  {
    string _Name;
    public string Name
    {
      get { return _Name; }
      set
      {
        SetProperty(ref _Name, value);
        DefaultChangeFactory.Current.OnChanging(VRWorld.Instance, "Name", _Name, value);
      }
    }
    string _Tag;
    public string Tag
    {
      get { return _Tag; }
      set 
      {
        _Tag = value;
        DefaultChangeFactory.Current.OnChanging(VRWorld.Instance, "Tag", _Tag, value);
      }
    }
    public override string ToString()
    {
      return base.ToString();
    }
  }
}
