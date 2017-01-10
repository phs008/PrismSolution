using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VRCAT.InspectorModule
{
    /// <summary>
    /// Numeric Value 에 대한 ValidationRule 처리
    /// </summary>
    public class StringToFloatValidation : ValidationRule
    {
        /// <summary>
        /// Validation 처리
        /// </summary>
        /// <param name="value">Text Value</param>
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string)value))
                return new ValidationResult(false, "값을 입력해 주세요");
            if (((string)value).Last().Equals('.'))
                return new ValidationResult(false, "소수점 뒷자리를 정확히 입력하세요");
            else
            {
                Regex regex = new Regex("^[.][0-9]+$|^[-][0-9]+$|^[0-9]*[.]{0,1}[0-9]+$|^-[0-9]*[.]{0,1}[0-9]*$");
                bool IsValueValidated = regex.IsMatch(((string)value));
                if (IsValueValidated)
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "부동소수점에 맞게 입력하세요");
                }
            }
        }
    }
}
