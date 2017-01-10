using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel.Event
{
    public class PickingEvent
    {
        public List<object> PickElements = new List<object>();
        static PickingEvent _instance;
        public static PickingEvent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PickingEvent();
                return _instance;
            }
        }
        private PickingEvent() { }
        //public PickingEvent() { }
    }
}
