#pragma once
#include "Math3D.Vector3.h"
#include "Math3D.Vector4.h"

class Color : public $__Object__$
{
public: Color(EngineMath3D::Color v) : r(v.r), g(v.g), b(v.b), a(v.a) { }

public: float r;
public: float g;
public: float b;
public: float a;
public: static Color* Zero();
public: Color();
public: Color(unsigned int col);
public: Color(float fr, float fg, float fb, float fa);
public: Color(Vector3* v);
public: Color(Vector4* v);
public: unsigned int MakeInt();
public: static Color* $Operator_PLUS$(Color* v);
public: static Color* $Operator_MINUS$(Color* v);
public: static Color* $Operator_PLUS$(Color* v0, Color* v);
public: static Color* $Operator_MINUS$(Color* v0, Color* v);
public: static Color* $Operator_TIMES$(Color* v, float f);
public: static Color* $Operator_DIVIDE$(Color* v, float f);
public: static Color* $Operator_TIMES$(float f, Color* v);
public: static bool $Operator_EQUAL$(Color* v, Color* v1);
public: static bool $Operator_NOTEQUAL$(Color* v, Color* v1);
public: static Color* Scale(Color* pv, float s);
public: void Scale(float s);
public: static Color* Subtract(Color* pv1, Color* pv2);
public: void Subtract(Color* pv2);
public: static Color* AdjustContrast(Color* pc, float s);
public: void AdjustContrast(float s);
public: static Color* AdjustSaturation(Color* pc, float s);
public: void AdjustSaturation(float s);
public: static Color* Lerp(Color* pv1, Color* pv2, float s);
public: static Color* Modulate(Color* pc1, Color* pc2);
public: Color* Negative();
public:
virtual const char* __GetClassName__();
virtual unsigned int __GetFieldNum__();
virtual const char* __GetFieldName__(unsigned int i);
virtual const char* __GetFieldType__(unsigned int i);
virtual const char* __GetFieldAccessor__(unsigned int i);

virtual int __ReadField__(string fieldName, void* ptr, int* len);
virtual int __WriteField__(string fieldName, void* ptr, int len, int typeInfo);

private:static const	vector<string>	mFieldNames;static const	vector<string>	mFieldTypes;static const	vector<string>	mFieldAccessors;};
