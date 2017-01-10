using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using VRCAT.DataModel;
using VRCAT.Infrastructure;

namespace VRCAT.WrapperBridge
{
    public class CameraRenderingViewHost : HwndHost
    {
        private IntPtr hwndHost;
        private MRenderWindow _3DWindow;
        private int initWidth, initHeight;

        public MContainer _RenderingCamera;
        public CameraRenderingViewHost(int width, int height)
        {
            this.initWidth = Math.Max(1, width);
            this.initHeight = Math.Max(1, height);
        }
        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            hwndHost = CreateWindowEx(0, "static", "CameraRendering", WS_CHILD | WS_VISIBLE  , 0, 0,
                                            this.initWidth, this.initHeight,
                                            hwndParent.Handle,
                                            (IntPtr)HOST_ID,
                                            IntPtr.Zero,
                                            0);
            _3DWindow = new MRenderWindow(hwndHost.ToInt32());
            HwndSource source = HwndSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
            return new System.Runtime.InteropServices.HandleRef(this, this.hwndHost);
        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            DestroyWindow(hwnd.Handle);
        }
        public void Render()
        {
            if (_RenderingCamera != null)
            {
                _3DWindow.PreRender();
                _3DWindow.Render(_RenderingCamera);
                _3DWindow.PostRender();
            }
        }
        public void Resize(int width, int height)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString() + string.Format(" : RenderingViewHost::Resize({0},{1})", width, height));
            if (width == 0 || height == 0)
                return;
            _3DWindow.Resize(width, height);
            //_RenderingCamera.AspectRatio((float)width / (float)height);
            //_RenderingCamera.Cam.AspectRatio((float)width / (float)height);
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
                throw new Exception(e.Message);
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

