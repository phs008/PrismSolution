#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "Math3D.Vector4.h"
#include <math.h>
#include <stdlib.h>


Vector4* Vector4::Zero()
{
return new Vector4(0, 0, 0, 0);
}

Vector4::Vector4()
{
}

Vector4::Vector4(float fx, float fy, float fz, float fw)
{
x = fx;
y = fy;
z = fz;
w = fw;
}

Vector4::Vector4(Vector4* v)
{
	x = v->x;
	y = v->y;
	z = v->z;
	w = v->w;
}

Vector4::Vector4(Vector3* v)
{
	x = v->x;
	y = v->y;
	z = v->z;
	w = 0.0f;
}

Vector4::Vector4(Vector2* v)
{
x = v->x;
y = v->y;
z = 0.0f;
w = 0.0f;
}

Vector4::Vector4(Color* v)
{
	x = v->r;
	y = v->g;
	z = v->b;
	w = v->a;
}

Vector4::Vector4(Quaternion* v)
{
	x = v->x;
	y = v->y;
	z = v->z;
	w = v->w;
}

Vector4* Vector4::$Operator_PLUS$(Vector4* v)
{
return v;
}


Vector4* Vector4::$Operator_MINUS$(Vector4* v)
{
return new Vector4((-v->x), (-v->y), (-v->z), (-v->w));
}


Vector4* Vector4::$Operator_PLUS$(Vector4* v0, Vector4* v)
{
return new Vector4((v0->x+v->x), (v0->y+v->y), (v0->z+v->z), (v0->w+v->w));
}


Vector4* Vector4::$Operator_MINUS$(Vector4* v0, Vector4* v)
{
return new Vector4((v0->x-v->x), (v0->y-v->y), (v0->z-v->z), (v0->w-v->w));
}


Vector4* Vector4::$Operator_TIMES$(Vector4* v, float f)
{
return new Vector4((v->x*f), (v->y*f), (v->z*f), (v->w*f));
}


Vector4* Vector4::$Operator_DIVIDE$(Vector4* v, float f)
{
return new Vector4((v->x/f), (v->y/f), (v->z/f), (v->w/f));
}


Vector4* Vector4::$Operator_TIMES$(float f, Vector4* v)
{
return new Vector4((f*v->x), (f*v->y), (f*v->z), (f*v->w));
}


Vector4* Vector4::$Operator_TIMES$(Vector4* v, Vector4* v2)
{
return new Vector4((v->x*v2->x), (v->y*v2->y), (v->z*v2->z), (v->w*v2->w));
}


Vector4* Vector4::$Operator_DIVIDE$(Vector4* v, Vector4* v2)
{
return new Vector4((v->x/v2->x), (v->y/v2->y), (v->z/v2->z), (v->w/v2->w));
}


bool Vector4::$Operator_EQUAL$(Vector4* v, Vector4* v1)
{
return ((((v1->x==v->x)&&(v1->y==v->y))&&(v1->z==v->z))&&(v1->w==v->w));
}


bool Vector4::$Operator_NOTEQUAL$(Vector4* v, Vector4* v1)
{
return ((((v1->x!=v->x)||(v1->y!=v->y))||(v1->z!=v->z))||(v1->w!=v->w));
}

void Vector4::Normalize()
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


float Vector4::Length()
{
	return (float)sqrt((x) * (x)+(y) * (y)+(z) * (z)+(w) * (w));
}

float Vector4::LengthSq()
{
	return ((((x*x) + (y*y)) + (z*z)) + (w*w));
}

Vector4* Vector4::Cross(Vector4* pv1, Vector4* pv2, Vector4* pv3)
{
	Vector4* result = new Vector4();
	result->x = (((pv1->y*(((pv2->z*pv3->w) - (pv3->z*pv2->w)))) - (pv1->z*(((pv2->y*pv3->w) - (pv3->y*pv2->w))))) + (pv1->w*(((pv2->y*pv3->z) - (pv2->z*pv3->y)))));
	result->y = (-((((pv1->x*(((pv2->z*pv3->w) - (pv3->z*pv2->w)))) - (pv1->z*(((pv2->x*pv3->w) - (pv3->x*pv2->w))))) + (pv1->w*(((pv2->x*pv3->z) - (pv3->x*pv2->z)))))));
	result->z = (((pv1->x*(((pv2->y*pv3->w) - (pv3->y*pv2->w)))) - (pv1->y*(((pv2->x*pv3->w) - (pv3->x*pv2->w))))) + (pv1->w*(((pv2->x*pv3->y) - (pv3->x*pv2->y)))));
	result->w = (-((((pv1->x*(((pv2->y*pv3->z) - (pv3->y*pv2->z)))) - (pv1->y*(((pv2->x*pv3->z) - (pv3->x*pv2->z))))) + (pv1->z*(((pv2->x*pv3->y) - (pv3->x*pv2->y)))))));
	return result;
}


float Vector4::Dot(Vector4* pv2)
{
	return ((((x*pv2->x) + (y*pv2->y)) + (z*pv2->z)) + (w*pv2->w));
}


float Vector4::Dot(Vector4* pv1, Vector4* pv2)
{
	return ((((pv1->x*pv2->x) + (pv1->y*pv2->y)) + (pv1->z*pv2->z)) + (pv1->w*pv2->w));
}


Vector4* Vector4::Lerp(Vector4* pv1, Vector4* pv2, float s)
{
	Vector4* result = new Vector4();
	result->x = ((((1 - s))*(pv1->x)) + (s*(pv2->x)));
	result->y = ((((1 - s))*(pv1->y)) + (s*(pv2->y)));
	result->z = ((((1 - s))*(pv1->z)) + (s*(pv2->z)));
	result->w = ((((1 - s))*(pv1->w)) + (s*(pv2->w)));
	return result;
}

Vector4* Vector4::Maximize(Vector4* pv1, Vector4* pv2)
{
	Vector4* result = new Vector4();
	result->x = fmaxf(pv1->x, pv2->x);
	result->x = fmaxf(pv1->y, pv2->y);
	result->x = fmaxf(pv1->z, pv2->z);
	result->x = fmaxf(pv1->w, pv2->w);
	return result;
}


Vector4* Vector4::Minimize(Vector4* pv1, Vector4* pv2)
{
	Vector4* result = new Vector4();
	result->x = fminf(pv1->x, pv2->x);
	result->x = fminf(pv1->y, pv2->y);
	result->x = fminf(pv1->z, pv2->z);
	result->x = fminf(pv1->w, pv2->w);
	return result;
}


Vector4* Vector4::Scale(Vector4* pv, float s)
{
	Vector4* result = new Vector4();
	result->x = (s*(pv->x));
	result->y = (s*(pv->y));
	result->z = (s*(pv->z));
	result->w = (s*(pv->w));
	return result;
}


void Vector4::Scale(float s)
{
	x = (s*x);
	y = (s*y);
	z = (s*z);
	w = (s*w);
}

Vector4* Vector4::Subtract(Vector4* pv1, Vector4* pv2)
{
	Vector4* result = new Vector4();
	result->x = (pv1->x - pv2->x);
	result->y = (pv1->y - pv2->y);
	result->z = (pv1->z - pv2->z);
	result->w = (pv1->w - pv2->w);
	return result;
}


void Vector4::Subtract(Vector4* pv2)
{
	x = (x - pv2->x);
	y = (y - pv2->y);
	z = (z - pv2->z);
	w = (w - pv2->w);
}


Vector4* Vector4::BaryCentric(Vector4* pv1, Vector4* pv2, Vector4* pv3, float f, float g)
{
	Vector4* result = new Vector4();
	result->x = ((((((1.0f - f) - g))*(pv1->x)) + (f*(pv2->x))) + (g*(pv3->x)));
	result->y = ((((((1.0f - f) - g))*(pv1->y)) + (f*(pv2->y))) + (g*(pv3->y)));
	result->z = ((((((1.0f - f) - g))*(pv1->z)) + (f*(pv2->z))) + (g*(pv3->z)));
	result->w = ((((((1.0f - f) - g))*(pv1->w)) + (f*(pv2->w))) + (g*(pv3->w)));
	return result;
}


Vector4* Vector4::CatmullRom(Vector4* pv0, Vector4* pv1, Vector4* pv2, Vector4* pv3, float s)
{
	Vector4* result = new Vector4();
	result->x = (0.5f*(((((2.0f*pv1->x) + (((pv2->x - pv0->x))*s)) + (((((((2.0f*pv0->x) - (5.0f*pv1->x)) + (4.0f*pv2->x)) - pv3->x))*s)*s)) + (((((((pv3->x - (3.0f*pv2->x)) + (3.0f*pv1->x)) - pv0->x))*s)*s)*s))));
	result->y = (0.5f*(((((2.0f*pv1->y) + (((pv2->y - pv0->y))*s)) + (((((((2.0f*pv0->y) - (5.0f*pv1->y)) + (4.0f*pv2->y)) - pv3->y))*s)*s)) + (((((((pv3->y - (3.0f*pv2->y)) + (3.0f*pv1->y)) - pv0->y))*s)*s)*s))));
	result->z = (0.5f*(((((2.0f*pv1->z) + (((pv2->z - pv0->z))*s)) + (((((((2.0f*pv0->z) - (5.0f*pv1->z)) + (4.0f*pv2->z)) - pv3->z))*s)*s)) + (((((((pv3->z - (3.0f*pv2->z)) + (3.0f*pv1->z)) - pv0->z))*s)*s)*s))));
	result->w = (0.5f*(((((2.0f*pv1->w) + (((pv2->w - pv0->w))*s)) + (((((((2.0f*pv0->w) - (5.0f*pv1->w)) + (4.0f*pv2->w)) - pv3->w))*s)*s)) + (((((((pv3->w - (3.0f*pv2->w)) + (3.0f*pv1->w)) - pv0->w))*s)*s)*s))));
	return result;
}


Vector4* Vector4::Hermite(Vector4* pv1, Vector4* pt1, Vector4* pv2, Vector4* pt2, float s)
{
	Vector4* result = new Vector4();
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
	result->w = ((((h1*(pv1->w)) + (h2*(pt1->w))) + (h3*(pv2->w))) + (h4*(pt2->w)));
	return result;
}

const vector<string> Vector4::mFieldNames = {"x", "y", "z", "w"};
const vector<string> Vector4::mFieldTypes = {"float", "float", "float", "float"};
const vector<string> Vector4::mFieldAccessors = {"public", "public", "public", "public"};


const char* Vector4::__GetClassName__()
{
return "Vector4";}


unsigned int Vector4::__GetFieldNum__()
{
return 4;}


const char* Vector4::__GetFieldName__(unsigned int i)
{
if (i >= mFieldNames.size())	return nullptr;else							return mFieldNames[i].c_str();}


const char* Vector4::__GetFieldType__(unsigned int i)
{
if (i >= mFieldTypes.size())	return nullptr;else							return mFieldTypes[i].c_str();}


const char* Vector4::__GetFieldAccessor__(unsigned int i)
{
if (i >= mFieldAccessors.size())	return nullptr;else								return mFieldAccessors[i].c_str();}


int Vector4::__ReadField__(string fieldName, void* ptr, int* len)
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


int Vector4::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
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