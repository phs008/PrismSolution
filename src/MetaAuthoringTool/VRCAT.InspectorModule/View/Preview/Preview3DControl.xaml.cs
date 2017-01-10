using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVRWrapper;
using VRCAT.DataModel;
using VRCAT.WrapperBridge;
using VRCAT.Infrastructure;
using System.IO;

namespace VRCAT.InspectorModule
{
    /// <summary>
    /// PreviewControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Preview3DControl : UserControl 
    {
        bool IsMaterialPreview = false;
        bool IsAnimtaionPreview = false;
        PreviewRenderingHost _renderHost;
        string Path = "";
        public Preview3DControl(string filePath,bool isMaterialPreview = false,bool isAnimationPreview = false)
        {
            if (!File.Exists(filePath))
                throw new Exception("파일경로가 정확하지 않아 오류가 발생했습니다. from. Preview3DControl 생성자");
            InitializeComponent();
            Loaded += PreviewControl_Loaded;
            Unloaded += Preview3DControl_Unloaded;
            SizeChanged += Preview3DControl_SizeChanged;
            Path = filePath;
            IsMaterialPreview = isMaterialPreview;
            IsAnimtaionPreview = isAnimationPreview;
        }

        private void Preview3DControl_Unloaded(object sender, RoutedEventArgs e)
        {
            _renderHost.Dispose();
        }

        private void Preview3DControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this._renderHost != null)
            {
                _renderHost.Resize((int)this.PreRenderingView.ActualWidth, (int)this.PreRenderingView.ActualHeight);
            }
        }

        private void PreviewControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_renderHost == null)
            {
                if (IsMaterialPreview)
                    _renderHost = new PreviewRenderingHost(Path, (int)this.PreRenderingView.ActualWidth, (int)this.PreRenderingView.ActualHeight, true);
                else if (IsAnimtaionPreview)
                    _renderHost = new PreviewRenderingHost(Path, (int)this.PreRenderingView.ActualWidth, (int)this.PreRenderingView.ActualHeight, false, true);
                else
                    _renderHost = new PreviewRenderingHost(Path, (int)this.PreRenderingView.ActualWidth, (int)this.PreRenderingView.ActualHeight);
            }
            this.PreRenderingView.Child = this._renderHost;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (_renderHost != null)
                _renderHost.Render();
        }

        private void PreRenderingView_MouseMove(object sender, MouseEventArgs e)
        {
            _renderHost.HandleMouseMove(sender, e);
        }

        private void PreRenderingView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _renderHost.HandleMouseDown(sender, e);
        }

        private void PreRenderingView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _renderHost.HandleMouseUp(sender, e);
        }

        private void PreRenderingView_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            _renderHost.HandleMouseWheel(sender, e);
        }
    }
}
