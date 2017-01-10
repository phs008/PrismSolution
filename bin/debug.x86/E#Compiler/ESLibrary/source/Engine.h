#pragma once

// predefined component id
typedef unsigned long long eng_obj_ptr;


#include "EngineMath.h"


#define COMPONENT_TRANSFORMGROUP  0
#define COMPONENT_WORLD 1
#define COMPONENT_CAMERA 2
#define COMPONENT_LIGHT 3


class ComponentBase;

//ENGINE_SCRIPT_PROPERTY #9
class PropertyInstance : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyInstance";
  }

  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }

  ComponentBase *Owner;
	int GroupIndex;

  PropertyInstance(ComponentBase *owner);
  virtual ~PropertyInstance() { } 

#include "InterfacePropertyInstanceECppMethodDecl.interface"
#include "InterfacePropertyInstanceECppMethodDeclStruct.interface"


};

#include "InterfacePropertyInstanceEFuncExternDecl.interface"


//===========================================================================================================================
//ComponentBase
class ComponentBase : public $__Object__$ 
{
public:
  virtual const char* __GetClassName__() {
    return "ComponentBase";
  }

  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }
  
public:
  eng_obj_ptr id;

  PropertyInstance *PropInstance;

  ComponentBase(eng_obj_ptr id);
  virtual ~ComponentBase();

  int KindOf(const char *className);
  string LeafClassName();

// ENGINE_SCRIPT_API #7
	Vector4* GetPropertyVector4(const char * propertyName );
  int SetPropertyVector4( const char * propertyName, Vector4* value );
  int AnimatePropertyVector4( const char * propertyName, Vector4* value, float laptime, int curveType );

  Vector3* GetPropertyVector3(const char * propertyName );
  int SetPropertyVector3( const char * propertyName, Vector3* value );

  Vector2* GetPropertyVector2(const char * propertyName);
  int SetPropertyVector2(const char * propertyName, Vector2* value);

  Color* GetPropertyColor(const char* propertyName);
  int SetPropertyColor(const char* propertyName , Color* color);

  Quaternion* GetPropertyQuaternion(const char * propertyName );
  int SetPropertyQuaternion( const char * propertyName, Quaternion* value );


  int GetPropertyInt( const char * propertyName );
  int SetPropertyInt( const char * propertyName, int value );

  float GetPropertyFloat(const char * propertyName);
  int SetPropertyFloat(const char * propertyName, float value);

  __int64 GetPropertyInt64(const char* propertyName);
  int SetPropertyInt64(const char * propertyName, __int64 value);

  double GetPropertyDouble(const char* propertyName);
  int SetPropertyDouble(const char * propertyName, double value);

  bool GetPropertyBoolean(const char * propertyName);
  int SetPropertyBoolean(const char * propertyName, bool value);


  const char * GetPropertyString( const char * propertyName );
  int SetPropertyString( const char * propertyName, const char *value );

  // Matrix GetPropertyMatrix(const char * propertyName);
  Matrix* GetPropertyMatrix(const char * propertyName);
  //  int SetPropertyMatrix(const char * propertyName, Matrix value);
  int SetPropertyMatrix(const char * propertyName, Matrix* value);


	void ApplyAllProperty();

	int SendMessage(const char *msg, int arg0, Vector4 *arg1, Vector4 *arg2);
	int PostMessage(const char *msg, int arg0, Vector4 *arg1, Vector4 *arg2);
	int TimedMessage(const char *msg, double interval, int arg0, Vector4 *arg1, Vector4 *arg2);
	int PeriodicMessage(const char *msg, double interval, int count, int arg0, Vector4 *arg1, Vector4 *arg2);
	bool CancelMessage(const char *msg);

};


EXTERN_C DLLAPI void (*ENG_CAPI_Debugger_Log)(const char *log, int v1, float v2);
EXTERN_C DLLAPI int (*ENG_CAPI_Debugger_MsgBox)(const char *log, int type);

// ENGINE_SCRIPT_API #6

EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_KindOf)(eng_obj_ptr obj, const char *className);
EXTERN_C DLLAPI const char * (*ENG_CAPI_ComponentBase_LeafClassName)(eng_obj_ptr obj);

EXTERN_C DLLAPI EngineMath3D::Vector4 (*ENG_CAPI_ComponentBase_GetPropertyVector4)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyVector4)( eng_obj_ptr obj, const char * propertyName, EngineMath3D::Vector4 value );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_AnimatePropertyVector4)( eng_obj_ptr obj, const char * propertyName, EngineMath3D::Vector4 value, float laptime, int curveType );

EXTERN_C DLLAPI EngineMath3D::Vector3 (*ENG_CAPI_ComponentBase_GetPropertyVector3)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyVector3)( eng_obj_ptr obj, const char * propertyName, EngineMath3D::Vector3 value );

EXTERN_C DLLAPI EngineMath3D::Vector2(*ENG_CAPI_ComponentBase_GetPropertyVector2)(eng_obj_ptr obj, const char * propertyName);
EXTERN_C DLLAPI int(*ENG_CAPI_ComponentBase_SetPropertyVector2)(eng_obj_ptr obj, const char * propertyName, EngineMath3D::Vector2 value);

EXTERN_C DLLAPI EngineMath3D::Color(*ENG_CAPI_ComponentBase_GetPropertyColor)(eng_obj_ptr obj, const char * propertyName);
EXTERN_C DLLAPI int(*ENG_CAPI_ComponentBase_SetPropertyColor)(eng_obj_ptr obj, const char * propertyName, EngineMath3D::Color value);

EXTERN_C DLLAPI EngineMath3D::Quaternion (*ENG_CAPI_ComponentBase_GetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName, EngineMath3D::Quaternion value );

//추가
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_GetPropertyInt)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyInt)( eng_obj_ptr obj, const char * propertyName, int value );

EXTERN_C DLLAPI float(*ENG_CAPI_ComponentBase_GetPropertyFloat)(eng_obj_ptr obj, const char * propertyName);
EXTERN_C DLLAPI int(*ENG_CAPI_ComponentBase_SetPropertyFloat)(eng_obj_ptr obj, const char * propertyName, float value);

EXTERN_C DLLAPI __int64(*ENG_CAPI_ComponentBase_GetPropertyInt64)(eng_obj_ptr obj, const char * propertyName);
EXTERN_C DLLAPI int(*ENG_CAPI_ComponentBase_SetPropertyInt64)(eng_obj_ptr obj, const char * propertyName, __int64 value);

EXTERN_C DLLAPI double(*ENG_CAPI_ComponentBase_GetPropertyDouble)(eng_obj_ptr obj, const char * propertyName);
EXTERN_C DLLAPI int(*ENG_CAPI_ComponentBase_SetPropertyDouble)(eng_obj_ptr obj, const char * propertyName, double value);

EXTERN_C DLLAPI bool (*ENG_CAPI_ComponentBase_GetPropertyBoolean)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyBoolean)( eng_obj_ptr obj, const char * propertyName, bool value );



EXTERN_C DLLAPI const char * (*ENG_CAPI_ComponentBase_GetPropertyString)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyString)( eng_obj_ptr obj, const char * propertyName, const char *value );

EXTERN_C DLLAPI  EngineMath3D::Matrix (*ENG_CAPI_ComponentBase_GetPropertyMatrix)(eng_obj_ptr obj, const char * propertyName);
EXTERN_C DLLAPI int(*ENG_CAPI_ComponentBase_SetPropertyMatrix)(eng_obj_ptr obj, const char * propertyName, EngineMath3D::Matrix value);

EXTERN_C DLLAPI void(*ENG_CAPI_ComponentBase_ApplyAllProperty)(eng_obj_ptr);

EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SendMessage)(eng_obj_ptr, const char *msg, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2);
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_PostMessage)(eng_obj_ptr, const char *msg, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2);
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_TimedMessage)(eng_obj_ptr, const char *msg, double interval, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2);
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_PeriodicMessage)(eng_obj_ptr, const char *msg, double interval, int count, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2);
EXTERN_C DLLAPI bool (*ENG_CAPI_ComponentBase_CancelMessage)(eng_obj_ptr, const char *msg);








//===========================================================================================================================
//ContainerComponent

class ContainerComponent : public ComponentBase
{
public:
  virtual const char* __GetClassName__() {
    return "ContainerComponent";
  }

  ContainerComponent(eng_obj_ptr uid);
  virtual ~ContainerComponent();

	bool OnWork(const char *command);
};


EXTERN_C DLLAPI bool (*ENG_CAPI_ContainerComponent_OnWork)(eng_obj_ptr uid, const char *command);

//===========================================================================================================================
//Container
class Container : public ComponentBase {
public:
  virtual const char* __GetClassName__() {
    return "Container";
  }

	Container():ComponentBase(0) {} 
  Container(eng_obj_ptr uid);
  virtual ~Container();

  
  ContainerComponent *GetReservedComponent(int componentID);
  ContainerComponent *FindComponentByType(const char *type);
  Container *Find(const char *objectNamePath);
  Container *GetRootContainer();
};
EXTERN_C DLLAPI eng_obj_ptr (*ENG_CAPI_Container_GetReservedComponent)(eng_obj_ptr obj,  int componentID );
EXTERN_C DLLAPI eng_obj_ptr(*ENG_CAPI_Container_FindComponentByType)(eng_obj_ptr obj, const char *type);
EXTERN_C DLLAPI eng_obj_ptr(*ENG_CAPI_Container_Find)(eng_obj_ptr obj, const char *objectNamePath);
EXTERN_C DLLAPI eng_obj_ptr(*ENG_CAPI_Container_GetRootContainer)(eng_obj_ptr obj);


//===========================================================================================================================
//PropertyTransform

class PropertyTransform : public $__Object__$ 
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyTransform";
  }

  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }

  ComponentBase *Owner;
	int GroupIndex;

  PropertyTransform(ComponentBase *owner);
  virtual ~PropertyTransform() { } 


  int GetUseUserTransform();
  void SetUseUserTransform(int useUserTransform);

  //  Matrix GetUserTransform();
  Matrix* GetUserTransform();
  //  void SetUserTransform(Matrix userTransform);
  void SetUserTransform(Matrix* userTransform);

  //  Matrix GetTransform(); // calculated transform
  Matrix *GetTransform(); // calculated transform

#include "InterfacePropertyTransformECppMethodDecl.interface"
#include "InterfacePropertyTransformECppMethodDeclStruct.interface"
	
};

#include "InterfacePropertyTransformEFuncExternDecl.interface"



EXTERN_C DLLAPI int(*ENG_CAPI_PropertyTransform_GetUseUserTransform)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransform_SetUseUserTransform)(eng_obj_ptr obj, int useUserTransform);

EXTERN_C DLLAPI EngineMath3D::Matrix(*ENG_CAPI_PropertyTransform_GetUserTransform)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransform_SetUserTransform)(eng_obj_ptr obj, EngineMath3D::Matrix userTransform);

EXTERN_C DLLAPI EngineMath3D::Matrix(*ENG_CAPI_PropertyTransform_GetTransform)(eng_obj_ptr obj);

//===========================================================================================================================
//TransformGroup


class TransformGroup : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "TransformGroup";
  }
  
public:
  TransformGroup(eng_obj_ptr uid);
  virtual ~TransformGroup() {} 

  PropertyTransform *PropTransform;


  //  void SetLocalRotation(Quaternion q);
  void SetLocalRotation(Quaternion* q);
  //  void LookAtLocalDirection(Vector3 direction);
  void LookAtLocalDirection(Vector3* direction);
  //  void LookAtPosition(Vector3 position);
  void LookAtPosition(Vector3* position);
  //  void LookAt(Vector3 position, Vector3 target, Vector3 up);
  void LookAt(Vector3* position, Vector3* target, Vector3* up);
  //  void ShiftPosition(Vector3 shift);
  void ShiftPosition(Vector3* shift);
  //  void ViewTop(Vector3 target, float distance);
  void ViewTop(Vector3* target, float distance);
  //  void ViewBottom(Vector3 target, float distance);
  void ViewBottom(Vector3* target, float distance);
  

  //  void ViewLeft(Vector3 target, float distance);
  void ViewLeft(Vector3* target, float distance);
  //  void ViewRight(Vector3 target, float distance);
  void ViewRight(Vector3* target, float distance);
  //  void ViewFront(Vector3 target, float distance);
  void ViewFront(Vector3* target, float distance);
  //  void ViewRear(Vector3 target, float distance);
  void ViewRear(Vector3* target, float distance);
  void MoveForward(float dist);
  //  void Rotate(float x, float y, Vector3 center);
  void Rotate(float x, float y, Vector3* center);
  //  void SetScale(Vector3 scale);
  void SetScale(Vector3* scale);
  //  void SetPosition(Vector3 pos);
  void SetPosition(Vector3* pos);
  //  void SetLocalPosition(Vector3 pos);
  void SetLocalPosition(Vector3* pos);

  //  Quaternion GetLocalRotation();
  Quaternion* GetLocalRotation();

  //  Vector3 GetScale();
  Vector3* GetScale();
  //  Vector3 GetLocalPosition();
  Vector3* GetLocalPosition();
  //  Vector3 GetLocalScale();
  Vector3* GetLocalScale();
  //  Vector3 GetPosition();
  Vector3* GetPosition();
  //int  GetPosition();
  
  //Vector3 GetDirection();
  Vector3* GetDirection();
  //  Vector3 GetUp();
  Vector3* GetUp();
  //  Vector3 GetTarget();
  Vector3* GetTarget();
  //  Vector3 WorldToLocalPosition(Vector3 world);
  Vector3* WorldToLocalPosition( Vector3* world);
  //  Vector3 WorldToLocalDirection(Vector3 world);
  Vector3* WorldToLocalDirection(Vector3* world);
  //  Vector3 LocalToWorldPosition(Vector3 local);
  Vector3* LocalToWorldPosition( Vector3* local);
  //  Vector3 LocalToWorldDirection(Vector3 local);
  Vector3* LocalToWorldDirection( Vector3* local);

  int IsVisible();
  int IsTransparent();
  int IsCullable();
  //  Vector3* <== ref type ??
  //  int FindNearCollision(Vector3 posfrom, Vector3 posto, Vector3* intersectnew, float* dist);
  int FindNearCollision(Vector3* posfrom, Vector3* posto, Vector3*& intersectnew, float* dist);
  //  TransformGroup* FindNearestCollision(Vector3 from, Vector3 to, Vector3* intersect,  float* distr);
  TransformGroup* FindNearestCollision(Vector3* from, Vector3* to, Vector3*& intersect,  float* distr);


  //void* GetWorld();

  //  BoundingBox GetLocalBox();
  BoundingBox* GetLocalBox();
  //  BoundingBox GetWorldBox(); //
  BoundingBox* GetWorldBox(); //
  //  BoundingBox GetSumBox();
  BoundingBox* GetSumBox();
};

EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr obj );
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_SetLocalRotation)(eng_obj_ptr obj, EngineMath3D::Quaternion q);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_LookAtLocalDirection)(eng_obj_ptr obj, EngineMath3D::Vector3 direction);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_LookAtPosition)(eng_obj_ptr obj, EngineMath3D::Vector3 position);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_LookAt)(eng_obj_ptr obj, EngineMath3D::Vector3 position, EngineMath3D::Vector3 target, EngineMath3D::Vector3 up);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ShiftPosition)(eng_obj_ptr obj, EngineMath3D::Vector3 shift);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewTop)(eng_obj_ptr obj, EngineMath3D::Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewBottom)(eng_obj_ptr obj, EngineMath3D::Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewLeft)(eng_obj_ptr obj, EngineMath3D::Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewRight)(eng_obj_ptr obj, EngineMath3D::Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewFront)(eng_obj_ptr obj, EngineMath3D::Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewRear)(eng_obj_ptr obj, EngineMath3D::Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_MoveForward)(eng_obj_ptr obj, float dist);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_Rotate)(eng_obj_ptr obj, float x, float y, EngineMath3D::Vector3 center);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_SetScale)(eng_obj_ptr obj, EngineMath3D::Vector3 scale);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_SetPosition)(eng_obj_ptr obj, EngineMath3D::Vector3 pos);
EXTERN_C DLLAPI EngineMath3D::Quaternion(*ENG_CAPI_TransformGroup_GetLocalRotation)(eng_obj_ptr obj);
EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_GetScale)(eng_obj_ptr obj);
EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_GetLocalPosition)(eng_obj_ptr obj);
EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_GetLocalScale)(eng_obj_ptr obj);
EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_GetUp)(eng_obj_ptr obj);
EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_GetTarget)(eng_obj_ptr obj);
EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_WorldToLocalPosition)(eng_obj_ptr obj, EngineMath3D::Vector3 world);
EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_WorldToLocalDirection)(eng_obj_ptr obj, EngineMath3D::Vector3 world);
EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_LocalToWorldPosition)(eng_obj_ptr obj, EngineMath3D::Vector3 local);
EXTERN_C DLLAPI EngineMath3D::Vector3(*ENG_CAPI_TransformGroup_LocalToWorldDirection)(eng_obj_ptr obj, EngineMath3D::Vector3 local);
EXTERN_C DLLAPI int(*ENG_CAPI_TransformGroup_IsVisible)(eng_obj_ptr obj);
EXTERN_C DLLAPI int(*ENG_CAPI_TransformGroup_IsTransparent)(eng_obj_ptr obj);
EXTERN_C DLLAPI int(*ENG_CAPI_TransformGroup_IsCullable)(eng_obj_ptr obj);

EXTERN_C DLLAPI int(*ENG_CAPI_TransformGroup_FindNearCollision)(eng_obj_ptr obj, EngineMath3D::Vector3 posfrom, EngineMath3D::Vector3 posto, EngineMath3D::Vector3* intersectnew, float* dist);
EXTERN_C DLLAPI eng_obj_ptr(*ENG_CAPI_TransformGroup_FindNearestCollision)(eng_obj_ptr obj, EngineMath3D::Vector3 from, EngineMath3D::Vector3 to, EngineMath3D::Vector3* intersect, float* distr);

EXTERN_C DLLAPI EngineMath3D::BoundingBox(*ENG_CAPI_TransformGroup_GetLocalBox)(eng_obj_ptr obj);
EXTERN_C DLLAPI EngineMath3D::BoundingBox(*ENG_CAPI_TransformGroup_GetWorldBox)(eng_obj_ptr obj);
EXTERN_C DLLAPI EngineMath3D::BoundingBox(*ENG_CAPI_TransformGroup_GetSumBox)(eng_obj_ptr obj);


	

	



//===========================================================================================================================
// Q 2016.8.11

// Property Camera 미러 클래스
class PropertyCamera : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyCamera";
  }

  virtual unsigned int __GetFieldNum__() {
    return 0;
  }

  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }

  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }

  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }

  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }

  ComponentBase *Owner;
	int GroupIndex;

  PropertyCamera(ComponentBase *owner);
  virtual ~PropertyCamera();


#include "InterfacePropertyCameraECppMethodDecl.interface"
#include "InterfacePropertyCameraECppMethodDeclStruct.interface"


};

#include "InterfacePropertyCameraEFuncExternDecl.interface"




//===========================================================================================================================

// 카메라 미러 클래스
class Camera : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "Camera";
  }

public:
  Camera(eng_obj_ptr uid);
  virtual ~Camera() {}

  bool PrepareInterface();

  PropertyCamera *PropCamera;

  // 투영 매트릭스를 반환한다
  //  Matrix GetProjectionMatrix();
  Matrix* GetProjectionMatrix();

  // 뷰 매트릭스를 반환한다
  // Matrix GetViewMatrix();
  Matrix* GetViewMatrix();

  // 뷰 매트릭스와 투영 매트릭스의 곱을 반환한다
  // Matrix GetViewProjectionMatrix();
  Matrix* GetViewProjectionMatrix();

  // x, y : 화면상의 마우스 포지션
  // width, height : 화면의 넓이와 길이
  // length : 반환되는 ray의 길이
  // pickRayOrig, pickRayDir : 함수의 반환값 레이의 시작 위치와 레이의 방향 및 크기를 반환한다
  //  bool GetPickRay(int x, int y, int width, int height, float length, Vector3 &pickRayOrig, Vector3 &pickRayDir);
  bool GetPickRay(int x, int y, int width, int height, float length, Vector3*& pickRayOrig, Vector3*& pickRayDir);

  // 뷰 매트릭스를 생성한다
  bool SetupView(int w, int h); // update view matrix;

  // 카메라 수평 이동
  void Pan(float x, float y);

	// world를 camera 좌표계로
	Vector4* WorldCoordToScreenCoord(Vector3 *v);

	// camera를 world 좌표계로 (ViewCoord 임 -1.0 .. 0.0)
	Vector3* ScreenCoordToWorldCoord(Vector3 *v);
};

// Q 2016.8.11
EXTERN_C DLLAPI int(*ENG_CAPI_Camera_PrepareInterface)(eng_obj_ptr);
EXTERN_C DLLAPI int(*ENG_CAPI_Camera_GetPickRay)(eng_obj_ptr, int, int, int, int, float, EngineMath3D::Vector3&, EngineMath3D::Vector3&);
EXTERN_C DLLAPI int(*ENG_CAPI_Camera_SetupView)(eng_obj_ptr, int, int);
EXTERN_C DLLAPI void(*ENG_CAPI_Camera_Pan)(eng_obj_ptr, float, float);
EXTERN_C DLLAPI EngineMath3D::Matrix(*ENG_CAPI_Camera_GetProjectionMatrix)(eng_obj_ptr);
EXTERN_C DLLAPI EngineMath3D::Matrix(*ENG_CAPI_Camera_GetViewMatrix)(eng_obj_ptr);
EXTERN_C DLLAPI EngineMath3D::Matrix(*ENG_CAPI_Camera_GetViewProjectionMatrix)(eng_obj_ptr);
EXTERN_C DLLAPI EngineMath3D::Vector4 (*ENG_CAPI_Camera_WorldCoordToScreenCoord)(eng_obj_ptr, EngineMath3D::Vector3);
EXTERN_C DLLAPI EngineMath3D::Vector3 (*ENG_CAPI_Camera_ScreenCoordToWorldCoord)(eng_obj_ptr, EngineMath3D::Vector3);


// obsolete set

//EXTERN_C DLLAPI int  (*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr);
//EXTERN_C DLLAPI int (*PTransformSetPropertyVector3)(int obj, const char *propName, float x, float y, float z);
//EXTERN_C DLLAPI int (*PTransformGetPropertyVector3)(int obj, const char *propName, float *x, float *y, float *z);
//EXTERN_C DLLAPI void*       (*ENG_CAPI_TransformGroup_GetWorld)(eng_obj_ptr);

//===========================================================================================================================


//CSI 0811
class PropertyLight: public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyLight";
  }

  virtual unsigned int __GetFieldNum__() {
    return 0;
  }

  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }

  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }

  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }

  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }

  ComponentBase *Owner;
	int GroupIndex;

  PropertyLight(ComponentBase *owner);
  virtual ~PropertyLight() { }


#include "InterfacePropertyLightECppMethodDecl.interface"
#include "InterfacePropertyLightECppMethodDeclStruct.interface"


};

#include "InterfacePropertyLightEFuncExternDecl.interface"



//===========================================================================================================================


class Light : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "Light";
  }

public:
  Light(eng_obj_ptr uid);
  virtual ~Light() {}

  PropertyLight *PropLight;


  //  BoundingBox GetLocalBox();
  BoundingBox* GetLocalBox();
};


EXTERN_C DLLAPI EngineMath3D::BoundingBox (*ENG_CAPI_Light_GetLocalBox)(eng_obj_ptr obj);


//===========================================================================================================================

class PropertyFog : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyFog";
  }


  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }

public:
  PropertyFog(ComponentBase *owner);
  virtual ~PropertyFog();

  ComponentBase *Owner;
	int GroupIndex;

#include "InterfacePropertyFogECppMethodDecl.interface"
#include "InterfacePropertyFogECppMethodDeclStruct.interface"


};

#include "InterfacePropertyFogEFuncExternDecl.interface"


//===========================================================================================================================


//World 

class World : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "World";
  }

  World(eng_obj_ptr uid);
  virtual ~World() {} 


  PropertyFog *PropFog; 
  Camera *GetDefaultCamera();
	float GetTime();
	float GetFrameElapseTime();
	void TimerSetSpeed(float speed);
	void TimerStart();
	void TimerStop();

};



EXTERN_C DLLAPI eng_obj_ptr (*ENG_CAPI_World_GetDefaultCamera)(eng_obj_ptr obj);
EXTERN_C DLLAPI float (*ENG_CAPI_World_GetTime)(eng_obj_ptr obj);
EXTERN_C DLLAPI float (*ENG_CAPI_World_GetFrameElapseTime)(eng_obj_ptr obj);
EXTERN_C DLLAPI void (*ENG_CAPI_World_TimerSetSpeed)(eng_obj_ptr obj, float speed);
EXTERN_C DLLAPI void (*ENG_CAPI_World_TimerStart)(eng_obj_ptr obj);
EXTERN_C DLLAPI void (*ENG_CAPI_World_TimerStop)(eng_obj_ptr obj);



//===========================================================================================================================

class PropertyMaterial : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyMaterial";
  }

  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }
public:

  PropertyMaterial(ComponentBase *owner);
  virtual ~PropertyMaterial();

  ComponentBase *Owner;
	int GroupIndex;
#include "InterfacePropertyMaterialECppMethodDecl.interface"
#include "InterfacePropertyMaterialECppMethodDeclStruct.interface"


};

#include "InterfacePropertyMaterialEFuncExternDecl.interface"




//===========================================================================================================================

class PropertyFbxFile : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyFbxFile";
  }



  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }
public:

  PropertyFbxFile(ComponentBase *owner);
  virtual ~PropertyFbxFile();

  ComponentBase *Owner;
	int GroupIndex;

#include "InterfacePropertyFbxFileECppMethodDecl.interface"
#include "InterfacePropertyFbxFileECppMethodDeclStruct.interface"


};

#include "InterfacePropertyFbxFileEFuncExternDecl.interface"




//===========================================================================================================================

class PropertyFbxAnimation : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyFbxAnimation";
  }



  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }
public:

  PropertyFbxAnimation(ComponentBase *owner);
  virtual ~PropertyFbxAnimation();

  ComponentBase *Owner;
	int GroupIndex;

#include "InterfacePropertyFbxAnimationECppMethodDecl.interface"
#include "InterfacePropertyFbxAnimationECppMethodDeclStruct.interface"


};

#include "InterfacePropertyFbxAnimationEFuncExternDecl.interface"



//===========================================================================================================================


class PropertyFbxNodeMesh : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyFbxNodeMesh";
  }




  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }
public:
  //	static Component::PropertyDefault DefaultValue;

  PropertyFbxNodeMesh(ComponentBase *owner);
  virtual ~PropertyFbxNodeMesh();

  ComponentBase *Owner;
	int GroupIndex;

#include "InterfacePropertyFbxNodeMeshECppMethodDecl.interface"
#include "InterfacePropertyFbxNodeMeshECppMethodDeclStruct.interface"


};

#include "InterfacePropertyFbxNodeMeshEFuncExternDecl.interface"



//===========================================================================================================================

class Fbx : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "Fbx";
  }

public:
  Fbx(eng_obj_ptr uid);
  virtual ~Fbx();

  PropertyFbxFile *PropFbxFile; 
	PropertyFbxAnimation *PropFbxAnimation;

  void Play();
  void Pause();
  void Stop();

  void ClearActiveAnimation();
  bool SetActiveAnimation(const char *animationName);
  bool SetActiveAnimation(int idx);

  void UpdateAnimationEnumerator();

  bool IsFbxVisible();
  bool IsFbxTransparent();

  void CheckFbxFlip();

  int GetAnimationMode();
  void SetAnimationMode(int mode);

  int GetActiveAnimationIndex();
  void SetActiveAnimationIndex(int index);

  int GetAnimationCurrentTime();
  void SetAnimationCurrentTime(int time);

};




EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_Play)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_Pause)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_Stop)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_ClearActiveAnimation)(eng_obj_ptr obj);
EXTERN_C DLLAPI int(*ENG_CAPI_Fbx_SetActiveAnimationByName)(eng_obj_ptr obj, const char *animationName);
EXTERN_C DLLAPI int(*ENG_CAPI_Fbx_SetActiveAnimationByIndex)(eng_obj_ptr obj, int idx);
EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_UpdateAnimationEnumerator)(eng_obj_ptr obj);
EXTERN_C DLLAPI int (*ENG_CAPI_Fbx_IsFbxVisible)(eng_obj_ptr obj);
EXTERN_C DLLAPI int (*ENG_CAPI_Fbx_IsFbxTransparent)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_CheckFbxFlip)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_CheckFbxFlip)(eng_obj_ptr obj);
EXTERN_C DLLAPI int(*ENG_CAPI_Fbx_GetAnimationMode)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_SetAnimationMode)(eng_obj_ptr obj, int mode);
EXTERN_C DLLAPI int(*ENG_CAPI_Fbx_GetActiveAnimationIndex)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_SetActiveAnimationIndex)(eng_obj_ptr obj, int index);
EXTERN_C DLLAPI int(*ENG_CAPI_Fbx_GetAnimationCurrentTime)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_SetAnimationCurrentTime)(eng_obj_ptr obj, int time);


//===========================================================================================================================



class FbxNodeBase : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "FbxNodeBase";
  }

public:

  FbxNodeBase(eng_obj_ptr uid);
  virtual ~FbxNodeBase();

  PropertyFbxFile *PropFbxFile; 
};



//===========================================================================================================================


class FbxNodeRoot : public FbxNodeBase {
public:
  virtual const char* __GetClassName__() {
    return "FbxNodeRoot";
  }

public:
  FbxNodeRoot(eng_obj_ptr uid);
  virtual ~FbxNodeRoot();

};




//===========================================================================================================================

class FbxNodeBone : public FbxNodeBase {
public:
  virtual const char* __GetClassName__() {
    return "FbxNodeBone";
  }

public:
  FbxNodeBone(eng_obj_ptr uid);
  virtual ~FbxNodeBone();

};




//===========================================================================================================================


class FbxNodeMesh : public FbxNodeBase {
public:
  virtual const char* __GetClassName__() {
    return "FbxNodeMesh";
  }

public:
  FbxNodeMesh(eng_obj_ptr uid);
  virtual ~FbxNodeMesh();

  PropertyFbxNodeMesh *PropFbxNodeMesh; 
  PropertyMaterial *PropMaterial; 
};











//===========================================================================================================================

class PropertyScript : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyScript";
  }

  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }
public:

  PropertyScript(ComponentBase *owner);
  virtual ~PropertyScript();

  ComponentBase *Owner;
	int GroupIndex;

#include "InterfacePropertyScriptECppMethodDecl.interface"
#include "InterfacePropertyScriptECppMethodDeclStruct.interface"


};

#include "InterfacePropertyScriptEFuncExternDecl.interface"



class ScriptComponent : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "ScriptComponent";
  }

public:
  ScriptComponent(eng_obj_ptr uid);
  virtual ~ScriptComponent() {}

  PropertyScript *PropScript;

};


//===========================================================================================================================

class PropertySound: public $__Object__$
{
public:
	virtual const char* __GetClassName__() {
		return "PropertySound";
	}

	virtual unsigned int __GetFieldNum__() {
		return 0;
	}

	virtual const char* __GetFieldName__(unsigned int i) {
		return NULL;
	}

	virtual const char* __GetFieldType__(unsigned int i) {
		return NULL;
	}

	virtual int __ReadField__(string fieldname, void* ptr, int* len) {
		return 0;
	}

	virtual int __WriteField__(string fieldname, void* ptr, int len) {
		return 0;
	}
public:

	PropertySound(ComponentBase *owner);
	virtual ~PropertySound();

	ComponentBase *Owner;
	int GroupIndex;
#include "InterfacePropertySoundECppMethodDecl.interface"
#include "InterfacePropertySoundECppMethodDeclStruct.interface"
};

#include "InterfacePropertySoundEFuncExternDecl.interface"



class Sound : public ContainerComponent {
public:
	virtual const char* __GetClassName__() {
		return "Sound";
	}

public:
	Sound(eng_obj_ptr uid);
	virtual ~Sound() {}

	PropertySound *PropSound;

	bool  PlayWave();

};

EXTERN_C DLLAPI bool(*ENG_CAPI_Sound_PlayWave)(eng_obj_ptr obj);


//===========================================================================================================================

class PropertyKinectSkeleton : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyKinectSkeleton";
  }

  virtual unsigned int __GetFieldNum__() {
    return 0;
  }
  
  virtual const char* __GetFieldName__(unsigned int i) {
    return NULL;
  }
  
  virtual const char* __GetFieldType__(unsigned int i) {
    return NULL;
  }
  
  virtual int __ReadField__(string fieldname, void* ptr, int* len) {
    return 0;
  }
  
  virtual int __WriteField__(string fieldname, void* ptr, int len) {
    return 0;
  }
public:

  PropertyKinectSkeleton(ComponentBase *owner);
  virtual ~PropertyKinectSkeleton();

  ComponentBase *Owner;
	int GroupIndex;

#include "InterfacePropertyKinectSkeletonECppMethodDecl.interface"
#include "InterfacePropertyKinectSkeletonECppMethodDeclStruct.interface"


};

#include "InterfacePropertyKinectSkeletonEFuncExternDecl.interface"





class KinectSkeletonComponent : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "KinectSkeletonComponent";
  }

public:
  KinectSkeletonComponent(eng_obj_ptr uid);
  virtual ~KinectSkeletonComponent() {}

  PropertyKinectSkeleton *PropKinectSkeleton;

};



//===========================================================================================================================


class PropertyKinectImage: public $__Object__$
{
public:
	virtual const char* __GetClassName__() {
		return "PropertyKinectImage";
	}

	virtual unsigned int __GetFieldNum__() {
		return 0;
	}

	virtual const char* __GetFieldName__(unsigned int i) {
		return NULL;
	}

	virtual const char* __GetFieldType__(unsigned int i) {
		return NULL;
	}

	virtual int __ReadField__(string fieldname, void* ptr, int* len) {
		return 0;
	}

	virtual int __WriteField__(string fieldname, void* ptr, int len) {
		return 0;
	}
public:

	PropertyKinectImage(ComponentBase *owner);
	virtual ~PropertyKinectImage();

	ComponentBase *Owner;
	int GroupIndex;

//#include "InterfacePropertyKinectSkeletonECppMethodDecl.interface"
//#include "InterfacePropertyKinectSkeletonECppMethodDeclStruct.interface"


};

//#include "InterfacePropertyKinectSkeletonEFuncExternDecl.interface"





class KinectImageComponent : public ContainerComponent {
public:
	virtual const char* __GetClassName__() {
		return "KinectImageComponent";
	}

public:
	KinectImageComponent(eng_obj_ptr uid);
	virtual ~KinectImageComponent() {}

	PropertyKinectImage *PropKinectImage;

};




