#pragma once
#include <Component\TypeBase.h>
using namespace Code3::Component;

namespace MVRWrapper
{
	public ref class MVector2
	{
	private:
		TypeVector2* _pProperty;
	public:
		MVector2();
		MVector2(float x, float y);
		static MVector2^ Zero()
		{
			return gcnew MVector2();
		}
	internal:
		MVector2(TypeVector2* _property);
		~MVector2()
		{
			delete _pProperty;
		}
	public:
		property float X
		{
			float get();
			void set(float value);
		}
		property float Y
		{
			float get();
			void set(float value);
		}
	};
}
