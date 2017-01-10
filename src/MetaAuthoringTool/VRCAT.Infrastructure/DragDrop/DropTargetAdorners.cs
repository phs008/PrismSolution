using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.Infrastructure.DragDrop
{
	public class DropTargetAdorners
	{
		public static Type Highlight
		{
			get { return typeof(DropTargetHighlightAdorner); }
		}

		public static Type Insert
		{
			get { return typeof(DropTargetInsertionAdorner); }
		}
	}
}
