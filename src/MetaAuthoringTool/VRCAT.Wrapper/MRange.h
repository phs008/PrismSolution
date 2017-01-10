#pragma once
#include <Component/TypeBase.h>
namespace MVRWrapper
{
	public ref class MRange
	{
	private:
		Code3::Component::TypeRange* _pProperty;
	internal:
		MRange(Code3::Component::TypeRange* param);
	public:
		property float max
		{
			float get();
			void set(float val);
		}
		property float min
		{
			float get();
			void set(float val);
		}
		property float val
		{
			float get();
			void set(float val);
		}
	};
}

