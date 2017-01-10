#pragma once
#include "Math3D.Vector3.h"
#include "Math3D.Vector4.h"

class Vector2 : public $__Object__$
{
public: Vector2(EngineMath3D::Vector2 v) : x(v.x), y(v.y) {}

public: float x;
public: float y;
public: Vector2();
public: Vector2(float fx, float fy);
public: Vector2(Vector2* v);
public: Vector2(Vector3* v);
public: Vector2(Vector4* v);
public: static Vector2* Zero();
public: static Vector2* $Operator_PLUS$(Vector2* v);
public: static Vector2* $Operator_MINUS$(Vector2* v);
public: static Vector2* $Operator_PLUS$(Vector2* v0, Vector2* v);
public: static Vector2* $Operator_MINUS$(Vector2* v0, Vector2* v);
public: static Vector2* $Operator_TIMES$(Vector2* v, float f);
public: static Vector2* $Operator_DIVIDE$(Vector2* v, float f);
public: static Vector2* $Operator_TIMES$(float f, Vector2* v);
public: static Vector2* $Operator_TIMES$(Vector2* v, Vector2* v2);
public: static Vector2* $Operator_DIVIDE$(Vector2* v, Vector2* v2);
public: static bool $Operator_EQUAL$(Vector2* v, Vector2* v1);
public: static bool $Operator_NOTEQUAL$(Vector2* v, Vector2* v1);
public: void Normalize();
public: float Length();
public: float LengthSq();
public: float CCW(Vector2* pv2);
public: float Dot(Vector2* pv2);
public: static float Dot(Vector2* pv1, Vector2* pv2);
public: static Vector2* Lerp(Vector2* pv1, Vector2* pv2, float s);
public: static Vector2* Maximize(Vector2* pv1, Vector2* pv2);
public: static Vector2* Minimize(Vector2* pv1, Vector2* pv2);
public: static Vector2* Scale(Vector2* pv, float s);
public: void Scale(float s);
public: static Vector2* Subtract(Vector2* pv1, Vector2* pv2);
public: void Subtract(Vector2* pv2);
public: static Vector2* BaryCentric(Vector2* pv1, Vector2* pv2, Vector2* pv3, float f, float g);
public: static Vector2* CatmullRom(Vector2* pv0, Vector2* pv1, Vector2* pv2, Vector2* pv3, float s);
public: static Vector2* Hermite(Vector2* pv1, Vector2* pt1, Vector2* pv2, Vector2* pt2, float s);
public:
virtual const char* __GetClassName__();
virtual unsigned int __GetFieldNum__();
virtual const char* __GetFieldName__(unsigned int i);
virtual const char* __GetFieldType__(unsigned int i);
virtual const char* __GetFieldAccessor__(unsigned int i);

virtual int __ReadField__(string fieldName, void* ptr, int* len);
virtual int __WriteField__(string fieldName, void* ptr, int len, int typeInfo);

private:static const	vector<string>	mFieldNames;static const	vector<string>	mFieldTypes;static const	vector<string>	mFieldAccessors;
};

