#include "stdafx.h"
#include "MVector4.h"
#include <Math3D\Vector4.h>
using namespace Code3::Math3D;

namespace MVRWrapper
{
	MVector4::MVector4()
	{
		_pProperty = new TypeVector4();
		_pProperty->Value = Vector4(0, 0, 0, 0);
	}
	MVector4::MVector4(float x, float y, float z, float w)
		:MVector4()
	{
		_pProperty->Value = Vector4(x, y, z, w);
	}
	MVector4::MVector4(TypeVector4* param)
	{
		_pProperty = param;
	}
	float MVector4::X::get()
	{
		return _pProperty->Value.x;
	}
	void MVector4::X::set(float param)
	{
		_pProperty->Value.x = param;
		_pProperty->ApplyChange();
	}
	float MVector4::Y::get()
	{
		return _pProperty->Value.y;
	}
	void MVector4::Y::set(float param)
	{
		_pProperty->Value.y = param;
		_pProperty->ApplyChange();
	}
	float MVector4::Z::get()
	{
		return _pProperty->Value.z;
	}
	void MVector4::Z::set(float param)
	{
		_pProperty->Value.z = param;
		_pProperty->ApplyChange();
	}
	float MVector4::W::get()
	{
		return _pProperty->Value.w;
	}
	void MVector4::W::set(float param)
	{
		_pProperty->Value.w = param;
		_pProperty->ApplyChange();
	}
}