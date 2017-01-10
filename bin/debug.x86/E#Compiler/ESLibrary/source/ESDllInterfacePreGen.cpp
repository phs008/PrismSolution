#include "ESharp.h"
#include "ESDllInterface.h"


int Fl2Es_VRLangEnd()
{
	return 1;
}


int Fl2Es_ExportFunction(void* fun_ptr, char* fun_name, char* fun_type)
{
	std::cout << "export-functions" << std::endl;
	return 0;
}


void Fl2Es_ActorDelete(void* actor)
{
	EActor*	eactor = (EActor*)actor;
	delete eactor;
}


int Fl2Es_ActorMethodUpdate(void* actor)
{
	EActor*	eactor = (EActor*)actor;
	return (eactor != NULL) ? eactor->Update() : 0;
}


int Fl2Es_ActorMethodOnMessage(void* actor, const char *msg, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2)
{
	EActor*	eactor = (EActor*)actor;
	return (eactor != NULL) ? eactor->OnMessage(msg, arg0, new Vector4(arg1), new Vector4(arg2) ) : 0;
}


int Fl2Es_ActorFieldRead(void* actor, char* fieldname, void* val, int* len)
{
	EActor*	eactor = (EActor*)actor;
	return (eactor != NULL) ? eactor->__ReadField__(fieldname, val, len) : 0;
}


int Fl2Es_ActorFieldWrite(void* actor, char* fieldname, void*  val, int  len, int type_info)
{
	EActor*	eactor = (EActor*)actor;
	return (eactor != NULL) ? eactor->__WriteField__(fieldname, val, len, type_info) : 0;
}


const char* Fl2Es_GetClassName(void* ptr)
{
	EActor*	obj = (EActor*)ptr;
	return (obj != NULL) ? obj->__GetClassName__() : "";
}


unsigned int Fl2Es_GetFieldNum(void* ptr)
{
	EActor*	obj = (EActor*)ptr;
	return (obj != NULL) ? obj->__GetFieldNum__() : 0;
}


const char* Fl2Es_GetFieldName(void* ptr, unsigned int i)
{
	EActor*	obj = (EActor*)ptr;
	return (obj != NULL) ? obj->__GetFieldName__(i) : "";
}


const char* Fl2Es_GetFieldType(void* ptr, unsigned int i)
{
	EActor*	obj = (EActor*) ptr;
	return (obj != NULL) ? obj->__GetFieldType__(i) : "";
}


const char* Fl2Es_GetFieldAccessor(void* ptr, unsigned int i)
{
	EActor*	obj = (EActor*) ptr;
	return (obj != NULL) ? obj->__GetFieldAccessor__(i) : "";
}
