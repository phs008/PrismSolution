#include "stdafx.h"
#include "MVector2.h"
#include <Math3D\Vector2.h>
using namespace Code3::Math3D;

namespace MVRWrapper
{
	MVector2::MVector2()
	{
		_pProperty = new TypeVector2();
		_pProperty->Value = Vector2(0, 0);
	}
	MVector2::MVector2(float x, float y)
		:MVector2()
	{
		_pProperty->Value = Vector2(x, y);
	}
	MVector2::MVector2(TypeVector2* _property)
	{
		_pProperty = _pProperty;
	}
	float MVector2::X::get()
	{
		return _pProperty->Value.x;
	}
	void MVector2::X::set(float value)
	{
		_pProperty->Value.x = value; 
		_pProperty->ApplyChange();
	}
	float MVector2::Y::get()
	{
		return _pProperty->Value.y;
	}
	void MVector2::Y::set(float value)
	{
		_pProperty->Value.y = value;
		_pProperty->ApplyChange();
	}
}