#include "MLogHandler.h"
#include "MarshalHelper.h"
namespace MVRWrapper
{
	MLog::MLog()
	{
		_pLoggerInstance = new WrapperLogger(this);
		Code3::Debugger::GetLogger().RegisterHandler(_pLoggerInstance);
	}
	MLog^ MLog::GetInstance()
	{
		if (_instance == nullptr)
			_instance = gcnew MLog();
		return _instance;
	}
	void MLog::GetLog(const char * message)
	{
		System::String^ returnVal = gcnew System::String(message);
		E(returnVal);
	}
	void MLog::SetLog(System::String^ message)
	{
		const char* c = MarshalHelper::StringToNativeChar(message);
		Code3::Debugger::GetLogger().Log(c);
	}
}
