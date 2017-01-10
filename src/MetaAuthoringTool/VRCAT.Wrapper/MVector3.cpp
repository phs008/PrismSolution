#include "MVector3.h"
#include "MProperty.h"
#include <Math3D\Vector3.h>

using namespace Code3::Math3D;

namespace MVRWrapper
{
	MVector3::MVector3()
	{
		_pProperty = new TypeVector3();
		_pProperty->Value = Vector3(0, 0, 0);
		
	}
	MVector3::MVector3(float x, float y, float z)
		:MVector3()
	{
		_pProperty->Value = Vector3(x, y, z);
	}
	/*MVector3::MVector3(MProperty^ parentProperty,TypeVector3 param)
		:MVector3()
	{
		_pProperty = &param;
		_ParentProperty = parentProperty;
	}
	*/
	MVector3::MVector3(TypeVector3* param)
	{
		_pProperty = param;
	}
	float MVector3::X::get()
	{
		return _pProperty->Value.x;
	}
	void MVector3::X::set(float value)
	{
		_pProperty->Value.x = value;
		_pProperty->ApplyChange();
	}
	float MVector3::Y::get()
	{
		return _pProperty->Value.y;
	}
	void MVector3::Y::set(float value)
	{
		_pProperty->Value.y = value;
		_pProperty->ApplyChange();
	}
	float MVector3::Z::get()
	{
		return _pProperty->Value.z;
	}
	void MVector3::Z::set(float value)
	{
		_pProperty->Value.z = value;
		_pProperty->ApplyChange();
	}
	Vector3 MVector3::GetNativeValue()
	{
		return _pProperty->Value;
	}
}