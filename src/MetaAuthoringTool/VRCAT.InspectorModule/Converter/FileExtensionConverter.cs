using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using VRCAT.Infrastructure;

namespace VRCAT.InspectorModule
{
    public class FileExtensionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string FileFullPath = value as string;
                string extenstion = FileFullPath.Split(new char[] { '.' }).Last();
                extenstion = extenstion.ToLower();
                if (string.IsNullOrEmpty(FileFullPath))
                {
                    BitmapImage source = new BitmapImage();
                    source.BeginInit();
                    source.DecodePixelWidth = 50;
                    source.DecodePixelHeight = 50;
                    source.CacheOption = BitmapCacheOption.OnLoad;
                    source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/noimage.png");
                    source.EndInit();
                    return source;
                }
                //else if(extenstion.Equals("tga") || extenstion.Equals("hdr"))
                //{
                //    BitmapImage source = new BitmapImage();
                //    source.BeginInit();
                //    source.DecodePixelWidth = 50;
                //    source.DecodePixelHeight = 50;
                //    source.CacheOption = BitmapCacheOption.OnLoad;
                //    switch (extenstion)
                //    {
                //        case "tga":
                //            source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/icon_TGA.png");
                //            break;
                //        case "hdr":
                //            source.UriSource = new Uri("pack://siteOfOrigin:,,,/Plugins/Image/icon_HDR.png");
                //            break;
                //    }
                //    source.EndInit();
                //    return source;
                //}
                else
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
                //}
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
