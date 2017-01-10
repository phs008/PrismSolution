using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCAT.Infrastructure;

namespace VRCAT.DataModel
{
  internal class SceneManager
  {
    MTObservableCollection<Scene> _SceneCollection;
    public MTObservableCollection<Scene> SceneCollection
    {
      get 
      {
        if (_SceneCollection == null)
          _SceneCollection = new MTObservableCollection<Scene>();
        return _SceneCollection; 
      }
      set { _SceneCollection = value; }
    }
    public void AddScene(Scene scene)
    {
      SceneCollection.Add(scene);
    }
  }
}
