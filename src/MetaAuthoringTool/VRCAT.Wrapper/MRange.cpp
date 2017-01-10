#include "MRange.h"
namespace MVRWrapper
{
	MRange::MRange(Code3::Component::TypeRange* param)
	{
		_pProperty = param;
	}
	float MRange::max::get()
	{
		return 0;
		///return _pProperty->Value.
	}
	void MRange::max::set(float val)
	{
		///_pProperty->Value.Max = val;
		_pProperty->ApplyChange();
	}
	float MRange::min::get()
	{
		return 0;
		///return _pProperty->Value.Min;
	}
	void MRange::min::set(float val)
	{
		///_pProperty->Value.Min = val;
		_pProperty->ApplyChange();
	}
	float MRange::val::get()
	{
		return 0;
		///return _pProperty->Value.Value;
	}
	void MRange::val::set(float val)
	{
		///_pProperty->Value.Value = val;
		_pProperty->ApplyChange();
	}
}
