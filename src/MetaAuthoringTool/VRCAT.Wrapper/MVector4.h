#pragma once
#include <Component\TypeBase.h>
using namespace Code3::Component;

namespace MVRWrapper
{
	public ref class MVector4
	{
	private:
		TypeVector4* _pProperty;
	public:
		MVector4();
		MVector4(float x, float y, float z, float w);
		static MVector4^ Zero()
		{
			return gcnew MVector4();
		}
	internal:
		MVector4(TypeVector4* param);
		~MVector4()
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
		property float Z
		{
			float get();
			void set(float value);
		}
		property float W
		{
			float get();
			void set(float value);
		}
	};
}