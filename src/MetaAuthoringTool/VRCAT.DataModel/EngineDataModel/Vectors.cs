using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel
{
    public class Vector3 : BindableBase
    {
        float _x;
        public float X
        {
            get { return _x; }
            set { SetProperty(ref _x, value); }
        }
        float _y;

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        float _z;

        public float Z
        {
            get { return _z; }
            set { _z = value; }
        }
    }
    public class Vector2
    {
        float _x;
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        float _y;
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
    public class Vector4
    {
        float _x;
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        float _y;

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        float _z;

        public float Z
        {
            get { return _z; }
            set { _z = value; }
        }
        float _w;
        public float W
        {
            get { return _w; }
            set { _w = value; }
        }
    }
}
