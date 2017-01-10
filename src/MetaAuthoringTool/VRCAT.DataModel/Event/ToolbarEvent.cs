using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel
{
    /// <summary>
    /// [작업중]
    /// ToolBar 선택 이벤트
    /// </summary>
	public class ToolbarEvent
	{
        public ToolbarEvent(string Value)
        {
            ClickMenuHeader = Value;
        }
        public string ClickMenuHeader { get; private set; }
	}
}
