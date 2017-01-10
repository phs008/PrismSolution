using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace VRCAT.InspectorModule
{
    //public class EnumBindingSourceExtension : MarkupExtension
    //{
    //    private Type _enumType;
    //    public Type EnumType
    //    {
    //        get { return this._enumType; }
    //        set
    //        {
    //            if (value != this._enumType)
    //            {
    //                if (null != value)
    //                {
    //                    Type enumType = Nullable.GetUnderlyingType(value) ?? value;
    //                    if (!enumType.IsEnum)
    //                        throw new ArgumentException("Type must be for an Enum.");
    //                }

    //                this._enumType = value;
    //            }
    //        }
    //    }

    //    public EnumBindingSourceExtension() { }

    //    public EnumBindingSourceExtension(Type enumType)
    //    {
    //        this.EnumType = enumType;
    //    }

    //    public override object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        if (null == this._enumType)
    //            throw new InvalidOperationException("The EnumType must be specified.");

    //        Type actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
    //        Array enumValues = Enum.GetValues(actualEnumType);

    //        if (actualEnumType == this._enumType)
    //            return enumValues;

    //        Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
    //        enumValues.CopyTo(tempArray, 1);
    //        return tempArray;
    //    }
    //}
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;
        public Type EnumType
        {
            get { return this._enumType; }
            set
            {
                if (value != this._enumType)
                {
                    if (null != value)
                    {
                        Type enumType = Nullable.GetUnderlyingType(value) ?? value;
                        if (!enumType.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    this._enumType = value;
                }
            }
        }
        private List<object[]> _enumData;

        public List<object[]> EnumData
        {
            get { return _enumData; }

            set
            {
                if(value != this._enumData)
                {
                    if(null != value)
                    {
                        this._enumData = value;
                    }
                }
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //if (null == this._enumData)
            //    throw new Exception("");
            //Array tempArray = Array.CreateInstance(typeof(string), _enumData.Count + 1);
            //for (int i =0; i<_enumData.Count; i++)
            //{
            //    object[] data = _enumData[0];
            //    tempArray.SetValue((string)data[0], i);
            //}
            //return tempArray;
            return null;
        }
    }
}
