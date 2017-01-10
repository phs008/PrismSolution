using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.InspectorModule
{
    public static class EnumHelper
    {
        public static IEnumerable<string> GetAllValuesAndDescription<T> () where T : struct , IConvertible, IComparable, IFormattable
        {
            return from e in Enum.GetValues(typeof(T)).Cast<Enum>()
                   select e.ToString();
        }
    }
}
