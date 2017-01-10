using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace VRCAT.Infrastructure.PrismAvalonExtensions
{
    /// <summary>
    /// NestedDockPosition Type
    /// </summary>
    public enum NestedDockPosition
    {
        Left,
        Right,
        Top,
        Bottom,
        Inside
    }
    /// <summary>
    /// NestedDockPosition Class
    /// </summary>
    public class NestedDockStrategy : DockStrategy
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="targetView">Parent View</param>
        /// <param name="position">NestedDockPosition</param>
        /// <param name="size">Grid Size</param>
        public NestedDockStrategy(object targetView, NestedDockPosition position, GridLength size)
        {
            _targetView = targetView;
            _position = position;
            _size = size;
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="targetView">Parent View</param>
        /// <param name="position">NestedDockPosition</param>
        public NestedDockStrategy(object targetView, NestedDockPosition position)
        {
            _targetView = targetView;
            _position = position;
        }

        GridLength _size = new GridLength();
        public GridLength Size
        {
            get { return _size; }
            set { _size = value; }
        }

        object _targetView;
        public object TargetView
        {
            get { return _targetView; }
            private set { _targetView = value; }
        }

        NestedDockPosition _position;
        public NestedDockPosition Position
        {
            get { return _position; }
            private set { _position = value; }
        }
    }
}
