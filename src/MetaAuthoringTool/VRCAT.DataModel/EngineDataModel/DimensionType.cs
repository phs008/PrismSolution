using Microsoft.Practices.Prism.Mvvm;
using System.ComponentModel;
using System.Reflection;
using VRCAT.Infrastructure.MonitoredUndo;

namespace VRCAT.DataModel
{
    public class DimensionType : BindableBase, ISupportsUndo
    {
        
        float _X;
        public float X
        {
            get { return _X; }
            set { _X = value; }
        }
        float _Y;
        public float Y
        {
            get { return _Y; }
            set { _Y = value; }
        }
        float _Z;
        public float Z
        {
            get { return _Z; }
            set { _Z = value; }
        }

        float _W;
        [RefreshProperties(System.ComponentModel.RefreshProperties.All)]
        [Browsable(false)]
        public float W
        {
            get { return _W; }
            set
            {
                SetProperty(ref _W, value);
            }
        }
        // TODO Attribute 중 Browsable.false 를 삭제하고 Browsable.Ture 를 추가 하고 테스트
        public DimensionType(bool IsUseW)
        {
            if(IsUseW)
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["W"];
                BrowsableAttribute attribute = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
                FieldInfo fieldToChange = attribute.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);
                fieldToChange.SetValue(attribute, true);
            }
            else
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["W"];
                BrowsableAttribute attribute = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
                FieldInfo fieldToChange = attribute.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);
                fieldToChange.SetValue(attribute, false);
            }
        }

        public object GetUndoRoot()
        {
            return this;
        }
    }
}
