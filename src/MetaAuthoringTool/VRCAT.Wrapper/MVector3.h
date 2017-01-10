#pragma once
#include <Component\TypeBase.h>
#include <Math3D\Vector3.h>
using namespace Code3::Component;
namespace MVRWrapper
{
	ref class MProperty;
	public ref class MVector3
	{
	private:
		TypeVector3* _pProperty;
		MProperty^ _ParentProperty;
	public:
		MVector3();
		MVector3(float x, float y, float z);
		static MVector3^ Zero()
		{
			return gcnew MVector3();
		}
	internal:
		//MVector3(MProperty^ parentProperty,TypeVector3 param);
		MVector3(TypeVector3* param);
		Code3::Math3D::Vector3 GetNativeValue();
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
	};
}