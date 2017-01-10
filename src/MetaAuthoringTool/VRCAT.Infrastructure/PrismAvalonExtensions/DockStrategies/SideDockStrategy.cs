using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace VRCAT.Infrastructure.PrismAvalonExtensions.DockStrategies
{
    /// <summary>
    /// Side Position Value
    /// </summary>
    [Serializable]
    public enum DockSide
    {
        Left,
        Right,
        Top,
        Bottom
    }

    /// <summary>
    /// SideDock Class
    /// </summary>
    [Serializable]
    public class SideDockStrategy : DockStrategy
    {
        public SideDockStrategy()
        {
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="title">Title</param>
        /// <param name="id">guid</param>
        /// <param name="side">DockSide</param>
        /// <param name="size">Size</param>
        public SideDockStrategy(object view, string title, string id, DockSide side, int size)
            : base(view, title, id)
        {
            Side = side;
            Size = size;
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="title">Title</param>
        /// <param name="side">DockSide</param>
        /// <param name="size">Size</param>
        public SideDockStrategy(object view, string title, DockSide side, int size)
            : base(view, title)
        {
            Side = side;
            Size = size;
        }

        DockSide _side;
        public DockSide Side
        {
            get { return _side; }
            set { _side = value; }
        }

        bool _autoHide = false;
        public bool AutoHide
        {
            get { return _autoHide; }
            set { _autoHide = value; }
        }

        int _size;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
    }
}
