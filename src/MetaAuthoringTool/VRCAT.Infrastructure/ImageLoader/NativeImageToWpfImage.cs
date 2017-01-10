using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeImageAPI;
using FreeImageAPI.Metadata;
using FreeImageAPI.Plugins;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;
using System.Windows;

namespace VRCAT.Infrastructure
{
    public class NativeImageToWpfImage
    {
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);
        public static BitmapSource GetImageSource(string filePath)
        {
            FreeImageBitmap fib = new FreeImageBitmap(filePath);
            return ToBitmapSource((System.Drawing.Bitmap)fib);
        }
        static BitmapSource ToBitmapSource(System.Drawing.Bitmap image)
        {
            using (System.Drawing.Bitmap source = image)
            {
                IntPtr ptr = source.GetHbitmap(); //obtain the Hbitmap

                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    ptr,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                DeleteObject(ptr); //release the HBitmap
                return bs;
            }
        }
    }
}
