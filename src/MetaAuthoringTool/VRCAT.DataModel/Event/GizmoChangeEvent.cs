using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// DataModel.Event
/// </summary>
namespace VRCAT.DataModel.Event
{
    public enum GizmoEventArg    { Position , Rotation , Scale };
    /// <summary>
    /// 3D View 에서 Gizmo로 Object 변경시 발생하는 이벤트
    /// </summary>
    public class GizmoChangeEvent
    {
        public GizmoEventArg eventArg { get; set; }
    }
}
