using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using VRCAT.DataModel;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;
using VRCAT.Infrastructure.DragDrop;
using VRCAT.WrapperBridge;
using WPFXCommand;

namespace VRCAT.RenderingModule
{
    /// <summary>
    /// RenderView UI
    /// </summary>
    public partial class RenderView : UserControl , INotifyPropertyChanged , IDropTarget
    {
        bool IsFocused = false;
        static int InstanceNumber = 0;
        int viewID = 0;

        bool ignoreResize = true;
        //RenderingViewHost _renderHost;
        MultiRenderingViewHost _renderHost;
        CameraRenderingViewHost _smallrenderHost;
        
        long lastTimeTick = 0;
        bool updateRendering = true;
        bool IsShowSceneCamSettingWindow = false;
        bool _isDragging = false;
        private Point _anchorPoint = new Point();

        ICommand _CtrlShiftFCommand;
        public ICommand CtrlShiftFCommand
        {
            get
            {
                if (_CtrlShiftFCommand == null)
                    _CtrlShiftFCommand = new RelayCommand(CtrlShiftFBehavior);
                return _CtrlShiftFCommand;
            }
        }
        ICommand _FocusCommand;
        public ICommand FocusCommand
        {
            get
            {
                if (_FocusCommand == null)
                    _FocusCommand = new RelayCommand(FocusBehavior);
                return _FocusCommand;
            }
        }
        private void FocusBehavior(object obj)
        {
            if (VRWorld.Instance.LasetedSelectedContainer != null)
                _renderHost._RenderingCamera.Transform.Focus(((MContainer)VRWorld.Instance.LasetedSelectedContainer).Transform);
        }
        private void CtrlShiftFBehavior(object obj)
        {
            if(_smallrenderHost._RenderingCamera != null)
                _renderHost.SetCameraTransformFromRenderingCamera(_smallrenderHost._RenderingCamera);
        }
        /// <summary>
        /// 생성자
        /// </summary>
        public RenderView()
        {
            this.viewID = ++RenderView.InstanceNumber;

            InitializeComponent();
            Loaded += RenderView_Loaded;
            SizeChanged += RenderView_SizeChanged;
            this.Unloaded += RenderView_Unloaded;
            this.DataContext = this;
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Subscribe(param =>
            {
                if (param.SelectedObject != null)
                {
                    if (param.SelectedObject is MContainer)
                    {
                        IsShowSceneCamSettingWindow = false;
                        MContainer selectedObject = (MContainer)param.SelectedObject;
                        for (int i = 0; i < selectedObject.GetComponentsCount(); i++)
                        {
                            if (selectedObject.GetComponent(i) is MCameraComponent)
                            {
                                _smallrenderHost._RenderingCamera = selectedObject;
                                this.SmallRenderingView.Visibility = Visibility.Visible;
                                IsShowSceneCamSettingWindow = true;
                                return;
                            }
                        }
                        if (!IsShowSceneCamSettingWindow)
                        {
                            _smallrenderHost._RenderingCamera = null;
                            this.SmallRenderingView.Visibility = Visibility.Hidden;
                        }
                    }
                    else
                    {
                        _smallrenderHost._RenderingCamera = null;
                        this.SmallRenderingView.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    _smallrenderHost._RenderingCamera = null;
                    this.SmallRenderingView.Visibility = Visibility.Hidden;
                }
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Subscribe(param =>
            {
                if (param.Event == TriggerEngineEvent.TriggerEvent.NewScene || param.Event == TriggerEngineEvent.TriggerEvent.LoadScene)
                {
                    this._smallrenderHost._RenderingCamera = null;
                    this.SmallRenderingView.Visibility = System.Windows.Visibility.Hidden;
                }
            });


            KeyBinding toolcameraChageKeyBinding = new KeyBinding(CtrlShiftFCommand, new KeyGesture(Key.F, ModifierKeys.Control | ModifierKeys.Shift));
            if (!Application.Current.MainWindow.InputBindings.Contains(toolcameraChageKeyBinding))
                Application.Current.MainWindow.InputBindings.Add(toolcameraChageKeyBinding);

            KeyBinding LastSelectObjectFocus = new KeyBinding(FocusCommand, new KeyGesture(Key.F, ModifierKeys.Control));
            LastSelectObjectFocus.CommandTarget = this;
            if (!Application.Current.MainWindow.InputBindings.Contains(LastSelectObjectFocus))
                Application.Current.MainWindow.InputBindings.Add(LastSelectObjectFocus);

            KeyBinderMultiCommand.Instance.AddKeyBinderMultiCommand(new KeyGesture(Key.Delete), DeleteItemCommand);

            this.GotFocus += RenderView_GotFocus;
            this.LostFocus += RenderView_LostFocus;
        }

        

        private void RenderView_GotFocus(object sender, RoutedEventArgs e)
        {
            IsFocused = true;
        }

        private void RenderView_LostFocus(object sender, RoutedEventArgs e)
        {
            IsFocused = false;
        }

        ICommand _DeleteItemCommand;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_DeleteItemCommand == null)
                    _DeleteItemCommand = new RelayCommand(DeleteItemCommandBehavior);
                return _DeleteItemCommand;
            }
        }

        private void DeleteItemCommandBehavior(object obj)
        {
            if(IsFocused)
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<DeleteContainerFromRenderView>>().Publish(null);
        }
        void RenderView_Loaded(object sender, RoutedEventArgs e)
        {
            if (this._renderHost == null)
            {
                //_renderHost = new RenderingViewHost((int)this.RenderingView.ActualWidth, (int)this.RenderingView.ActualHeight);
                _renderHost = new MultiRenderingViewHost((int)this.RenderingView.ActualWidth, (int)this.RenderingView.ActualHeight);
                this.RenderingView.Child = this._renderHost;
                this.lastTimeTick = DateTime.Now.Ticks;
                _renderHost.Resize((int)this.RenderingView.ActualWidth, (int)this.RenderingView.ActualHeight);
                _renderHost.DrawGrid(true);
            }
            if(this._smallrenderHost == null)
            {
                _smallrenderHost = new CameraRenderingViewHost((int)this.SmallRenderingView.ActualWidth, (int)this.SmallRenderingView.ActualHeight);
                this.SmallRenderingView.Child = this._smallrenderHost;
                _smallrenderHost.Resize((int)this.SmallRenderingView.ActualWidth, (int)this.SmallRenderingView.ActualHeight);
            }
            CompositionTarget.Rendering += this.CompositionTarget_Rendering;
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
            {
                _renderHost.Resize((int)this.RenderingView.ActualWidth, (int)this.RenderingView.ActualHeight);
                this.updateRendering = true;
            }
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            long timeInterval = Math.Min(1000, DateTime.Now.Ticks - this.lastTimeTick);
            lastTimeTick = DateTime.Now.Ticks;
            //if (this.RenderingView.IsFocused) // rendering view focused
            //{
            //    if (_renderHost != null)
            //        _renderHost.NavigateCamera(timeInterval);
            //}
            if (_renderHost != null)
            {
                if (this.updateRendering)
                {
                    _renderHost.Render();
                    //this.updateRendering = false;
                }
            }
            if(_smallrenderHost != null)
            {
                if (this.updateRendering)
                    _smallrenderHost.Render();
            }
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

        private void RenderingView_KeyDown(object sender, KeyEventArgs e)
        {
            _renderHost.HandleKeyDown(sender, e);
            if (Keyboard.IsKeyDown(Key.LeftShift) && e.Key == Key.F)
            {
                //if (this._renderHost.SelectedObject == this._renderHost.Scene.mainCamera)
                //    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<GizmoChangeEvent>>().Publish(new GizmoChangeEvent());
            }
        }

        private void RenderingView_KeyUp(object sender, KeyEventArgs e)
        {
            _renderHost.HandleKeyUp(sender, e);
            this.updateRendering = true;
        }
        private void RenderingView_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Keyboard.Focus(this.RenderingView);
            _renderHost.HandleMouseWheel(sender, e);
            this.updateRendering = true;
        }
        private void RenderingView_MouseMove(object sender, MouseEventArgs e)
        {
            _renderHost.HandleMouseMove(sender, e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.updateRendering = true;
            }

            ///if (!floatingTip.IsOpen) { floatingTip.IsOpen = true; }

            Point currentPos = e.GetPosition(this.RenderingView);

            // The + 20 part is so your mouse pointer doesn't overlap.
            this.floatingTip.HorizontalOffset = currentPos.X + 20;
            this.floatingTip.VerticalOffset = currentPos.Y;
            this.tooltipText.Text = string.Format("({0:F0},{1:F0})", currentPos.X, currentPos.Y);

            //if (_isDragging)
            //{
            //    double x = currentPos.X;
            //    double y = currentPos.Y;
            //    Rect.SetValue(Canvas.LeftProperty, Math.Min(x, _anchorPoint.X));
            //    Rect.SetValue(Canvas.TopProperty, Math.Min(y, _anchorPoint.Y));
            //    Rect.Width = Math.Abs(x - _anchorPoint.X);
            //    Rect.Height = Math.Abs(y - _anchorPoint.Y);
            //    if (Rect.Visibility != Visibility.Visible)
            //        Rect.Visibility = Visibility.Visible;
            //}
        }
        private void RenderingView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(this.RenderingView);
            Mouse.Capture(this.RenderingView);
            _renderHost.HandleMouseDown(sender, e);
            this.updateRendering = true;
            _anchorPoint.X = e.GetPosition(RenderingView).X;
            _anchorPoint.Y = e.GetPosition(RenderingView).Y;
            _isDragging = true;
        }
        private void RenderingView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            _renderHost.HandleMouseUp(sender, e);
            this.updateRendering = true;
            ResetRect();
        }
        private void RenderView_MouseLeave(object sender, MouseEventArgs e)
        {
            floatingTip.IsOpen = false;
            ///ResetRect();
        }
        void ResetRect()
        {
            ///Rect.Visibility = Visibility.Collapsed;
            ///_isDragging = false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        private void ShowGridCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (null != _renderHost)
                _renderHost.DrawGrid(true);
        }
        private void ShowGridCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (null != _renderHost)
                _renderHost.DrawGrid(false);
        }
        private void TopViewBtn_Click(object sender, RoutedEventArgs e)
        {
            LeftViewBtn.IsChecked = false;
            RightViewBtn.IsChecked = false;
            BottomViewBtn.IsChecked = false;
            _renderHost.CameraViewChange(0);
        }
        private void LeftViewBtn_Click(object sender, RoutedEventArgs e)
        {
            TopViewBtn.IsChecked = false;
            RightViewBtn.IsChecked = false;
            BottomViewBtn.IsChecked = false;
            _renderHost.CameraViewChange(1);
        }

        private void RightViewBtn_Click(object sender, RoutedEventArgs e)
        {
            TopViewBtn.IsChecked = false;
            LeftViewBtn.IsChecked = false;
            BottomViewBtn.IsChecked = false;
            _renderHost.CameraViewChange(2);
        }

        private void BottomViewBtn_Click(object sender, RoutedEventArgs e)
        {
            TopViewBtn.IsChecked = false;
            LeftViewBtn.IsChecked = false;
            RightViewBtn.IsChecked = false;
            _renderHost.CameraViewChange(3);
        }

        private void ShowWireFrame_Checked(object sender, RoutedEventArgs e)
        {
            if (_renderHost != null)
                _renderHost.SetWireFrame(true);
        }

        private void ShowWireFrame_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_renderHost != null)
                _renderHost.SetWireFrame(false);
        }

        private void ToolCameraPropertyChange_Click(object sender, RoutedEventArgs e)
        {
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = _renderHost._RenderingCamera });
            this.SmallRenderingView.Visibility = Visibility.Hidden;
        }

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data == dropInfo.TargetItem)
                return;
            if (dropInfo.Data is NodeVM || dropInfo.Data is FileModel)
            {
                if (dropInfo.Data is FileModel)
                {
                    string ext = ((FileModel)dropInfo.Data).FileExtension;
                    if (ext.Equals("ffbx") || ext.Equals("FFBX"))
                    {
                        dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                        dropInfo.Effects = System.Windows.DragDropEffects.Copy;
                    }
                }
                else
                {
                    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                    dropInfo.Effects = System.Windows.DragDropEffects.Copy;
                }
            }
        }
        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is FileModel)
            {
                string path = ((FileModel)dropInfo.Data).FullPath;
                MFbx f = new MFbx(path);
                f.Name = ((FileModel)dropInfo.Data).Name;
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("RefreshNode");
                PickingEvent.Instance.PickElements.Clear();
                PickingEvent.Instance.PickElements.Add(f);
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);

                ///TODO : UnDO , ReDO StateManager 테스트 용
                //StateManager.Instance.ChangeSet(
                //    new UndoCommand(() =>
                //    {
                //        f.Name = ((FileModel)dropInfo.Data).Name;
                //        f.SetAnimationIdx(0);
                //        RefreshNodeView();
                //    },
                //    () =>
                //    {
                //        f.RemoveThis();
                //        RefreshNodeView();
                //    }));
            }
        }

        private void OrthographicView_Checked(object sender, RoutedEventArgs e)
        {
            this.OrthographicView.Content = "2D";
            this._renderHost.ChangeOrthographicView(true);
        }

        private void OrthographicView_Unchecked(object sender, RoutedEventArgs e)
        {
            this.OrthographicView.Content = "3D";
            this._renderHost.ChangeOrthographicView(false);
        }
    }
}
