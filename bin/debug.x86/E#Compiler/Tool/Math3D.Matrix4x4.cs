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



public class Matrix
{

    //public float[,] m = new float[4,4];

    //static public Matrix Identity() { return new Matrix(1,0,0,0, 0,1,0,0, 0,0,1,0, 0,0,0,1 ); }


    //public Matrix()
    //{
    //}

    //public Matrix(float [] pf)
    //{
    //	if (pf == null)
    //		return;
    //	m[0,0] = pf[0];
    //	m[0,1] = pf[1];
    //	m[0,2] = pf[2];
    //	m[0,3] = pf[3];

    //	m[1,0] = pf[4];
    //	m[1,1] = pf[5];
    //	m[1,2] = pf[6];
    //	m[1,3] = pf[7];

    //	m[2,0] = pf[8];
    //	m[2,1] = pf[9];
    //	m[2,2] = pf[10];
    //	m[2,3] = pf[11];

    //	m[3,0] = pf[12];
    //	m[3,1] = pf[13];
    //	m[3,2] = pf[14];
    //	m[3,3] = pf[15];
    //}


    //public Matrix(Matrix pf)
    //{
    //	if (pf == null)
    //		return;
    //	Array.Copy(pf.m, m, 16);
    //}

    //public Matrix(float f11, float f12, float f13, float f14, 
    //                float f21, float f22, float f23, float f24,
    //                float f31, float f32, float f33, float f34,
    //                float f41, float f42, float f43, float f44)
    //{
    //	m[0, 0] = f11; m[0, 1] = f12; m[0, 2] = f13; m[0, 3] = f14;
    //	m[1, 0] = f21; m[1, 1] = f22; m[1, 2] = f23; m[1, 3] = f24;
    //	m[2, 0] = f31; m[2, 1] = f32; m[2, 2] = f33; m[2, 3] = f34;
    //	m[3, 0] = f41; m[3, 1] = f42; m[3, 2] = f43; m[3, 3] = f44;
    //}

    //public bool IsIdentity()
    //{
    //	return Array.Equals(m, Identity().m);
    //}

    //public float this[uint row, uint col]
    //{
    //	get { return m[row, col]; }
    //	set { m[row,col] = value; }
    //}


    //static public Matrix operator + (Matrix m)
    //{
    //	return m;
    //}

    //static public Matrix operator - (Matrix m)
    //{
    //	return new Matrix(-m[0,0], -m[0,1], -m[0,2], -m[0,3],
    //                    -m[1,0], -m[1,1], -m[1,2], -m[1,3],
    //                    -m[2,0], -m[2,1], -m[2,2], -m[2,3],
    //                    -m[3,1], -m[3,1], -m[3,2], -m[3,3]);
    //}


    //static public Matrix operator * (Matrix m1, Matrix mat)
    //{
    //	return m1.Multiply(mat);
    //}

    //static public Matrix operator * (Matrix m1, float f)
    //{
    //	return m1.Multiply(f);
    //}

    //static public Matrix operator * (float f, Matrix m1)
    //{
    //	return m1.Multiply(f);
    //}

    //static public Matrix operator / (Matrix m1, float f)
    //{
    //	return m1.Divide(f);
    //}
    //static public Matrix operator + (Matrix m1, Matrix mat)
    //{
    //	return m1.Add(mat);
    //}

    //static public Matrix operator - (Matrix m1, Matrix mat)
    //{
    //	return m1.Subtract(mat);
    //}



    //static public bool operator == (Matrix m1, Matrix m2)
    //{
    //	if (m1.m[0,0] == m2.m[0,0] && m1.m[0,1] == m2.m[0,1] && m1.m[0,2] == m2.m[0,2] && m1.m[0,3] == m2.m[0,3] &&
    //												m1.m[1,0] == m2.m[1,0] && m1.m[1,1] == m2.m[1,1] && m1.m[1,2] == m2.m[1,2] && m1.m[1,3] == m2.m[1,3] &&
    //												m1.m[2,0] == m2.m[2,0] && m1.m[2,1] == m2.m[2,1] && m1.m[2,2] == m2.m[2,2] && m1.m[2,3] == m2.m[2,3] &&
    //												m1.m[3,0] == m2.m[3,1] && m1.m[3,1] == m2.m[3,1] && m1.m[3,2] == m2.m[3,2] && m1.m[3,3] == m2.m[3,3])
    //		return true;
    //	else
    //		return false;
    //}

    //static public bool operator !=(Matrix m1, Matrix m2)
    //{
    //	if (m1.m[0,0] != m2.m[0,0] ||	 m1.m[0,1] != m2.m[0,1] || m1.m[0,2] != m2.m[0,2] || m1.m[0,3] != m2.m[0,3] ||
    //												m1.m[1,0] != m2.m[1,0] || m1.m[1,1] != m2.m[1,1] || m1.m[1,2] != m2.m[1,2] || m1.m[1,3] != m2.m[1,3] ||
    //												m1.m[2,0] != m2.m[2,0] || m1.m[2,1] != m2.m[2,1] || m1.m[2,2] != m2.m[2,2] || m1.m[2,3] != m2.m[2,3] ||
    //												m1.m[3,0] != m2.m[3,1] || m1.m[3,1] != m2.m[3,1] || m1.m[3,2] != m2.m[3,2] || m1.m[3,3] != m2.m[3,3])
    //		return true;
    //	else
    //		return false;
    //}




    //public Matrix Multiply(Matrix pm2)
    //{
    //	Matrix result = new Matrix();
    //	int i,j;

    //	for (i=0; i<4; i++)
    //	{
    //		for (j=0; j<4; j++)
    //		{	
    //			result.m[i,j] = m[i,0] * pm2.m[0,j] + m[i,1] * pm2.m[1,j] + m[i,2] * pm2.m[2,j] + m[i,3] * pm2.m[3,j];
    //		}
    //	}
    //	return result;
    //}

    //public Matrix Multiply(float f)
    //{
    //	Matrix result = new Matrix(this);
    //	result[0,0] *= f; result[0,1] *= f; result[0,2] *= f; result[0,3] *= f;
    //	result[1,0] *= f; result[1,1] *= f; result[1,2] *= f; result[1,3] *= f;
    //	result[2,0] *= f; result[2,1] *= f; result[2,2] *= f; result[2,3] *= f;
    //	result[3,1] *= f; result[3,1] *= f; result[3,2] *= f; result[3,3] *= f;
    //	return result;
    //}


    //public Matrix Divide(float f0)
    //{
    //	Matrix result = new Matrix(this);
    //   float f = 1.0f / f0;

    //	result[0,0] *= f; result[0,1] *= f; result[0,2] *= f; result[0,3] *= f;
    //	result[1,0] *= f; result[1,1] *= f; result[1,2] *= f; result[1,3] *= f;
    //	result[2,0] *= f; result[2,1] *= f; result[2,2] *= f; result[2,3] *= f;
    //	result[3,1] *= f; result[3,1] *= f; result[3,2] *= f; result[3,3] *= f;
    //	return result;
    //}

    //public Matrix Add(Matrix mat)
    //{
    //	return new Matrix(m[0,0] + mat.m[0,0], m[0,1] + mat.m[0,1], m[0,2] + mat.m[0,2], m[0,3] + mat.m[0,3],
    //												m[1,0] + mat.m[1,0], m[1,1] + mat.m[1,1], m[1,2] + mat.m[1,2], m[1,3] + mat.m[1,3],
    //												m[2,0] + mat.m[2,0], m[2,1] + mat.m[2,1], m[2,2] + mat.m[2,2], m[2,3] + mat.m[2,3],
    //												m[3,0] + mat.m[3,1], m[3,1] + mat.m[3,1], m[3,2] + mat.m[3,2], m[3,3] + mat.m[3,3]);

    //}


    //public Matrix Subtract(Matrix mat)
    //{
    //	return new Matrix(m[0,0] - mat.m[0,0], m[0,1] - mat.m[0,1], m[0,2] - mat.m[0,2], m[0,3] - mat.m[0,3],
    //												m[1,0] - mat.m[1,0], m[1,1] - mat.m[1,1], m[1,2] - mat.m[1,2], m[1,3] - mat.m[1,3],
    //												m[2,0] - mat.m[2,0], m[2,1] - mat.m[2,1], m[2,2] - mat.m[2,2], m[2,3] - mat.m[2,3],
    //												m[3,0] - mat.m[3,1], m[3,1] - mat.m[3,1], m[3,2] - mat.m[3,2], m[3,3] - mat.m[3,3]);

    //}


    //public float Determinant()
    //{
    //	Vector4 minor, v1 = new Vector4(), v2 = new Vector4(), v3 = new Vector4();
    //	float det;

    //	v1.x = m[0, 0]; v1.y = m[1, 0]; v1.z = m[2, 0]; v1.w = m[3, 0];
    //	v2.x = m[0, 1]; v2.y = m[1, 1]; v2.z = m[2, 1]; v2.w = m[3, 1];
    //	v3.x = m[0, 2]; v3.y = m[1, 2]; v3.z = m[2, 2]; v3.w = m[3, 2];
    //	minor = Vector4.Cross(v1, v2, v3);
    //	det = -(m[0, 3] * minor.x + m[1, 3] * minor.y + m[2, 3] * minor.z + m[3, 3] * minor.w);
    //	return det;
    //}


    //public void Inverse()
    //{
    //	float det = 0;
    //	Inverse(ref det);
    //}

    //public void Inverse(ref float pdeterminant)
    //{
    //	int a, i, j;
    //	Matrix result = new Matrix();

    //	Vector4 v;
    //	Vector4[] vec = new Vector4[3];
    //	float det;

    //	det = Determinant();
    //	if ( det == 0.0f )
    //		return ;

    //	if ( pdeterminant != null ) 
    //		pdeterminant = det;

    //	for (i=0; i<4; i++)
    //	{
    //		for (j=0; j<4; j++)
    //		{
    //			if (j != i )
    //			{
    //				a = j;
    //				if ( j > i ) 
    //					a = a-1;
    //				vec[a].x = m[j,0];
    //				vec[a].y = m[j,1];
    //				vec[a].z = m[j,2];
    //				vec[a].w = m[j,3];
    //			}
    //		}

    //		v = Math3D.Vector4.Cross(vec[0], vec[1], vec[2]);
    //		result.m[0, i] = (float)System.Math.Pow(-1.0f, i) * v.x / det;
    //		result.m[1, i] = (float)System.Math.Pow(-1.0f, i) * v.y / det;
    //		result.m[2, i] = (float)System.Math.Pow(-1.0f, i) * v.z / det;
    //		result.m[3, i] = (float)System.Math.Pow(-1.0f, i) * v.w / det;
    //	}

    //	Array.Copy(m, result.m, 16);
    //}

    //static public Matrix LookAtLH(Vector3 peye, Vector3 pat, Vector3 pup)
    //{
    //	Matrix result = new Matrix();
    //	Vector3 right, up, vec ;

    //	vec = pat - peye;
    //	vec.Normalize();
    //	right = Math3D.Vector3.Cross( pup, vec);
    //	up = Math3D.Vector3.Cross(vec, right);
    //	right.Normalize();
    //	up.Normalize();

    //	result.m[0, 0] = right.x;
    //	result.m[1, 0] = right.y;
    //	result.m[2, 0] = right.z;
    //	result.m[3, 0] = -right.Dot(peye);
    //	result.m[0, 1] = up.x;
    //	result.m[1, 1] = up.y;
    //	result.m[2, 1] = up.z;
    //	result.m[3, 1] = -up.Dot(peye);
    //	result.m[0, 2] = vec.x;
    //	result.m[1, 2] = vec.y;
    //	result.m[2, 2] = vec.z;
    //	result.m[3, 2] = -vec.Dot(peye);
    //	result.m[0, 3] = 0.0f;
    //	result.m[1, 3] = 0.0f;
    //	result.m[2, 3] = 0.0f;
    //	result.m[3, 3] = 1.0f;
    //	return result;
    //}


    //static public Matrix LookAtRH(Vector3 peye, Vector3 pat, Vector3 pup)
    //{
    //	Matrix result = new Matrix();
    //	Vector3 right, up, vec, vec2;

    //	vec = pat - peye;
    //	vec.Normalize();
    //	right = Math3D.Vector3.Cross(pup, vec);
    //	up = Math3D.Vector3.Cross(vec, right);
    //	right.Normalize();
    //	up.Normalize();

    //	result.m[0, 0] = -right.x;
    //	result.m[1, 0] = -right.y;
    //	result.m[2, 0] = -right.z;
    //	result.m[3, 0] = right.Dot(peye);
    //	result.m[0, 1] = up.x;
    //	result.m[1, 1] = up.y;
    //	result.m[2, 1] = up.z;
    //	result.m[3, 1] = -up.Dot(peye);
    //	result.m[0, 2] = -vec.x;
    //	result.m[1, 2] = -vec.y;
    //	result.m[2, 2] = -vec.z;
    //	result.m[3, 2] = vec.Dot(peye);
    //	result.m[0, 3] = 0.0f;
    //	result.m[1, 3] = 0.0f;
    //	result.m[2, 3] = 0.0f;
    //	result.m[3, 3] = 1.0f;
    //	return result;
    //}



    //static public Matrix MultiplyTranspose(Matrix pm1, Matrix pm2)
    //{
    //	Matrix result = pm1 * pm2;
    //	result.Transpose();
    //	return result;
    //}


    //static public Matrix OrthoLH(float w, float h, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 2.0f / w;
    //	result.m[1, 1] = 2.0f / h;
    //	result.m[2, 2] = 1.0f / (zf - zn);
    //	result.m[3, 2] = zn / (zn - zf);
    //	return result;
    //}




    //static public Matrix OrthoOffCenterLH(float l, float r, float b, float t, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 2.0f / (r - l);
    //	result.m[1, 1] = 2.0f / (t - b);
    //	result.m[2, 2] = 1.0f / (zf - zn);
    //	result.m[3, 0] = -1.0f - 2.0f * l / (r - l);
    //	result.m[3, 1] = 1.0f + 2.0f * t / (b - t);
    //	result.m[3, 2] = zn / (zn - zf);
    //	return result;
    //}




    //static public Matrix OrthoOffCenterRH(float l, float r, float b, float t, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 2.0f / (r - l);
    //	result.m[1, 1] = 2.0f / (t - b);
    //	result.m[2, 2] = 1.0f / (zn - zf);
    //	result.m[3, 0] = -1.0f - 2.0f * l / (r - l);
    //	result.m[3, 1] = 1.0f + 2.0f * t / (b - t);
    //	result.m[3, 2] = zn / (zn - zf);
    //	return result;
    //}




    //static public Matrix OrthoRH(float w, float h, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 2.0f / w;
    //	result.m[1, 1] = 2.0f / h;
    //	result.m[2, 2] = 1.0f / (zn - zf);
    //	result.m[3, 2] = zn / (zn - zf);
    //	return result;
    //}


    //static public Matrix PerspectiveFovLH(float fovy, float aspect, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 1.0f / (aspect * (float)System.Math.Tan(fovy / 2.0f));
    //	result.m[1, 1] = 1.0f / (float)System.Math.Tan(fovy / 2.0f);
    //	result.m[2, 2] = zf / (zf - zn);
    //	result.m[2, 3] = 1.0f;
    //	result.m[3, 2] = (zf * zn) / (zn - zf);
    //	result.m[3, 3] = 0.0f;
    //	return result;
    //}


    //static public Matrix PerspectiveFovRH(float fovy, float aspect, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 1.0f / (aspect * (float)System.Math.Tan(fovy / 2.0f));
    //	result.m[1, 1] = 1.0f / (float)System.Math.Tan(fovy / 2.0f);
    //	result.m[2, 2] = zf / (zn - zf);
    //	result.m[2, 3] = -1.0f;
    //	result.m[3, 2] = (zf * zn) / (zn - zf);
    //	result.m[3, 3] = 0.0f;
    //	return result;
    //}




    //static public Matrix PerspectiveLH(float w, float h, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 2.0f * zn / w;
    //	result.m[1, 1] = 2.0f * zn / h;
    //	result.m[2, 2] = zf / (zf - zn);
    //	result.m[3, 2] = (zn * zf) / (zn - zf);
    //	result.m[2, 3] = 1.0f;
    //	result.m[3, 3] = 0.0f;
    //	return result;
    //}




    //static public Matrix PerspectiveOffCenterLH(float l, float r, float b, float t, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 2.0f * zn / (r - l);
    //	result.m[1, 1] = -2.0f * zn / (b - t);
    //	result.m[2, 0] = -1.0f - 2.0f * l / (r - l);
    //	result.m[2, 1] = 1.0f + 2.0f * t / (b - t);
    //	result.m[2, 2] = -zf / (zn - zf);
    //	result.m[3, 2] = (zn * zf) / (zn - zf);
    //	result.m[2, 3] = 1.0f;
    //	result.m[3, 3] = 0.0f;
    //	return result;
    //}





    //static public Matrix PerspectiveOffCenterRH(float l, float r, float b, float t, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 2.0f * zn / (r - l);
    //	result.m[1, 1] = -2.0f * zn / (b - t);
    //	result.m[2, 0] = 1.0f + 2.0f * l / (r - l);
    //	result.m[2, 1] = -1.0f - 2.0f * t / (b - t);
    //	result.m[2, 2] = zf / (zn - zf);
    //	result.m[3, 2] = (zn * zf) / (zn - zf);
    //	result.m[2, 3] = -1.0f;
    //	result.m[3, 3] = 0.0f;
    //	return result;
    //}


    //static public Matrix PerspectiveRH(float w, float h, float zn, float zf)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 2.0f * zn / w;
    //	result.m[1, 1] = 2.0f * zn / h;
    //	result.m[2, 2] = zf / (zn - zf);
    //	result.m[3, 2] = (zn * zf) / (zn - zf);
    //	result.m[2, 3] = -1.0f;
    //	result.m[3, 3] = 0.0f;
    //	return result;
    //}


    //static public Matrix Reflect(Plane pplane)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	Plane Nplane = new Plane(pplane);
    //	Nplane.Normalize();

    //	result.m[0, 0] = 1.0f - 2.0f * Nplane.a * Nplane.a;
    //	result.m[0, 1] = -2.0f * Nplane.a * Nplane.b;
    //	result.m[0, 2] = -2.0f * Nplane.a * Nplane.c;
    //	result.m[1, 0] = -2.0f * Nplane.a * Nplane.b;
    //	result.m[1, 1] = 1.0f - 2.0f * Nplane.b * Nplane.b;
    //	result.m[1, 2] = -2.0f * Nplane.b * Nplane.c;
    //	result.m[2, 0] = -2.0f * Nplane.c * Nplane.a;
    //	result.m[2, 1] = -2.0f * Nplane.c * Nplane.b;
    //	result.m[2, 2] = 1.0f - 2.0f * Nplane.c * Nplane.c;
    //	result.m[3, 0] = -2.0f * Nplane.d * Nplane.a;
    //	result.m[3, 1] = -2.0f * Nplane.d * Nplane.b;
    //	result.m[3, 2] = -2.0f * Nplane.d * Nplane.c;
    //	return result;
    //}




    //static public Matrix RotationAxis(Vector3 pv, float angle)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	Vector3 v = new Vector3(pv);
    //	v.Normalize();

    //	float cosangle = (float)System.Math.Cos(angle);
    //	float sinangle = (float)System.Math.Sin(angle);

    //	result.m[0, 0] = (1.0f - cosangle) * v.x * v.x + cosangle;
    //	result.m[1, 0] = (1.0f - cosangle) * v.x * v.y - sinangle * v.z;
    //	result.m[2, 0] = (1.0f - cosangle) * v.x * v.z + sinangle * v.y;
    //	result.m[0, 1] = (1.0f - cosangle) * v.y * v.x + sinangle * v.z;
    //	result.m[1, 1] = (1.0f - cosangle) * v.y * v.y + cosangle;
    //	result.m[2, 1] = (1.0f - cosangle) * v.y * v.z - sinangle * v.x;
    //	result.m[0, 2] = (1.0f - cosangle) * v.z * v.x - sinangle * v.y;
    //	result.m[1, 2] = (1.0f - cosangle) * v.z * v.y + sinangle * v.x;
    //	result.m[2, 2] = (1.0f - cosangle) * v.z * v.z + cosangle;
    //	return result;
    //}


    //static public Matrix RotationQuaternion(Quaternion pq)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = 1.0f - 2.0f * (pq.y * pq.y + pq.z * pq.z);
    //	result.m[0, 1] = 2.0f * (pq.x * pq.y + pq.z * pq.w);
    //	result.m[0, 2] = 2.0f * (pq.x * pq.z - pq.y * pq.w);
    //	result.m[1, 0] = 2.0f * (pq.x * pq.y - pq.z * pq.w);
    //	result.m[1, 1] = 1.0f - 2.0f * (pq.x * pq.x + pq.z * pq.z);
    //	result.m[1, 2] = 2.0f * (pq.y * pq.z + pq.x * pq.w);
    //	result.m[2, 0] = 2.0f * (pq.x * pq.z + pq.y * pq.w);
    //	result.m[2, 1] = 2.0f * (pq.y * pq.z - pq.x * pq.w);
    //	result.m[2, 2] = 1.0f - 2.0f * (pq.x * pq.x + pq.y * pq.y);
    //	return result;
    //}


    //static public Matrix RotationX(float angle)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[1, 1] = (float)System.Math.Cos(angle);
    //	result.m[2, 2] = result.m[1, 1]; // (float)System.Math.Cos(angle)
    //	result.m[1, 2] = (float)System.Math.Sin(angle);
    //	result.m[2, 1] = -result.m[1, 2]; //-(float)System.Math.Sin(angle);
    //	return result;
    //}


    //static public Matrix RotationY(float angle)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = (float)System.Math.Cos(angle);
    //	result.m[2, 2] = result.m[0, 0]; //(float)System.Math.Cos(angle);
    //	result.m[2, 0] = (float)System.Math.Sin(angle);
    //	result.m[0, 2] = -result.m[2, 0]; // -(float)System.Math.Sin(angle);
    //	return result;
    //}


    //static public Matrix RotationYawPitchRoll(float yaw, float pitch, float roll)
    //{
    //	Matrix result ;
    //	Matrix m;

    //	m = Math3D.Matrix.RotationZ(roll);
    //	result = m;
    //	m = Math3D.Matrix.RotationX( pitch);
    //	result = result * m;
    //	m = Math3D.Matrix.RotationY( yaw );
    //	result = result * m;
    //	return result;
    //}

    //static public Matrix RotationZ(float angle)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = (float)System.Math.Cos(angle);
    //	result.m[1, 1] = result.m[0, 0]; //(float)System.Math.Cos(angle);
    //	result.m[0, 1] = (float)System.Math.Sin(angle);
    //	result.m[1, 0] = -result.m[0, 1]; //-(float)System.Math.Sin(angle);
    //	return result;
    //}


    //static public Matrix Scaling(float sx, float sy, float sz)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[0, 0] = sx;
    //	result.m[1, 1] = sy;
    //	result.m[2, 2] = sz;
    //	return result;
    //}



    //static public Matrix Translation(float sx, float sy, float sz)
    //{
    //	Matrix result = Math3D.Matrix.Identity();
    //	result.m[3, 0] = sx;
    //	result.m[3, 1] = sy;
    //	result.m[3, 2] = sz;
    //	return result;
    //}



    //static public Matrix Shadow(Vector4 plight, Plane pplane)
    //{
    //	Matrix result = new Matrix();
    //	Plane Nplane = new Plane(pplane);
    //	float dot;

    //	Nplane.Normalize();
    //	dot = Nplane.Dot(plight);
    //	result.m[0, 0] = dot - Nplane.a * plight.x;
    //	result.m[0, 1] = -Nplane.a * plight.y;
    //	result.m[0, 2] = -Nplane.a * plight.z;
    //	result.m[0, 3] = -Nplane.a * plight.w;
    //	result.m[1, 0] = -Nplane.b * plight.x;
    //	result.m[1, 1] = dot - Nplane.b * plight.y;
    //	result.m[1, 2] = -Nplane.b * plight.z;
    //	result.m[1, 3] = -Nplane.b * plight.w;
    //	result.m[2, 0] = -Nplane.c * plight.x;
    //	result.m[2, 1] = -Nplane.c * plight.y;
    //	result.m[2, 2] = dot - Nplane.c * plight.z;
    //	result.m[2, 3] = -Nplane.c * plight.w;
    //	result.m[3, 0] = -Nplane.d * plight.x;
    //	result.m[3, 1] = -Nplane.d * plight.y;
    //	result.m[3, 2] = -Nplane.d * plight.z;
    //	result.m[3, 3] = dot - Nplane.d * plight.w;
    //	return result;
    //}


    //static public Matrix Transformation(Vector3 scalingCenter, Quaternion scalingRotation, Vector3 scaling, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
    //{
    //	Matrix m1, m2, m3, m4, m5, m6, m7;
    //	Quaternion prc = new Quaternion();
    //	Vector3 psc = new Vector3(), pt = new Vector3();

    //	psc.x = scalingCenter.x;
    //	psc.y = scalingCenter.y;
    //	psc.z = scalingCenter.z;

    //	prc.x = rotationCenter.x;
    //	prc.y = rotationCenter.y;
    //	prc.z = rotationCenter.z;

    //	pt.x = translation.x;
    //	pt.y = translation.y;
    //	pt.z = translation.z;

    //	m1 = Math3D.Matrix.Translation(-psc.x, -psc.y, -psc.z);

    //	m4 = RotationQuaternion( scalingRotation);
    //	m2 = new Matrix(m4);
    //	m2.Inverse();

    //	m3 = Scaling(scaling.x, scaling.y, scaling.z);

    //	m6 = RotationQuaternion( rotation);

    //	m5 = Math3D.Matrix.Translation(psc.x - prc.x, psc.y - prc.y, psc.z - prc.z);
    //	m7 = Math3D.Matrix.Translation(prc.x + pt.x, prc.y + pt.y, prc.z + pt.z);

    //	return m1 * m2 * m3 * m4 * m5 * m6 * m7;
    //}




    //public void Transpose()
    //{
    //	Matrix result = new Matrix();
    //	int i, j;

    //	for (i = 0; i < 4; i++)
    //	{
    //		for (j = 0; j < 4; j++)
    //		{
    //			result.m[i, j] = m[j, i];
    //		}
    //	}
    //	Array.Copy(m, result.m, 16);
    //}

    //Matrix AffineTransformation(float scaling, Vector3 rotationcenter, Quaternion rotation, Vector3 translation)
    //{
    //	Matrix result = new Matrix();
    //	Matrix m1, m2, m3, m4, m5;

    //	m1 = Math3D.Matrix.Scaling(scaling, scaling, scaling);

    //	m2 = Math3D.Matrix.Translation( -rotationcenter.x, -rotationcenter.y, -rotationcenter.z);
    //	m4 = Math3D.Matrix.Translation( rotationcenter.x, rotationcenter.y, rotationcenter.z);

    //	m3 = Math3D.Matrix.RotationQuaternion( rotation);

    //	m5 = Math3D.Matrix.Translation( translation.x, translation.y, translation.z);

    //	return m1 * m2 * m3 * m4 * m5;
    //}





    //public bool DecomposeMatrix( ref Vector3 pos, ref Quaternion rotation, ref Vector3 scale )
    //{
    //	pos.x = m[3,0];
    //	pos.y = m[3,1];
    //	pos.z = m[3,2];

    //	m[3,0] = 0;
    //	m[3,1] = 0;
    //	m[3,2] = 0;

    //	scale.x = (float)System.Math.Sqrt(m[0,0] * m[0,0] + m[1,0] * m[1,0] + m[2,0] * m[2,0] );
    //	scale.y = (float)System.Math.Sqrt(m[0,1] * m[0,1] + m[1,1] * m[1,1] + m[2,1] * m[2,1]);
    //	scale.z = (float)System.Math.Sqrt(m[0,2] * m[0,2] + m[1,2] * m[1,2] + m[2,2] * m[2,2]);

    //	if (scale.x == 0.0 || scale.y == 0.0 || scale.z == 0.0 )
    //		return false;

    //	m[0,0] /= scale.x;   m[1,0] /= scale.x;   m[2,0] /= scale.x;   
    //	m[0,1] /= scale.y;   m[1,1] /= scale.y;   m[2,1] /= scale.y;   
    //	m[0,2] /= scale.z;   m[1,2] /= scale.z;   m[2,2] /= scale.z;   
    //	m[0,3] = 0;          m[1,3] = 0;          m[2,3] = 0;          m[3,3] = 1;

    //	rotation = Quaternion.RotationMatrix(this);
    //	return true;
    //}




    //static public Matrix LookAt(Vector3 dir, Vector3 pos)
    //{
    //	Matrix result = new Matrix();
    //	// direction 방향이 +z .. 상이 y 좌우가 x LH 방식

    //	Matrix userWorldMatrix;
    //	if (!Math3D.Util.IsNormalToolSmall(dir.x) || !Math3D.Util.IsNormalToolSmall(dir.z))
    //	{
    //		Vector3 up = new Vector3(0,1,0);
    //		Vector3 target = pos + dir;

    //		userWorldMatrix = LookAtLH(pos, target, up);
    //	}
    //	else
    //	{
    //		Vector3 up = new Vector3(1, 0, 0);
    //		Vector3 target = pos + dir;

    //		userWorldMatrix = LookAtLH(pos, target, up);
    //	}

    //	return userWorldMatrix;;
    //}





    //// high level functions



    //static public Matrix CoordTransformMatrix(Vector3 xaxis, Vector3 yaxis, Vector3 zaxis)
    //{
    //	Matrix mat = new Matrix();

    //	mat.m[0, 0] = xaxis.x;
    //	mat.m[1, 0] = xaxis.y;
    //	mat.m[2, 0] = xaxis.z;
    //	mat.m[3, 0] = 0;

    //	mat.m[0, 1] = yaxis.x;
    //	mat.m[1, 1] = yaxis.y;
    //	mat.m[2, 1] = yaxis.z;
    //	mat.m[3, 1] = 0;

    //	mat.m[0, 2] = zaxis.x;
    //	mat.m[1, 2] = zaxis.y;
    //	mat.m[2, 2] = zaxis.z;
    //	mat.m[3, 2] = 0;

    //	mat.m[0, 3] = 0;
    //	mat.m[1, 3] = 0;
    //	mat.m[2, 3] = 0;
    //	mat.m[3, 3] = 1;

    //	return mat;
    //}










}











/* look at matrix template

	template<class T>void Camera<T>::setuplookat(){
	static 3DVECTOR<T> f,up,s,u;
	static matrix<T> tra;
	f.set(targ.x-pos.x,targ.y-pos.y,targ.z-pos.z);
	f.normalize();
	up=upv;
	up.normalize();
	right.CrossProduct((targ-pos),up);
	s.CrossProduct(f,up);
	u.CrossProduct(s,f);
	LookAt.Unit(); tra.Unit();
	LookAt.arrMat[0]=s.x;	LookAt.arrMat[4]=s.y;	LookAt.arrMat[8]=s.z;
	LookAt.arrMat[1]=u.x;	LookAt.arrMat[5]=u.y;	LookAt.arrMat[9]=u.z;
	LookAt.arrMat[2]=-f.x;	LookAt.arrMat[6]=-f.y;	LookAt.arrMat[10]=-f.z;
	tra.arrMat[12]=-pos.x;	tra.arrMat[13]=-pos.y; 	tra.arrMat[14]=-pos.z;
	LookAt=LookAt*tra;
*/
