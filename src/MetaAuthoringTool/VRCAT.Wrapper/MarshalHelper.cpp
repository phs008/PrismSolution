#include "MarshalHelper.h"
using namespace System::Runtime::InteropServices;
namespace MVRWrapper
{
	System::String^ MarshalHelper::NativeStringToString(InternString val)
	{
		char* ansiValue = val.GetString();
		System::String^ returnVal = gcnew System::String(ansiValue);
		
		return returnVal;
	}
	System::String^ MarshalHelper::NativeStringToString(const char* cha)
	{
		System::String^ returnVal = gcnew System::String(cha);
		return returnVal;
	}
	InternString MarshalHelper::StringToNativeString(System::String^ val)
	{
		char* ansiValue = (char*)Marshal::StringToHGlobalAnsi(val).ToPointer();
		InternString* returnVal = new InternString(ansiValue);
		return *returnVal;
	}
	char* MarshalHelper::StringToNativeChar(System::String^ val)
	{
		char* ansiValue = (char*)Marshal::StringToHGlobalAnsi(val).ToPointer();
		return ansiValue;
	}
}