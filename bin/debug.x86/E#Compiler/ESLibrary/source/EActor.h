#include "EngineMath.h"


extern "C" void (*ENG_CAPI_Debugger_Log)(const char *log, int v1, float v2);
extern "C" int (*ENG_CAPI_Debugger_MsgBox)(const char *log, int type);


class EActor : public $__Object__$
{
	public:static const int MB_OK = 0x00000000L;
	public:static const int MB_OKCANCEL = 0x00000001L;
	public:static const int MB_ABORTRETRYIGNORE = 0x00000002L;
	public:static const int MB_YESNOCANCEL = 0x00000003L;
	public:static const int MB_YESNO = 0x00000004L;
	public:static const int MB_RETRYCANCEL = 0x00000005L;
	public:static const int MB_ICONHAND = 0x00000010L;
	public:static const int MB_ICONQUESTION = 0x00000020L;
	public:static const int MB_ICONEXCLAMATION = 0x00000030L;
	public:static const int MB_ICONASTERISK = 0x00000040L;

	public:static const int IDOK = 1;
	public:static const int IDCANCEL = 2;
	public:static const int IDABORT = 3;
	public:static const int IDRETRY = 4;
	public:static const int IDIGNORE = 5;
	public:static const int IDYES = 6;
	public:static const int IDNO = 7;

public :
	EActor()			= default;
	virtual ~EActor()	= default;

	virtual int Update()	{ return 0; }
	virtual int OnMessage(string msg, int arg0, Vector4 *arg1, Vector4 *arg2) { return 0; } 

	virtual const char* __GetClassName__()						{ return "EActor"; }
	virtual unsigned int __GetFieldNum__()						{ return 0; }
	virtual const char* __GetFieldName__(unsigned int i)		{ return nullptr; }
	virtual const char* __GetFieldType__(unsigned int i)		{ return nullptr; }
	virtual const char* __GetFieldAccessor__(unsigned int i)	{ return nullptr; }

	virtual int __ReadField__ (string fieldName, void* ptr, int* len)				{ return 0; }
	virtual int __WriteField__(string fieldName, void* ptr, int len, int typeInfo)	{ return 0; }

	void Log(string log, int v1, float v2) { if (ENG_CAPI_Debugger_Log) ENG_CAPI_Debugger_Log(log.c_str(), v1, v2); }
	int MsgBox( string log, int type) { if (ENG_CAPI_Debugger_MsgBox) return ENG_CAPI_Debugger_MsgBox(log.c_str(), type); else return 0; }
};
