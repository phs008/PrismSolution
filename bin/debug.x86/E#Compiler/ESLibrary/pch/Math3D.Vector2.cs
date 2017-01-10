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





	public class Vector2
	{

		public float x;
		public float y;

    static public Vector2 Zero() { return new Vector2(0, 0); }

    public Vector2()
    {
    }

    //public Vector2(float[] pf)
    //{
    //    if (pf == null)
    //        return;

    //    x = pf[0];
    //    y = pf[1];
    //}

    public Vector2(float fx, float fy)
    {
        x = fx;
        y = fy;
    }

    public Vector2(Vector2 v)
    {
        x = v.x;
        y = v.y;
    }

		/*
    public Vector2(Vector3 v)
    {
        x = v.x;
        y = v.y;
    }

    public Vector2(Vector4 v)
    {
        x = v.x;
        y = v.y;
    }

		*/




    static public Vector2 operator +(Vector2 v)
    {
        return v;
    }

    static public Vector2 operator -(Vector2 v)
    {
        return new Vector2(-v.x, -v.y);
    }

    static public Vector2 operator +(Vector2 v0, Vector2 v)
    {
        return new Vector2(v0.x + v.x, v0.y + v.y);
    }

    static public Vector2 operator -(Vector2 v0, Vector2 v)
    {
        return new Vector2(v0.x - v.x, v0.y - v.y);
    }

    static public Vector2 operator *(Vector2 v, float f)
    {
        return new Vector2(v.x * f, v.y * f);
    }

    static public Vector2 operator /(Vector2 v, float f)
    {
        return new Vector2(v.x / f, v.y / f);
    }

    static public Vector2 operator *(float f, Vector2 v)
    {
        return new Vector2(f * v.x, f * v.y);
    }


    static public Vector2 operator *(Vector2 v, Vector2 v2)
    {
        return new Vector2(v.x * v2.x, v.y * v2.y);
    }

    static public Vector2 operator /(Vector2 v, Vector2 v2)
    {
        return new Vector2(v.x / v2.x, v.y / v2.y);
    }


    static public bool operator ==(Vector2 v, Vector2 v1)
    {
        return v1.x == v.x && v1.y == v.y;
    }

    static public bool operator !=(Vector2 v, Vector2 v1)
    {
        return v1.x != v.x || v1.y != v.y;
    }

    public void Normalize()
    {
        float norm;

        norm = Length();
        if (norm == 0.0f)
        {
            x = 0.0f;
            y = 0.0f;
        }
        else
        {
            x = x / norm;
            y = y / norm;
        }
    }

    public float Length()
    {
        //return (float)System.Math.Sqrt((x) * (x) + (y) * (y));
    }

    public float LengthSq()
    {
        return x * x + y * y;
    }

    public float CCW(Vector2 pv2)
    {
        return x * pv2.y - y * pv2.x;
    }

    public float Dot(Vector2 pv2)
    {
        return x * pv2.x + y * pv2.y;
    }

    static public float Dot(Vector2 pv1, Vector2 pv2)
    {
        return pv1.x * pv2.x + pv1.y * pv2.y;
    }


    static public Vector2 Lerp(Vector2 pv1, Vector2 pv2, float s)
    {
        Vector2 result = new Vector2();
        result.x = (1 - s) * (pv1.x) + s * (pv2.x);
        result.y = (1 - s) * (pv1.y) + s * (pv2.y);
        return result;
    }

    static public Vector2 Maximize(Vector2 pv1, Vector2 pv2)
    {
        Vector2 result = new Vector2();
        //result.x = System.Math.Max(pv1.x, pv2.x);
        //result.y = System.Math.Max(pv1.y, pv2.y);
        return result;
    }

    static public Vector2 Minimize(Vector2 pv1, Vector2 pv2)
    {
        Vector2 result = new Vector2();
        //result.x = System.Math.Min(pv1.x, pv2.x);
        //result.y = System.Math.Min(pv1.y, pv2.y);
        return result;
    }

    static public Vector2 Scale(Vector2 pv, float s)
    {
        Vector2 result = new Vector2();
        result.x = s * (pv.x);
        result.y = s * (pv.y);
        return result;
    }

    public void Scale(float s)
    {
        x = s * x;
        y = s * y;
    }

    static public Vector2 Subtract(Vector2 pv1, Vector2 pv2)
    {
        Vector2 result = new Vector2();
        result.x = pv1.x - pv2.x;
        result.y = pv1.y - pv2.y;
        return result;
    }

    public void Subtract(Vector2 pv2)
    {
        x = x - pv2.x;
        y = y - pv2.y;
    }

    static public Vector2 BaryCentric(Vector2 pv1, Vector2 pv2, Vector2 pv3, float f, float g)
    {
        Vector2 result = new Vector2();

        result.x = (1.0f - f - g) * (pv1.x) + f * (pv2.x) + g * (pv3.x);
        result.y = (1.0f - f - g) * (pv1.y) + f * (pv2.y) + g * (pv3.y);
        return result;
    }


    static public Vector2 CatmullRom(Vector2 pv0, Vector2 pv1, Vector2 pv2, Vector2 pv3, float s)
    {
        Vector2 result = new Vector2();
        result.x = 0.5f * (2.0f * pv1.x + (pv2.x - pv0.x) * s + (2.0f * pv0.x - 5.0f * pv1.x + 4.0f * pv2.x - pv3.x) * s * s + (pv3.x - 3.0f * pv2.x + 3.0f * pv1.x - pv0.x) * s * s * s);
        result.y = 0.5f * (2.0f * pv1.y + (pv2.y - pv0.y) * s + (2.0f * pv0.y - 5.0f * pv1.y + 4.0f * pv2.y - pv3.y) * s * s + (pv3.y - 3.0f * pv2.y + 3.0f * pv1.y - pv0.y) * s * s * s);
        return result;
    }


    static public Vector2 Hermite(Vector2 pv1, Vector2 pt1, Vector2 pv2, Vector2 pt2, float s)
    {
        Vector2 result = new Vector2();
        float h1, h2, h3, h4;

        h1 = 2.0f * s * s * s - 3.0f * s * s + 1.0f;
        h2 = s * s * s - 2.0f * s * s + s;
        h3 = -2.0f * s * s * s + 3.0f * s * s;
        h4 = s * s * s - s * s;

        result.x = h1 * (pv1.x) + h2 * (pt1.x) + h3 * (pv2.x) + h4 * (pt2.x);
        result.y = h1 * (pv1.y) + h2 * (pt1.y) + h3 * (pv2.y) + h4 * (pt2.y);
        return result;
    }


    //static public Vector2 TransformCoord(Vector2 pv, Matrix3 pm)
    //    {
    //        Vector2 result = new Vector2();
    //        float norm;

    //        norm = pm.m[0, 2] * pv.x + pm.m[1, 2] * pv.y + pm.m[2, 2];
    //        if (norm != 0.0f)
    //        {
    //            Vector2 v = pv;
    //            result.x = (pm.m[0, 0] * v.x + pm.m[1, 0] * v.y + pm.m[2, 0]) / norm;
    //            result.y = (pm.m[0, 1] * v.x + pm.m[1, 1] * v.y + pm.m[2, 1]) / norm;
    //        }
    //        else
    //        {
    //            result.x = 0.0f;
    //            result.y = 0.0f;
    //        }
    //        return result;
    //    }


    //    public void TransformCoord(Matrix3 pm)
    //    {
    //        Vector2 result = TransformCoord(this, pm);
    //        x = result.x;
    //        y = result.y;
    //    }



    //static public Vector2 TransformNormal(Vector2 pv, Matrix3 pm)
    //{
    //    Vector2 result = new Vector2();
    //    result.x = pm.m[0, 0] * pv.x + pm.m[1, 0] * pv.y;
    //    result.y = pm.m[0, 1] * pv.x + pm.m[1, 1] * pv.y;
    //    return result;
    //}

    //public void TransformNormal(Matrix3 pm)
    //{
    //    Vector2 result = TransformNormal(this, pm);
    //    x = result.x;
    //    y = result.y;
    //}
}





