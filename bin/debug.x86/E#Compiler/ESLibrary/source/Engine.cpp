#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"


//#include "Math3D.Vector2.cpp"

#include "EngineMath.cpp"


//전역 함수 포인터
//===========================================================
//PropertyInstance 구현 



PropertyInstance::PropertyInstance(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}
//ENGINE_SCRIPT_PROPERTY #7
#include "InterfacePropertyInstanceEFuncDecl.interface"
#include "InterfacePropertyInstanceECppMethodImpl.interface"
#include "InterfacePropertyInstanceECppMethodImplStruct.interface"



//================================================================================
//Component Base 
void (*ENG_CAPI_Debugger_Log)(const char *log, int v1, float v2) = NULL;
int (*ENG_CAPI_Debugger_MsgBox)(const char *log, int type) = NULL;


// ENGINE_SCRIPT_API #8 
//================================================================================
//Component Base 
int (*ENG_CAPI_ComponentBase_KindOf)(eng_obj_ptr obj, const char *className) = NULL;
const char *(*ENG_CAPI_ComponentBase_LeafClassName)(eng_obj_ptr obj) = NULL;

EngineMath3D::Vector4 (*ENG_CAPI_ComponentBase_GetPropertyVector4)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyVector4)( eng_obj_ptr obj, const char * propertyName, EngineMath3D::Vector4 value ) = NULL;
int (*ENG_CAPI_ComponentBase_AnimatePropertyVector4)( eng_obj_ptr obj, const char * propertyName, EngineMath3D::Vector4 value, float laptime, int curveType ) = NULL;

EngineMath3D::Vector3 (*ENG_CAPI_ComponentBase_GetPropertyVector3)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyVector3)( eng_obj_ptr obj, const char * propertyName, EngineMath3D::Vector3 value ) = NULL;

EngineMath3D::Vector2(*ENG_CAPI_ComponentBase_GetPropertyVector2)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyVector2)(eng_obj_ptr obj, const char * propertyName, EngineMath3D::Vector2 value) = NULL;

EngineMath3D::Color(*ENG_CAPI_ComponentBase_GetPropertyColor)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyColor)(eng_obj_ptr obj, const char * propertyName, EngineMath3D::Color value) = NULL;

EngineMath3D::Quaternion (*ENG_CAPI_ComponentBase_GetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName, EngineMath3D::Quaternion value ) = NULL;


int (*ENG_CAPI_ComponentBase_GetPropertyInt)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyInt)( eng_obj_ptr obj, const char * propertyName, int value ) = NULL;

float(*ENG_CAPI_ComponentBase_GetPropertyFloat)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyFloat)(eng_obj_ptr obj, const char * propertyName, float value) = NULL;

__int64(*ENG_CAPI_ComponentBase_GetPropertyInt64)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyInt64)(eng_obj_ptr obj, const char * propertyName, __int64 value) = NULL;

double(*ENG_CAPI_ComponentBase_GetPropertyDouble)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyDouble)(eng_obj_ptr obj, const char * propertyName, double value) = NULL;

bool(*ENG_CAPI_ComponentBase_GetPropertyBoolean)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyBoolean)(eng_obj_ptr obj, const char * propertyName, bool value) = NULL;


const char * (*ENG_CAPI_ComponentBase_GetPropertyString)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyString)( eng_obj_ptr obj, const char * propertyName, const char *value ) = NULL;

EngineMath3D::Matrix (*ENG_CAPI_ComponentBase_GetPropertyMatrix)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyMatrix)(eng_obj_ptr obj, const char * propertyName, EngineMath3D::Matrix value) = NULL;

void(*ENG_CAPI_ComponentBase_ApplyAllProperty)(eng_obj_ptr) = NULL;

int(*ENG_CAPI_ComponentBase_SendMessage)(eng_obj_ptr, const char *msg, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2) = NULL;
int(*ENG_CAPI_ComponentBase_PostMessage)(eng_obj_ptr, const char *msg, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2) = NULL;
int(*ENG_CAPI_ComponentBase_TimedMessage)(eng_obj_ptr, const char *msg, double interval, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2) = NULL;
int(*ENG_CAPI_ComponentBase_PeriodicMessage)(eng_obj_ptr, const char *msg, double interval, int count, int arg0, EngineMath3D::Vector4 arg1, EngineMath3D::Vector4 arg2) = NULL;
bool(*ENG_CAPI_ComponentBase_CancelMessage)(eng_obj_ptr, const char *msg) = NULL;



//===========================================================
//ContainerComponent 




//===========================================================
//Container 
eng_obj_ptr(*ENG_CAPI_Container_GetReservedComponent)(eng_obj_ptr obj, int componentID) = NULL;
eng_obj_ptr(*ENG_CAPI_Container_FindComponentByType)(eng_obj_ptr obj, const char *type) = NULL;
eng_obj_ptr(*ENG_CAPI_Container_Find)(eng_obj_ptr obj, const char *objectNamePath) = NULL;
eng_obj_ptr(*ENG_CAPI_Container_GetRootContainer)(eng_obj_ptr obj) = NULL;



//===========================================================
//ContainerComponent
bool (*ENG_CAPI_ContainerComponent_OnWork)(eng_obj_ptr obj, const char *command) = NULL;


//===========================================================
//PropertyTransform 

int(*ENG_CAPI_PropertyTransform_GetUseUserTransform)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransform_SetUseUserTransform)(eng_obj_ptr obj, int useUserTransform) = NULL;

EngineMath3D::Matrix(*ENG_CAPI_PropertyTransform_GetUserTransform)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransform_SetUserTransform)(eng_obj_ptr obj, EngineMath3D::Matrix userTransform) = NULL;

EngineMath3D::Matrix(*ENG_CAPI_PropertyTransform_GetTransform)(eng_obj_ptr obj) = NULL;



//================================================================================
//TransformGroup
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr obj) = NULL;
void    (*ENG_CAPI_TransformGroup_SetLocalRotation)(eng_obj_ptr obj,EngineMath3D::Quaternion) = NULL;
void    (*ENG_CAPI_TransformGroup_LookAtLocalDirection)(eng_obj_ptr obj,EngineMath3D::Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_LookAtPosition)(eng_obj_ptr obj,EngineMath3D::Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_LookAt)(eng_obj_ptr obj,EngineMath3D::Vector3,EngineMath3D::Vector3,EngineMath3D::Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_ShiftPosition)(eng_obj_ptr,EngineMath3D::Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewTop)(eng_obj_ptr,EngineMath3D::Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewBottom)(eng_obj_ptr,EngineMath3D::Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewLeft)(eng_obj_ptr,EngineMath3D::Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewRight)(eng_obj_ptr,EngineMath3D::Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewFront)(eng_obj_ptr,EngineMath3D::Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewRear)(eng_obj_ptr,EngineMath3D::Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_MoveForward)(eng_obj_ptr,float) = NULL;
void    (*ENG_CAPI_TransformGroup_Rotate)(eng_obj_ptr,float,float,EngineMath3D::Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_SetScale)(eng_obj_ptr,EngineMath3D::Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_SetPosition)(eng_obj_ptr,EngineMath3D::Vector3) = NULL;
EngineMath3D::Quaternion (*ENG_CAPI_TransformGroup_GetLocalRotation)(eng_obj_ptr) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_GetScale)(eng_obj_ptr) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_GetLocalPosition)(eng_obj_ptr) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_GetLocalScale)(eng_obj_ptr) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_GetUp)(eng_obj_ptr) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_GetTarget)(eng_obj_ptr) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_WorldToLocalPosition)(eng_obj_ptr,EngineMath3D::Vector3) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_WorldToLocalDirection)(eng_obj_ptr,EngineMath3D::Vector3) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_LocalToWorldPosition)(eng_obj_ptr,EngineMath3D::Vector3) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_TransformGroup_LocalToWorldDirection)(eng_obj_ptr,EngineMath3D::Vector3) = NULL;
int     (*ENG_CAPI_TransformGroup_IsVisible)(eng_obj_ptr) = NULL;
int     (*ENG_CAPI_TransformGroup_IsTransparent)(eng_obj_ptr) = NULL;
int     (*ENG_CAPI_TransformGroup_IsCullable)(eng_obj_ptr) = NULL;
int     (*ENG_CAPI_TransformGroup_FindNearCollision)(eng_obj_ptr, EngineMath3D::Vector3, EngineMath3D::Vector3, EngineMath3D::Vector3*, float*) = NULL;
eng_obj_ptr (*ENG_CAPI_TransformGroup_FindNearestCollision)(eng_obj_ptr, EngineMath3D::Vector3, EngineMath3D::Vector3, EngineMath3D::Vector3*, float*) = NULL;
EngineMath3D::BoundingBox (*ENG_CAPI_TransformGroup_GetLocalBox)(eng_obj_ptr) = NULL;
EngineMath3D::BoundingBox (*ENG_CAPI_TransformGroup_GetWorldBox)(eng_obj_ptr) = NULL;
EngineMath3D::BoundingBox (*ENG_CAPI_TransformGroup_GetSumBox)(eng_obj_ptr) = NULL;



//================================================================================
//PropertyFog

#include "InterfacePropertyFogEFuncDecl.interface"
#include "InterfacePropertyFogECppMethodImpl.interface"
#include "InterfacePropertyFogECppMethodImplStruct.interface"

//================================================================================
//World

eng_obj_ptr (*ENG_CAPI_World_GetDefaultCamera)(eng_obj_ptr obj) = NULL;
float (*ENG_CAPI_World_GetTime)(eng_obj_ptr obj) = NULL;
float (*ENG_CAPI_World_GetFrameElapseTime)(eng_obj_ptr obj) = NULL;
void (*ENG_CAPI_World_TimerSetSpeed)(eng_obj_ptr obj, float speed) = NULL;
void (*ENG_CAPI_World_TimerStart)(eng_obj_ptr obj) = NULL;
void (*ENG_CAPI_World_TimerStop)(eng_obj_ptr obj) = NULL;


//=================================================

// Fbx 구현
// Q 2016.8.17
void(*ENG_CAPI_Fbx_Play)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_Fbx_Pause)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_Fbx_Stop)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_Fbx_ClearActiveAnimation)(eng_obj_ptr obj) = NULL;
int(*ENG_CAPI_Fbx_SetActiveAnimationByName)(eng_obj_ptr obj, const char *animationName) = NULL;
int(*ENG_CAPI_Fbx_SetActiveAnimationByIndex)(eng_obj_ptr obj, int idx) = NULL;
void(*ENG_CAPI_Fbx_UpdateAnimationEnumerator)(eng_obj_ptr obj) = NULL;
int (*ENG_CAPI_Fbx_IsFbxVisible)(eng_obj_ptr obj) = NULL;
int (*ENG_CAPI_Fbx_IsFbxTransparent)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_Fbx_CheckFbxFlip)(eng_obj_ptr obj) = NULL;

int(*ENG_CAPI_Fbx_GetAnimationMode)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_Fbx_SetAnimationMode)(eng_obj_ptr obj, int mode) = NULL;
int(*ENG_CAPI_Fbx_GetActiveAnimationIndex)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_Fbx_SetActiveAnimationIndex)(eng_obj_ptr obj, int index) = NULL;
int(*ENG_CAPI_Fbx_GetAnimationCurrentTime)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_Fbx_SetAnimationCurrentTime)(eng_obj_ptr obj, int time) = NULL;



//=============================================
bool(*ENG_CAPI_Sound_PlayWave)(eng_obj_ptr obj) = NULL;


//=============================================
//PropertyTransform 구현 
PropertyTransform::PropertyTransform(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}


#include "InterfacePropertyTransformEFuncDecl.interface"
#include "InterfacePropertyTransformECppMethodImpl.interface"
#include "InterfacePropertyTransformECppMethodImplStruct.interface"





int PropertyTransform::GetUseUserTransform()
{
  return Owner->GetPropertyInt("UseUserTransform");
}
void PropertyTransform::SetUseUserTransform(int useUserTransform)
{
  Owner->SetPropertyInt("UseUserTransform", useUserTransform);
}

// Matrix PropertyTransform::GetUserTransform()
Matrix* PropertyTransform::GetUserTransform()
{
  return Owner->GetPropertyMatrix("UserTransform");
}

// void PropertyTransform::SetUserTransform(Matrix userTransform)
void PropertyTransform::SetUserTransform(Matrix* userTransform)
{
  Owner->SetPropertyMatrix("UserTransform", userTransform);
}


//==============================================
//ComponentBase 구현 
ComponentBase::ComponentBase(eng_obj_ptr uid)
{
  id = uid;
  PropInstance = new PropertyInstance(this);
}


ComponentBase::~ComponentBase()
{

}


// ENGINE_SCRIPT_API #9

int ComponentBase::KindOf(const char *className)
{
  if (!ENG_CAPI_ComponentBase_KindOf)
    return 0;

  return ENG_CAPI_ComponentBase_KindOf(id, className);
}



string ComponentBase::LeafClassName()
{
  if (!ENG_CAPI_ComponentBase_LeafClassName)
    return string("");

  string s = ENG_CAPI_ComponentBase_LeafClassName(id);
  return s;
}



Vector4* ComponentBase::GetPropertyVector4(const char * propertyName )
{
	Vector4* __ret__ = new Vector4;
  *__ret__ =
    (!ENG_CAPI_ComponentBase_GetPropertyVector4) ?
    Vector4(0,0,0,0) :
    Vector4( ENG_CAPI_ComponentBase_GetPropertyVector4( id, propertyName ) );
	return __ret__;
}



int ComponentBase::SetPropertyVector4( const char * propertyName, Vector4* value )
{
  if (!ENG_CAPI_ComponentBase_SetPropertyVector4)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyVector4( id, propertyName , *value);
}




int ComponentBase::AnimatePropertyVector4( const char * propertyName, Vector4* value, float laptime, int curveType )
{
  if (!ENG_CAPI_ComponentBase_AnimatePropertyVector4)
    return 0;
  else
    return ENG_CAPI_ComponentBase_AnimatePropertyVector4( id, propertyName , *value, laptime, curveType);
}


// Vector3 ComponentBase::GetPropertyVector3( const char * propertyName )
Vector3* ComponentBase::GetPropertyVector3(const char * propertyName )
{
	Vector3* __ret__ = new Vector3;
  *__ret__ =
    (!ENG_CAPI_ComponentBase_GetPropertyVector3) ?
    Vector3(0,0,0) :
    Vector3(ENG_CAPI_ComponentBase_GetPropertyVector3( id, propertyName ));
	return __ret__;
}



// int ComponentBase::SetPropertyVector3( const char * propertyName, Vector3 value )
int ComponentBase::SetPropertyVector3( const char * propertyName, Vector3* value )
{
  if (!ENG_CAPI_ComponentBase_SetPropertyVector3)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyVector3( id, propertyName , *value);
}


// Vector2 ComponentBase::GetPropertyVector2(const char * propertyName)
Vector2* ComponentBase::GetPropertyVector2(const char * propertyName)
{
	Vector2* __ret__ = new Vector2;
  *__ret__ = 
    (!ENG_CAPI_ComponentBase_GetPropertyVector2)  ? 
    Vector2(0, 0) :
    Vector2(ENG_CAPI_ComponentBase_GetPropertyVector2(id, propertyName));
	return __ret__;
}



// int ComponentBase::SetPropertyVector2(const char * propertyName, Vector2 value)
int ComponentBase::SetPropertyVector2(const char * propertyName, Vector2* value)
{
  if (!ENG_CAPI_ComponentBase_SetPropertyVector2)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyVector2(id, propertyName, *value);

}

// Color ComponentBase::GetPropertyColor(const char* propertyName)
Color* ComponentBase::GetPropertyColor(const char* propertyName)
{
	Color* __ret__ = new Color;
  if (!ENG_CAPI_ComponentBase_GetPropertyColor) {
    __ret__->r = 0.0f;
    __ret__->g = 0.0f;
    __ret__->b = 0.0f;
    __ret__->a = 0.0f;
  }
  else {
    *__ret__ = Color( ENG_CAPI_ComponentBase_GetPropertyColor(id, propertyName) );
  }
	return __ret__;
}


// int ComponentBase::SetPropertyColor(const char* propertyName, Color color)
int ComponentBase::SetPropertyColor(const char* propertyName, Color* color)
{
  if (!ENG_CAPI_ComponentBase_SetPropertyColor)
    return 0;
  else  {
    return ENG_CAPI_ComponentBase_SetPropertyColor(id, propertyName, *color);
  }
	
}


// Quaternion ComponentBase::GetPropertyQuaternion( const char * propertyName )
Quaternion* ComponentBase::GetPropertyQuaternion(  const char * propertyName )
{
	Quaternion* __ret__ = new Quaternion;
  *__ret__ =
    (!ENG_CAPI_ComponentBase_GetPropertyQuaternion) ? 
    Quaternion(0,0,0,1)  :
    Quaternion(ENG_CAPI_ComponentBase_GetPropertyQuaternion( id, propertyName ));
	return __ret__;
}



// int ComponentBase::SetPropertyQuaternion( const char * propertyName, Quaternion value )
int ComponentBase::SetPropertyQuaternion( const char * propertyName, Quaternion* value )
{
  if (!ENG_CAPI_ComponentBase_SetPropertyQuaternion)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyQuaternion( id, propertyName , *value);

}



bool ComponentBase::GetPropertyBoolean( const char * propertyName )
{
  if (!ENG_CAPI_ComponentBase_GetPropertyBoolean)
    return 0;
  else
    return ENG_CAPI_ComponentBase_GetPropertyBoolean( id, propertyName );
}


int ComponentBase::SetPropertyBoolean( const char * propertyName, bool value )
{
  if (!ENG_CAPI_ComponentBase_SetPropertyBoolean)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyBoolean( id, propertyName , value);
}




int ComponentBase::GetPropertyInt( const char * propertyName )
{
  if (!ENG_CAPI_ComponentBase_GetPropertyInt)
    return 0;
  else
    return ENG_CAPI_ComponentBase_GetPropertyInt( id, propertyName );
}


int ComponentBase::SetPropertyInt( const char * propertyName, int value )
{
  if (!ENG_CAPI_ComponentBase_SetPropertyInt)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyInt( id, propertyName , value);
}


float ComponentBase::GetPropertyFloat(const char * propertyName)
{
  if (!ENG_CAPI_ComponentBase_GetPropertyFloat)
    return 0;
  else
    return ENG_CAPI_ComponentBase_GetPropertyFloat(id, propertyName);
}


int ComponentBase::SetPropertyFloat(const char * propertyName, float value)
{
  if (!ENG_CAPI_ComponentBase_SetPropertyFloat)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyFloat(id, propertyName, value);
}



const char * ComponentBase::GetPropertyString( const char * propertyName )
{
  if (!ENG_CAPI_ComponentBase_GetPropertyString)
    return 0;
  else
    {
      string s = ENG_CAPI_ComponentBase_GetPropertyString( id, propertyName );
      return s.c_str();
    }
}


int ComponentBase::SetPropertyString( const char * propertyName, const char *value )
{
  if (!ENG_CAPI_ComponentBase_SetPropertyString)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyString( id, propertyName , value);
}

//Matrix ComponentBase::GetPropertyMatrix(const char * propertyName)
Matrix* ComponentBase::GetPropertyMatrix(const char * propertyName)
{
	Matrix* __ret__ = new Matrix;
  *__ret__ = 
    (!ENG_CAPI_ComponentBase_GetPropertyMatrix) ? 
    Matrix() : 
    Matrix(ENG_CAPI_ComponentBase_GetPropertyMatrix(id, propertyName) );
	return __ret__;
}


// int ComponentBase::SetPropertyMatrix(const char * propertyName, Matrix value)
int ComponentBase::SetPropertyMatrix(const char * propertyName, Matrix* value)
{
  if (!ENG_CAPI_ComponentBase_SetPropertyMatrix)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyMatrix(id, propertyName, *value);
}


void
ComponentBase::ApplyAllProperty() {
  if (!ENG_CAPI_ComponentBase_ApplyAllProperty)
    return;
  return ENG_CAPI_ComponentBase_ApplyAllProperty(id);
}




int ComponentBase::SendMessage(const char *msg, int arg0, Vector4 *arg1, Vector4 *arg2)
{
  if (!ENG_CAPI_ComponentBase_SendMessage)
    return 0;
  return ENG_CAPI_ComponentBase_SendMessage(id, msg, arg0, *arg1, *arg2);
}

int ComponentBase::PostMessage(const char *msg, int arg0, Vector4 *arg1, Vector4 *arg2)
{
  if (!ENG_CAPI_ComponentBase_PostMessage)
    return 0;
  return ENG_CAPI_ComponentBase_PostMessage(id, msg, arg0, *arg1, *arg2);
}



int ComponentBase::TimedMessage(const char *msg, double interval, int arg0, Vector4 *arg1, Vector4 *arg2)
{
  if (!ENG_CAPI_ComponentBase_TimedMessage)
    return 0;
  return ENG_CAPI_ComponentBase_TimedMessage(id, msg, interval, arg0, *arg1, *arg2 );
}

int ComponentBase::PeriodicMessage(const char *msg, double interval, int count, int arg0, Vector4 *arg1, Vector4 *arg2)
{
  if (!ENG_CAPI_ComponentBase_PeriodicMessage)
    return 0;
  return ENG_CAPI_ComponentBase_PeriodicMessage(id, msg, interval, count, arg0, *arg1, *arg2);
}



bool ComponentBase::CancelMessage(const char *msg)
{
  if (!ENG_CAPI_ComponentBase_CancelMessage)
    return false;
  return ENG_CAPI_ComponentBase_CancelMessage(id, msg);
}










//============================================
//ContainerComponent 구현 

ContainerComponent::ContainerComponent(eng_obj_ptr uid)
  : ComponentBase(uid)
{

}


ContainerComponent::~ContainerComponent()
{

}


bool ContainerComponent::OnWork(const char *command)
{
  if (!ENG_CAPI_ContainerComponent_OnWork)
    return false;
  return ENG_CAPI_ContainerComponent_OnWork(id, command);
}



//============================================


ContainerComponent *Container::GetReservedComponent(int componentID)
{
  if (!ENG_CAPI_Container_GetReservedComponent)
    return NULL;

  eng_obj_ptr compo_uid = ENG_CAPI_Container_GetReservedComponent( id, componentID ); 

  if (compo_uid == 0)
    return NULL;

  //string clsName = LeafClassName();
  //if (clsName == "TransformGroup")
  if (componentID == COMPONENT_TRANSFORMGROUP) 
    return new TransformGroup(compo_uid);

  if (componentID == COMPONENT_CAMERA)
    return new Camera(compo_uid);

  if (componentID == COMPONENT_WORLD)
    return new World(compo_uid);
	
  if (componentID == COMPONENT_LIGHT)
    return new Light(compo_uid);
	
  return NULL;

}

ContainerComponent *Container::FindComponentByType(const char *type)
{
  if (!ENG_CAPI_Container_FindComponentByType)
    return NULL;

  eng_obj_ptr compo_uid = ENG_CAPI_Container_FindComponentByType(id, type);

  if (compo_uid == 0)
    return NULL;

	if (strcmp(type, "TransformGroup") == 0)
    return new TransformGroup(compo_uid);

	if (strcmp(type, "Fbx") == 0)
    return new Fbx(compo_uid);

  if (strcmp(type, "Camera") == 0)
    return new Camera(compo_uid);

  if (strcmp(type, "Light") == 0)
    return new Light(compo_uid);

  if (strcmp(type, "World") == 0)
    return new World(compo_uid);

  if (strcmp(type, "ScriptComponent") == 0)
    return new ScriptComponent(compo_uid);

  if (strcmp(type, "KinectSkeletonComponent") == 0)
    return new KinectSkeletonComponent(compo_uid);

  if (strcmp(type, "Fbx") == 0)
    return new Fbx(compo_uid);

  if (strcmp(type, "FbxNodeBase") == 0)
    return new FbxNodeBase(compo_uid);

  if (strcmp(type, "FbxNodeRoot") == 0)
    return new FbxNodeRoot(compo_uid);

  if (strcmp(type, "FbxNodeMesh") == 0)
    return new FbxNodeMesh(compo_uid);

  if (strcmp(type, "FbxNodeBone") == 0)
    return new FbxNodeBone(compo_uid);

  if (strcmp(type, "Sound") == 0)
	  return new Sound(compo_uid);


  return NULL;
}


Container*
Container::Find(const char* objectNamePath) 
{
  if (!ENG_CAPI_Container_Find)
    return NULL;

  Container* obj = new Container(0);
  if (obj == NULL)
    return NULL;
  else 
    {
      obj->id = ENG_CAPI_Container_Find(id, objectNamePath);
      return obj;
    }
}

Container* Container::GetRootContainer()
{
	if (!ENG_CAPI_Container_GetRootContainer)
		return NULL;

	Container* obj = new Container(0);
	if (obj == NULL)
		return NULL;
	else
	{
		obj->id = ENG_CAPI_Container_GetRootContainer(id);
		return obj;
	}
}




//===========================================================================================================================
//Container 구현 

Container::Container(eng_obj_ptr uid) : ComponentBase(uid)
{

}



Container::~Container()
{

}




//============================================
//TransformGroup 구현 

TransformGroup::TransformGroup(eng_obj_ptr uid)
  : ContainerComponent(uid)
{
  PropTransform = new PropertyTransform(this);
}



// Vector3 TransformGroup::GetPosition() 
Vector3* TransformGroup::GetPosition() 
{
	Vector3* __ret__ = new Vector3;
  *__ret__ =
    (ENG_CAPI_TransformGroup_GetPosition) ?
    Vector3(ENG_CAPI_TransformGroup_GetPosition(id)):
    Vector3(0,0,0) ;
	return __ret__;
}



// void TransformGroup::SetLocalRotation(Quaternion q) {
void TransformGroup::SetLocalRotation(Quaternion* q) {
  if (ENG_CAPI_TransformGroup_SetLocalRotation) {
    ENG_CAPI_TransformGroup_SetLocalRotation(id, *q);
  }
}

// void TransformGroup::LookAtLocalDirection(Vector3 direction) 
void TransformGroup::LookAtLocalDirection(Vector3* direction) 
{
  if (ENG_CAPI_TransformGroup_LookAtLocalDirection) {
    ENG_CAPI_TransformGroup_LookAtLocalDirection(id, *direction);
  }
}

// void TransformGroup::LookAtPosition(Vector3 position)
void TransformGroup::LookAtPosition(Vector3* position) {
  if (ENG_CAPI_TransformGroup_LookAtPosition) {
    ENG_CAPI_TransformGroup_LookAtPosition(id, *position);
  }
}

// void TransformGroup::LookAt(Vector3 position, Vector3 target, Vector3 up) {
void TransformGroup::LookAt(Vector3* position, Vector3* target, Vector3* up) {
  if (ENG_CAPI_TransformGroup_LookAt) {
    ENG_CAPI_TransformGroup_LookAt(id, *position, *target, *up);
  }
}


// void TransformGroup::ShiftPosition(Vector3 shift) {
void TransformGroup::ShiftPosition(Vector3* shift) {
  if (ENG_CAPI_TransformGroup_ShiftPosition) {
    ENG_CAPI_TransformGroup_ShiftPosition(id, *shift);
  }
}


// void TransformGroup::ViewTop(Vector3 target, float distance) {
void TransformGroup::ViewTop(Vector3* target, float distance) {
  if (ENG_CAPI_TransformGroup_ViewTop) {
    ENG_CAPI_TransformGroup_ViewTop(id, *target, distance);
  }
}


// void TransformGroup::ViewBottom(Vector3 target, float distance) {
void TransformGroup::ViewBottom(Vector3* target, float distance) {
  if (ENG_CAPI_TransformGroup_ViewBottom) {
    ENG_CAPI_TransformGroup_ViewBottom(id, *target, distance);
  }
}


// void TransformGroup::ViewLeft(Vector3 target, float distance) {
void TransformGroup::ViewLeft(Vector3* target, float distance) {
  if (ENG_CAPI_TransformGroup_ViewLeft) {
    ENG_CAPI_TransformGroup_ViewLeft(id, *target, distance);
  }
}


// void TransformGroup::ViewRight(Vector3 target, float distance) {
void TransformGroup::ViewRight(Vector3* target, float distance) {
  if (ENG_CAPI_TransformGroup_ViewRight) {
    ENG_CAPI_TransformGroup_ViewRight(id, *target, distance);
  }
}

// void TransformGroup::ViewFront(Vector3 target, float distance) {
void TransformGroup::ViewFront(Vector3* target, float distance) {
  if (ENG_CAPI_TransformGroup_ViewFront) {
    ENG_CAPI_TransformGroup_ViewFront(id, *target, distance);
  }
}

// void TransformGroup::ViewRear(Vector3 target, float distance) {
void TransformGroup::ViewRear(Vector3* target, float distance) {
  if (ENG_CAPI_TransformGroup_ViewRear) {
    ENG_CAPI_TransformGroup_ViewRear(id, *target, distance);
  }
}

void TransformGroup::MoveForward(float dist) {
  if (!ENG_CAPI_TransformGroup_MoveForward)
    return ;
  ENG_CAPI_TransformGroup_MoveForward(id, dist);
}


// void TransformGroup::Rotate(float x, float y, Vector3 center) {
void TransformGroup::Rotate(float x, float y, Vector3* center) {
  if (ENG_CAPI_TransformGroup_Rotate) {
    ENG_CAPI_TransformGroup_Rotate(id, x, y, *center);
  }
}

// void TransformGroup::SetScale(Vector3 scale) {
void TransformGroup::SetScale(Vector3* scale) {
  if (ENG_CAPI_TransformGroup_SetScale) {
    ENG_CAPI_TransformGroup_SetScale(id, *scale);
  }
}

// void TransformGroup::SetPosition(Vector3 pos) {
void TransformGroup::SetPosition(Vector3* pos) {
  if (ENG_CAPI_TransformGroup_SetPosition) {
    ENG_CAPI_TransformGroup_SetPosition(id, *pos);
  }
}






// Quaternion TransformGroup::GetLocalRotation() {
Quaternion* TransformGroup::GetLocalRotation() {
	Quaternion* __ret__ = new Quaternion(0,0,0,1);
	if (ENG_CAPI_TransformGroup_GetLocalRotation)
	{
		*__ret__ = Quaternion(ENG_CAPI_TransformGroup_GetLocalRotation(id) );
	
	}

	return __ret__;

}




// Vector3 TransformGroup::GetScale() {
Vector3* TransformGroup::GetScale() {
	Vector3* __ret__ = new Vector3;
	*__ret__ =
    ENG_CAPI_TransformGroup_GetScale ?
    Vector3(ENG_CAPI_TransformGroup_GetScale(id) ):
    Vector3(0,0,0);
	return __ret__;
}

// Vector3 TransformGroup::GetLocalPosition() {
Vector3* TransformGroup::GetLocalPosition() {
	Vector3* __ret__ = new Vector3;
	*__ret__ =
    ENG_CAPI_TransformGroup_GetLocalPosition ?
    Vector3(ENG_CAPI_TransformGroup_GetLocalPosition(id) ):
    Vector3(0,0,0);
	return __ret__;
}

// Vector3 TransformGroup::GetLocalScale() {
Vector3* TransformGroup::GetLocalScale() {
	Vector3* __ret__ = new Vector3;
  *__ret__ =
    ENG_CAPI_TransformGroup_GetLocalScale ?
    Vector3( ENG_CAPI_TransformGroup_GetLocalScale(id) ):
    Vector3(0,0,0) ;
	return __ret__;
}


// Vector3 TransformGroup::GetUp() {
Vector3* TransformGroup::GetUp() 
{
	Vector3* __ret__ = new Vector3;
  *__ret__ =
    ENG_CAPI_TransformGroup_GetUp ? 
    Vector3(ENG_CAPI_TransformGroup_GetUp(id) ):
    Vector3(0,0,0) ;
	return __ret__;
}


// Vector3 TransformGroup::GetTarget() {
Vector3* TransformGroup::GetTarget() 
{
	Vector3* __ret__ = new Vector3;
  *__ret__ =
    ENG_CAPI_TransformGroup_GetTarget ?
    Vector3(ENG_CAPI_TransformGroup_GetTarget(id) ):
    Vector3(0,0,0) ;
	return __ret__;
}


// Vector3 TransformGroup::WorldToLocalPosition(Vector3 world) {
Vector3* TransformGroup::WorldToLocalPosition(Vector3* world) {
	Vector3* __ret__ = new Vector3;
  *__ret__ =
    ENG_CAPI_TransformGroup_WorldToLocalPosition ?
    Vector3( ENG_CAPI_TransformGroup_WorldToLocalPosition(id, *world) ):
    Vector3(*world);
	return __ret__;
}


// Vector3 TransformGroup::WorldToLocalDirection(Vector3 world) {
Vector3* TransformGroup::WorldToLocalDirection(Vector3* world) {
	Vector3* __ret__ = new Vector3;
  *__ret__ =
    ENG_CAPI_TransformGroup_WorldToLocalDirection ?
    Vector3( ENG_CAPI_TransformGroup_WorldToLocalDirection(id, *world) ):
    Vector3( *world );
	return __ret__;
}


// Vector3 TransformGroup::LocalToWorldPosition(Vector3 local) {
Vector3* TransformGroup::LocalToWorldPosition(Vector3* local) {
	Vector3* __ret__ = new Vector3;
  *__ret__ =
    ENG_CAPI_TransformGroup_LocalToWorldPosition ? 
    Vector3( ENG_CAPI_TransformGroup_LocalToWorldPosition(id, *local) ):
    Vector3( *local );
	return __ret__;
}


// Vector3 TransformGroup::LocalToWorldDirection(Vector3 local) {
Vector3* TransformGroup::LocalToWorldDirection(Vector3* local) {
	Vector3* __ret__ = new Vector3;
  *__ret__ =
    ENG_CAPI_TransformGroup_LocalToWorldDirection ?
    Vector3( ENG_CAPI_TransformGroup_LocalToWorldDirection(id, *local) ):
    Vector3( *local );
	return __ret__;
}

int
TransformGroup::IsVisible() {
  if (!ENG_CAPI_TransformGroup_IsVisible)
    return 0;
  return ENG_CAPI_TransformGroup_IsVisible(id);
}


int
TransformGroup::IsTransparent(){
  if (!ENG_CAPI_TransformGroup_IsTransparent)
    return 0;
  return ENG_CAPI_TransformGroup_IsTransparent(id);
}

int
TransformGroup::IsCullable() {
  if (!ENG_CAPI_TransformGroup_IsCullable)
    return 0;
  return ENG_CAPI_TransformGroup_IsCullable(id);
}


// int
// TransformGroup::FindNearCollision(Vector3 posfrom, Vector3 posto, Vector3* intersectnew, float* dist) {
int
TransformGroup::FindNearCollision(Vector3* posfrom, Vector3* posto, Vector3*& intersectnew, float* dist) {
  if (ENG_CAPI_TransformGroup_FindNearCollision) 
	{
		EngineMath3D::Vector3 vi;
    int r = ENG_CAPI_TransformGroup_FindNearCollision(id,*posfrom,*posto,&vi,dist);
		*intersectnew = Vector3(vi);
		return r;
  }
  else {
    return 0;
  }
}


// TransformGroup*
// TransformGroup::FindNearestCollision(Vector3 from, Vector3 to, Vector3* intersect, float* distr) {
TransformGroup*
TransformGroup::FindNearestCollision(Vector3* from, Vector3* to, Vector3*& intersect, float* distr) {
  TransformGroup* obj = new TransformGroup(0);
  if (obj == NULL)
    return NULL;
  else {
		EngineMath3D::Vector3 vi;
    obj->id = ENG_CAPI_TransformGroup_FindNearestCollision(id, *from, *to, &vi, distr);
		*intersect = Vector3(vi);
    return obj;
  }
}

// BoundingBox TransformGroup::GetLocalBox() {
BoundingBox* TransformGroup::GetLocalBox() {
	BoundingBox* __ret__ = new BoundingBox;
	if (ENG_CAPI_TransformGroup_GetLocalBox)
		*__ret__ = BoundingBox( ENG_CAPI_TransformGroup_GetLocalBox(id) );

	return __ret__;
}

// BoundingBox TransformGroup::GetWorldBox() {
BoundingBox* TransformGroup::GetWorldBox() {
	BoundingBox* __ret__ = new BoundingBox;
	if (ENG_CAPI_TransformGroup_GetWorldBox)
		*__ret__ = BoundingBox( ENG_CAPI_TransformGroup_GetWorldBox(id) );
	return __ret__;
}

// BoundingBox TransformGroup::GetSumBox() {
BoundingBox* TransformGroup::GetSumBox() {
	BoundingBox* __ret__ = new BoundingBox;
	if (ENG_CAPI_TransformGroup_GetSumBox)
		*__ret__ =  BoundingBox( ENG_CAPI_TransformGroup_GetSumBox(id) );
	return __ret__;
}

//================================================================================
//Light

Light::Light(eng_obj_ptr uid) : ContainerComponent(uid) {
  PropLight = new PropertyLight(this);
}


//BoundingBox(*ENG_CAPI_Light_GetLocalBox)(eng_obj_ptr obj) = NULL;
// BoundingBox Light::GetLocalBox()
BoundingBox* Light::GetLocalBox()
{
	BoundingBox* __ret__ = new BoundingBox;
	if (ENG_CAPI_Light_GetLocalBox)
		*__ret__ =  BoundingBox( ENG_CAPI_Light_GetLocalBox(id) );
	return __ret__;
}


//================================================================================
//PropertyLight

PropertyLight::PropertyLight(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}


#include "InterfacePropertyLightEFuncDecl.interface"
#include "InterfacePropertyLightECppMethodImpl.interface"
#include "InterfacePropertyLightECppMethodImplStruct.interface"


//Light
EngineMath3D::BoundingBox(*ENG_CAPI_Light_GetLocalBox)(eng_obj_ptr obj ) = NULL;









//===========================================================================================================================
//Camera 구현 

// Q 2016.8.11
Camera::Camera(eng_obj_ptr uid) : ContainerComponent(uid) {
  PropCamera = new PropertyCamera(this);
}

bool
Camera::PrepareInterface() {
  if (!ENG_CAPI_Camera_PrepareInterface)
    return false;
  return ENG_CAPI_Camera_PrepareInterface(id);
}

// bool
// Camera::GetPickRay(int x, int y, int width, int height, float length,
//                    Vector3 &pickRayOrig, Vector3 &pickRayDir) {
bool
Camera::GetPickRay(int x, int y, int width, int height, float length,
		   Vector3*& pickRayOrig, Vector3*& pickRayDir) {
  if (!ENG_CAPI_Camera_GetPickRay)
    return false;
	{
		EngineMath3D::Vector3 v0;
		EngineMath3D::Vector3 v1;

		int r = ENG_CAPI_Camera_GetPickRay(id, x, y, width, height, length, v0, v1 );

		*pickRayOrig = Vector3(v0);
		*pickRayDir = Vector3(v1);
		return r;
	}
}

bool
Camera::SetupView(int w, int h) {
  if (!ENG_CAPI_Camera_SetupView)
    return false;
  return ENG_CAPI_Camera_SetupView(id, w, h);
}

void
Camera::Pan(float x, float y) {
  if (!ENG_CAPI_Camera_Pan)
    return;
  return ENG_CAPI_Camera_Pan(id, x, y);
}


// Matrix Camera::GetProjectionMatrix() {
Matrix *Camera::GetProjectionMatrix() {
	Matrix* __ret__ = new Matrix;
  if (ENG_CAPI_Camera_GetProjectionMatrix) {
    *__ret__ = Matrix( ENG_CAPI_Camera_GetProjectionMatrix(id) );
  }
	return __ret__;
}

// Matrix Camera::GetViewMatrix() {
Matrix *Camera::GetViewMatrix() {
	Matrix* __ret__ = new Matrix;
  if (ENG_CAPI_Camera_GetViewMatrix)
    *__ret__ = Matrix( ENG_CAPI_Camera_GetViewMatrix(id) );
	return __ret__;
}

// Matrix Camera::GetViewProjectionMatrix() {
Matrix *Camera::GetViewProjectionMatrix() {
	Matrix* __ret__ = new Matrix;
  if (ENG_CAPI_Camera_GetViewProjectionMatrix)
    *__ret__ = Matrix( ENG_CAPI_Camera_GetViewProjectionMatrix(id) );
	return __ret__;
}



// Vector4 Camera::WorldCoordToScreenCoord() {
Vector4* Camera::WorldCoordToScreenCoord( Vector3* v) 
{
	Vector4* __ret__ = new Vector4;
  if (ENG_CAPI_Camera_WorldCoordToScreenCoord)
    *__ret__ = Vector4( ENG_CAPI_Camera_WorldCoordToScreenCoord(id, *v) );
	return __ret__;
}



// Vector4 Camera::ScreenCoordToWorldCoord() {
Vector3* Camera::ScreenCoordToWorldCoord(Vector3* v) 
{
	Vector3* __ret__ = new Vector3;
  if (ENG_CAPI_Camera_ScreenCoordToWorldCoord)
    *__ret__ = Vector3( ENG_CAPI_Camera_ScreenCoordToWorldCoord(id, *v) );
	return __ret__;
}


//===========================================================================================================================



PropertyCamera::PropertyCamera(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}

PropertyCamera::~PropertyCamera()
{
}


#include "InterfacePropertyCameraEFuncDecl.interface"
#include "InterfacePropertyCameraECppMethodImpl.interface"
#include "InterfacePropertyCameraECppMethodImplStruct.interface"

int(*ENG_CAPI_Camera_PrepareInterface)(eng_obj_ptr) = NULL;
int(*ENG_CAPI_Camera_GetPickRay)(eng_obj_ptr, int, int, int, int, float, EngineMath3D::Vector3&, EngineMath3D::Vector3&) = NULL;
int(*ENG_CAPI_Camera_SetupView)(eng_obj_ptr, int, int) = NULL;
void(*ENG_CAPI_Camera_Pan)(eng_obj_ptr, float, float) = NULL;
EngineMath3D::Matrix (*ENG_CAPI_Camera_GetProjectionMatrix)(eng_obj_ptr) = NULL;
EngineMath3D::Matrix (*ENG_CAPI_Camera_GetViewMatrix)(eng_obj_ptr) = NULL;
EngineMath3D::Matrix (*ENG_CAPI_Camera_GetViewProjectionMatrix)(eng_obj_ptr) = NULL;
EngineMath3D::Vector4 (*ENG_CAPI_Camera_WorldCoordToScreenCoord)(eng_obj_ptr, EngineMath3D::Vector3) = NULL;
EngineMath3D::Vector3 (*ENG_CAPI_Camera_ScreenCoordToWorldCoord)(eng_obj_ptr, EngineMath3D::Vector3) = NULL;

//===========================================================================================================================

//PropertyFog
PropertyFog::PropertyFog(ComponentBase *owner) 
{
	Owner = owner;
	GroupIndex = 0;
}

PropertyFog::~PropertyFog() {}






//================================================================================
//World


World::World(eng_obj_ptr uid)
  : ContainerComponent(uid)
{
  PropFog = new PropertyFog(this);
}




Camera *World::GetDefaultCamera()
{
  if (!ENG_CAPI_World_GetDefaultCamera)
    return NULL;
  else
	{
		eng_obj_ptr cameraId = ENG_CAPI_World_GetDefaultCamera(id);
		if (cameraId)
			return new Camera(cameraId);
		else
			return NULL;
	}
}




float World::GetTime()
{
  if (!ENG_CAPI_World_GetTime)
    return 0.0;
  else
	{
		return ENG_CAPI_World_GetTime(id);
	}
}




float World::GetFrameElapseTime()
{
  if (!ENG_CAPI_World_GetFrameElapseTime)
    return 0.0;
  else
	{
		return ENG_CAPI_World_GetFrameElapseTime(id);
	}
}


void World::TimerSetSpeed(float speed)
{
  if (ENG_CAPI_World_TimerSetSpeed)
	{
		ENG_CAPI_World_TimerSetSpeed(id, speed);
	}
}


void World::TimerStart()
{
  if (ENG_CAPI_World_TimerStart)
	{
		ENG_CAPI_World_TimerStart(id);
	}
}



void World::TimerStop()
{
  if (ENG_CAPI_World_TimerStop)
	{
		ENG_CAPI_World_TimerStop(id);
	}
}




//=================================================
//PropertyInstance 구현 

PropertyMaterial::PropertyMaterial(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}

PropertyMaterial::~PropertyMaterial()
{

}


#include "InterfacePropertyMaterialEFuncDecl.interface"
#include "InterfacePropertyMaterialECppMethodImpl.interface"
#include "InterfacePropertyMaterialECppMethodImplStruct.interface"




//=================================================
//PropertyFbxFile 구현 

PropertyFbxFile::PropertyFbxFile(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}


PropertyFbxFile::~PropertyFbxFile()
{
}




#include "InterfacePropertyFbxFileEFuncDecl.interface"
#include "InterfacePropertyFbxFileECppMethodImpl.interface"
#include "InterfacePropertyFbxFileECppMethodImplStruct.interface"


//=================================================
//PropertyFbxAnimation 구현 

PropertyFbxAnimation::PropertyFbxAnimation(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}


PropertyFbxAnimation::~PropertyFbxAnimation()
{
}



#include "InterfacePropertyFbxAnimationEFuncDecl.interface"
#include "InterfacePropertyFbxAnimationECppMethodImpl.interface"
#include "InterfacePropertyFbxAnimationECppMethodImplStruct.interface"



//=================================================
//PropertyFbxNodeMesh 구현 

PropertyFbxNodeMesh::PropertyFbxNodeMesh(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}

PropertyFbxNodeMesh::~PropertyFbxNodeMesh()
{
}


#include "InterfacePropertyFbxNodeMeshEFuncDecl.interface"
#include "InterfacePropertyFbxNodeMeshECppMethodImpl.interface"
#include "InterfacePropertyFbxNodeMeshECppMethodImplStruct.interface"

//================================================================================
// Q2016.8.17
// Fbx

Fbx::Fbx(eng_obj_ptr uid) : ContainerComponent(uid) 
{
  PropFbxFile = new PropertyFbxFile(this);
	PropFbxAnimation = new PropertyFbxAnimation(this);
}

Fbx::~Fbx()
{
}


void
Fbx::Play()
{
  if (!ENG_CAPI_Fbx_Play)
    return;
		
  ENG_CAPI_Fbx_Play(id);
}

void
Fbx::Pause()
{
  if (!ENG_CAPI_Fbx_Pause)
    return;
	
  ENG_CAPI_Fbx_Pause(id);
}

void
Fbx::Stop()
{
  if (!ENG_CAPI_Fbx_Stop)
    return;
		
  ENG_CAPI_Fbx_Stop(id);
}

void
Fbx::ClearActiveAnimation()
{
  if (!ENG_CAPI_Fbx_ClearActiveAnimation)
    return;
		
  ENG_CAPI_Fbx_ClearActiveAnimation(id);
}

bool
Fbx::SetActiveAnimation(const char *animationName)
{
  if (!ENG_CAPI_Fbx_SetActiveAnimationByName)
    return false;
  else
    return ENG_CAPI_Fbx_SetActiveAnimationByName(id, animationName);
}

bool
Fbx::SetActiveAnimation(int idx)
{
  if (!ENG_CAPI_Fbx_SetActiveAnimationIndex)
    return false;
  else
    return ENG_CAPI_Fbx_SetActiveAnimationByIndex(id, idx);
}

void
Fbx::UpdateAnimationEnumerator()
{
  if (!ENG_CAPI_Fbx_UpdateAnimationEnumerator)
    return;
  ENG_CAPI_Fbx_UpdateAnimationEnumerator(id);
}

bool
Fbx::IsFbxVisible()
{
  if (!ENG_CAPI_Fbx_IsFbxVisible)
    return false;
  else
    return ENG_CAPI_Fbx_IsFbxVisible;
}

bool
Fbx::IsFbxTransparent()
{
  if (!ENG_CAPI_Fbx_IsFbxTransparent)
    return false;
  else
    return ENG_CAPI_Fbx_IsFbxTransparent;
}

void
Fbx::CheckFbxFlip()
{
  if (!ENG_CAPI_Fbx_CheckFbxFlip)
    return;

  ENG_CAPI_Fbx_CheckFbxFlip(id);
}

int
Fbx::GetAnimationMode()
{
  if (!ENG_CAPI_Fbx_GetAnimationMode)
    return 0;
  else
    ENG_CAPI_Fbx_GetAnimationMode;
}

void
Fbx::SetAnimationMode(int mode)
{
  if (!ENG_CAPI_Fbx_SetAnimationMode)
    return;
  else
    ENG_CAPI_Fbx_SetAnimationMode;
}

int
Fbx::GetActiveAnimationIndex()
{
  if (!ENG_CAPI_Fbx_GetActiveAnimationIndex)
    return 0;
  else
    ENG_CAPI_Fbx_GetActiveAnimationIndex;
}

void
Fbx::SetActiveAnimationIndex(int index)
{
  if (!ENG_CAPI_Fbx_SetActiveAnimationIndex)
    return ;
  else
    ENG_CAPI_Fbx_SetActiveAnimationIndex;
}


int
Fbx::GetAnimationCurrentTime()
{
  if (!ENG_CAPI_Fbx_GetAnimationCurrentTime)
    return 0;
  else
    ENG_CAPI_Fbx_GetAnimationCurrentTime;
}

void
Fbx::SetAnimationCurrentTime(int time)
{
  if (!ENG_CAPI_Fbx_SetAnimationCurrentTime)
    return;
  else
    ENG_CAPI_Fbx_SetAnimationCurrentTime;
}




//================================================================================
// FbxNodeBase

FbxNodeBase::FbxNodeBase(eng_obj_ptr uid) : ContainerComponent(uid) 
{
  PropFbxFile = new PropertyFbxFile(this); 
}

FbxNodeBase::~FbxNodeBase()
{
}



//================================================================================
// FbxNodeRoot


FbxNodeRoot::FbxNodeRoot(eng_obj_ptr uid) : FbxNodeBase(uid) 
{
}

FbxNodeRoot::~FbxNodeRoot()
{
}



//================================================================================
// FbxNodeBone


FbxNodeBone::FbxNodeBone(eng_obj_ptr uid) : FbxNodeBase(uid) 
{
}

FbxNodeBone::~FbxNodeBone()
{
}




//================================================================================
// FbxNodeMesh

FbxNodeMesh::FbxNodeMesh(eng_obj_ptr uid) : FbxNodeBase(uid) 
{
  PropFbxNodeMesh = new PropertyFbxNodeMesh(this);
	/*
	PropMaterial = new PropertyMaterial[10] {this, this, this, this, this, this, this, this, this, this }; 
	for (int i = 0; i < 10; i++)
		PropMaterial[i].GroupIndex = i;
	*/
	PropMaterial = new PropertyMaterial(this);
	PropMaterial->GroupIndex = 0;
}




FbxNodeMesh::~FbxNodeMesh()
{
}





//================================================================================
//ScriptComponent

ScriptComponent::ScriptComponent(eng_obj_ptr uid) : ContainerComponent(uid) {
  PropScript = new PropertyScript(this);
}



//================================================================================
//PropertyScript

PropertyScript::PropertyScript(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}

PropertyScript::~PropertyScript()
{
}


#include "InterfacePropertyScriptEFuncDecl.interface"
#include "InterfacePropertyScriptECppMethodImpl.interface"
#include "InterfacePropertyScriptECppMethodImplStruct.interface"






//================================================================================
//KinectSkeleton

KinectSkeletonComponent::KinectSkeletonComponent(eng_obj_ptr uid) : ContainerComponent(uid) 
{
	/*
	PropKinectSkeleton = new PropertyKinectSkeleton[6] { this, this, this, this, this, this } ;
	for (int i = 0; i < 6; i++)
		PropKinectSkeleton[i].GroupIndex = i;
	*/
	PropKinectSkeleton = new PropertyKinectSkeleton(this);
	
}



//================================================================================
//PropertyLight

PropertyKinectSkeleton::PropertyKinectSkeleton(ComponentBase *owner)
{
  Owner = owner;
	GroupIndex = 0;
}

PropertyKinectSkeleton::~PropertyKinectSkeleton()
{
}


#include "InterfacePropertyKinectSkeletonEFuncDecl.interface"
#include "InterfacePropertyKinectSkeletonECppMethodImpl.interface"
#include "InterfacePropertyKinectSkeletonECppMethodImplStruct.interface"

//================================================================================

PropertySound::PropertySound(ComponentBase *owner)
{
	Owner = owner;
	GroupIndex = 0;
}

PropertySound::~PropertySound()
{
}


#include "InterfacePropertySoundEFuncDecl.interface"
#include "InterfacePropertySoundECppMethodImpl.interface"
#include "InterfacePropertySoundECppMethodImplStruct.interface"









//================================================================================
// Sound

Sound::Sound(eng_obj_ptr uid) : ContainerComponent(uid) 
{
  PropSound = new PropertySound(this);
}

bool Sound::PlayWave()
{
	if (ENG_CAPI_Sound_PlayWave == false)
		return false;
	else
	{
		ENG_CAPI_Sound_PlayWave(id);
		return true;
	}
}



//================================================================================
//KinectImageComponent

KinectImageComponent::KinectImageComponent(eng_obj_ptr uid) : ContainerComponent(uid)
{
	/*
	PropKinectSkeleton = new PropertyKinectSkeleton[6] { this, this, this, this, this, this } ;
	for (int i = 0; i < 6; i++)
	PropKinectSkeleton[i].GroupIndex = i;
	*/
	PropKinectImage = new PropertyKinectImage(this);
	PropKinectImage->GroupIndex = 0;
}



//================================================================================
//PropertyKinectImage

PropertyKinectImage::PropertyKinectImage(ComponentBase *owner)
{
	Owner = owner;
	GroupIndex = 0;
}

PropertyKinectImage::~PropertyKinectImage()
{
}


//#include "InterfacePropertyKinectSkeletonEFuncDecl.interface"
//#include "InterfacePropertyKinectSkeletonECppMethodImpl.interface"
//#include "InterfacePropertyKinectSkeletonECppMethodImplStruct.interface"

//================================================================================