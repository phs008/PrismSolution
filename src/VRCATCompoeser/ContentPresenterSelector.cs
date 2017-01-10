using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace VRCATCompoeser
{
    public class ContentPresenterSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item != null)
            {
                if ((bool)item == true)
                    return (container as FrameworkElement).FindResource("OpenProject") as DataTemplate;
                else
                    return (container as FrameworkElement).FindResource("NewProject") as DataTemplate;
            }
            else
                return null;
        }
    }
    public class BottomContentPresenterSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                if ((bool)item == true)
                    return (container as FrameworkElement).FindResource("OpenProjectBottomContent") as DataTemplate;
                else
                    return (container as FrameworkElement).FindResource("NewProjectBottomContent") as DataTemplate;
            }
            else
                return null;
        }
    }
    public class PlatformTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            try
            {
                FrameworkElement element = container as FrameworkElement;
                return element.FindResource(item) as DataTemplate;
            }
            catch { return null; }
        }
    }
    public class DisplayImageSelector : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string display = value.ToString();
            switch(display)
            {
                case "Desktop/Console":
                    display = "pack://siteoforigin:,,,/Resources/desktop.png";
                    break;
                case "Mobile":
                    display = "pack://siteoforigin:,,,/Resources/mobile.png";
                    break;
                case "HMD":
                    display = "pack://siteoforigin:,,,/Resources/hmd.png";
                    break;
                case "Monitor/Screen":
                    display = "pack://siteoforigin:,,,/Resources/monitor.png";
                    break;
                case "No Virtual Device":
                    display = "pack://siteoforigin:,,,/Resources/nodevice.png";
                    break;
                case "Virtual Device":
                    display = "pack://siteoforigin:,,,/Resources/vrdevice.png";
                    break;
                case "None":
                    display = "pack://siteoforigin:,,,/Resources/none.png";
                    break;
                case "High Quality Rendering":
                    display = "pack://siteoforigin:,,,/Resources/pbr.png";
                    break;
            }
            return display;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
