using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;

namespace VRCAT.Infrastructure.PrismAvalonExtensions.DockStrategies
{
    /// <summary>
    /// [사용되지 않음]
    /// DocumentDocking Class
    /// </summary>
    [Obsolete("Don`t Use this Class",true)]
    public class DocumentDockStrategy : DockStrategy
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl View</param>
        /// <param name="title">Title</param>
        [Obsolete("Don`t Use this Class",true)]
        public DocumentDockStrategy(object view, string title)
            : base(view, title)
        {
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl View</param>
        /// <param name="title">Title</param>
        /// <param name="id">Guid</param>
        [Obsolete("Don`t Use this Class", true)]
        public DocumentDockStrategy(object view, string title, string id)
            : base(view, title, id)
        {
        }
    }
}
