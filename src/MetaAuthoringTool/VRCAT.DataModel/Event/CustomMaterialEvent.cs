using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel.Event
{
    /// <summary>
    /// Material 처리 관련 Event argument
    /// </summary>
    public enum MtlEventArg { Create, Modification };
    /// <summary>
    /// Materail 처리 이벤트 class
    /// </summary>
    public class CustomMaterialEvent
    {
        /// <summary>
        /// Material Event argument
        /// </summary>
        public MtlEventArg eventArg { get; set; }
        /// <summary>
        /// 생성할 Material Path
        /// </summary>
        public string GenerateMtlPath { get; set; }
    }
}
