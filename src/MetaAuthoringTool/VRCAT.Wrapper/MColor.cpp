#include "stdafx.h"
#include "MColor.h"
#include <Math3D\Color.h>
using namespace Code3::Math3D;

namespace MVRWrapper
{
	MColor::MColor()
	{
		_pProperty = new TypeColor();
		_pProperty->Value = Color(1, 1, 1, 1);
	}
	MColor::MColor(float r, float g, float b, float a)
		:MColor()
	{
		_pProperty->Value = Color(r, g, b, a);
	}
	MColor::MColor(TypeColor* param)
	{
		_pProperty = param;
		
	}
	float MColor::R::get()
	{
		return _pProperty->Value.r;
	}
	void MColor::R::set(float value)
	{
		_pProperty->Value.r = value;
		_pProperty->ApplyChange();
	}
	float MColor::G::get()
	{
		return _pProperty->Value.g;
	}
	void MColor::G::set(float value)
	{
		_pProperty->Value.g = value;
		_pProperty->ApplyChange();
	}
	float MColor::B::get()
	{
		return _pProperty->Value.b;
	}
	void MColor::B::set(float value)
	{
		_pProperty->Value.b = value;
		_pProperty->ApplyChange();
	}
	float MColor::A::get()
	{
		return _pProperty->Value.a;
	}
	void MColor::A::set(float value)
	{
		_pProperty->Value.a = value;
		_pProperty->ApplyChange();
	}
}