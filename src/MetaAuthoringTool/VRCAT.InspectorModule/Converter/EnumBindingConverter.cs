using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static VRCAT.InspectorModule.VREnumVM;

namespace VRCAT.InspectorModule
{
    public class EnumBindingConverter : IValueConverter
    {
        List<string> returnLabel = new List<string>();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<VREnumData>)
            {
                if (returnLabel.Count == 0)
                {
                    foreach (VREnumData data in (List<VREnumData>)value)
                    {
                        returnLabel.Add(data.Label);
                    }
                }
                return returnLabel;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is VREnumData)
            {

            }
            return null;
        }
    }
}
