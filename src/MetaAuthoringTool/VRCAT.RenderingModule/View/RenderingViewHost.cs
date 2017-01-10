using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using VRCAT.Infrastructure;
using VRCAT.RenderingModule;
using VRCAT.DataModel.Event;
using VRCATWrapper;
using System.Windows.Input;
namespace VRCAT.RenderingModule
{

    public class RenderingViewHost : HwndHost
    {
        public MVRScene scene;
        public MVRViewport viewPort;

        private IntPtr hwndHost;
        private MVRObject mainCamera;

        HwndSource _internalHwndSource;

        private readonly int thisHostNum;
        private bool startDrag = false;
        private float dragStartX;
        private float dragStartY;
        private bool isDrag = false;
        private int XPoint, YPoint;
        private int initWidth, initHeight;

        private float cameraMoveUnit = 6.0f;
        private float cameraRotationUnit = 0.1f;
        private float cameraAccelation = 10.0f;
        public float cameraSensitivity = 0.5f;//1.0f;

        MVRObject _SelectedObject;
        public MVRObject SelectedObject
        {
            get { return _SelectedObject; }
            set { _SelectedObject = value; }
        }

        public RenderingViewHost(int x, int y, int Width, int Height)
        {
            XPoint = x;
            YPoint = y;
            initWidth = Math.Max(1, Width);
            initHeight = Math.Max(1, Height);
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Subscribe(param =>
            {
                if (param.SelectedObject is MVRObject)
                {
                    this.SelectedObject = (MVRObject)param.SelectedObject;
                    this.scene.ShowGizmo(this.SelectedObject);
                    this.Render(true, true);
                }
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(param =>
            {
                if (param.Equals("PositionGizmoClick"))
                    this.scene.SetGizemoMode(0);
                else if (param.Equals("RotationGizmoClick"))
                    this.scene.SetGizemoMode(1);
                else if (param.Equals("ScaleGizmoClick"))
                    this.scene.SetGizemoMode(2);
            });
        }


        protected override System.Runtime.InteropServices.HandleRef BuildWindowCore(System.Runtime.InteropServices.HandleRef hwndParent)
        {
            hwndHost = CreateWindowEx(0, "static", "Rendering",
                                            WS_CHILD | WS_VISIBLE | WS_CLIPCHILDREN,
                                            this.XPoint, this.YPoint,
                                            this.initWidth, this.initHeight,
                                            hwndParent.Handle,
                                            (IntPtr)HOST_ID,
                                            IntPtr.Zero,
                                            0);

            this.viewPort = MVREngine.GetEngine().CreateViewPort(this.initWidth, this.initHeight, 32, this.hwndHost);
            //this.viewPort.SetToolMode(true);

            MVREngine.GetEngine().SetViewport(this.viewPort);
            this.scene = MVREngine.GetEngine().GetCurScene();

            if (!MVREngine.GetEngine().EngineInitSuccess)
            {
                MVREngine.GetEngine().GetCurScene().InitPickMaterial();
                MVREngine.GetEngine().EngineInitSuccess = true;
            }

            MVRObject sceneCamera = this.scene.Createobject("SceneCamera");
            sceneCamera.SetParent(null);
            sceneCamera.SetShowAttribute(MVRObjectShowAttribute.show_gameOnly);
            sceneCamera.AddComponent(new MVRCamera(), true);
            //this.scene.SetMainCamera(sceneCamera);

            this.mainCamera = sceneCamera;

            HwndSource source = HwndSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);

            return new System.Runtime.InteropServices.HandleRef(this, this.hwndHost);
        }

        protected override void DestroyWindowCore(System.Runtime.InteropServices.HandleRef hwnd)
        {
            //MVREngine.GetEngine().EngineInitSuccess = false;
        }

        internal void Resize(int width, int height)
        {
            if (MVREngine.GetEngine().EngineInitSuccess)
            {
                if (width == 0 || height == 0)
                    return;
                MVREngine.GetEngine().SetViewport(this.viewPort);
                this.viewPort.Resize(width, height);
                this.Render(true, true);
            }
        }
        int renderFrame = 0;
        internal void Render(bool showGrid, bool showGizmo)
        {
            if (MVREngine.GetEngine().EngineInitSuccess)
            {
                Console.WriteLine("Scene Rendering Frame : " + (++renderFrame).ToString());
                this.scene.SetMainCamera(this.mainCamera);
                MVREngine.GetEngine().SetScene(this.scene);
                MVREngine.GetEngine().SetViewport(this.viewPort);
                MVREngine.GetEngine().Update();
                MVREngine.GetEngine().Render();
                if (showGrid)
                    MVREngine.GetEngine().GetCurScene().RenderGrid();
                if (showGizmo)
                    MVREngine.GetEngine().RenderGizmo();
                MVREngine.GetEngine().SwapBuffers();
            }
        }
        internal void MoveCameraToSelectedObject()
        {
            if (this.SelectedObject == null)
                return;
            MVRVector3 min = new MVRVector3();
            MVRVector3 max = new MVRVector3();
            this.SelectedObject.CalcBBox(true);
            this.SelectedObject.GetBoundBox(min, max, true);
            float posX = (max.X - min.X) * 0.5f + min.X;
            float posY = (max.Y - min.Y) * 0.5f + min.Y;
            float posZ = (max.Z - min.Z) * 0.5f + min.Z;
            this.mainCamera.Transform.Position = new MVRVector3(posX, posY, posZ);
            float distance = max.X - min.X;
            distance = Math.Max(distance, max.Y - min.Y);
            distance = Math.Max(distance, max.Z - min.Z);
            this.mainCamera.Transform.MoveForward(-distance * 2.0f);
            this.Render(true, true);
        }
        internal void HandleMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.startDrag = true;
            Point p = e.GetPosition(this);
            dragStartX = (float)p.X;
            dragStartY = (float)p.Y;
            if (e.ChangedButton == MouseButton.Left)
            {
                MVREngine.GetEngine().SetViewport(this.viewPort);
                this.scene.SetMainCamera(this.mainCamera);
                Console.WriteLine(string.Format("mouse down ({0},{1})",p.X, p.Y));
                this.scene.GizmoMouseDown((int)p.X, (int)p.Y);
                this.scene.Pick((int)p.X, (int)p.Y);
                this.Render(true, true);
            }
        }

        internal void HandleMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.startDrag = false;
            if (e.ChangedButton == MouseButton.Left)
                this.scene.GizmoMouseUp();
        }

        internal void HandleMouseMove(object sender, MouseEventArgs e)
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
                mainCamera.Transform.Rotate(new MVRVector3(deltaY * rotationAngle, -deltaX * rotationAngle, 0));
            }
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                mainCamera.Transform.Move(new MVRVector3(deltaX * moveDist, deltaY * moveDist, 0));
            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.scene.SetMainCamera(this.mainCamera);
                this.scene.GizmoMouseMove((int)p.X, (int)p.Y);
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("EngineRefresh");
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<GizmoChangeEvent>>().Publish(new GizmoChangeEvent());
            }
            this.Render(true, true);
        }
        internal void HandleMouseWheel(object sender, MouseWheelEventArgs e)
        {
            float rotationAngle = this.cameraRotationUnit * cameraSensitivity;
            float moveDist = this.cameraMoveUnit * 0.005f * cameraSensitivity;
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                rotationAngle = rotationAngle * this.cameraAccelation;
                moveDist = moveDist * this.cameraAccelation;
            }
            mainCamera.Transform.MoveForward(e.Delta * rotationAngle);
            this.Render(true, true);
        }
        internal void NavigateCamera(long timeInterval)
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
                renderFrame = true;
                mainCamera.Transform.MoveForward(moveDist);
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                renderFrame = true;
                mainCamera.Transform.MoveLeft(moveDist);
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                renderFrame = true;
                mainCamera.Transform.MoveLeft(-moveDist);
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                renderFrame = true;
                mainCamera.Transform.MoveForward(-moveDist);
            }
            if (renderFrame)
                this.Render(true, true);
        }
        internal void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                if (e.Key == Key.F)
                {
                    this.MoveCameraToSelectedObject();
                }
            }
        }
        internal void HandleKeyUp(object sender, KeyEventArgs e)
        {
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            try
            {
                if (msg == WM_PAINT)
                {
//                     Paint paint;
//                     BeginPaint(hwndHost, out paint);
//                     this.Render(true, true);
//                     EndPaint(hwndHost, ref paint);
                }
                else if (msg == WM_ERASEBKGND)
                {
                    Paint paint;
                    BeginPaint(hwndHost, out paint);
                    this.Render(true, true);
                    EndPaint(hwndHost, ref paint);

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
        static extern IntPtr BeginPaint (IntPtr handle, out Paint paint);

        [DllImport("user32.dll")]
        static extern bool EndPaint(IntPtr handle,[In] ref Paint paint);

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
