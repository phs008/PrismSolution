#pragma once

#include "EngineMath.h"



#define EXTERN_C	extern "C"
#define DLLAPI		__declspec(dllexport)


EXTERN_C DLLAPI	const char*		Fl2Es_GetCompilerVersion();

EXTERN_C DLLAPI	int				Fl2Es_VRLangBegin();
EXTERN_C DLLAPI	int				Fl2Es_VRLangEnd();

EXTERN_C DLLAPI	int				Fl2Es_ExportFunction(void* fun_ptr, char* fun_name, char* fun_type);

EXTERN_C DLLAPI	void*			Fl2Es_ActorCreate(char* classname, unsigned long UID);
EXTERN_C DLLAPI	void			Fl2Es_ActorDelete(void* es_obj);

EXTERN_C DLLAPI	int				Fl2Es_ActorMethodUpdate(void* es_obj);
EXTERN_C DLLAPI	int				Fl2Es_ActorMethodOnMessage(void* es_obj, const char *msg, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2);
EXTERN_C DLLAPI	int				Fl2Es_ActorFieldRead (void* es_obj, char* fieldname, void* val, int* len);
EXTERN_C DLLAPI	int				Fl2Es_ActorFieldWrite(void* es_obj, char* fieldname, void* val, int  len, int type_info);

EXTERN_C DLLAPI	const char*		Fl2Es_GetClassName(void* ptr);
EXTERN_C DLLAPI	unsigned int	Fl2Es_GetFieldNum(void* ptr);
EXTERN_C DLLAPI	const char*		Fl2Es_GetFieldName(void* ptr, unsigned int i);
EXTERN_C DLLAPI	const char*		Fl2Es_GetFieldType(void* ptr, unsigned int i);
EXTERN_C DLLAPI	const char*		Fl2Es_GetFieldAccessor(void* ptr, unsigned int i);
