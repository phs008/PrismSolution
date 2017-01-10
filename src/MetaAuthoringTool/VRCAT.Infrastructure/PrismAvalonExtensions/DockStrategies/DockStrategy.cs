using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace VRCAT.Infrastructure.PrismAvalonExtensions.DockStrategies
{
    /// <summary>
    /// Docking 추상 클래스
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(SideDockStrategy))]
    [XmlInclude(typeof(NestedDockStrategy))]
    public abstract class DockStrategy
    {
        public DockStrategy()
        {
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="title">Title</param>
        public DockStrategy(object view, string title)
        {
            View = view;
            Title = title;
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="title">Title</param>
        /// <param name="id">guid</param>
        public DockStrategy(object view, string title, string id)
        {
            View = view;
            Title = title;
            Id = id;
        }

        string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        BitmapSource _icon;
        /// <summary>
        /// Icon source
        /// </summary>
        [XmlIgnore]
        public BitmapSource Icon
        {
            get
            {
                if (_icon == null && !string.IsNullOrEmpty(_base64Icon)) _icon = Base64ToImage(_base64Icon);
                return _icon;
            }
            set { _icon = value; }
        }
        /// <summary>
        /// Base64기반 image 값
        /// </summary>
        string _base64Icon;
        public string Base64Icon
        {
            get
            {
                if (_base64Icon == null) _base64Icon = ImageToBase64(Icon);
                return _base64Icon;
            }
            set { _base64Icon = value; }
        }

        object _view;
        /// <summary>
        /// ContentControl view
        /// </summary>
        [XmlIgnore]
        public object View
        {
            get { return _view; }
            set
            {
                _view = value;
                ViewType = string.Format("{0}, {1}", value.GetType().FullName, value.GetType().Assembly.GetName().Name);
            }
        }

        string _viewType;
        /// <summary>
        /// ViewType
        /// </summary>
        public string ViewType
        {
            get { return _viewType; }
            set { _viewType = value; }
        }

        string _title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        bool _canClose = true;
        /// <summary>
        /// CanClose
        /// </summary>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }
        /// <summary>
        /// 이미지를 Base64 숫자로 인코딩 처리
        /// </summary>
        /// <param name="bitmap">BitmapSource</param>
        /// <returns></returns>
        string ImageToBase64(BitmapSource bitmap)
        {
            if (bitmap == null) return null;
            var encoder = new PngBitmapEncoder();
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        /// <summary>
        /// Base64 값을 BitmapSource 를 변환
        /// </summary>
        /// <param name="base64">base64 값</param>
        /// <returns></returns>
        BitmapSource Base64ToImage(string base64)
        {
            if (string.IsNullOrEmpty(base64)) return null;
            byte[] bytes = Convert.FromBase64String(base64);
            using (var stream = new MemoryStream(bytes))
            {
                return BitmapFrame.Create(stream);
            }
        }
    }
}
