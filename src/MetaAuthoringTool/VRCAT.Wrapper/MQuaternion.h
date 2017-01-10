#pragma once
#include <Component\TypeBase.h>
#include "MVector3.h"
using namespace Code3::Component;
namespace MVRWrapper
{
	
	public ref class MQuaternion
	{
	private:
		TypeQuaternion* _pProperty;
	internal:
		MQuaternion(TypeQuaternion* param);
		Code3::Math3D::Quaternion GetNativeValue();
		void UpdateCoordinateVector();
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

