#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "Math3D.Color.h"
#include <math.h>
#include <stdlib.h>


Color* Color::Zero()
{
return new Color(0, 0, 0, 0);
}


Color::Color()
{
}


Color::Color(unsigned int col)
{
float f = (1.0f/255.0f);
r = (f*(float)(unsigned int)((col>>16)));
g = (f*(float)(unsigned int)((col>>8)));
b = (f*(float)(unsigned int)col);
a = (f*(float)(unsigned int)((col>>24)));
}


Color::Color(float fr, float fg, float fb, float fa)
{
r = fr;
g = fg;
b = fb;
a = fa;
}

Color::Color(Vector3* v)
{
	r = v->x;
	g = v->y;
	b = v->z;
	a = 1.0f;
}

Color::Color(Vector4* v)
{
	r = v->x;
	g = v->y;
	b = v->z;
	a = v->w;
}

unsigned int Color::MakeInt()
{
}


Color* Color::$Operator_PLUS$(Color* v)
{
return v;
}


Color* Color::$Operator_MINUS$(Color* v)
{
return new Color((-v->r), (-v->g), (-v->b), (-v->a));
}


Color* Color::$Operator_PLUS$(Color* v0, Color* v)
{
return new Color((v0->r+v->r), (v0->g+v->g), (v0->b+v->b), (v0->a+v->a));
}


Color* Color::$Operator_MINUS$(Color* v0, Color* v)
{
return new Color((v0->r-v->r), (v0->g-v->g), (v0->b-v->b), (v0->a-v->a));
}


Color* Color::$Operator_TIMES$(Color* v, float f)
{
return new Color((v->r*f), (v->g*f), (v->b*f), (v->a*f));
}


Color* Color::$Operator_DIVIDE$(Color* v, float f)
{
return new Color((v->r/f), (v->g/f), (v->b/f), (v->a/f));
}


Color* Color::$Operator_TIMES$(float f, Color* v)
{
return new Color((f*v->r), (f*v->g), (f*v->b), (f*v->a));
}


bool Color::$Operator_EQUAL$(Color* v, Color* v1)
{
return ((((v1->r==v->r)&&(v1->g==v->g))&&(v1->b==v->b))&&(v1->a==v->a));
}


bool Color::$Operator_NOTEQUAL$(Color* v, Color* v1)
{
return ((((v1->r!=v->r)||(v1->g!=v->g))||(v1->b!=v->b))||(v1->a!=v->a));
}


Color* Color::Scale(Color* pv, float s)
{
Color* result = new Color();
result->r = (s*(pv->r));
result->g = (s*(pv->g));
result->b = (s*(pv->b));
result->a = (s*(pv->a));
return result;
}


void Color::Scale(float s)
{
r = (s*r);
g = (s*g);
b = (s*b);
a = (s*a);
}


Color* Color::Subtract(Color* pv1, Color* pv2)
{
Color* result = new Color();
result->r = (pv1->r-pv2->r);
result->g = (pv1->g-pv2->g);
result->b = (pv1->b-pv2->b);
result->a = (pv1->a-pv2->a);
return result;
}


void Color::Subtract(Color* pv2)
{
r = (r-pv2->r);
g = (g-pv2->g);
b = (b-pv2->b);
a = (a-pv2->a);
}


Color* Color::AdjustContrast(Color* pc, float s)
{
Color* result = new Color();
result->r = (0.5f+(s*((pc->r-0.5f))));
result->g = (0.5f+(s*((pc->g-0.5f))));
result->b = (0.5f+(s*((pc->b-0.5f))));
result->a = pc->a;
return result;
}


void Color::AdjustContrast(float s)
{
r = (0.5f+(s*((r-0.5f))));
g = (0.5f+(s*((g-0.5f))));
b = (0.5f+(s*((b-0.5f))));
}


Color* Color::AdjustSaturation(Color* pc, float s)
{
Color* result = new Color();
float grey;
grey = (((pc->r*0.2125f)+(pc->g*0.7154f))+(pc->b*0.0721f));
result->r = (grey+(s*((pc->r-grey))));
result->g = (grey+(s*((pc->g-grey))));
result->b = (grey+(s*((pc->b-grey))));
result->a = pc->a;
return result;
}


void Color::AdjustSaturation(float s)
{
Color* result = AdjustSaturation(this, s);
r = result->r;
g = result->g;
b = result->b;
a = result->a;
}


Color* Color::Lerp(Color* pv1, Color* pv2, float s)
{
Color* result = new Color();
result->r = ((((1-s))*(pv1->r))+(s*(pv2->r)));
result->g = ((((1-s))*(pv1->g))+(s*(pv2->g)));
result->b = ((((1-s))*(pv1->b))+(s*(pv2->b)));
result->a = ((((1-s))*(pv1->a))+(s*(pv2->a)));
return result;
}


Color* Color::Modulate(Color* pc1, Color* pc2)
{
Color* result = new Color();
result->r = ((pc1->r)*(pc2->r));
result->g = ((pc1->g)*(pc2->g));
result->b = ((pc1->b)*(pc2->b));
result->a = ((pc1->a)*(pc2->a));
return result;
}


Color* Color::Negative()
{
Color* result = new Color();
result->r = (1.0f-r);
result->g = (1.0f-g);
result->b = (1.0f-b);
result->a = a;
return result;
}


const vector<string> Color::mFieldNames = {"r", "g", "b", "a"};
const vector<string> Color::mFieldTypes = {"float", "float", "float", "float"};
const vector<string> Color::mFieldAccessors = {"public", "public", "public", "public"};


const char* Color::__GetClassName__()
{
return "Color";}


unsigned int Color::__GetFieldNum__()
{
return 4;}


const char* Color::__GetFieldName__(unsigned int i)
{
if (i >= mFieldNames.size())	return nullptr;else							return mFieldNames[i].c_str();}


const char* Color::__GetFieldType__(unsigned int i)
{
if (i >= mFieldTypes.size())	return nullptr;else							return mFieldTypes[i].c_str();}


const char* Color::__GetFieldAccessor__(unsigned int i)
{
if (i >= mFieldAccessors.size())	return nullptr;else								return mFieldAccessors[i].c_str();}


int Color::__ReadField__(string fieldName, void* ptr, int* len)
{
if (fieldName == "r")
{
memcpy(ptr, (void*)&r, sizeof(r));*len = sizeof(r);}

if (fieldName == "g")
{
memcpy(ptr, (void*)&g, sizeof(g));*len = sizeof(g);}

if (fieldName == "b")
{
memcpy(ptr, (void*)&b, sizeof(b));*len = sizeof(b);}

if (fieldName == "a")
{
memcpy(ptr, (void*)&a, sizeof(a));*len = sizeof(a);}

return 0;}


int Color::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
{
void* buf = nullptr;

if (fieldName == "r")
{
buf = &r;}

if (fieldName == "g")
{
buf = &g;}

if (fieldName == "b")
{
buf = &b;}

if (fieldName == "a")
{
buf = &a;}

if (buf == nullptr)
{
return 1;
}

memcpy(buf, ptr, len);
return 0;}
