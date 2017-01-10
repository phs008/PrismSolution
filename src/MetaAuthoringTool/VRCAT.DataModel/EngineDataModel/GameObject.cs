using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCAT.Infrastructure.MonitoredUndo;

namespace VRCAT.DataModel
{
  public class GameObject : AbstructObjectBase
  {
    public GameObject()
    {
    }
    public GameObject(string name)
    {
    }
    public GameObject(string name,params Type[] components)
    {

    }
  }
}
