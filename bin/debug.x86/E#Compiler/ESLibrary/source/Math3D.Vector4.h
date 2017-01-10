#pragma once
#include "Math3D.Vector3.h"
#include "Math3D.Vector2.h"
#include "Math3D.Color.h"
#include "Math3D.Quaternion.h"

class Vector4 : public $__Object__$
{

public: Vector4(EngineMath3D::Vector4 v) : x(v.x), y(v.y), z(v.z), w(v.w) { }

public: float x;
public: float y;
public: float z;
public: float w;
public: static Vector4* Zero();
public: Vector4();
public: Vector4(float fx, float fy, float fz, float fw);
public: Vector4(Vector2* v);
public: Vector4(Vector3* v);
public: Vector4(Vector4* v);
public: Vector4(Color* v);
public: Vector4(Quaternion* v);
public: static Vector4* $Operator_PLUS$(Vector4* v);
public: static Vector4* $Operator_MINUS$(Vector4* v);
public: static Vector4* $Operator_PLUS$(Vector4* v0, Vector4* v);
public: static Vector4* $Operator_MINUS$(Vector4* v0, Vector4* v);
public: static Vector4* $Operator_TIMES$(Vector4* v, float f);
public: static Vector4* $Operator_DIVIDE$(Vector4* v, float f);
public: static Vector4* $Operator_TIMES$(float f, Vector4* v);
public: static Vector4* $Operator_TIMES$(Vector4* v, Vector4* v2);
public: static Vector4* $Operator_DIVIDE$(Vector4* v, Vector4* v2);
public: static bool $Operator_EQUAL$(Vector4* v, Vector4* v1);
public: static bool $Operator_NOTEQUAL$(Vector4* v, Vector4* v1);
public: void Normalize();
public: float Length();
public: float LengthSq();
public: static Vector4* Cross(Vector4* pv1, Vector4* pv2, Vector4* pv3);
public: float Dot(Vector4* pv2);
public: static float Dot(Vector4* pv1, Vector4* pv2);
public: static Vector4* Lerp(Vector4* pv1, Vector4* pv2, float s);
public: static Vector4* Maximize(Vector4* pv1, Vector4* pv2);
public: static Vector4* Minimize(Vector4* pv1, Vector4* pv2);
public: static Vector4* Scale(Vector4* pv, float s);
public: void Scale(float s);
public: static Vector4* Subtract(Vector4* pv1, Vector4* pv2);
public: void Subtract(Vector4* pv2);
public: static Vector4* BaryCentric(Vector4* pv1, Vector4* pv2, Vector4* pv3, float f, float g);
public: static Vector4* CatmullRom(Vector4* pv0, Vector4* pv1, Vector4* pv2, Vector4* pv3, float s);
public: static Vector4* Hermite(Vector4* pv1, Vector4* pt1, Vector4* pv2, Vector4* pt2, float s);
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

