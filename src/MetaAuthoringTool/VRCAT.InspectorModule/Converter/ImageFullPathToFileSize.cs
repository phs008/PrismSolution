using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace VRCAT.InspectorModule
{
    public class ImageFullPathToFileSize : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string FullPath = (string)value;
            //FileInfo fInfo = new FileInfo(FullPath);
            //double bytesize = fInfo.Length;
            //bytesize /= 1024f;
            //bytesize = Math.Round(bytesize * 100) / 100;
            //string retunVal = bytesize.ToString() + "kb";
            //return retunVal;

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class ImageFullPathToPixelWidth : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //BitmapDecoder decoder = BitmapDecoder.Create(new Uri((string)value), BitmapCreateOptions.None, BitmapCacheOption.Default);
            //BitmapFrame frame = decoder.Frames[0];
            //int width = frame.PixelWidth;
            //return width;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class ImageFullPathToPixelHeight : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //BitmapDecoder decoder = BitmapDecoder.Create(new Uri((string)value), BitmapCreateOptions.None, BitmapCacheOption.Default);
            //BitmapFrame frame = decoder.Frames[0];
            //return frame.PixelHeight.ToString();
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
