using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;
using VRCAT.WrapperBridge;

namespace VRCAT.PlaySceneModule
{
    /// <summary>
    /// PlaySceneView View
    /// </summary>
    public partial class PlaySceneView : UserControl
    {
        static int InstanceNumber = 0;
        int viewID = 0;

        bool ignoreResize = true;
        RenderingViewHost _renderHost;
        long lastTimeTick = 0;

        bool IsShowSceneCamSettingWindow = false;

        /// <summary>
        /// 생성자
        /// </summary>
        public PlaySceneView()
        {
            this.viewID = ++PlaySceneView.InstanceNumber;

            InitializeComponent();
            Loaded += RenderView_Loaded;
            SizeChanged += RenderView_SizeChanged;
            this.Unloaded += RenderView_Unloaded;
        }
        public void Dispose()
        {
            _renderHost.Dispose();
            _renderHost = null;
        }

        void RenderView_Loaded(object sender, RoutedEventArgs e)
        {
            if (this._renderHost == null)
            {
                _renderHost = new RenderingViewHost((int)this.RenderingView.ActualWidth, (int)this.RenderingView.ActualHeight);
                _renderHost.PlayMode = true;
                _renderHost.IsPause = false;
                this.RenderingView.Child = this._renderHost;

                CompositionTarget.Rendering += this.CompositionTarget_Rendering;
                this.lastTimeTick = DateTime.Now.Ticks;
            }

            this._renderHost.StopRendering = false;
        }

        void RenderView_Unloaded(object sender, RoutedEventArgs e)
        {
            if (this._renderHost != null)
                this._renderHost.StopRendering = true;
        }

        void RenderView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString() + string.Format(" : RenderView({0}) - RenderView_SizeChanged({1},{2})", this.viewID, (int)this.RenderingView.ActualWidth, (int)this.RenderingView.ActualHeight));
            if (this._renderHost != null)
                _renderHost.Resize((int)this.RenderingView.ActualWidth, (int)this.RenderingView.ActualHeight);
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            long timeInterval = Math.Min(1000, DateTime.Now.Ticks - this.lastTimeTick);
            lastTimeTick = DateTime.Now.Ticks;
            if (this.RenderingView.IsFocused) // rendering view focused
            {
                if (_renderHost != null)
                    _renderHost.NavigateCamera(timeInterval);
            }
            if (_renderHost != null)
            {
                _renderHost.Render();
            }
            //if (this.updateRendering)
            //{
            //    this.updateRendering = false;
            //    if (this._renderHost != null)
            //        this._renderHost.Resize((int)this.RenderingView.ActualWidth, (int)this.RenderingView.ActualHeight);
            //}

        }

        private static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                    return (T)current;
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void RenderingView_MouseMove(object sender, MouseEventArgs e)
        {
            _renderHost.HandleMouseMove(sender, e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
            }
        }

        private void RenderingView_KeyDown(object sender, KeyEventArgs e)
        {
            _renderHost.HandleKeyDown(sender, e);
            if (Keyboard.IsKeyDown(Key.LeftShift) && e.Key == Key.F)
            {
            }

            Console.WriteLine("RenderingView_KeyDown" + e.Key.ToString());
        }

        private void RenderingView_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("RenderingView_KeyUp" + e.Key.ToString());
            _renderHost.HandleKeyUp(sender, e);
        }
        private void RenderingView_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Keyboard.Focus(this.RenderingView);
            _renderHost.HandleMouseWheel(sender, e);
        }

        private void RenderingView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(this.RenderingView);
            Mouse.Capture(this.RenderingView);
            _renderHost.HandleMouseDown(sender, e);
        }

        private void RenderingView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            _renderHost.HandleMouseUp(sender, e);
        }

        private void RenderView_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
