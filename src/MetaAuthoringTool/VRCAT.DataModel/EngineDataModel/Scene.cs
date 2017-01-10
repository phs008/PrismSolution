using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCAT.Infrastructure;

namespace VRCAT.DataModel
{
  public class Scene
  {
    MTObservableCollection<GameObject> _EntityCollection;
    internal MTObservableCollection<GameObject> EntityCollection
    {
      get
      {
        if (_EntityCollection == null)
          _EntityCollection = new MTObservableCollection<GameObject>();
        return _EntityCollection;
      }
      set { _EntityCollection = value; }
    }
    public void LoadScene()
    {

    }
    public void SaveScene()
    {

    }
  }
}
