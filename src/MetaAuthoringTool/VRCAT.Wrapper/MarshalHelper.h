#pragma once

#include <BasicType\InternString.h>

namespace MVRWrapper
{
	public ref class MarshalHelper
	{
	public:
		static System::String^ NativeStringToString(InternString val);
		static System::String^ NativeStringToString(const char* cha);
	internal:
		static InternString StringToNativeString(System::String^ val);
		static char* MarshalHelper::StringToNativeChar(System::String^ val);
		template <class T , class U>
		static bool isinst(U u)
		{
			return dynamic_cast<T>(u) != nullptr;
		}
	};
}