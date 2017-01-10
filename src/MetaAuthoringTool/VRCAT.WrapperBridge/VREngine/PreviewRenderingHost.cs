using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using MVRWrapper;
using System.Text;
using System.IO;

namespace VRCAT.WrapperBridge
{
    /// <summary>
    /// 3D Engine Rendeering View Host 클래스
    /// </summary>
    public class PreviewRenderingHost : HwndHost
    {
        private IntPtr hwndHost;

        private bool startDrag = false;
        private float dragStartX;
        private float dragStartY;
        private int initWidth, initHeight;

        private float cameraMoveUnit = 4.0f;
        private float cameraRotationUnit = 0.1f;
        private float cameraAccelation = 10.0f;
        private float cameraSensitivity = 0.5f;//1.0f;
        private MRenderWindow _3DWindow;
        private MCamera _ToolCamera;
        private MWorld _World;
        private string _Path;
        private bool _IsMaterialPreview = false;
        private bool _IsAnimationPreview = false;
        private MContainer SelectedObject;
        MContainer targetObject = null;
        /// <summary>
        /// Rendering View 생성자
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">height</param>
        /// <remarks>EditMode 에 따라 Grid,Gizmo 표현 변경됨</remarks>
        public PreviewRenderingHost(string Path, int width, int height,bool IsMaterialPreview = false , bool IsAnimationPreview = false)
        {
            if (!EngineInit.GetInstance.IsEngineInit)
                EngineInit.GetInstance.EngineInitStart();
            this.initWidth = Math.Max(1, width);
            this.initHeight = Math.Max(1, height);

            this._Path = Path;
            this._IsMaterialPreview = IsMaterialPreview;
            this._IsAnimationPreview = IsAnimationPreview;
        }

        /// <summary>
        /// Win32 Window 생성자
        /// </summary>
        /// <remarks>WPF의 window handle 은 메인 UI 하나뿐이다. 그래서 Win32 용 Window 생성을 할려면 HwndHost를 상속받아 하위 윈도우 생성을 한뒤 상위 Main window 에 해당 handle을 넘겨줘야함</remarks>
        /// <param name="hwndParent">메인 UI Window Handle</param>
        /// <returns></returns>
        protected override System.Runtime.InteropServices.HandleRef BuildWindowCore(System.Runtime.InteropServices.HandleRef hwndParent)
        {
            hwndHost = CreateWindowEx(0, "static", "PreViewRendering", WS_CHILD | WS_VISIBLE | WS_CLIPCHILDREN, 0, 0,
                                            this.initWidth, this.initHeight,
                                            hwndParent.Handle,
                                            (IntPtr)HOST_ID,
                                            IntPtr.Zero,
                                            0);
            _3DWindow = new MRenderWindow(hwndHost.ToInt32());
            _World = new MWorld();
            _ToolCamera = new MCamera(true);
            _ToolCamera.Cam.DrawGrid(true);
            
            if (this._IsMaterialPreview)
            {
                targetObject = new MSphere(_World);
                ((MSphere)targetObject).setMaterial(this._Path);
                //_ToolCamera.Cam.DrawGrid(false);
            }
            else if(this._IsAnimationPreview)
            {
                string comparePath = Path.GetFileName(this._Path);
                CharEnumerator charEnum = comparePath.GetEnumerator();
                StringBuilder sBuild = new StringBuilder();
                while(charEnum.MoveNext())
                {
                    if (charEnum.Current.Equals('.'))
                        break;
                    sBuild.Append(charEnum.Current);
                }
                string ffbxPath = sBuild.ToString() + ".ffbx";
                ffbxPath = this._Path.Replace(comparePath, ffbxPath);
                targetObject = new MFbx(ffbxPath, _World);
                ((MFbx)targetObject).FbxComponent.SetTestAnimation(this._Path);
            }
            else
            {
                targetObject = new MFbx(this._Path, _World);
            }

            _ToolCamera.Transform.LookAt(new MVector3(0, 5, -10), new MVector3(0, 0, 0), new MVector3(0, 1, 0));
            HwndSource source = HwndSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
            return new System.Runtime.InteropServices.HandleRef(this, this.hwndHost);
        }
        public void SaveResource()
        {
            if(targetObject != null)
            {
                if(targetObject is MSphere)
                {
                    //((MSphere)targetObject).
                }
                else if(targetObject is MFbx)
                {

                }
            }
        }
        protected override void DestroyWindowCore(System.Runtime.InteropServices.HandleRef hwnd)
        {
            _3DWindow.Dispose();
            DestroyWindow(hwnd.Handle);
            //MVREngine.GetEngine().EngineInitSuccess = false;
        }
        /// <summary>
        /// UI Resize 시 Scene Resize 처리
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Resize(int width, int height)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString() + string.Format(" : RenderingViewHost::Resize({0},{1})", width, height));
            if (width == 0 || height == 0)
                return;
            _3DWindow.Resize(width, height);
            _ToolCamera.Cam.AspectRatio((float)width / (float)height);
        }
        //int renderFrame = 0;
        /// <summary>
        /// Engine의 Update 및 Render 호출
        /// </summary>
        public void Render()
        {
            _3DWindow.PreRender();
            _3DWindow.FrameAnimate(_World);
            _3DWindow.Render(_World, _ToolCamera);
            _3DWindow.PostRender();
        }
        /// <summary>
        /// Shift + F3 키 눌렀을때 해당 SceneCamera 위치로 MainCamera 위치를 Transform
        /// </summary>
        private void MoveCameraToSelectedObject()
        {
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 MouseDown 이벤트 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.startDrag = true;
            Point p = e.GetPosition(this);
            dragStartX = (float)p.X;
            dragStartY = (float)p.Y;
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 MouseUP 이벤트 처리
        /// </summary>
        public void HandleMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.startDrag = false;
            if (e.ChangedButton == MouseButton.Left)
            {
            }
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 MouseMove 이벤트 처리
        /// </summary>
        public void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (!this.startDrag)
                return;

            Point p = e.GetPosition(this);
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
                _ToolCamera.Transform.Rotate(deltaX * rotationAngle, -deltaY * rotationAngle);
            }
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                _ToolCamera.Transform.Move(-deltaX, deltaY, moveDist);
            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {

            }
        }
        /// <summary>
        /// Win32 3D Rendering View 내 에서의 MouseWheel 이벤트 처리
        /// </summary>
        public void HandleMouseWheel(object sender, MouseWheelEventArgs e)
        {
            float rotationAngle = this.cameraRotationUnit * cameraSensitivity;
            float moveDist = this.cameraMoveUnit * 0.0005f * cameraSensitivity;
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                rotationAngle = rotationAngle * this.cameraAccelation;
                moveDist = moveDist * this.cameraAccelation;
            }
            int delta = e.Delta / 100;
            _ToolCamera.Transform.MoveForward(delta + moveDist);
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
        }
        public void HandleKeyUp(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) && e.Key == Key.F)
            {
                if (this.targetObject != null)
                {
                    this._ToolCamera.Transform.Focus(this.targetObject.Transform);
                }
            }
        }
        /// <summary>
        /// Win32 Message Hook
        /// </summary>
        /// <remarks>RealtimeRendering 모드 또는 StopRendering 이 아닐경우 Win32 WM_PAINT 이벤트 발생시 마다 엔진 Render 지시</remarks>
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            try
            {
                if (msg == WM_PAINT)
                {
                    //Console.WriteLine(DateTime.Now.ToShortTimeString() + " : WM_PAINT");
                    //Paint paint;
                    //BeginPaint(hwndHost, out paint);
                    //this.Render();
                    //EndPaint(hwndHost, ref paint);
                }
                else if (msg == WM_ERASEBKGND)
                {
                    //if (this.EditMode && !this.StopRendering)
                    //{
                    //    Console.WriteLine(DateTime.Now.ToShortTimeString() + " : WM_ERASEBKGND");
                    //    this.Render();
                    //}
                }
                else if (msg == WM_SIZE)
                {
                }
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
