#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "Math3D.Vector2.h"
#include <math.h>
#include <stdlib.h>


Vector2::Vector2()
{
}


Vector2::Vector2(float fx, float fy)
{
x = fx;
y = fy;
}

Vector2::Vector2(Vector2* v)
{
	x = v->x;
	y = v->y;
}

Vector2::Vector2(Vector3* v)
{
	x = v->x;
	y = v->y;
}

Vector2::Vector2(Vector4* v)
{
	x = v->x;
	y = v->y;
}

Vector2* Vector2::Zero()
{
	return new Vector2(0, 0);
}

Vector2* Vector2::$Operator_PLUS$(Vector2* v)
{
return v;
}


Vector2* Vector2::$Operator_MINUS$(Vector2* v)
{
return new Vector2((-v->x), (-v->y));
}


Vector2* Vector2::$Operator_PLUS$(Vector2* v0, Vector2* v)
{
return new Vector2((v0->x+v->x), (v0->y+v->y));
}


Vector2* Vector2::$Operator_MINUS$(Vector2* v0, Vector2* v)
{
return new Vector2((v0->x-v->x), (v0->y-v->y));
}


Vector2* Vector2::$Operator_TIMES$(Vector2* v, float f)
{
return new Vector2((v->x*f), (v->y*f));
}


Vector2* Vector2::$Operator_DIVIDE$(Vector2* v, float f)
{
return new Vector2((v->x/f), (v->y/f));
}


Vector2* Vector2::$Operator_TIMES$(float f, Vector2* v)
{
return new Vector2((f*v->x), (f*v->y));
}


Vector2* Vector2::$Operator_TIMES$(Vector2* v, Vector2* v2)
{
return new Vector2((v->x*v2->x), (v->y*v2->y));
}


Vector2* Vector2::$Operator_DIVIDE$(Vector2* v, Vector2* v2)
{
return new Vector2((v->x/v2->x), (v->y/v2->y));
}


bool Vector2::$Operator_EQUAL$(Vector2* v, Vector2* v1)
{
return ((v1->x==v->x)&&(v1->y==v->y));
}


bool Vector2::$Operator_NOTEQUAL$(Vector2* v, Vector2* v1)
{
return ((v1->x!=v->x)||(v1->y!=v->y));
}

void Vector2::Normalize()
{
	float norm;
	norm = Length();
	if ((norm == 0.0f))
	{
		x = 0.0f;
		y = 0.0f;
	}
	else
	{
		x = (x / norm);
		y = (y / norm);
	}
}


float Vector2::Length()
{
	return sqrt((x) * (x)+(y) * (y));
}

float Vector2::LengthSq()
{
	return ((x*x) + (y*y));
}

float Vector2::CCW(Vector2* pv2)
{
	return ((x*pv2->y) - (y*pv2->x));
}


float Vector2::Dot(Vector2* pv2)
{
	return ((x*pv2->x) + (y*pv2->y));
}


float Vector2::Dot(Vector2* pv1, Vector2* pv2)
{
	return ((pv1->x*pv2->x) + (pv1->y*pv2->y));
	
}

Vector2* Vector2::Lerp(Vector2* pv1, Vector2* pv2, float s)
{
	Vector2* result = new Vector2();
	result->x = ((((1 - s))*(pv1->x)) + (s*(pv2->x)));
	result->y = ((((1 - s))*(pv1->y)) + (s*(pv2->y)));
	return result;
}


Vector2* Vector2::Maximize(Vector2* pv1, Vector2* pv2)
{
	Vector2* result = new Vector2();
	result->x = fmaxf(pv1->x, pv2->x);
	result->x = fmaxf(pv1->y, pv2->y);
	return result;
}


Vector2* Vector2::Minimize(Vector2* pv1, Vector2* pv2)
{
	Vector2* result = new Vector2();
	result->x = fminf(pv1->x, pv2->x);
	result->x = fminf(pv1->y, pv2->y);
	return result;
}

Vector2* Vector2::Scale(Vector2* pv, float s)
{
	Vector2* result = new Vector2();
	result->x = (s*(pv->x));
	result->y = (s*(pv->y));
	return result;
}


void Vector2::Scale(float s)
{
	x = (s*x);
	y = (s*y);
}


Vector2* Vector2::Subtract(Vector2* pv1, Vector2* pv2)
{
	Vector2* result = new Vector2();
	result->x = (pv1->x - pv2->x);
	result->y = (pv1->y - pv2->y);
	return result;
}


void Vector2::Subtract(Vector2* pv2)
{
	x = (x - pv2->x);
	y = (y - pv2->y);
}

Vector2* Vector2::BaryCentric(Vector2* pv1, Vector2* pv2, Vector2* pv3, float f, float g)
{
	Vector2* result = new Vector2();
	result->x = ((((((1.0f - f) - g))*(pv1->x)) + (f*(pv2->x))) + (g*(pv3->x)));
	result->y = ((((((1.0f - f) - g))*(pv1->y)) + (f*(pv2->y))) + (g*(pv3->y)));
	return result;
}

Vector2* Vector2::CatmullRom(Vector2* pv0, Vector2* pv1, Vector2* pv2, Vector2* pv3, float s)
{
	Vector2* result = new Vector2();
	result->x = (0.5f*(((((2.0f*pv1->x) + (((pv2->x - pv0->x))*s)) + (((((((2.0f*pv0->x) - (5.0f*pv1->x)) + (4.0f*pv2->x)) - pv3->x))*s)*s)) + (((((((pv3->x - (3.0f*pv2->x)) + (3.0f*pv1->x)) - pv0->x))*s)*s)*s))));
	result->y = (0.5f*(((((2.0f*pv1->y) + (((pv2->y - pv0->y))*s)) + (((((((2.0f*pv0->y) - (5.0f*pv1->y)) + (4.0f*pv2->y)) - pv3->y))*s)*s)) + (((((((pv3->y - (3.0f*pv2->y)) + (3.0f*pv1->y)) - pv0->y))*s)*s)*s))));
	return result;
}


Vector2* Vector2::Hermite(Vector2* pv1, Vector2* pt1, Vector2* pv2, Vector2* pt2, float s)
{
	Vector2* result = new Vector2();
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
	return result;
}

const vector<string> Vector2::mFieldNames = {"x", "y"};
const vector<string> Vector2::mFieldTypes = {"float", "float"};
const vector<string> Vector2::mFieldAccessors = {"public", "public"};


const char* Vector2::__GetClassName__()
{
return "Vector2";
}


unsigned int Vector2::__GetFieldNum__()
{
return 2;
}


const char* Vector2::__GetFieldName__(unsigned int i)
{
if (i >= mFieldNames.size())	return nullptr;
else							return mFieldNames[i].c_str();
}


const char* Vector2::__GetFieldType__(unsigned int i)
{
if (i >= mFieldTypes.size())	return nullptr;
else							return mFieldTypes[i].c_str();
}


const char* Vector2::__GetFieldAccessor__(unsigned int i)
{
if (i >= mFieldAccessors.size())	return nullptr;
else								return mFieldAccessors[i].c_str();
}


int Vector2::__ReadField__(string fieldName, void* ptr, int* len)
{
if (fieldName == "x")
{
memcpy(ptr, (void*)&x, sizeof(x));*len = sizeof(x);}

if (fieldName == "y")
{
memcpy(ptr, (void*)&y, sizeof(y));*len = sizeof(y);}

return 0;}


int Vector2::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
{
void* buf = nullptr;

if (fieldName == "x")
{
buf = &x;}

if (fieldName == "y")
{
buf = &y;}

if (buf == nullptr)
{
return 1;
}

memcpy(buf, ptr, len);
return 0;
}