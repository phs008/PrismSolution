#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "Math3D.Vector3.h"
#include <math.h>
#include <stdlib.h>


Vector3* Vector3::Zero()
{
return new Vector3(0, 0, 0);
}


Vector3::Vector3()
{
}


Vector3::Vector3(float fx, float fy, float fz)
{
x = fx;
y = fy;
z = fz;
}


Vector3::Vector3(Vector3* v)
{
x = v->x;
y = v->y;
z = v->z;
}

Vector3::Vector3(Vector2* v)
{
	x = v->x;
	y = v->y;
	z = 0.0f;
}

Vector3::Vector3(Vector4* v)
{
	x = v->x;
	y = v->y;
	z = v->z;
}

Vector3::Vector3(Color* v)
{
	x = v->r;
	y = v->g;
	z = v->b;
}

Vector3* Vector3::$Operator_PLUS$(Vector3* v)
{
	return v;
}


Vector3* Vector3::$Operator_MINUS$(Vector3* v)
{
	return new Vector3((-v->x), (-v->y), (-v->z));
}


Vector3* Vector3::$Operator_PLUS$(Vector3* v0, Vector3* v)
{
	return new Vector3((v0->x + v->x), (v0->y + v->y), (v0->z + v->z));
}


Vector3* Vector3::$Operator_MINUS$(Vector3* v0, Vector3* v)
{
	return new Vector3((v0->x - v->x), (v0->y - v->y), (v0->z - v->z));
}


Vector3* Vector3::$Operator_TIMES$(Vector3* v, float f)
{
	return new Vector3((v->x*f), (v->y*f), (v->z*f));
}


Vector3* Vector3::$Operator_DIVIDE$(Vector3* v, float f)
{
	return new Vector3((v->x / f), (v->y / f), (v->z / f));
}


Vector3* Vector3::$Operator_TIMES$(float f, Vector3* v)
{
	return new Vector3((f*v->x), (f*v->y), (f*v->z));
}


Vector3* Vector3::$Operator_TIMES$(Vector3* v, Vector3* v2)
{
	return new Vector3((v->x*v2->x), (v->y*v2->y), (v->z*v2->z));
}


Vector3* Vector3::$Operator_DIVIDE$(Vector3* v, Vector3* v2)
{
	return new Vector3((v->x / v2->x), (v->y / v2->y), (v->z / v2->z));
}


bool Vector3::$Operator_EQUAL$(Vector3* v, Vector3* v1)
{
	return (((v1->x == v->x) && (v1->y == v->y)) && (v1->z == v->z));
}


bool Vector3::$Operator_NOTEQUAL$(Vector3* v, Vector3* v1)
{
	return (((v1->x != v->x) || (v1->y != v->y)) || (v1->z != v->z));
}

void Vector3::Normalize()
{
	float norm;
	norm = Length();
	if ((norm == 0.0f))
	{
		x = 0.0f;
		y = 0.0f;
		z = 0.0f;
	}
	else
	{
		x = (x / norm);
		y = (y / norm);
		z = (z / norm);
	}
}


float Vector3::Length()
{
	return (float)sqrt((x) * (x)+(y) * (y)+(z) * (z));
}

float Vector3::LengthSq()
{
	return (((x*x) + (y*y)) + (z*z));
}

Vector3* Vector3::Cross(Vector3* pv1, Vector3* pv2)
{
	Vector3* result = new Vector3();
	result->x = (((pv1->y)*(pv2->z)) - ((pv1->z)*(pv2->y)));
	result->y = (((pv1->z)*(pv2->x)) - ((pv1->x)*(pv2->z)));
	result->z = (((pv1->x)*(pv2->y)) - ((pv1->y)*(pv2->x)));
	return result;
}


void Vector3::Cross(Vector3* pv2)
{
	Vector3* result = Cross(this, pv2);
	x = result->x;
	y = result->y;
	z = result->z;
}


float Vector3::Dot(Vector3* pv2)
{
	return (((x*pv2->x) + (y*pv2->y)) + (z*pv2->z));
}


float Vector3::Dot(Vector3* pv1, Vector3* pv2)
{
	return (((pv1->x*pv2->x) + (pv1->y*pv2->y)) + (pv1->z*pv2->z));
}

Vector3* Vector3::Lerp(Vector3* pv1, Vector3* pv2, float s)
{
	Vector3* result = new Vector3();
	result->x = ((((1 - s))*(pv1->x)) + (s*(pv2->x)));
	result->y = ((((1 - s))*(pv1->y)) + (s*(pv2->y)));
	result->z = ((((1 - s))*(pv1->z)) + (s*(pv2->z)));
	return result;
}


Vector3* Vector3::Maximize(Vector3* pv1, Vector3* pv2)
{
	Vector3* result = new Vector3();
	result->x = fmaxf(pv1->x, pv2->x);
	result->y = fmaxf(pv1->y, pv2->y);
	result->z = fmaxf(pv1->z, pv2->z);
	return result;
}


Vector3* Vector3::Minimize(Vector3* pv1, Vector3* pv2)
{
	Vector3* result = new Vector3();
	result->x = fminf(pv1->x, pv2->x);
	result->y = fminf(pv1->y, pv2->y);
	result->z = fminf(pv1->z, pv2->z);
	return result;
}


Vector3* Vector3::Scale(Vector3* pv, float s)
{
	Vector3* result = new Vector3();
	result->x = (s*(pv->x));
	result->y = (s*(pv->y));
	result->z = (s*(pv->z));
	return result;
}


void Vector3::Scale(float s)
{
	x = (s*x);
	y = (s*y);
	z = (s*z);
}

Vector3* Vector3::Subtract(Vector3* pv1, Vector3* pv2)
{
	Vector3* result = new Vector3();
	result->x = (pv1->x - pv2->x);
	result->y = (pv1->y - pv2->y);
	result->z = (pv1->z - pv2->z);
	return result;
}


void Vector3::Subtract(Vector3* pv2)
{
	x = (x - pv2->x);
	y = (y - pv2->y);
	z = (z - pv2->z);
}


Vector3* Vector3::BaryCentric(Vector3* pv1, Vector3* pv2, Vector3* pv3, float f, float g)
{
	Vector3* result = new Vector3();
	result->x = ((((((1.0f - f) - g))*(pv1->x)) + (f*(pv2->x))) + (g*(pv3->x)));
	result->y = ((((((1.0f - f) - g))*(pv1->y)) + (f*(pv2->y))) + (g*(pv3->y)));
	result->z = ((((((1.0f - f) - g))*(pv1->z)) + (f*(pv2->z))) + (g*(pv3->z)));
	return result;
}

Vector3* Vector3::CatmullRom(Vector3* pv0, Vector3* pv1, Vector3* pv2, Vector3* pv3, float s)
{
	Vector3* result = new Vector3();
	result->x = (0.5f*(((((2.0f*pv1->x) + (((pv2->x - pv0->x))*s)) + (((((((2.0f*pv0->x) - (5.0f*pv1->x)) + (4.0f*pv2->x)) - pv3->x))*s)*s)) + (((((((pv3->x - (3.0f*pv2->x)) + (3.0f*pv1->x)) - pv0->x))*s)*s)*s))));
	result->y = (0.5f*(((((2.0f*pv1->y) + (((pv2->y - pv0->y))*s)) + (((((((2.0f*pv0->y) - (5.0f*pv1->y)) + (4.0f*pv2->y)) - pv3->y))*s)*s)) + (((((((pv3->y - (3.0f*pv2->y)) + (3.0f*pv1->y)) - pv0->y))*s)*s)*s))));
	result->z = (0.5f*(((((2.0f*pv1->z) + (((pv2->z - pv0->z))*s)) + (((((((2.0f*pv0->z) - (5.0f*pv1->z)) + (4.0f*pv2->z)) - pv3->z))*s)*s)) + (((((((pv3->z - (3.0f*pv2->z)) + (3.0f*pv1->z)) - pv0->z))*s)*s)*s))));
	return result;
}


Vector3* Vector3::Hermite(Vector3* pv1, Vector3* pt1, Vector3* pv2, Vector3* pt2, float s)
{
	Vector3* result = new Vector3();
	float h1;
	float h2;
	float h3;
	float h4;
	h1 = (((((2.0f*s)*s)*s) - ((3.0f*s)*s)) + 1.0f);
	h2 = ((((s*s)*s) - ((2.0f*s)*s)) + s);
	h3 = (((((-2.0f)*s)*s)*s) + ((3.0f*s)*s));
	h4 = (((s*s)*s) - (s*s));
	result->x = ((((h1*(pv1->x)) + (h2*(pt1->x))) + (h3*(pv2->x))) + (h4*(pt2->x)));
	result->y = ((((h1*(pv1->y)) + (h2*(pt1->y))) + (h3*(pv2->y))) + (h4*(pt2->y)));
	result->z = ((((h1*(pv1->z)) + (h2*(pt1->z))) + (h3*(pv2->z))) + (h4*(pt2->z)));
	return result;
}

const vector<string> Vector3::mFieldNames = {"x", "y", "z"};
const vector<string> Vector3::mFieldTypes = {"float", "float", "float"};
const vector<string> Vector3::mFieldAccessors = {"public", "public", "public"};


const char* Vector3::__GetClassName__()
{
return "Vector3";}


unsigned int Vector3::__GetFieldNum__()
{
return 3;}


const char* Vector3::__GetFieldName__(unsigned int i)
{
if (i >= mFieldNames.size())	return nullptr;else							return mFieldNames[i].c_str();}


const char* Vector3::__GetFieldType__(unsigned int i)
{
if (i >= mFieldTypes.size())	return nullptr;else							return mFieldTypes[i].c_str();}


const char* Vector3::__GetFieldAccessor__(unsigned int i)
{
if (i >= mFieldAccessors.size())	return nullptr;else								return mFieldAccessors[i].c_str();}


int Vector3::__ReadField__(string fieldName, void* ptr, int* len)
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

return 0;}


int Vector3::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
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

if (buf == nullptr)
{
return 1;
}

memcpy(buf, ptr, len);
return 0;
}
