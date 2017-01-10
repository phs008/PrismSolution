using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace VRCAT.Infrastructure.PrismAvalonExtensions.DockStrategies
{
    /// <summary>
    /// Nested Position Value
    /// </summary>
    [Serializable]
    public enum NestedDockPosition
    {
        Left,
        Right,
        Top,
        Bottom,
        Inside
    }

    /// <summary>
    /// NestedDock Class
    /// </summary>
    [Serializable]
    public class NestedDockStrategy : DockStrategy
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public NestedDockStrategy()
        {
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="title">Title</param>
        /// <param name="target">ParentDocking TargetView</param>
        /// <param name="position">NestedDockPosition</param>
        /// <param name="size">size</param>
        public NestedDockStrategy(object view, string title, object target, NestedDockPosition position, int size)
            : base(view, title)
        {
            Position = position;
            TargetView = target;
            Size = size;
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="title">Title</param>
        /// <param name="target">ParentDocking TargetView</param>
        /// <param name="position">NestedDockPosition</param>
        public NestedDockStrategy(object view, string title, object target, NestedDockPosition position)
            : base(view, title)
        {
            Position = position;
            TargetView = target;
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="title">Title</param>
        /// <param name="id">guid</param>
        /// <param name="target">ParentDocking TargetView</param>
        /// <param name="position">NestedDockPosition</param>
        /// <param name="size">size</param>
        public NestedDockStrategy(object view, string title, string id, object target, NestedDockPosition position, int size)
            : base(view, title, id)
        {
            Position = position;
            TargetView = target;
            Size = size;
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="title">Title</param>
        /// <param name="id">guid</param>
        /// <param name="target">ParentDocking TargetView</param>
        /// <param name="position">NestedDockPosition</param>
        public NestedDockStrategy(object view, string title, string id, object target, NestedDockPosition position)
            : base(view, title, id)
        {
            Position = position;
            TargetView = target;
        }

        int _size;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        bool _autoHide = false;
        public bool AutoHide
        {
            get { return _autoHide; }
            set { _autoHide = value; }
        }

        object _targetView;
        /// <summary>
        /// Parent TargetView
        /// </summary>
        [XmlIgnore]
        public object TargetView
        {
            get { return _targetView; }
            set
            {
                _targetView = value;
                TargetViewType = string.Format("{0}, {1}", value.GetType().FullName, value.GetType().Assembly.GetName().Name);
            }
        }

        string _targetViewType;
        /// <summary>
        /// TargetViewType
        /// </summary>
        public string TargetViewType
        {
            get { return _targetViewType; }
            set { _targetViewType = value; }
        }

        NestedDockPosition _position;
        /// <summary>
        /// Nested Position
        /// </summary>
        public NestedDockPosition Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
