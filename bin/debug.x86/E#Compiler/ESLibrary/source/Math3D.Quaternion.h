#pragma once
#include "Math3D.Vector3.h"

class Quaternion : public $__Object__$
{
public: Quaternion(EngineMath3D::Quaternion v) : x(v.x), y(v.y), z(v.z), w(v.w) { }

public: float x;
public: float y;
public: float z;
public: float w;
public: static Quaternion* Identity();
public: Quaternion();
public: Quaternion(float fx, float fy, float fz, float fw);
public: Quaternion(Quaternion* v);
public: bool IsIdentity();
public: static Quaternion* $Operator_PLUS$(Quaternion* v);
public: static Quaternion* $Operator_MINUS$(Quaternion* v);
public: static Quaternion* $Operator_PLUS$(Quaternion* v0, Quaternion* v);
public: static Quaternion* $Operator_MINUS$(Quaternion* v0, Quaternion* v);
public: static Quaternion* $Operator_TIMES$(Quaternion* v, float f);
public: static Quaternion* $Operator_DIVIDE$(Quaternion* v, float f);
public: static Quaternion* $Operator_TIMES$(float f, Quaternion* v);
public: static bool $Operator_EQUAL$(Quaternion* v, Quaternion* v1);
public: static bool $Operator_NOTEQUAL$(Quaternion* v, Quaternion* v1);
public: void Normalize();
public: float Length();
public: float LengthSq();
public: static Quaternion* Cross(Quaternion* pv1, Quaternion* pv2, Quaternion* pv3);
public: float Dot(Quaternion* pv2);
public: static float Dot(Quaternion* pv1, Quaternion* pv2);
public: static Quaternion* Maximize(Quaternion* pv1, Quaternion* pv2);
public: static Quaternion* Minimize(Quaternion* pv1, Quaternion* pv2);
public: static Quaternion* Scale(Quaternion* pv, float s);
public: void Scale(float s);
public: static Quaternion* Subtract(Quaternion* pv1, Quaternion* pv2);
public: void Subtract(Quaternion* pv2);
public: static Quaternion* Multiply(Quaternion* pq1, Quaternion* pq2);
public: static Quaternion* $Operator_TIMES$(Quaternion* pq1, Quaternion* pq2);
public: void Multiply(Quaternion* pq2);
public: static Quaternion* BaryCentric(Quaternion* pq1, Quaternion* pq2, Quaternion* pq3, float f, float g);
public: static Quaternion* Slerp(Quaternion* pq1, Quaternion* pq2, float t);
private: Quaternion* Exp();
private: Quaternion* Inverse();
private: Quaternion* Ln();
public: static Quaternion* RotationAxis(Vector3* pv, float angle);
public: static Quaternion* RotationYawPitchRoll(float yaw, float pitch, float roll);
public: static Quaternion* Squad(Quaternion* pq1, Quaternion* pq2, Quaternion* pq3, Quaternion *pq4, float t);
public: void ToAxisAngle(Vector3*& paxis, float& pangle);
public: Quaternion* Conjugate();
public: static EulerToQuaternion(Vector3* euler);
public: Quaternion* EulerToQuaternionFloat(Vector3* euler);
public: Quaternion* EulerToQuaternion2(Vector3* euler);
public: Quaternion* EulerToQuaternionFloat2(Vector3* euler);
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
