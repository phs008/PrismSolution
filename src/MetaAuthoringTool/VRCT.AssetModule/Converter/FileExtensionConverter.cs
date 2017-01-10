using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using VRCAT.DataModel;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows;
using VRCAT.Infrastructure;
using System.Diagnostics;

namespace VRCAT.AssetModule
{
    /// <summary>
    /// [변경 작업중. 삭제 예정]
    /// AssetFile 확장자에 따른 thumbnail image 생성 Converter
    /// </summary>
	public class FileExtensionConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
            try
            {
                string FileFullPath = value as string;
                string extenstion = FileFullPath.Split(new char[] { '.' }).Last();
                extenstion = extenstion.ToLower();
                if (extenstion.Equals("jpeg") || extenstion.Equals("jpg") || extenstion.Equals("png") || extenstion.Equals("bmp") || extenstion.Equals("tga") || extenstion.Equals("hdr"))
                {
                    //BitmapImage source = new BitmapImage();
                    //source.BeginInit();
                    //source.DecodePixelWidth = 50;
                    //source.DecodePixelHeight = 50;
                    //source.CacheOption = BitmapCacheOption.OnLoad;
                    //source.UriSource = new Uri(FileFullPath);
                    //source.EndInit();
                    //return source;

                    return NativeImageToWpfImage.GetImageSource(FileFullPath);
                }
                else if(extenstion.Equals("ffbx")|| extenstion.Equals("fmat") || extenstion.Equals("fani") || extenstion.Equals("fmesh") || extenstion.Equals("tga") || extenstion.Equals("hdr"))
                {
                    BitmapImage source = new BitmapImage();
                    source.BeginInit();
                    source.DecodePixelWidth = 50;
                    source.DecodePixelHeight = 50;
                    source.CacheOption = BitmapCacheOption.OnLoad;
                    switch (extenstion)
                    {
                        case "ffbx":
                            source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/FFBX.png");
                            break;
                        case "fmesh":
                            source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/FMESH.png");
                            break;
                        case "fmat":
                            source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/FMAT.png");
                            break;
                        case "fani":
                            source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/FANI.png");
                            break;
                        case "tga":
                            source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/icon_TGA.png");
                            break;
                        case "hdr":
                            source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/icon_HDR.png");
                            break;

                    }
                    source.EndInit();
                    return source;
                }
                else if(extenstion.Equals("mp3"))
                {
                    BitmapImage source = new BitmapImage();
                    source.BeginInit();
                    source.DecodePixelWidth = 50;
                    source.DecodePixelHeight = 50;
                    source.CacheOption = BitmapCacheOption.OnLoad;
                    source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/mp3.png");
                    source.EndInit();
                    return source;
                }
                else if(extenstion.Equals("fsf"))
                {
                    BitmapImage source = new BitmapImage();
                    source.BeginInit();
                    source.DecodePixelWidth = 50;
                    source.DecodePixelHeight = 50;
                    source.CacheOption = BitmapCacheOption.OnLoad;
                    source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/scene.png");
                    source.EndInit();
                    return source;
                }
                else
                {
                    if (File.Exists(FileFullPath))
                    {
                        using (Icon sysicon = Icon.ExtractAssociatedIcon(FileFullPath))
                        {
                            Interop.SHFILEINFO info = new Interop.SHFILEINFO(true);
                            int cbFileInfo = Marshal.SizeOf(info);
                            Interop.SHGFI flags;

                            flags = Interop.SHGFI.Icon | Interop.SHGFI.LargeIcon | Interop.SHGFI.UseFileAttributes;
                            //flags = Interop.SHGFI.Icon | Interop.SHGFI.SmallIcon | Interop.SHGFI.UseFileAttributes;

                            Interop.SHGetFileInfo(FileFullPath, 256, out info, (uint)cbFileInfo, flags);

                            IntPtr iconHandle = info.hIcon;
                            ImageSource img = Imaging.CreateBitmapSourceFromHIcon(
                                        iconHandle,
                                        Int32Rect.Empty,
                                        BitmapSizeOptions.FromEmptyOptions());
                            Interop.DestroyIcon(iconHandle);
                            return img;
                        }
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ////Loger.SetLog.Error(ex.Message);
                return null;
            }
        }

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value;
		}
	}
    public static class Interop
    {
        /// <summary>Maximal Length of unmanaged Windows-Path-strings</summary>
        private const int MAX_PATH = 260;
        /// <summary>Maximal Length of unmanaged Typename</summary>
        private const int MAX_TYPE = 80;


        [Flags]
        public enum SHGFI : int
        {
            /// <summary>get icon</summary>
            Icon = 0x000000100,
            /// <summary>get display name</summary>
            DisplayName = 0x000000200,
            /// <summary>get type name</summary>
            TypeName = 0x000000400,
            /// <summary>get attributes</summary>
            Attributes = 0x000000800,
            /// <summary>get icon location</summary>
            IconLocation = 0x000001000,
            /// <summary>return exe type</summary>
            ExeType = 0x000002000,
            /// <summary>get system icon index</summary>
            SysIconIndex = 0x000004000,
            /// <summary>put a link overlay on icon</summary>
            LinkOverlay = 0x000008000,
            /// <summary>show icon in selected state</summary>
            Selected = 0x000010000,
            /// <summary>get only specified attributes</summary>
            Attr_Specified = 0x000020000,
            /// <summary>get large icon</summary>
            LargeIcon = 0x000000000,
            /// <summary>get small icon</summary>
            SmallIcon = 0x000000001,
            /// <summary>get open icon</summary>
            OpenIcon = 0x000000002,
            /// <summary>get shell size icon</summary>
            ShellIconSize = 0x000000004,
            /// <summary>pszPath is a pidl</summary>
            PIDL = 0x000000008,
            /// <summary>use passed dwFileAttribute</summary>
            UseFileAttributes = 0x000000010,
            /// <summary>apply the appropriate overlays</summary>
            AddOverlays = 0x000000020,
            /// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
            OverlayIndex = 0x000000040,
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {
            public SHFILEINFO(bool b)
            {
                hIcon = IntPtr.Zero;
                iIcon = 0;
                dwAttributes = 0;
                szDisplayName = "";
                szTypeName = "";
            }
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_TYPE)]
            public string szTypeName;
        };

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern int SHGetFileInfo(
          string pszPath,
          int dwFileAttributes,
          out    SHFILEINFO psfi,
          uint cbfileInfo,
          SHGFI uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyIcon(IntPtr hIcon);
    }
}
