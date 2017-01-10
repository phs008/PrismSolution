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



public class Quaternion
{

    public float x;
    public float y;
    public float z;
    public float w;

    static public Quaternion Identity() { return new Quaternion(0, 0, 0, 1); }

    public Quaternion()
    {
    }

		/*
    public Quaternion(float[] pf)
    {
        if (pf == null)
            return;

        x = pf[0];
        y = pf[1];
        z = pf[2];
        w = pf[3];
    }
		*/

    public Quaternion(float fx, float fy, float fz, float fw)
    {
        x = fx;
        y = fy;
        z = fz;
        w = fw;
    }

	/*
    public Quaternion(Vector4 v)
    {
        x = v.x;
        y = v.y;
        y = v.z;
        w = v.w;
    }
		*/

    public Quaternion(Quaternion v)
    {
        x = v.x;
        y = v.y;
        y = v.z;
        w = v.w;
    }

    public bool IsIdentity()
    {
        return ((x == 0.0f) && (y == 0.0f) && (z == 0.0f) && (w == 1.0f));
    }


    static public Quaternion operator +(Quaternion v)
    {
        return v;
    }

    static public Quaternion operator -(Quaternion v)
    {
        return new Quaternion(-v.x, -v.y, -v.z, -v.w);
    }

    static public Quaternion operator +(Quaternion v0, Quaternion v)
    {
        return new Quaternion(v0.x + v.x, v0.y + v.y, v0.z + v.z, v0.w + v.w);
    }

    static public Quaternion operator -(Quaternion v0, Quaternion v)
    {
        return new Quaternion(v0.x - v.x, v0.y - v.y, v0.z - v.z, v0.w - v.w);
    }

    static public Quaternion operator *(Quaternion v, float f)
    {
        return new Quaternion(v.x * f, v.y * f, v.z * f, v.w * f);
    }

    static public Quaternion operator /(Quaternion v, float f)
    {
        return new Quaternion(v.x / f, v.y / f, v.z / f, v.w / f);
    }

    static public Quaternion operator *(float f, Quaternion v)
    {
        return new Quaternion(f * v.x, f * v.y, f * v.z, f * v.w);
    }

    static public bool operator ==(Quaternion v, Quaternion v1)
    {
        return v1.x == v.x && v1.y == v.y && v1.z == v.z && v1.w == v.w;
    }

    static public bool operator !=(Quaternion v, Quaternion v1)
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
			return 0.0f; // (float)System.Math.Sqrt((x) * (x) + (y) * (y) + (z) * (z) + (w) * (w));
    }

    public float LengthSq()
    {
        return x * x + y * y + z * z + w * w;
    }

    static public Quaternion Cross(Quaternion pv1, Quaternion pv2, Quaternion pv3)
    {
        Quaternion result = new Quaternion();
        result.x = pv1.y * (pv2.z * pv3.w - pv3.z * pv2.w) - pv1.z * (pv2.y * pv3.w - pv3.y * pv2.w) + pv1.w * (pv2.y * pv3.z - pv2.z * pv3.y);
        result.y = -(pv1.x * (pv2.z * pv3.w - pv3.z * pv2.w) - pv1.z * (pv2.x * pv3.w - pv3.x * pv2.w) + pv1.w * (pv2.x * pv3.z - pv3.x * pv2.z));
        result.z = pv1.x * (pv2.y * pv3.w - pv3.y * pv2.w) - pv1.y * (pv2.x * pv3.w - pv3.x * pv2.w) + pv1.w * (pv2.x * pv3.y - pv3.x * pv2.y);
        result.w = -(pv1.x * (pv2.y * pv3.z - pv3.y * pv2.z) - pv1.y * (pv2.x * pv3.z - pv3.x * pv2.z) + pv1.z * (pv2.x * pv3.y - pv3.x * pv2.y));
        return result;
    }

    public float Dot(Quaternion pv2)
    {
        return x * pv2.x + y * pv2.y + z * pv2.z + w * pv2.w;
    }

    static public float Dot(Quaternion pv1, Quaternion pv2)
    {
        return pv1.x * pv2.x + pv1.y * pv2.y + pv1.z * pv2.z + pv1.w * pv2.w;
    }



    static public Quaternion Maximize(Quaternion pv1, Quaternion pv2)
    {
        Quaternion result = new Quaternion();
        return result;
    }

    static public Quaternion Minimize(Quaternion pv1, Quaternion pv2)
    {
        Quaternion result = new Quaternion();
        return result;
    }

    static public Quaternion Scale(Quaternion pv, float s)
    {
        Quaternion result = new Quaternion();
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

    static public Quaternion Subtract(Quaternion pv1, Quaternion pv2)
    {
        Quaternion result = new Quaternion();
        result.x = pv1.x - pv2.x;
        result.y = pv1.y - pv2.y;
        result.z = pv1.z - pv2.z;
        result.w = pv1.w - pv2.w;
        return result;
    }

    public void Subtract(Quaternion pv2)
    {
        x = x - pv2.x;
        y = y - pv2.y;
        z = z - pv2.z;
        w = w - pv2.w;
    }

    static public Quaternion Multiply(Quaternion pq1, Quaternion pq2)
    {
        Quaternion result = new Quaternion();
        result.x = pq2.w * pq1.x + pq2.x * pq1.w + pq2.y * pq1.z - pq2.z * pq1.y;
        result.y = pq2.w * pq1.y - pq2.x * pq1.z + pq2.y * pq1.w + pq2.z * pq1.x;
        result.z = pq2.w * pq1.z + pq2.x * pq1.y - pq2.y * pq1.x + pq2.z * pq1.w;
        result.w = pq2.w * pq1.w - pq2.x * pq1.x - pq2.y * pq1.y - pq2.z * pq1.z;
        return result;
    }

    static public Quaternion operator *(Quaternion pq1, Quaternion pq2)
    {
			Quaternion result = new Quaternion();
			return result;
		}

		public void Multiply(Quaternion pq2)
    {
        Quaternion result = new Quaternion();
        result.x = pq2.w * x + pq2.x * w + pq2.y * z - pq2.z * y;
        result.y = pq2.w * y - pq2.x * z + pq2.y * w + pq2.z * x;
        result.z = pq2.w * z + pq2.x * y - pq2.y * x + pq2.z * w;
        result.w = pq2.w * w - pq2.x * x - pq2.y * y - pq2.z * z;
        x = result.x;
        y = result.y;
        z = result.z;
        w = result.w;
    }


    static public Quaternion BaryCentric(Quaternion pq1, Quaternion pq2, Quaternion pq3, float f, float g)
    {
        return Slerp(Slerp(pq1, pq2, f + g), Slerp(pq1, pq3, f + g), g / (f + g));
    }



    Quaternion Exp()
    {
        Quaternion result = new Quaternion();
        return result;
    }





    Quaternion Inverse()
    {
        Quaternion result = new Quaternion();
        float norm;

        norm = LengthSq();
        if (norm == 0.0f)
        {
            result.x = 0.0f;
            result.y = 0.0f;
            result.z = 0.0f;
            result.w = 0.0f;
        }
        else
        {
            result.x = -x / norm;
            result.y = -y / norm;
            result.z = -z / norm;
            result.w = w / norm;
        }
        return result;
    }



    Quaternion Ln()
    {
        Quaternion result = new Quaternion();
        return result;
    }




	/*
    static public Quaternion RotationAxis(Vector3 pv, float angle)
    {
        Quaternion result = new Quaternion();
        return result;
    }


    static public Quaternion RotationMatrix(Matrix pm)
    {
        Quaternion result = new Quaternion();
        return result;
    }

	*/




    static public Quaternion RotationYawPitchRoll(float yaw, float pitch, float roll)
    {
        Quaternion result = new Quaternion();
        return result;
    }


    static public Quaternion Slerp(Quaternion pq1, Quaternion pq2, float t)
    {
        Quaternion result = new Quaternion();
        return result;
    }




    static public Quaternion Squad(Quaternion pq1, Quaternion pq2, Quaternion pq3, Quaternion pq4, float t)
    {
        Quaternion result = new Quaternion();

        result = Slerp(Slerp(pq1, pq4, t), Slerp(pq2, pq3, t), 2.0f * t * (1.0f - t));
        return result;
    }




	/*
    public void ToAxisAngle(ref Vector3 paxis, ref float pangle)
    {
    }

	*/
    public Quaternion Conjugate()
    {
        Quaternion result = new Quaternion();

        result.x = -x;
        result.y = -y;
        result.z = -z;
        result.w = w;
        return result;
    }





	/*
    static public Quaternion EulerToQuaternion(Vector3 euler)
    {
        Quaternion r = new Quaternion();
        return r;
    }


    Quaternion EulerToQuaternionFloat(Vector3 euler)
    {
        Quaternion r = new Quaternion();
        return r;
    }

	*/



	// other method /// not accurate
	/*
	Quaternion EulerToQuaternion2(Vector3 euler)
	{
			// heading y 
			// attitude z 
			// bank x

			double c1 = (float)System.Math.Cos( (double)euler.y); 
			double s1 = (float)System.Math.Sin( (double)euler.y); 
			double c2 = (float)System.Math.Cos( (double)euler.z); 
			double s2 = (float)System.Math.Sin( (double)euler.z);
			double c3 = (float)System.Math.Cos( (double)euler.x);
			double s3 = (float)System.Math.Sin( (double)euler.x);

			double w = (float)System.Math.Sqrt( 1.0 + c1 * c2 + c1 * c3 - s1 * s2 * s3 + c2 * c3) / 2.0;
			double w4 = (4.0 * w);

			Quaternion r = new Quaternion();
			r.x = (float)((c2 * s3 + c1 * s3 + s1 * s2 * c3) / w4);
			r.y = (float)((s1 * c2 + s1 * c3 + c1 * s2 * s3) / w4);
			r.z = (float)((-s1 * s3 + c1 * s2 * c3 + s2) / w4);
			r.w = 1.0f;
			r.Normalize();
			r.w = 1.0f;
			return r;
	}

	Quaternion EulerToQuaternionFloat2(Vector3 euler)
	{
			// heading y 
			// attitude z 
			// bank x

			float c1 = (float)System.Math.Cos(euler.y); 
			float s1 = (float)System.Math.Sin(euler.y); 
			float c2 = (float)System.Math.Cos(euler.z); 
			float s2 = (float)System.Math.Sin(euler.z);
			float c3 = (float)System.Math.Cos(euler.x);
			float s3 = (float)System.Math.Sin(euler.x);

			float w = (float)System.Math.Sqrt( 1.0f + c1 * c2 + c1 * c3 - s1 * s2 * s3 + c2 * c3) / 2.0f;
			float w4 = (float)(4.0 * w);

			Quaternion r = new Quaternion();
			r.x = (c2 * s3 + c1 * s3 + s1 * s2 * c3) / w4 ;
			r.y = (s1 * c2 + s1 * c3 + c1 * s2 * s3) / w4 ;
			r.z = (-s1 * s3 + c1 * s2 * c3 +s2) / w4 ;
			r.w = 1.0f;
			r.Normalize();
			return r;
	}
	*/
}





