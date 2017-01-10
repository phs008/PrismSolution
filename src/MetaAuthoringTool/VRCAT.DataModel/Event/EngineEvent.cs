using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel.Event
{
    public enum EngineEventArg { RenderWindowCreated , WorldCreated , Vector3Refresh};
    public class EngineEvent
    {
        public EngineEventArg eventArg { get; set; }
    }
}
