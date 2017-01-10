#pragma once
#include <Debugger/Logger.h>
#include <vcclr.h>
using namespace Code3::Debugger;
namespace MVRWrapper
{
	class WrapperLogger;
	public delegate void GetLogMessage(System::String^ s);
	public ref class MLog 
	{
	private:
		static MLog^ _instance;
		WrapperLogger* _pLoggerInstance;
	private:
		MLog();
	internal:
		void GetLog(const char * message);
	public:
		static event GetLogMessage^ E;
		static MLog^ GetInstance();
		void SetLog(System::String^ message);
	};

	class WrapperLogger : public Code3::Debugger::LoggerHandler
	{
	private:
		gcroot<MLog^> _MLogInstance;
	public:
		WrapperLogger(MLog^ param)
		{
			_MLogInstance = param;
		}
		virtual bool Onclear()
		{
			return true;
		}
		virtual bool OnLog(Code3::Debugger::Logger *logger, const char * s)
		{
			_MLogInstance->GetLog(s);
			return true;
		}
	};
}

