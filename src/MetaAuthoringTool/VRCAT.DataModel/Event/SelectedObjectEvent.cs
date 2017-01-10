using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel.Event
{
    /// <summary>
    /// 외부 모듈에서 Object 정보 선택시 해당 Object를 Inspector 모듈에 전달
    /// </summary>
	public class SelectedObjectEvent
	{
		public object SelectedObject;
	}
}
