using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace VRCAT.Infrastructure.PrismAvalonExtensions
{
    /// <summary>
    /// Docking MetaData 클래스
    /// </summary>
    public class DockingMetadata
    {
        private DockingMetadata()
        {
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="dockStrategy">DockStrategy</param>
        public DockingMetadata(FrameworkElement view, DockStrategy dockStrategy)
        {
            View = view;
            ContentId = string.Format("{0}, {1}", view.GetType().FullName, view.GetType().Assembly.GetName().Name);
            DockStrategy = dockStrategy;
        }

        string _contentId = Guid.NewGuid().ToString();
        /// <summary>
        /// ContentID (GUID)
        /// </summary>
        public string ContentId
        {
            get { return _contentId; }
            set { _contentId = value; }
        }

        FrameworkElement _view;
        /// <summary>
        /// View Content
        /// </summary>
        public FrameworkElement View
        {
            get { return _view; }
            private set { _view = value; }
        }

        DockStrategy _dockStrategy;
        /// <summary>
        /// DockStrategy
        /// </summary>
        public DockStrategy DockStrategy
        {
            get { return _dockStrategy; }
            private set { _dockStrategy = value; }
        }

        string _title;
        /// <summary>
        /// Dock Title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        BindingBase _titleBinding;
        public BindingBase TitleBinding
        {
            get { return _titleBinding; }
            set { _titleBinding = value; }
        }

        bool _canClose = true;
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        bool _autoHide;
        public bool AutoHide
        {
            get { return _autoHide; }
            set { _autoHide = value; }
        }

        BitmapSource _icon;
        public BitmapSource Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
    }
}
