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




public class Vector3
{

    public float x;
    public float y;
    public float z;

    static public Vector3 Zero() { return new Vector3(0, 0, 0); }

    public Vector3()
    {
    }

    //public Vector3(float[] pf)
    //{
    //    if (pf == null)
    //        return;

    //    x = pf[0];
    //    y = pf[1];
    //    z = pf[2];
    //}

    public Vector3(float fx, float fy, float fz)
    {
        x = fx;
        y = fy;
        z = fz;
    }

		/*
    public Vector3(Vector2 v)
    {
        x = v.x;
        y = v.y;
        z = 0.0f;
    }
		*/

    public Vector3(Vector3 v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }
		

    //public Vector3(Color v)
    //{
    //    x = v.r;
    //    y = v.g;
    //    z = v.b;
    //}

		/*
    public Vector3(Vector4 v)
    {
        x = v.x;
        y = v.y;
        y = v.z;
    }
		*/





    static public Vector3 operator +(Vector3 v)
    {
        return v;
    }

    static public Vector3 operator -(Vector3 v)
    {
        return new Vector3(-v.x, -v.y, -v.z);
    }

    static public Vector3 operator +(Vector3 v0, Vector3 v)
    {
        return new Vector3(v0.x + v.x, v0.y + v.y, v0.z + v.z);
    }

    static public Vector3 operator -(Vector3 v0, Vector3 v)
    {
        return new Vector3(v0.x - v.x, v0.y - v.y, v0.z - v.z);
    }

    static public Vector3 operator *(Vector3 v, float f)
    {
        return new Vector3(v.x * f, v.y * f, v.z * f);
    }

    static public Vector3 operator /(Vector3 v, float f)
    {
        return new Vector3(v.x / f, v.y / f, v.z / f);
    }

    static public Vector3 operator *(float f, Vector3 v)
    {
        return new Vector3(f * v.x, f * v.y, f * v.z);
    }



    static public Vector3 operator *(Vector3 v, Vector3 v2)
    {
        return new Vector3(v.x * v2.x, v.y * v2.y, v.z * v2.z);
    }

    static public Vector3 operator /(Vector3 v, Vector3 v2)
    {
        return new Vector3(v.x / v2.x, v.y / v2.y, v.z / v2.z);
    }


    static public bool operator ==(Vector3 v, Vector3 v1)
    {
        return v1.x == v.x && v1.y == v.y && v1.z == v.z;
    }

    static public bool operator !=(Vector3 v, Vector3 v1)
    {
        return v1.x != v.x || v1.y != v.y || v1.z != v.z;
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
        }
        else
        {
            x = x / norm;
            y = y / norm;
            z = z / norm;
        }
    }

    public float Length()
    {
        //return (float)System.Math.Sqrt((x) * (x) + (y) * (y) + (z) * (z));
    }

    public float LengthSq()
    {
        return x * x + y * y + z * z;
    }

    static public Vector3 Cross(Vector3 pv1, Vector3 pv2)
    {
        Vector3 result = new Vector3();
        result.x = (pv1.y) * (pv2.z) - (pv1.z) * (pv2.y);
        result.y = (pv1.z) * (pv2.x) - (pv1.x) * (pv2.z);
        result.z = (pv1.x) * (pv2.y) - (pv1.y) * (pv2.x);
        return result;
    }

    public void Cross(Vector3 pv2)
    {
        Vector3 result = Cross(this, pv2);
        x = result.x;
        y = result.y;
        z = result.z;
    }


    public float Dot(Vector3 pv2)
    {
        return x * pv2.x + y * pv2.y + z * pv2.z;
    }

    static public float Dot(Vector3 pv1, Vector3 pv2)
    {
        return pv1.x * pv2.x + pv1.y * pv2.y + pv1.z * pv2.z;
    }


    static public Vector3 Lerp(Vector3 pv1, Vector3 pv2, float s)
    {
        Vector3 result = new Vector3();
        result.x = (1 - s) * (pv1.x) + s * (pv2.x);
        result.y = (1 - s) * (pv1.y) + s * (pv2.y);
        result.z = (1 - s) * (pv1.z) + s * (pv2.z);
        return result;
    }

    static public Vector3 Maximize(Vector3 pv1, Vector3 pv2)
    {
        Vector3 result = new Vector3();
        //result.x = System.Math.Max(pv1.x, pv2.x);
        //result.y = System.Math.Max(pv1.y, pv2.y);
        //result.z = System.Math.Max(pv1.z, pv2.z);
        return result;
    }

    static public Vector3 Minimize(Vector3 pv1, Vector3 pv2)
    {
        Vector3 result = new Vector3();
        //result.x = System.Math.Min(pv1.x, pv2.x);
        //result.y = System.Math.Min(pv1.y, pv2.y);
        //result.z = System.Math.Min(pv1.z, pv2.z);
        return result;
    }

    static public Vector3 Scale(Vector3 pv, float s)
    {
        Vector3 result = new Vector3();
        result.x = s * (pv.x);
        result.y = s * (pv.y);
        result.z = s * (pv.z);
        return result;
    }

    public void Scale(float s)
    {
        x = s * x;
        y = s * y;
        z = s * z;
    }

    static public Vector3 Subtract(Vector3 pv1, Vector3 pv2)
    {
        Vector3 result = new Vector3();
        result.x = pv1.x - pv2.x;
        result.y = pv1.y - pv2.y;
        result.z = pv1.z - pv2.z;
        return result;
    }

    public void Subtract(Vector3 pv2)
    {
        x = x - pv2.x;
        y = y - pv2.y;
        z = z - pv2.z;
    }

    static public Vector3 BaryCentric(Vector3 pv1, Vector3 pv2, Vector3 pv3, float f, float g)
    {
        Vector3 result = new Vector3();

        result.x = (1.0f - f - g) * (pv1.x) + f * (pv2.x) + g * (pv3.x);
        result.y = (1.0f - f - g) * (pv1.y) + f * (pv2.y) + g * (pv3.y);
        result.z = (1.0f - f - g) * (pv1.z) + f * (pv2.z) + g * (pv3.z);
        return result;
    }


    static public Vector3 CatmullRom(Vector3 pv0, Vector3 pv1, Vector3 pv2, Vector3 pv3, float s)
    {
        Vector3 result = new Vector3();
        result.x = 0.5f * (2.0f * pv1.x + (pv2.x - pv0.x) * s + (2.0f * pv0.x - 5.0f * pv1.x + 4.0f * pv2.x - pv3.x) * s * s + (pv3.x - 3.0f * pv2.x + 3.0f * pv1.x - pv0.x) * s * s * s);
        result.y = 0.5f * (2.0f * pv1.y + (pv2.y - pv0.y) * s + (2.0f * pv0.y - 5.0f * pv1.y + 4.0f * pv2.y - pv3.y) * s * s + (pv3.y - 3.0f * pv2.y + 3.0f * pv1.y - pv0.y) * s * s * s);
        result.z = 0.5f * (2.0f * pv1.z + (pv2.z - pv0.z) * s + (2.0f * pv0.z - 5.0f * pv1.z + 4.0f * pv2.z - pv3.z) * s * s + (pv3.z - 3.0f * pv2.z + 3.0f * pv1.z - pv0.z) * s * s * s);
        return result;
    }

		

    static public Vector3 Hermite(Vector3 pv1, Vector3 pt1, Vector3 pv2, Vector3 pt2, float s)
    {
        Vector3 result = new Vector3();
        float h1, h2, h3, h4;

        h1 = 2.0f * s * s * s - 3.0f * s * s + 1.0f;
        h2 = s * s * s - 2.0f * s * s + s;
        h3 = -2.0f * s * s * s + 3.0f * s * s;
        h4 = s * s * s - s * s;

        result.x = h1 * (pv1.x) + h2 * (pt1.x) + h3 * (pv2.x) + h4 * (pt2.x);
        result.y = h1 * (pv1.y) + h2 * (pt1.y) + h3 * (pv2.y) + h4 * (pt2.y);
        result.z = h1 * (pv1.z) + h2 * (pt1.z) + h3 * (pv2.z) + h4 * (pt2.z);
        return result;
    }


	/*

			static public Vector3 TransformCoord(Vector3 pv, Matrix pm)
        {
            Vector3 result = new Vector3();
            return result;

        }


        public void TransformCoord(Matrix pm)
        {
            Vector3 result = TransformCoord(this, pm);
            x = result.x;
            y = result.y;
            z = result.z;
        }


        static public Vector3 TransformNormal(Vector3 pv, Matrix pm)
        {
            Vector3 result = new Vector3();
            Vector3 v = pv;
            result.x = pm.m[0, 0] * v.x + pm.m[1, 0] * v.y + pm.m[2, 0] * v.z;
            result.y = pm.m[0, 1] * v.x + pm.m[1, 1] * v.y + pm.m[2, 1] * v.z;
            result.z = pm.m[0, 2] * v.x + pm.m[1, 2] * v.y + pm.m[2, 2] * v.z;
            return result;
        }


        public void TransformNormal(Matrix pm)
        {
            Vector3 result = TransformNormal(this, pm);
            x = result.x;
            y = result.y;
            z = result.z;
        }



        static public Vector4 Transform(Vector3 pv, Matrix pm)
        {
            Vector4 result = new Vector4();
            result.x = pm.m[0, 0] * pv.x + pm.m[1, 0] * pv.y + pm.m[2, 0] * pv.z + pm.m[3, 0];
            result.y = pm.m[0, 1] * pv.x + pm.m[1, 1] * pv.y + pm.m[2, 1] * pv.z + pm.m[3, 1];
            result.z = pm.m[0, 2] * pv.x + pm.m[1, 2] * pv.y + pm.m[2, 2] * pv.z + pm.m[3, 2];
            result.w = pm.m[0, 3] * pv.x + pm.m[1, 3] * pv.y + pm.m[2, 3] * pv.z + pm.m[3, 3];
            return result;
        }

	*/

        
	/*
        static public Vector3 Project(Vector3 pv, NXVIEWPORT8* pviewport, Matrix* pprojection, Matrix* pview, Matrix* pworld)
        {
        	Vector3 result = new Vector3();
        	Matrix m;
        	Vector3 result;

        	NXMatrixMultiply(&m, pworld, pview);
        	NXMatrixMultiply(&m, &m, pprojection);
        	TransformCoord(&result, pv, &m);
        	result.x = pviewport.X + (1.0f + result.x) * pviewport.Width / 2.0f;
        	result.y = pviewport.Y + (1.0f - result.y) * pviewport.Height / 2.0f;
        	result.z = pviewport.MinZ + result.z * (pviewport.MaxZ - pviewport.MinZ);
        	*result = result;
        	return result;
        }



        Vector3 Unproject(Vector3 result, Vector3 pv, NXVIEWPORT8* pviewport, Matrix* pprojection, Matrix* pview, Matrix* pworld)
        {
        	Matrix m;
        	Vector3 result;

        	NXMatrixMultiply(&m, pworld, pview);
        	NXMatrixMultiply(&m, &m, pprojection);
        	NXMatrixInverse(&m, NULL, &m);
        	result.x = 2.0f * (pv.x - pviewport.X) / pviewport.Width - 1.0f;
        	result.y = 1.0f - 2.0f * (pv.y - pviewport.Y) / pviewport.Height;
        	result.z = (pv.z - pviewport.MinZ) / (pviewport.MaxZ - pviewport.MinZ);
        	TransformCoord(&result, &result, &m);
        	*result = result;
        	return result;
        }
				*/


}





