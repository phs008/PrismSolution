#pragma once
#include <Component\TypeBase.h>
using namespace Code3::Component;

namespace MVRWrapper
{
	public ref class MColor
	{
	private:
		TypeColor* _pProperty;
	public:
		MColor();
		MColor(float r, float g, float b, float a);
	public:
		property static MColor^ Pink
		{
			MColor^ get()
			{
				MColor^ returnVal = gcnew MColor(1.0, 0.753, 0.796, 1);
				return returnVal;
			}
		}
		property static MColor^ Black
		{
			MColor^ get()
			{
				MColor^ returnVal = gcnew MColor(0.0, 0.0, 0.0, 1);
				return returnVal;
			}
		}
		property static MColor^ Gray
		{
			MColor^ get()
			{
				MColor^ returnVal = gcnew MColor(0.502, 0.502, 0.52, 1);
				return returnVal;
			}
		}
		property static MColor^ White
		{
			MColor^ get()
			{
				MColor^ returnVal = gcnew MColor(1.0, 1.0, 1.0, 1);
				return returnVal;
			}
		}
		property static MColor^ Brown
		{
			MColor^ get()
			{
				MColor^ returnVal = gcnew MColor(0.647, 0.165, 0.165, 1);
				return returnVal;
			}
		}
		property static MColor^ Navy
		{
			MColor^ get()
			{
				MColor^ returnVal = gcnew MColor(0.0, 0.0, 0.502, 1);
				return returnVal;
			}
		}
		property static MColor^ Blue
		{
			MColor^ get()
			{
				MColor^ returnVal = gcnew MColor(0.0, 0.0, 1.0, 1);
				return returnVal;
			}
		}
		property static MColor^ Red
		{
			MColor^ get()
			{
				MColor^ returnVal = gcnew MColor(1.0, 0.0, 0.0, 1);
				return returnVal;
			}
		}
	internal:
		MColor(TypeColor* param);
		~MColor()
		{
			delete _pProperty;
		}
	public:
		property float R
		{
			float get();
			void set(float value);
		}
		property float G
		{
			float get();
			void set(float value);
		}
		property float B
		{
			float get();
			void set(float value);
		}
		property float A
		{
			float get();
			void set(float value);
		}
	};
}