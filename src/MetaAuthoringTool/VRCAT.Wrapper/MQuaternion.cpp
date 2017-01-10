#include "MQuaternion.h"
using namespace Code3::Math3D;
using namespace System;
namespace MVRWrapper
{
	MQuaternion::MQuaternion(TypeQuaternion* param)
	{
		_pProperty = param;
		///UpdateCoordinateVector();
	}
	Code3::Math3D::Quaternion MQuaternion::GetNativeValue()
	{
		return _pProperty->Value;
	}
	float MQuaternion::X::get()
	{
		Vector3 euler = Quaternion::QuaternionToEulerFloat(this->_pProperty->Value);
		float returnVal = Util::RadianToDegree(euler.x);
		return System::Math::Round(returnVal, 2);
	}
	void MQuaternion::X::set(float param)
	{
		_pProperty->Value = Code3::Quaternion::EulerDegreeToQuaternionFloat(Vector3(param, Y, Z));
		_pProperty->ApplyChange();
		
	}
	float MQuaternion::Y::get()
	{
		Vector3 euler = Quaternion::QuaternionToEulerFloat(this->_pProperty->Value);
		float returnVal = Util::RadianToDegree(euler.y);
		return System::Math::Round(returnVal, 2);
	}
	void MQuaternion::Y::set(float param)
	{
		_pProperty->Value = Code3::Quaternion::EulerDegreeToQuaternionFloat(Vector3(X, param, Z));
		_pProperty->ApplyChange();
		
	}
	float MQuaternion::Z::get()
	{
		Vector3 euler = Quaternion::QuaternionToEulerFloat(this->_pProperty->Value);
		float returnVal = Util::RadianToDegree(euler.z);
		return System::Math::Round(returnVal, 2);
	}
	void MQuaternion::Z::set(float param)
	{
		_pProperty->Value = Code3::Quaternion::EulerDegreeToQuaternionFloat(Vector3(X, Y, param));
		_pProperty->ApplyChange();
	}

	void MQuaternion::UpdateCoordinateVector()
	{
		//float sqX = _pProperty->Value.x * _pProperty->Value.x;
		//float sqY = _pProperty->Value.y * _pProperty->Value.y;
		//float sqZ = _pProperty->Value.z * _pProperty->Value.z;
		//float sqW = _pProperty->Value.w * _pProperty->Value.w;
		//_coordinateX->x = 1 - (2 * (sqY + sqZ));
		//_coordinateX->y = (2 * _pProperty->Value.x * _pProperty->Value.y) - (2 * _pProperty->Value.z * _pProperty->Value.w);
		//_coordinateX->z = (2 * _pProperty->Value.x * _pProperty->Value.z) + (2 * _pProperty->Value.y * _pProperty->Value.w);

		////_coordinateX->Normalize();

		//_coordinateY->x = (2 * _pProperty->Value.x * _pProperty->Value.y) + (2 * _pProperty->Value.z * _pProperty->Value.w);
		//_coordinateY->y = 1 - (2 * (sqX + sqZ));
		//_coordinateY->z = (2 * _pProperty->Value.y * _pProperty->Value.z) - (2 * _pProperty->Value.x * _pProperty->Value.w);

		////_coordinateY->Normalize();

		//_coordinateZ->x = (2 * _pProperty->Value.x * _pProperty->Value.z) - (2 * _pProperty->Value.y * _pProperty->Value.w);
		//_coordinateZ->y = (2 * _pProperty->Value.y * _pProperty->Value.z) + (2 * _pProperty->Value.x * _pProperty->Value.w);
		//_coordinateZ->z = 1 - (2 * (sqX + sqY));

		//_coordinateZ->Normalize();
	}
}
