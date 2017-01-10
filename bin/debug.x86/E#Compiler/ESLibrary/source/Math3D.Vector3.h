#pragma once
#include "Math3D.Vector2.h"
#include "Math3D.Vector4.h"
#include "Math3D.Color.h"

class Vector3 : public $__Object__$
{
public: Vector3(EngineMath3D::Vector3 v) : x(v.x), y(v.y), z(v.z) { }
public: float x;
public: float y;
public: float z;
public: static Vector3* Zero();
public: Vector3();
public: Vector3(float fx, float fy, float fz);
public: Vector3(Vector2* v);
public: Vector3(Vector3* v);
public: Vector3(Vector4* v);
public: Vector3(Color* v);
public: static Vector3* $Operator_PLUS$(Vector3* v);
public: static Vector3* $Operator_MINUS$(Vector3* v);
public: static Vector3* $Operator_PLUS$(Vector3* v0, Vector3* v);
public: static Vector3* $Operator_MINUS$(Vector3* v0, Vector3* v);
public: static Vector3* $Operator_TIMES$(Vector3* v, float f);
public: static Vector3* $Operator_DIVIDE$(Vector3* v, float f);
public: static Vector3* $Operator_TIMES$(float f, Vector3* v);
public: static Vector3* $Operator_TIMES$(Vector3* v, Vector3* v2);
public: static Vector3* $Operator_DIVIDE$(Vector3* v, Vector3* v2);
public: static bool $Operator_EQUAL$(Vector3* v, Vector3* v1);
public: static bool $Operator_NOTEQUAL$(Vector3* v, Vector3* v1);
public: void Normalize();
public: float Length();
public: float LengthSq();
public: static Vector3* Cross(Vector3* pv1, Vector3* pv2);
public: void Cross(Vector3* pv2);
public: float Dot(Vector3* pv2);
public: static float Dot(Vector3* pv1, Vector3* pv2);
public: static Vector3* Lerp(Vector3* pv1, Vector3* pv2, float s);
public: static Vector3* Maximize(Vector3* pv1, Vector3* pv2);
public: static Vector3* Minimize(Vector3* pv1, Vector3* pv2);
public: static Vector3* Scale(Vector3* pv, float s);
public: void Scale(float s);
public: static Vector3* Subtract(Vector3* pv1, Vector3* pv2);
public: void Subtract(Vector3* pv2);
public: static Vector3* BaryCentric(Vector3* pv1, Vector3* pv2, Vector3* pv3, float f, float g);
public: static Vector3* CatmullRom(Vector3* pv0, Vector3* pv1, Vector3* pv2, Vector3* pv3, float s);
public: static Vector3* Hermite(Vector3* pv1, Vector3* pt1, Vector3* pv2, Vector3* pt2, float s);
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
