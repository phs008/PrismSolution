using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;





//------------------------------------------------------------
// Copyright. 2004-2015 Code3 Corp.  http://www.code3.co.kr
// 
// Author : Heechan Park
// Summary : 
// 
//------------------------------------------------------------ 






public class Vector4
{

    public float x;
    public float y;
    public float z;
    public float w;

    static public Vector4 Zero() { return new Vector4(0, 0, 0, 0); }

    public Vector4()
    {
    }

    //public Vector4(float[] pf)
    //{
    //    if (pf == null)
    //        return;

    //    x = pf[0];
    //    y = pf[1];
    //    z = pf[2];
    //    w = pf[3];
    //}

    public Vector4(float fx, float fy, float fz, float fw)
    {
        x = fx;
        y = fy;
        z = fz;
        w = fw;
    }

    public Vector4(Vector4 v)
    {
        x = v.x;
        y = v.y;
        z = 0.0f;
        w = 0.0f;
    }

	/*
    public Vector4(Vector3 v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
        z = 0.0f;
    }
		*/
    //public Vector4(Color v)
    //{
    //    x = v.r;
    //    y = v.g;
    //    y = v.b;
    //    w = v.a;
    //}

    //public Vector4(Quaternion v)
    //{
    //    x = v.x;
    //    y = v.y;
    //    y = v.z;
    //    w = v.w;
    //}

    static public Vector4 operator +(Vector4 v)
    {
        return v;
    }

    static public Vector4 operator -(Vector4 v)
    {
        return new Vector4(-v.x, -v.y, -v.z, -v.w);
    }

    static public Vector4 operator +(Vector4 v0, Vector4 v)
    {
        return new Vector4(v0.x + v.x, v0.y + v.y, v0.z + v.z, v0.w + v.w);
    }

    static public Vector4 operator -(Vector4 v0, Vector4 v)
    {
        return new Vector4(v0.x - v.x, v0.y - v.y, v0.z - v.z, v0.w - v.w);
    }

    static public Vector4 operator *(Vector4 v, float f)
    {
        return new Vector4(v.x * f, v.y * f, v.z * f, v.w * f);
    }

    static public Vector4 operator /(Vector4 v, float f)
    {
        return new Vector4(v.x / f, v.y / f, v.z / f, v.w / f);
    }

    static public Vector4 operator *(float f, Vector4 v)
    {
        return new Vector4(f * v.x, f * v.y, f * v.z, f * v.w);
    }


    static public Vector4 operator *(Vector4 v, Vector4 v2)
    {
        return new Vector4(v.x * v2.x, v.y * v2.y, v.z * v2.z, v.w * v2.w);
    }

    static public Vector4 operator /(Vector4 v, Vector4 v2)
    {
        return new Vector4(v.x / v2.x, v.y / v2.y, v.z / v2.z, v.w / v2.w);
    }


    static public bool operator ==(Vector4 v, Vector4 v1)
    {
        return v1.x == v.x && v1.y == v.y && v1.z == v.z && v1.w == v.w;
    }

    static public bool operator !=(Vector4 v, Vector4 v1)
    {
        return v1.x != v.x || v1.y != v.y || v1.z != v.z || v1.w != v.w;
    }

    public void Normalize()
    {
        float norm;
        norm = Length();
        if (norm == 0.0f)
        {
            x = 0.0f;
            y = 0.0f;
            z = 0.0f;
            w = 0.0f;
        }
        else
        {
            x = x / norm;
            y = y / norm;
            z = z / norm;
            w = w / norm;
        }
    }

    public float Length()
    {
			return 0.0f;
    }

    public float LengthSq()
    {
        return x * x + y * y + z * z + w * w;
    }

    static public Vector4 Cross(Vector4 pv1, Vector4 pv2, Vector4 pv3)
    {
        Vector4 result = new Vector4();
        result.x = pv1.y * (pv2.z * pv3.w - pv3.z * pv2.w) - pv1.z * (pv2.y * pv3.w - pv3.y * pv2.w) + pv1.w * (pv2.y * pv3.z - pv2.z * pv3.y);
        result.y = -(pv1.x * (pv2.z * pv3.w - pv3.z * pv2.w) - pv1.z * (pv2.x * pv3.w - pv3.x * pv2.w) + pv1.w * (pv2.x * pv3.z - pv3.x * pv2.z));
        result.z = pv1.x * (pv2.y * pv3.w - pv3.y * pv2.w) - pv1.y * (pv2.x * pv3.w - pv3.x * pv2.w) + pv1.w * (pv2.x * pv3.y - pv3.x * pv2.y);
        result.w = -(pv1.x * (pv2.y * pv3.z - pv3.y * pv2.z) - pv1.y * (pv2.x * pv3.z - pv3.x * pv2.z) + pv1.z * (pv2.x * pv3.y - pv3.x * pv2.y));
        return result;
    }

    public float Dot(Vector4 pv2)
    {
        return x * pv2.x + y * pv2.y + z * pv2.z + w * pv2.w;
    }


    static public float Dot(Vector4 pv1, Vector4 pv2)
    {
        return pv1.x * pv2.x + pv1.y * pv2.y + pv1.z * pv2.z + pv1.w * pv2.w;
    }


    static public Vector4 Lerp(Vector4 pv1, Vector4 pv2, float s)
    {
        Vector4 result = new Vector4();
        result.x = (1 - s) * (pv1.x) + s * (pv2.x);
        result.y = (1 - s) * (pv1.y) + s * (pv2.y);
        result.z = (1 - s) * (pv1.z) + s * (pv2.z);
        result.w = (1 - s) * (pv1.w) + s * (pv2.w);
        return result;
    }

    static public Vector4 Maximize(Vector4 pv1, Vector4 pv2)
    {
        Vector4 result = new Vector4();
        return result;
    }

    static public Vector4 Minimize(Vector4 pv1, Vector4 pv2)
    {
        Vector4 result = new Vector4();
        return result;
    }

    static public Vector4 Scale(Vector4 pv, float s)
    {
        Vector4 result = new Vector4();
        result.x = s * (pv.x);
        result.y = s * (pv.y);
        result.z = s * (pv.z);
        result.w = s * (pv.w);
        return result;
    }

    public void Scale(float s)
    {
        x = s * x;
        y = s * y;
        z = s * z;
        w = s * w;
    }

    static public Vector4 Subtract(Vector4 pv1, Vector4 pv2)
    {
        Vector4 result = new Vector4();
        result.x = pv1.x - pv2.x;
        result.y = pv1.y - pv2.y;
        result.z = pv1.z - pv2.z;
        result.w = pv1.w - pv2.w;
        return result;
    }

    public void Subtract(Vector4 pv2)
    {
        x = x - pv2.x;
        y = y - pv2.y;
        z = z - pv2.z;
        w = w - pv2.w;
    }

    static public Vector4 BaryCentric(Vector4 pv1, Vector4 pv2, Vector4 pv3, float f, float g)
    {
        Vector4 result = new Vector4();

        result.x = (1.0f - f - g) * (pv1.x) + f * (pv2.x) + g * (pv3.x);
        result.y = (1.0f - f - g) * (pv1.y) + f * (pv2.y) + g * (pv3.y);
        result.z = (1.0f - f - g) * (pv1.z) + f * (pv2.z) + g * (pv3.z);
        result.w = (1.0f - f - g) * (pv1.w) + f * (pv2.w) + g * (pv3.w);
        return result;
    }


    static public Vector4 CatmullRom(Vector4 pv0, Vector4 pv1, Vector4 pv2, Vector4 pv3, float s)
    {
        Vector4 result = new Vector4();
        result.x = 0.5f * (2.0f * pv1.x + (pv2.x - pv0.x) * s + (2.0f * pv0.x - 5.0f * pv1.x + 4.0f * pv2.x - pv3.x) * s * s + (pv3.x - 3.0f * pv2.x + 3.0f * pv1.x - pv0.x) * s * s * s);
        result.y = 0.5f * (2.0f * pv1.y + (pv2.y - pv0.y) * s + (2.0f * pv0.y - 5.0f * pv1.y + 4.0f * pv2.y - pv3.y) * s * s + (pv3.y - 3.0f * pv2.y + 3.0f * pv1.y - pv0.y) * s * s * s);
        result.z = 0.5f * (2.0f * pv1.z + (pv2.z - pv0.z) * s + (2.0f * pv0.z - 5.0f * pv1.z + 4.0f * pv2.z - pv3.z) * s * s + (pv3.z - 3.0f * pv2.z + 3.0f * pv1.z - pv0.z) * s * s * s);
        result.w = 0.5f * (2.0f * pv1.w + (pv2.w - pv0.w) * s + (2.0f * pv0.w - 5.0f * pv1.w + 4.0f * pv2.w - pv3.w) * s * s + (pv3.w - 3.0f * pv2.w + 3.0f * pv1.w - pv0.w) * s * s * s);
        return result;
    }


    static public Vector4 Hermite(Vector4 pv1, Vector4 pt1, Vector4 pv2, Vector4 pt2, float s)
    {
        Vector4 result = new Vector4();
        float h1, h2, h3, h4;

        h1 = 2.0f * s * s * s - 3.0f * s * s + 1.0f;
        h2 = s * s * s - 2.0f * s * s + s;
        h3 = -2.0f * s * s * s + 3.0f * s * s;
        h4 = s * s * s - s * s;

        result.x = h1 * (pv1.x) + h2 * (pt1.x) + h3 * (pv2.x) + h4 * (pt2.x);
        result.y = h1 * (pv1.y) + h2 * (pt1.y) + h3 * (pv2.y) + h4 * (pt2.y);
        result.z = h1 * (pv1.z) + h2 * (pt1.z) + h3 * (pv2.z) + h4 * (pt2.z);
        result.w = h1 * (pv1.w) + h2 * (pt1.w) + h3 * (pv2.w) + h4 * (pt2.w);
        return result;
    }



    //static public Vector4 TransformCoord(Vector4 pv, Matrix pm)
    //{
    //    Vector4 result = new Vector4();
    //    float norm;

    //    norm = pm.m[0, 3] * pv.x + pm.m[1, 3] * pv.y + pm.m[2, 3] * pv.z + pm.m[3, 3];

    //    if (norm != 0.0f)
    //    {
    //        result.x = (pm.m[0, 0] * pv.x + pm.m[1, 0] * pv.y + pm.m[2, 0] * pv.z + pm.m[3, 0]) / norm;
    //        result.y = (pm.m[0, 1] * pv.x + pm.m[1, 1] * pv.y + pm.m[2, 1] * pv.z + pm.m[3, 1]) / norm;
    //        result.z = (pm.m[0, 2] * pv.x + pm.m[1, 2] * pv.y + pm.m[2, 2] * pv.z + pm.m[3, 2]) / norm;
    //    }
    //    else
    //    {
    //        result.x = 0.0f;
    //        result.y = 0.0f;
    //        result.z = 0.0f;
    //    }
    //    return result;

    //}


    //public void TransformCoord(Matrix pm)
    //{
    //    Vector4 result = TransformCoord(this, pm);
    //    x = result.x;
    //    y = result.y;
    //    z = result.z;
    //}


    //static public Vector4 TransformNormal(Vector4 pv, Matrix pm)
    //{
    //    Vector4 result = new Vector4();
    //    result.x = pm.m[0, 0] * pv.x + pm.m[1, 0] * pv.y + pm.m[2, 0] * pv.z;
    //    result.y = pm.m[0, 1] * pv.x + pm.m[1, 1] * pv.y + pm.m[2, 1] * pv.z;
    //    result.z = pm.m[0, 2] * pv.x + pm.m[1, 2] * pv.y + pm.m[2, 2] * pv.z;
    //    return result;
    //}


    //public void TransformNormal(Matrix pm)
    //{
    //    Vector4 result = TransformNormal(this, pm);
    //    x = result.x;
    //    y = result.y;
    //    z = result.z;
    //}



    //static public Vector4 Transform(Vector4 pv, Matrix pm)
    //{
    //    Vector4 result = new Vector4();
    //    result.x = pm.m[0, 0] * pv.x + pm.m[1, 0] * pv.y + pm.m[2, 0] * pv.z + pm.m[3, 0] * pv.w;
    //    result.y = pm.m[0, 1] * pv.x + pm.m[1, 1] * pv.y + pm.m[2, 1] * pv.z + pm.m[3, 1] * pv.w;
    //    result.z = pm.m[0, 2] * pv.x + pm.m[1, 2] * pv.y + pm.m[2, 2] * pv.z + pm.m[3, 2] * pv.w;
    //    result.w = pm.m[0, 3] * pv.x + pm.m[1, 3] * pv.y + pm.m[2, 3] * pv.z + pm.m[3, 3] * pv.w;
    //    return result;
    //}
}





