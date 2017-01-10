using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using VRCAT.DataModel;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;

namespace VRCAT.WrapperBridge
{
    public class MultiRenderingViewHost : HwndHost
    {
        private IntPtr hwndHost;
        private Procedure procedure;

        private bool startDrag = false;
        private float dragStartX = -1;
        private float dragStartY = -1;
        private int initWidth, initHeight;

        private float cameraMoveUnit = 4.0f;
        private float cameraRotationUnit = 0.1f;
        private float cameraAccelation = 10.0f;
        private float cameraSensitivity = 0.5f;//1.0f;
        private MRenderWindow _3DWindow;
        public MCamera _RenderingCamera;
        public bool StopRendering { get; set; }

        /// <summary>
        /// Rendering View 생성자
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">height</param>
        public MultiRenderingViewHost(int width, int height)
        {
            if (!EngineInit.GetInstance.IsEngineInit)
                EngineInit.GetInstance.EngineInitStart();

            this.initWidth = Math.Max(1, width);
            this.initHeight = Math.Max(1, height);
            this.StopRendering = true;

            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(param =>
            {
                if (param.Equals("SceneLoading"))
                {
                    MGizmoHandler.GetInstance().SetEnable(true);
                    //MWorld.GetInstance().LoadGizmo(true);
                }
            });

            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Subscribe(param =>
            {
                if (param.Event == TriggerEngineEvent.TriggerEvent.FocusToObject)
                {
                    MContainer target = (MContainer)param.Value;
                    _RenderingCamera.Transform.Focus(target.Transform);
                }
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Subscribe(param =>
            {
                if (param.SelectedObject is MContainer)
                {
                    VRWorld.Instance.LasetedSelectedContainer = (MContainer)param.SelectedObject;
                }
                if (param.SelectedObject == null)
                    VRWorld.Instance.LasetedSelectedContainer = null;
            });
        }

        /// <summary>
        /// Win32 Window 생성자
        /// </summary>
        /// <remarks>WPF의 window handle 은 메인 UI 하나뿐이다. 그래서 Win32 용 Window 생성을 할려면 HwndHost를 상속받아 하위 윈도우 생성을 한뒤 상위 Main window 에 해당 handle을 넘겨줘야함</remarks>
        /// <param name="hwndParent">메인 UI Window Handle</param>
        /// <returns></returns>
        protected override System.Runtime.InteropServices.HandleRef BuildWindowCore(System.Runtime.InteropServices.HandleRef hwndParent)
        {
            hwndHost = CreateWindowEx(0, "static", "Rendering", WS_CHILD | WS_VISIBLE | WS_CLIPCHILDREN | WS_CLIPSIBLINGS, 0, 0,
                                            this.initWidth, this.initHeight,
                                            hwndParent.Handle,
                                            (IntPtr)HOST_ID,
                                            IntPtr.Zero,
                                            0);

            #region rednering view wnd proc 에서 그리는거 테스트중 [ http://developers-club.com/posts/261927/ ]
            //var callback = Marshal.GetFunctionPointerForDelegate(procedure = WndProc);
            //var width = initWidth;
            //var height = initHeight;
            //var cursor = LoadCursor(IntPtr.Zero, 32512);
            //var menu = string.Empty;
            //var background = new IntPtr(1);
            //var zero = IntPtr.Zero;
            //var caption = string.Empty;
            //var style = 3u;
            //var extra = 0;
            //var extended = 0;
            //var window = 0x50000000;
            //var point = 0;
            //var name = "Win32";

            //var wnd = new WindowClass
            //{
            //    Style = style,
            //    Callback = callback,
            //    ClassExtra = extra,
            //    WindowExtra = extra,
            //    Instance = zero,
            //    Icon = zero,
            //    Cursor = cursor,
            //    Background = background,
            //    Menu = menu,
            //    Class = name
            //};

            //RegisterClass(ref wnd);
            //hwndHost = CreateWindowEx(extended, name, caption,
            //    window, point, point, width, height,
            //    hwndParent.Handle, zero, zero, zero);
            #endregion

            _3DWindow = new MRenderWindow(hwndHost.ToInt32());
            _RenderingCamera = new MCamera(true);
            _RenderingCamera.Transform.LookAt(new MVector3(0, 5, -10), new MVector3(0, 0, 0), new MVector3(0, 1, 0));
            _RenderingCamera.Cam.ChangeFarViewPlane(20000);

            MGizmoHandler.GetInstance().AddGizmoHandle(_3DWindow);
            MGizmoHandler.GetInstance().SetEnable(false);


            //HwndSource source = HwndSource.FromVisual(this) as HwndSource;
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);

            /// RenderWindow가 생성되었다 메세지 전달
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<EngineEvent>>().Publish(new EngineEvent() { eventArg = EngineEventArg.RenderWindowCreated });

            return new System.Runtime.InteropServices.HandleRef(this, this.hwndHost);
        }
        protected override void DestroyWindowCore(System.Runtime.InteropServices.HandleRef hwnd)
        {
            DestroyWindow(hwnd.Handle);
            //MVREngine.GetEngine().EngineInitSuccess = false;
        }
        public void SetWireFrame(bool set)
        {
            _RenderingCamera.Cam.WireFrame(set);
        }
        /// <summary>
        /// UI Resize 시 Scene Resize 처리
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Resize(int width, int height)
        {
            if (width == 0 || height == 0)
                return;
            _3DWindow.Resize(width, height);
            //_RenderingCamera.AspectRatio((float)width / (float)height);
            //_RenderingCamera.Cam.AspectRatio((float)width / (float)height);
        }
        public void SetCameraTransformFromRenderingCamera(MContainer selectCamera)
        {
            //selectCamera.Transform.SetPosition(_RenderingCamera.Transform.Position);

            //selectCamera.Transform.Position.X = _RenderingCamera.Transform.Position.X;
            //selectCamera.Transform.Position.Y = _RenderingCamera.Transform.Position.Y;
            //selectCamera.Transform.Position.Z = _RenderingCamera.Transform.Position.Z;

            //selectCamera.Transform.SetPosition(_RenderingCamera.Transform.Position);

            selectCamera.Transform.Position = _RenderingCamera.Transform.Position;
            selectCamera.Transform.Rotation = _RenderingCamera.Transform.Rotation;

            //float degreeX = _RenderingCamera.Transform.Rotation.X;
            //float degreeY = _RenderingCamera.Transform.Rotation.Y;
            selectCamera.ApplyAllProperty();
        }
        //int renderFrame = 0;
        /// <summary>
        /// Engine의 Update 및 Render 호출
        /// </summary>
        public void Render()
        {
            _3DWindow.PreRender();
            //if (VRWorld.Instance.IsFrameAnimate)
            //{
            //    _3DWindow.FrameAnimate(null);
            //    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("InspectorUpdateEvent");
            //}
            ///MWorld.GetInstance().FrameAnimate();
            _3DWindow.Render(_RenderingCamera);
            _3DWindow.DrawGizmo(MWorld.GetInstance(), _RenderingCamera);
            _3DWindow.PostRender();
        }
        /// <summary>
        /// Grid 렌더링 Enable / Disable
        /// </summary>
        /// <param name="enable"></param>
        public void DrawGrid(bool enable)
        {
            _RenderingCamera.Cam.DrawGrid(enable);
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 MouseDown 이벤트 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleMouseDown(object sender, MouseButtonEventArgs e)
        {
            startDrag = true;
            Point p = e.GetPosition(this);
            dragStartX = (float)p.X;
            dragStartY = (float)p.Y;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _3DWindow.SetRectangleStartPoint(dragStartX, dragStartY);
                bool IsGizmoSelected = _3DWindow.GetGizmoSelection();
                if(!IsGizmoSelected)
                {
                    MContainer pickObject = MWorld.GetInstance().PickingObject((int)p.X, (int)p.Y, _3DWindow.ScreenWidth, _3DWindow.ScreenHeight, _RenderingCamera);
                    if (pickObject != null)
                    {
                        if (Keyboard.IsKeyDown(Key.LeftCtrl))
                        {
                            if (PickingEvent.Instance.PickElements.Contains(pickObject))
                                PickingEvent.Instance.PickElements.Remove(pickObject);
                            else
                                PickingEvent.Instance.PickElements.Add(pickObject);
                        }
                        else
                        {
                            PickingEvent.Instance.PickElements.Clear();
                            PickingEvent.Instance.PickElements.Add(pickObject);
                        }
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);
                    }
                    else
                    {
                        PickingEvent.Instance.PickElements.Clear();
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(PickingEvent.Instance);
                    }
                }

                //if (VRWorld.Instance.LasetedSelectedContainer == null)
                //{
                //    MContainer pickObject = MWorld.GetInstance().PickingObject((int)p.X, (int)p.Y, _3DWindow.ScreenWidth, _3DWindow.ScreenHeight, _RenderingCamera);
                //    if (pickObject != null)
                //    {
                //        pickObject.Selected(true);
                //        VRWorld.Instance.LasetedSelectedContainer = pickObject;
                //        MGizmoHandler.GetInstance().SetObject(pickObject);
                //        //MGizmoConnector.GetInstance().SetObject(pickObject.Transform);
                //        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(new PickingEvent());
                //        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = pickObject });
                //        MGizmoHandler.GetInstance().SetEnable(true);
                //        //MGizmoConnector.GetInstance().SetEnable(true);
                //    }
                //    else
                //        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
                //}
                //else
                //{
                //    if (!IsGizmoSelected)
                //    {
                //        MContainer pickObject = MWorld.GetInstance().PickingObject((int)p.X, (int)p.Y, _3DWindow.ScreenWidth, _3DWindow.ScreenHeight, _RenderingCamera);
                //        if (pickObject != null)
                //        {
                //            /// Pick Object 를 초기화 시키고서
                //            VRWorld.Instance.LasetedSelectedContainer = null;
                //            MGizmoHandler.GetInstance().SetEnable(false);
                //            MGizmoHandler.GetInstance().DetachAllGizmo();
                //            //MGizmoConnector.GetInstance().SetEnable(false);
                //            //MGizmoConnector.GetInstance().DetachAllGizmo();
                //            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(new PickingEvent());


                //            /// Pick Object 처리
                //            pickObject.Selected(true);
                //            VRWorld.Instance.LasetedSelectedContainer = pickObject;
                //            MGizmoHandler.GetInstance().SetObject(pickObject);
                //            //MGizmoConnector.GetInstance().SetObject(pickObject.Transform);
                //            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(new PickingEvent());
                //            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = pickObject });
                //            MGizmoHandler.GetInstance().SetEnable(true);
                //            //MGizmoConnector.GetInstance().SetEnable(true);
                //        }
                //        else
                //        {
                //            /// Pick Object 를 초기화 시키기
                //            VRWorld.Instance.LasetedSelectedContainer = null;
                //            MGizmoHandler.GetInstance().SetEnable(false);
                //            //MGizmoConnector.GetInstance().SetEnable(false);
                //            MGizmoHandler.GetInstance().DetachAllGizmo();
                //            //MGizmoConnector.GetInstance().DetachAllGizmo();
                //            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Publish(new PickingEvent());
                //        }
                //    }
                //}
                _3DWindow.GizmoMouseClick((int)dragStartX, (int)dragStartY, _RenderingCamera, _3DWindow.ScreenWidth, _3DWindow.ScreenHeight);
            }
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 MouseUP 이벤트 처리
        /// </summary>
        public void HandleMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.startDrag = false;
            if (e.ChangedButton == MouseButton.Left)
            {
                _3DWindow.GizmoMouseRelease();
                _3DWindow.SetRectangleStartPoint(0, 0);
                _3DWindow.SetRectangleDeltaPoint(0, 0);
                //MWorld.GetInstance().GizmoMouseRelease();
                //Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<EngineEvent>>().Publish(new EngineEvent() { eventArg = EngineEventArg.Vector3Refresh });
            }
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 MouseMove 이벤트 처리
        /// </summary>
        public void HandleMouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            if (startDrag)
            {
                
                float deltaX = (float)(p.X - dragStartX);
                float deltaY = (float)(p.Y - dragStartY);
                dragStartX = (float)p.X;
                dragStartY = (float)p.Y;
                float rotationAngle = this.cameraRotationUnit * cameraSensitivity;
                float moveDist = this.cameraMoveUnit * 0.05f * cameraSensitivity;
                if (Keyboard.IsKeyDown(Key.LeftShift))
                {
                    rotationAngle = rotationAngle * this.cameraAccelation;
                    moveDist = moveDist * this.cameraAccelation;
                }
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    _RenderingCamera.Transform.Rotate(deltaX * rotationAngle, -deltaY * rotationAngle);
                }
                if (e.MiddleButton == MouseButtonState.Pressed)
                {
                    _RenderingCamera.Transform.Move(-deltaX, deltaY, moveDist);
                }
                if(e.LeftButton == MouseButtonState.Pressed)
                {
                    _3DWindow.SetRectangleDeltaPoint((float)p.X, (float)p.Y);
                    //_3DWindow.DrawRectangle();
                }
            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _3DWindow.GizmoMouseDrag((int)p.X, (int)p.Y, _RenderingCamera, _3DWindow.ScreenWidth, _3DWindow.ScreenHeight);
                if (VRWorld.Instance.LasetedSelectedContainer != null)
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<EngineEvent>>().Publish(new EngineEvent() { eventArg = EngineEventArg.Vector3Refresh });
            }
            else
                _3DWindow.GizmoMouseMove((int)p.X, (int)p.Y, _RenderingCamera, _3DWindow.ScreenWidth, _3DWindow.ScreenHeight);
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 MouseWheel 이벤트 처리
        /// </summary>
        public void HandleMouseWheel(object sender, MouseWheelEventArgs e)
        {
            float rotationAngle = this.cameraRotationUnit * cameraSensitivity;
            float moveDist = this.cameraMoveUnit * 0.0005f * cameraSensitivity;
            moveDist = 1;
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                rotationAngle = rotationAngle * this.cameraAccelation;
                moveDist = moveDist * this.cameraAccelation;
                moveDist *= 2;
            }
            int delta = e.Delta / 100;
            _RenderingCamera.Transform.MoveForward(delta * moveDist);
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 NavigateCamera 이벤트 처리
        /// </summary>
        public void NavigateCamera(long timeInterval)
        {
            bool renderFrame = false;
            float rotationAngle = this.cameraRotationUnit * cameraSensitivity;
            float moveDist = this.cameraMoveUnit * (timeInterval * 0.0005f) * cameraSensitivity;
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                rotationAngle = rotationAngle * this.cameraAccelation;
                moveDist = moveDist * this.cameraAccelation;
            }

            if (Keyboard.IsKeyDown(Key.W))
            {
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
            }
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 KeyDown 이벤트 처리
        /// </summary>
        public void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                if (e.Key == Key.W)
                {
                    _RenderingCamera.Transform.MoveForward(1);
                }
                else if (e.Key == Key.A)
                {
                    _RenderingCamera.Transform.Move(-1, 0, 1);
                }
                else if (e.Key == Key.D)
                {
                    _RenderingCamera.Transform.Move(1, 0, 1);
                }
                else if (e.Key == Key.S)
                {
                    _RenderingCamera.Transform.MoveForward(-1);
                }
            }
        }
        public void HandleKeyUp(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) && e.Key == Key.F)
            {
                if (VRWorld.Instance.LasetedSelectedContainer != null)
                {
                    this._RenderingCamera.Transform.Focus(((MContainer)VRWorld.Instance.LasetedSelectedContainer).Transform);
                }
            }
        }

        public void CameraViewChange(int viewType)
        {
            float distance = 30;
            switch (viewType)
            {
                case 0:
                    _RenderingCamera.Transform.ViewTop(distance);
                    break;
                case 1:
                    _RenderingCamera.Transform.ViewLeft(distance);
                    break;
                case 2:
                    _RenderingCamera.Transform.ViewRight(distance);
                    break;
                case 3:
                    _RenderingCamera.Transform.ViewBotton(distance);
                    break;
            }
        }
        public void ChangeOrthographicView(bool value)
        {
            this._RenderingCamera.Cam.IsOrthographicView(value);
        }

        /// <summary>
        /// Win32 Message Hook
        /// </summary>
        /// <remarks>RealtimeRendering 모드 또는 StopRendering 이 아닐경우 Win32 WM_PAINT 이벤트 발생시 마다 엔진 Render 지시</remarks>
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            try
            {
                //if (msg == WM_PAINT)
                //{
                //    Paint paint;
                //    BeginPaint(hwnd, out paint);

                //    EndPaint(hwnd, ref paint);
                //    handled = true;


                //    Console.WriteLine(DateTime.Now.ToShortTimeString() + " : WM_PAINT");
                //    Paint paint;
                //    BeginPaint(hwndHost, out paint);
                //    this.Render();
                //    EndPaint(hwndHost, ref paint);
                //}
                //else if (msg == WM_ERASEBKGND)
                //{
                //    //if (this.EditMode && !this.StopRendering)
                //    //{
                //    //    Console.WriteLine(DateTime.Now.ToShortTimeString() + " : WM_ERASEBKGND");
                //    //    this.Render();
                //    //}
                //}
                //else if (msg == WM_SIZE)
                //{
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //return base.WndProc(hwnd, msg, wParam, lParam, ref handled);
            return IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct Paint
        {
            public IntPtr Context;
            public bool Erase;
            public Rect Area;
            public bool Restore;
            public bool Update;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] Reserved;
        }
        [DllImport("user32.dll")]
        static extern IntPtr BeginPaint(IntPtr handle, out Paint paint);

        [DllImport("user32.dll")]
        static extern bool EndPaint(IntPtr handle, [In] ref Paint paint);
        [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
        internal static extern bool DestroyWindow(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateWindowEx(int dwExStyle,
                                                      string lpszClassName,
                                                      string lpszWindowName,
                                                      int style,
                                                      int x, int y,
                                                      int width, int height,
                                                      IntPtr hwndParent,
                                                      IntPtr hMenu,
                                                      IntPtr hInst,
                                                      [MarshalAs(UnmanagedType.AsAny)] object pvParam);
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor
            (IntPtr instance,
            int name);

        [StructLayout(LayoutKind.Sequential)]
        struct WindowClass
        {
            public uint Style;
            public IntPtr Callback;
            public int ClassExtra;
            public int WindowExtra;
            public IntPtr Instance;
            public IntPtr Icon;
            public IntPtr Cursor;
            public IntPtr Background;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Menu;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Class;
        }

        [DllImport("user32.dll")]
        static extern ushort RegisterClass
            ([In]
            ref WindowClass register);

        delegate IntPtr Procedure
            (IntPtr handle,
            uint message,
            IntPtr wparam,
            IntPtr lparam);

        static IntPtr WndProc(IntPtr handle, uint message, IntPtr wparam, IntPtr lparam)
        {
            return DefWindowProc(handle, message, wparam, lparam);
        }

        [DllImport("user32.dll")]
        static extern IntPtr DefWindowProc
            (IntPtr handle,
            uint message,
            IntPtr wparam,
            IntPtr lparam);

        internal const int
                    WS_OVERLAPPED = 0x00000000,
                    WS_CHILD = 0x40000000,
                    WS_VISIBLE = 0x10000000,
                    LBS_NOTIFY = 0x00000001,
                    HOST_ID = 0x00000002,
                    LISTBOX_ID = 0x00000001,
                    WS_VSCROLL = 0x00200000,
                    WS_CLIPSIBLINGS = 0x04000000,
                  WS_CLIPCHILDREN = 0x02000000,
                    WS_BORDER = 0x00800000;

        internal const int
            WM_SIZE = 0x0005,
            WM_PAINT = 0x000F,
            WM_ERASEBKGND = 0x0014,
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
            WM_MOUSERMOVE = 0x0200,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_MOUSEWHEEL = 0x020A,
            WM_NCHITTEST = 0x0084;

        internal const int
                VK_TAB = 0x09,
                VK_CLEAR = 0x0C,
                VK_RETURN = 0x0D,
                VK_SHIFT = 0x10,
                VK_CONTROL = 0x11,
                VK_MENU = 0x12,
                VK_PAUSE = 0x13,
                VK_CAPITAL = 0x14,
                VK_KANA = 0x15,
                VK_HANGUEL = 0x15,
                VK_HANGUL = 0x15,
                VK_JUNJA = 0x17,
                VK_FINAL = 0x18,
                VK_HANJA = 0x19,
                VK_KANJI = 0x19,
                VK_ESCAPE = 0x1B,
                VK_CONVERT = 0x1C,
                VK_NONCONVERT = 0x1D,
                VK_ACCEPT = 0x1E,
                VK_MODECHANGE = 0x1F,
                VK_SPACE = 0x20,
                VK_PRIOR = 0x21,
                VK_NEXT = 0x22,
                VK_END = 0x23,
                VK_HOME = 0x24,
                VK_LEFT = 0x25,
                VK_UP = 0x26,
                VK_RIGHT = 0x27,
                VK_DOWN = 0x28,
                VK_SELECT = 0x29,

                K_0 = 0x30,
                K_1 = 0x31,
                K_2 = 0x32,
                K_3 = 0x33,
                K_4 = 0x34,
                K_5 = 0x35,
                K_6 = 0x36,
                K_7 = 0x37,
                K_8 = 0x38,
                K_9 = 0x39,
                K_A = 0x41,
                K_B = 0x42,
                K_C = 0x43,
                K_D = 0x44,
                K_E = 0x45,
                K_F = 0x46,
                K_G = 0x47,
                K_H = 0x48,
                K_I = 0x49,
                K_J = 0x4A,
                K_K = 0x4B,
                K_L = 0x4C,
                K_M = 0x4D,
                K_N = 0x4E,
                K_O = 0x4F,
                K_P = 0x50,
                K_Q = 0x51,
                K_R = 0x52,
                K_S = 0x53,
                K_T = 0x54,
                K_U = 0x55,
                K_V = 0x56,
                K_W = 0x57,
                K_X = 0x58,
                K_Y = 0x59,
                K_Z = 0x5A,

                VK_F1 = 0x70,
                VK_F2 = 0x71,
                VK_F3 = 0x72,
                VK_F4 = 0x73,
                VK_F5 = 0x74,
                VK_F6 = 0x75,
                VK_F7 = 0x76,
                VK_F8 = 0x77,
                VK_F9 = 0x78,
                VK_F10 = 0x79,
                VK_F11 = 0x7A,
                VK_F12 = 0x7B,

                VK_LSHIFT = 16,
                VK_RSHIFT = 17,
                VK_LCONTROL = 0xA2,
                VK_RCONTROL = 0xA3;
    }
}
