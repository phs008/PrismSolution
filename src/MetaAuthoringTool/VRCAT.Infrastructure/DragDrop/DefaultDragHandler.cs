using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VRCAT.Infrastructure.DragDrop
{
	public class DefaultDragHandler : IDragSource
	{
		public virtual void StartDrag(IDragInfo dragInfo)
		{
			var itemCount = dragInfo.SourceItems.Cast<object>().Count();

			if (itemCount == 1)
			{
				dragInfo.Data = dragInfo.SourceItems.Cast<object>().First();
			}
			else if (itemCount > 1)
			{
				dragInfo.Data = TypeUtilities.CreateDynamicallyTypedList(dragInfo.SourceItems);
			}

			dragInfo.Effects = (dragInfo.Data != null) ?
													 DragDropEffects.Copy | DragDropEffects.Move :
													 DragDropEffects.None;
		}

		public bool CanStartDrag(IDragInfo dragInfo)
		{
			return true;
		}

		public virtual void Dropped(IDropInfo dropInfo)
		{
		}

		public virtual void DragCancelled()
		{
		}
	}
}
