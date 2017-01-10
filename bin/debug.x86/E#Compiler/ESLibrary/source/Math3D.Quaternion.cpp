#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "Math3D.Quaternion.h"
#include <math.h>
#include <stdlib.h>

Quaternion* Quaternion::Identity()
{
return new Quaternion(0, 0, 0, 1);
}


Quaternion::Quaternion()
{
}


Quaternion::Quaternion(float fx, float fy, float fz, float fw)
{
x = fx;
y = fy;
z = fz;
w = fw;
}


Quaternion::Quaternion(Quaternion* v)
{
x = v->x;
y = v->y;
y = v->z;
w = v->w;
}


bool Quaternion::IsIdentity()
{
return ((((((x==0.0f))&&((y==0.0f)))&&((z==0.0f)))&&((w==1.0f))));
}


Quaternion* Quaternion::$Operator_PLUS$(Quaternion* v)
{
return v;
}


Quaternion* Quaternion::$Operator_MINUS$(Quaternion* v)
{
return new Quaternion((-v->x), (-v->y), (-v->z), (-v->w));
}


Quaternion* Quaternion::$Operator_PLUS$(Quaternion* v0, Quaternion* v)
{
return new Quaternion((v0->x+v->x), (v0->y+v->y), (v0->z+v->z), (v0->w+v->w));
}


Quaternion* Quaternion::$Operator_MINUS$(Quaternion* v0, Quaternion* v)
{
return new Quaternion((v0->x-v->x), (v0->y-v->y), (v0->z-v->z), (v0->w-v->w));
}


Quaternion* Quaternion::$Operator_TIMES$(Quaternion* v, float f)
{
return new Quaternion((v->x*f), (v->y*f), (v->z*f), (v->w*f));
}


Quaternion* Quaternion::$Operator_DIVIDE$(Quaternion* v, float f)
{
return new Quaternion((v->x/f), (v->y/f), (v->z/f), (v->w/f));
}


Quaternion* Quaternion::$Operator_TIMES$(float f, Quaternion* v)
{
return new Quaternion((f*v->x), (f*v->y), (f*v->z), (f*v->w));
}


bool Quaternion::$Operator_EQUAL$(Quaternion* v, Quaternion* v1)
{
return ((((v1->x==v->x)&&(v1->y==v->y))&&(v1->z==v->z))&&(v1->w==v->w));
}


bool Quaternion::$Operator_NOTEQUAL$(Quaternion* v, Quaternion* v1)
{
return ((((v1->x!=v->x)||(v1->y!=v->y))||(v1->z!=v->z))||(v1->w!=v->w));
}

void Quaternion::Normalize()
{
	float norm;
	norm = Length();
	if ((norm == 0.0f))
	{
		x = 0.0f;
		y = 0.0f;
		z = 0.0f;
		w = 0.0f;
	}
	else
	{
		x = (x / norm);
		y = (y / norm);
		z = (z / norm);
		w = (w / norm);
	}
}


float Quaternion::Length()
{
	return (float)sqrt((x) * (x)+(y) * (y)+(z) * (z)+(w) * (w));
}


float Quaternion::LengthSq()
{
	return ((((x*x) + (y*y)) + (z*z)) + (w*w));
}

Quaternion* Quaternion::Cross(Quaternion* pv1, Quaternion* pv2, Quaternion* pv3)
{
	Quaternion* result = new Quaternion();
	result->x = (((pv1->y*(((pv2->z*pv3->w) - (pv3->z*pv2->w)))) - (pv1->z*(((pv2->y*pv3->w) - (pv3->y*pv2->w))))) + (pv1->w*(((pv2->y*pv3->z) - (pv2->z*pv3->y)))));
	result->y = (-((((pv1->x*(((pv2->z*pv3->w) - (pv3->z*pv2->w)))) - (pv1->z*(((pv2->x*pv3->w) - (pv3->x*pv2->w))))) + (pv1->w*(((pv2->x*pv3->z) - (pv3->x*pv2->z)))))));
	result->z = (((pv1->x*(((pv2->y*pv3->w) - (pv3->y*pv2->w)))) - (pv1->y*(((pv2->x*pv3->w) - (pv3->x*pv2->w))))) + (pv1->w*(((pv2->x*pv3->y) - (pv3->x*pv2->y)))));
	result->w = (-((((pv1->x*(((pv2->y*pv3->z) - (pv3->y*pv2->z)))) - (pv1->y*(((pv2->x*pv3->z) - (pv3->x*pv2->z))))) + (pv1->z*(((pv2->x*pv3->y) - (pv3->x*pv2->y)))))));
	return result;
}


float Quaternion::Dot(Quaternion* pv2)
{
	return ((((x*pv2->x) + (y*pv2->y)) + (z*pv2->z)) + (w*pv2->w));
}


float Quaternion::Dot(Quaternion* pv1, Quaternion* pv2)
{
	return ((((pv1->x*pv2->x) + (pv1->y*pv2->y)) + (pv1->z*pv2->z)) + (pv1->w*pv2->w));
}


Quaternion* Quaternion::Maximize(Quaternion* pv1, Quaternion* pv2)
{
	Quaternion* result = new Quaternion();
	result->x = fmaxf(pv1->x, pv2->x);
	result->y = fmaxf(pv1->y, pv2->y);
	result->z = fmaxf(pv1->z, pv2->z);
	result->w = fmaxf(pv1->w, pv2->w);
	return result;
}


Quaternion* Quaternion::Minimize(Quaternion* pv1, Quaternion* pv2)
{
	Quaternion* result = new Quaternion();
	result->x = fminf(pv1->x, pv2->x);
	result->y = fminf(pv1->y, pv2->y);
	result->z = fminf(pv1->z, pv2->z);
	result->w = fminf(pv1->w, pv2->w);
	return result;
}

Quaternion* Quaternion::Scale(Quaternion* pv, float s)
{
	Quaternion* result = new Quaternion();
	result->x = (s*(pv->x));
	result->y = (s*(pv->y));
	result->z = (s*(pv->z));
	result->w = (s*(pv->w));
	return result;
}


void Quaternion::Scale(float s)
{
	x = (s*x);
	y = (s*y);
	z = (s*z);
	w = (s*w);
}


Quaternion* Quaternion::Subtract(Quaternion* pv1, Quaternion* pv2)
{
	Quaternion* result = new Quaternion();
	result->x = (pv1->x - pv2->x);
	result->y = (pv1->y - pv2->y);
	result->z = (pv1->z - pv2->z);
	result->w = (pv1->w - pv2->w);
	return result;
}


void Quaternion::Subtract(Quaternion* pv2)
{
	x = (x - pv2->x);
	y = (y - pv2->y);
	z = (z - pv2->z);
	w = (w - pv2->w);
}


Quaternion* Quaternion::Multiply(Quaternion* pq1, Quaternion* pq2)
{
	Quaternion* result = new Quaternion();
	result->x = ((((pq2->w*pq1->x) + (pq2->x*pq1->w)) + (pq2->y*pq1->z)) - (pq2->z*pq1->y));
	result->y = ((((pq2->w*pq1->y) - (pq2->x*pq1->z)) + (pq2->y*pq1->w)) + (pq2->z*pq1->x));
	result->z = ((((pq2->w*pq1->z) + (pq2->x*pq1->y)) - (pq2->y*pq1->x)) + (pq2->z*pq1->w));
	result->w = ((((pq2->w*pq1->w) - (pq2->x*pq1->x)) - (pq2->y*pq1->y)) - (pq2->z*pq1->z));
	return result;
}


Quaternion* Quaternion::$Operator_TIMES$(Quaternion* pq1, Quaternion* pq2)
{
	return Quaternion::Multiply(pq1, pq2);
}


void Quaternion::Multiply(Quaternion* pq2)
{
	Quaternion* result = new Quaternion();
	result->x = ((((pq2->w*x) + (pq2->x*w)) + (pq2->y*z)) - (pq2->z*y));
	result->y = ((((pq2->w*y) - (pq2->x*z)) + (pq2->y*w)) + (pq2->z*x));
	result->z = ((((pq2->w*z) + (pq2->x*y)) - (pq2->y*x)) + (pq2->z*w));
	result->w = ((((pq2->w*w) - (pq2->x*x)) - (pq2->y*y)) - (pq2->z*z));
	x = result->x;
	y = result->y;
	z = result->z;
	w = result->w;
}

Quaternion* Quaternion::BaryCentric(Quaternion* pq1, Quaternion* pq2, Quaternion* pq3, float f, float g)
{
	Quaternion *q1 = Slerp(pq1, pq2, (f + g));
	Quaternion *q2 = Slerp(pq1, pq3, (f + g));
	return Slerp(q1, q2, (g / ((f + g))));
}


Quaternion* Quaternion::Slerp(Quaternion* pq1, Quaternion* pq2, float t)
{
	Quaternion* result = new Quaternion();
	float dot;
	float epsilon;
	float temp;
	float theta;
	float u;
	epsilon = 1.0f;
	temp = (1.0f - t);
	u = t;
	dot = Dot(pq1, pq2);
	if ((dot<0.0f))
	{
		epsilon = (-1.0f);
		dot = (-dot);
	}
	if (((1.0f - dot)>0.001f))
	{
		theta = (float)acos(dot);
		temp = (float)sin(theta * temp) / (float)sin(theta);
		u = (float)sin(theta * u) / (float)sin(theta);
	}
	result->x = ((temp*pq1->x) + ((epsilon*u)*pq2->x));
	result->y = ((temp*pq1->y) + ((epsilon*u)*pq2->y));
	result->z = ((temp*pq1->z) + ((epsilon*u)*pq2->z));
	result->w = ((temp*pq1->w) + ((epsilon*u)*pq2->w));
	return result;
}

Quaternion* Quaternion::Exp()
{
	Quaternion* result = new Quaternion();
	float norm;
	norm = (float)sqrt(x * x + y * y + z * z);
	if ((norm != 0.0f))
	{
		float sinnorm = (float)sin(norm);
		float cosnorm = (float)cos(norm);
		result->x = sinnorm * x / norm;
		result->y = sinnorm * y / norm;
		result->z = sinnorm * z / norm;
		result->w = cosnorm;
	}
	else
	{
		result->x = 0.0f;
		result->y = 0.0f;
		result->z = 0.0f;
		result->w = 1.0f;
	}
	return result;
}

Quaternion* Quaternion::Inverse()
{
	Quaternion* result = new Quaternion();
	float norm;

	norm = LengthSq();
	if ((norm == 0.0f))
	{
		result->x = 0.0f;
		result->y = 0.0f;
		result->z = 0.0f;
		result->w = 0.0f;
	}
	else
	{
		result->x = ((-x) / norm);
		result->y = ((-y) / norm);
		result->z = ((-z) / norm);
		result->w = (w / norm);
	}
	return result;
}


Quaternion* Quaternion::Ln()
{
	Quaternion* result = new Quaternion();
	float norm;
	float normvec;
	float theta;
	
	norm = LengthSq();
	if ((norm>1.0001f))
	{
		result->x = x;
		result->y = y;
		result->z = z;
		result->w = 0.0f;
	}
	else
	{
		if ((norm>0.99999f))
		{
			normvec = (float)sqrt(x * x + y * y + z * z);
			theta = (float)atan2(normvec, w) / normvec;
			result->x = (theta*x);
			result->y = (theta*y);
			result->z = (theta*z);
			result->w = 0.0f;
		}
		else
		{
		}
	}
	return result;
}

Quaternion* Quaternion::RotationAxis(Vector3* pv, float angle)
{
	Quaternion* result = new Quaternion();
	Vector3* temp = new Vector3(pv);
	temp->Normalize();
	float sinangle2 = (float)sin(angle / 2.0f);
	float cosangle2 = (float)cos(angle / 2.0f);
	result->x = sinangle2 * temp->x;
	result->y = sinangle2 * temp->y;
	result->z = sinangle2 * temp->z;
	result->w = cosangle2;
	return result;
}

Quaternion* Quaternion::RotationYawPitchRoll(float yaw, float pitch, float roll)
{
	Quaternion* result = new Quaternion();
	float cospitch2 = (float)cos(pitch / 2.0f);
	float sinpitch2 = (float)sin(pitch / 2.0f);
	float sinyaw2 = (float)sin(yaw / 2.0f);
	float cosyaw2 = (float)cos(yaw / 2.0f);
	float sinroll2 = (float)sin(roll / 2.0f);
	float cosroll2 = (float)cos(roll / 2.0f);

	result->x = sinyaw2 * cospitch2 * sinroll2 + cosyaw2 * sinpitch2 * cosroll2;
	result->y = sinyaw2 * cospitch2 * cosroll2 - cosyaw2 * sinpitch2 * sinroll2;
	result->z = cosyaw2 * cospitch2 * sinroll2 - sinyaw2 * sinpitch2 * cosroll2;
	result->w = cosyaw2 * cospitch2 * cosroll2 + sinyaw2 * sinpitch2 * sinroll2;

	return result;
}

Quaternion* Quaternion::Squad(Quaternion* pq1, Quaternion* pq2, Quaternion* pq3, Quaternion *pq4, float t)
{
	Quaternion* result = new Quaternion();

	result = Slerp(Slerp( pq1, pq4, t), Slerp(pq2, pq3, t), 2.0f * t * (1.0f - t));
	return result;
}

void  Quaternion::ToAxisAngle(Vector3*& paxis, float& pangle)
{
	float norm;

	pangle = 0.0f;
	norm = Length();
	if (norm != 0.0f)
	{
		paxis->x = x / norm;
		paxis->y = y / norm;
		paxis->z = z / norm;
		if ((float)abs(w) <= 1.0f) 
			pangle = 2.0f * (float)acos(w);
	}
	else
	{
		paxis->x = 1.0f;
		paxis->y = 0.0f;
		paxis->z = 0.0f;
	}
}

Quaternion* Quaternion::Conjugate()
{
	Quaternion* result = new Quaternion();
	result->x = (-x);
	result->y = (-y);
	result->z = (-z);
	result->w = w;
	return result;
}

/*
Quaternion* Quaternion::EulerToQuaternion(Vector3* euler)
{
	double c1 = (float)cos((double)euler->y / 2.0);
	double s1 = (float)sin((double)euler->y / 2.0);
	double c2 = (float)cos((double)euler->z / 2.0);
	double s2 = (float)sin((double)euler->z / 2.0);
	double c3 = (float)cos((double)euler->x / 2.0);
	double s3 = (float)sin((double)euler->x / 2.0);

	double c1c2 = c1 * c2;
	double s1s2 = s1 * s2;
	
	double w = c1c2 * c3 - s1s2 * s3;
	double x = c1c2 * c3 + s1s2 * c3;
	double y = s1 * c2 * c3 + c1 * s2 * s3;
	double z = c1 * s2 * c3 - s1 * c2 * s3;

	Quaternion* r = new Quaternion((float)x, (float)y, (float)z, (float)w);
	r->Normalize();
	return r;
}

Quaternion* Quaternion::EulerToQuaternionFloat(Vector3* euler)
{
	float c1 = (float)cos((double)euler->y / 2.0);
	float s1 = (float)sin((double)euler->y / 2.0);
	float c2 = (float)cos((double)euler->z / 2.0);
	float s2 = (float)sin((double)euler->z / 2.0);
	float c3 = (float)cos((double)euler->x / 2.0);
	float s3 = (float)sin((double)euler->x / 2.0);

	float c1c2 = c1 * c2;
	float s1s2 = s1 * s2;

	float w = c1c2 * c3 - s1s2 * s3;
	float x = c1c2 * c3 + s1s2 * c3;
	float y = s1 * c2 * c3 + c1 * s2 * s3;
	float z = c1 * s2 * c3 - s1 * c2 * s3;

	Quaternion* r = new Quaternion(x, y, z, w);
	r->Normalize();
	return r;
}


Quaternion* Quaternion::EulerToQuaternion2(Vector3* euler)
{
	double c1 = (float)cos((double)euler->y / 2.0);
	double s1 = (float)sin((double)euler->y / 2.0);
	double c2 = (float)cos((double)euler->z / 2.0);
	double s2 = (float)sin((double)euler->z / 2.0);
	double c3 = (float)cos((double)euler->x / 2.0);
	double s3 = (float)sin((double)euler->x / 2.0);

	double w = (float)sqrt(1.0 + c1 * c2 + c1 * c3 - s1 * s2 * s3 + c2 * c3) / 2.0;
	double w4 = (4.0 * w);

	Quaternion* r = new Quaternion();
	r->x = (float)((c2 * s3 + c1 * s3 + s1 * s2 * c3) / w4);
	r->y = (float)((s1 * c2 + s1 * c3 + c1 * s2 * s3) / w4);
	r->z = (float)(((-s1) * s3 + c1 * s2 * c3 + s2) / w4);
	r->w = 1.0f;
	r->Normalize();
	r->w = 1.0f;
	return r;
}

Quaternion* Quaternion::EulerToQuaternionFloat2(Vector3* euler)
{
	float c1 = (float)cos((double)euler->y / 2.0);
	float s1 = (float)sin((double)euler->y / 2.0);
	float c2 = (float)cos((double)euler->z / 2.0);
	float s2 = (float)sin((double)euler->z / 2.0);
	float c3 = (float)cos((double)euler->x / 2.0);
	float s3 = (float)sin((double)euler->x / 2.0);

	float w = (float)sqrt(1.0 + c1 * c2 + c1 * c3 - s1 * s2 * s3 + c2 * c3) / 2.0;
	float w4 = (4.0 * w);

	Quaternion* r = new Quaternion();
	r->x = ((c2 * s3 + c1 * s3 + s1 * s2 * c3) / w4);
	r->y = ((s1 * c2 + s1 * c3 + c1 * s2 * s3) / w4);
	r->z = (((-s1) * s3 + c1 * s2 * c3 + s2) / w4);
	r->w = 1.0f;
	r->Normalize();
	r->w = 1.0f;
	return r;
}

*/


const vector<string> Quaternion::mFieldNames = {"x", "y", "z", "w"};
const vector<string> Quaternion::mFieldTypes = {"float", "float", "float", "float"};
const vector<string> Quaternion::mFieldAccessors = {"public", "public", "public", "public"};


const char* Quaternion::__GetClassName__()
{
return "Quaternion";}


unsigned int Quaternion::__GetFieldNum__()
{
return 4;}


const char* Quaternion::__GetFieldName__(unsigned int i)
{
if (i >= mFieldNames.size())	return nullptr;else							return mFieldNames[i].c_str();}


const char* Quaternion::__GetFieldType__(unsigned int i)
{
if (i >= mFieldTypes.size())	return nullptr;else							return mFieldTypes[i].c_str();}


const char* Quaternion::__GetFieldAccessor__(unsigned int i)
{
if (i >= mFieldAccessors.size())	return nullptr;else								return mFieldAccessors[i].c_str();}


int Quaternion::__ReadField__(string fieldName, void* ptr, int* len)
{
if (fieldName == "x")
{
memcpy(ptr, (void*)&x, sizeof(x));*len = sizeof(x);}

if (fieldName == "y")
{
memcpy(ptr, (void*)&y, sizeof(y));*len = sizeof(y);}

if (fieldName == "z")
{
memcpy(ptr, (void*)&z, sizeof(z));*len = sizeof(z);}

if (fieldName == "w")
{
memcpy(ptr, (void*)&w, sizeof(w));*len = sizeof(w);}

return 0;}


int Quaternion::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
{
void* buf = nullptr;

if (fieldName == "x")
{
buf = &x;}

if (fieldName == "y")
{
buf = &y;}

if (fieldName == "z")
{
buf = &z;}

if (fieldName == "w")
{
buf = &w;}

if (buf == nullptr)
{
return 1;
}

memcpy(buf, ptr, len);
return 0;
}
