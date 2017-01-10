using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel
{
    /// <summary>
    /// Engine 내부 기능을 작동시킬 Trigger Event
    /// </summary>
    public class TriggerEngineEvent
    {
        /// <summary>
        /// Engine Triggert Envent Type
        /// </summary>
        public enum TriggerEvent { NewScene,SaveScene, LoadScene, RenderingRefresh,FocusToObject};
        /// <summary>
        /// Engine Trigger 생성자
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="value"></param>
        public TriggerEngineEvent(TriggerEvent trigger, object value)
        {
            this.Event = trigger;
            this.Value = value;
        }
        /// <summary>
        /// Engine Event Type
        /// </summary>
        public TriggerEvent Event { get; private set; }
        /// <summary>
        /// Engine Parameter Value
        /// </summary>
        public object Value { get; private set; }
    }
}
