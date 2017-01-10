#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"


//전역 함수 포인터
//===========================================================
//PropertyInstance 구현 


//=================================================
//PropertyInstance 구현 

PropertyInstance::PropertyInstance(ComponentBase *owner)
{
  Owner = owner;
}

#include "InterfacePropertyInstanceEFuncDecl.interface"
#include "InterfacePropertyInstanceECppMethodImpl.interface"
#include "InterfacePropertyInstanceECppMethodImplStruct.interface"



//================================================================================
//Component Base 
int (*ENG_CAPI_ComponentBase_KindOf)(eng_obj_ptr obj, const char *className) = NULL;
const char *(*ENG_CAPI_ComponentBase_LeafClassName)(eng_obj_ptr obj) = NULL;

Vector3 (*ENG_CAPI_ComponentBase_GetPropertyVector3)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyVector3)( eng_obj_ptr obj, const char * propertyName, Vector3 value ) = NULL;

Vector2(*ENG_CAPI_ComponentBase_GetPropertyVector2)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyVector2)(eng_obj_ptr obj, const char * propertyName, Vector2 value) = NULL;

Color(*ENG_CAPI_ComponentBase_GetPropertyColor)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyColor)(eng_obj_ptr obj, const char * propertyName, Color value) = NULL;

Quaternion (*ENG_CAPI_ComponentBase_GetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName, Quaternion value ) = NULL;


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

Matrix (*ENG_CAPI_ComponentBase_GetPropertyMatrix)(eng_obj_ptr obj, const char * propertyName) = NULL;
int(*ENG_CAPI_ComponentBase_SetPropertyMatrix)(eng_obj_ptr obj, const char * propertyName, Matrix value) = NULL;
//===========================================================
//ContainerComponent 




//===========================================================
//Container 
eng_obj_ptr(*ENG_CAPI_Container_GetReservedComponent)(eng_obj_ptr obj, int componentID) = NULL;
eng_obj_ptr(*ENG_CAPI_Container_FindComponentByType)(eng_obj_ptr obj, const char *type) = NULL;


//===========================================================
//PropertyTransformGroup 
const char* (*ENG_CAPI_PropertyTransformGroup_GetName)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetName)(eng_obj_ptr obj, const char *name) = NULL;

bool(*ENG_CAPI_PropertyTransformGroup_GetShow)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetShow)(eng_obj_ptr obj, bool name) = NULL;

Vector3(*ENG_CAPI_PropertyTransformGroup_GetPosition)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetPosition)(eng_obj_ptr obj, Vector3 pos) = NULL;

Quaternion(*ENG_CAPI_PropertyTransformGroup_GetRotation)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetRotation)(eng_obj_ptr obj, Quaternion rot) = NULL;

Vector3(*ENG_CAPI_PropertyTransformGroup_GetScale)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetScale)(eng_obj_ptr obj, Vector3 rot) = NULL;

int(*ENG_CAPI_PropertyTransformGroup_GetSortType)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetSortType)(eng_obj_ptr obj, int sortType) = NULL;

int(*ENG_CAPI_PropertyTransformGroup_GetFixedOrder)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetFixedOrder)(eng_obj_ptr obj, int fixedOrder) = NULL;

int(*ENG_CAPI_PropertyTransformGroup_GetCullType)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetCullType)(eng_obj_ptr obj, int cullType) = NULL;

int(*ENG_CAPI_PropertyTransformGroup_GetUseUserTransform)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetUseUserTransform)(eng_obj_ptr obj, int useUserTransform) = NULL;

Matrix(*ENG_CAPI_PropertyTransformGroup_GetUserTransform)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyTransformGroup_SetUserTransform)(eng_obj_ptr obj, Matrix userTransform) = NULL;

Matrix(*ENG_CAPI_PropertyTransformGroup_GetTransform)(eng_obj_ptr obj) = NULL;



//================================================================================
//TransformGroup
Vector3 (*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr obj) = NULL;
void    (*ENG_CAPI_TransformGroup_SetLocalRotation)(eng_obj_ptr obj,Quaternion) = NULL;
void    (*ENG_CAPI_TransformGroup_LookAtLocalDirection)(eng_obj_ptr obj,Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_LookAtPosition)(eng_obj_ptr obj,Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_LookAt)(eng_obj_ptr obj,Vector3,Vector3,Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_ShiftPosition)(eng_obj_ptr,Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewTop)(eng_obj_ptr,Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewBottom)(eng_obj_ptr,Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewLeft)(eng_obj_ptr,Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewRight)(eng_obj_ptr,Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewFront)(eng_obj_ptr,Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_ViewRear)(eng_obj_ptr,Vector3,float) = NULL;
void    (*ENG_CAPI_TransformGroup_MoveForward)(eng_obj_ptr,float) = NULL;
void    (*ENG_CAPI_TransformGroup_Rotate)(eng_obj_ptr,float,float,Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_SetScale)(eng_obj_ptr,Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_SetPosition)(eng_obj_ptr,Vector3) = NULL;
Quaternion (*ENG_CAPI_TransformGroup_GetLocalRotation)(eng_obj_ptr) = NULL;
Vector3 (*ENG_CAPI_TransformGroup_GetScale)(eng_obj_ptr) = NULL;
Vector3 (*ENG_CAPI_TransformGroup_GetLocalPosition)(eng_obj_ptr) = NULL;
Vector3 (*ENG_CAPI_TransformGroup_GetLocalScale)(eng_obj_ptr) = NULL;
Vector3 (*ENG_CAPI_TransformGroup_GetUp)(eng_obj_ptr) = NULL;
Vector3 (*ENG_CAPI_TransformGroup_GetTarget)(eng_obj_ptr) = NULL;
Vector3 (*ENG_CAPI_TransformGroup_WorldToLocalPosition)(eng_obj_ptr,Vector3) = NULL;
Vector3 (*ENG_CAPI_TransformGroup_WorldToLocalDirection)(eng_obj_ptr,Vector3) = NULL;
Vector3 (*ENG_CAPI_TransformGroup_LocalToWorldPosition)(eng_obj_ptr,Vector3) = NULL;
Vector3 (*ENG_CAPI_TransformGroup_LocalToWorldDirection)(eng_obj_ptr,Vector3) = NULL;
int     (*ENG_CAPI_TransformGroup_IsVisible)(eng_obj_ptr) = NULL;
int     (*ENG_CAPI_TransformGroup_IsTransparent)(eng_obj_ptr) = NULL;
int     (*ENG_CAPI_TransformGroup_IsCullable)(eng_obj_ptr) = NULL;
int     (*ENG_CAPI_TransformGroup_FindNearCollision)(eng_obj_ptr, Vector3, Vector3, Vector3*, float*) = NULL;
eng_obj_ptr (*ENG_CAPI_TransformGroup_Find)(eng_obj_ptr, const char*) = NULL;
eng_obj_ptr (*ENG_CAPI_TransformGroup_FindNearestCollision)(eng_obj_ptr, Vector3, Vector3, Vector3*, float*) = NULL;
BoundingBox (*ENG_CAPI_TransformGroup_GetLocalBox)(eng_obj_ptr) = NULL;
BoundingBox (*ENG_CAPI_TransformGroup_GetWorldBox)(eng_obj_ptr) = NULL;
BoundingBox (*ENG_CAPI_TransformGroup_GetSumBox)(eng_obj_ptr) = NULL;
//================================================================================
//Light
BoundingBox(*ENG_CAPI_Light_GetLocalBox)(eng_obj_ptr obj ) = NULL;
void(*ENG_CAPI_Light_ApplyAllProperty)(eng_obj_ptr obj) = NULL;

//================================================================================
//PropertyLight
int(*ENG_CAPI_PropertyLight_GetLightType)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetLightType)(eng_obj_ptr obj, int lightType) = NULL;
Color(*ENG_CAPI_PropertyLight_GetLightColor)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetLightColor)(eng_obj_ptr obj, Color lightColor) = NULL;
int(*ENG_CAPI_PropertyLight_GetLightRange)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetLightRange)(eng_obj_ptr obj, int LightRange) = NULL;
float(*ENG_CAPI_PropertyLight_GetAmbient)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetAmbient)(eng_obj_ptr obj, float ambient) = NULL;
float(*ENG_CAPI_PropertyLight_GetSpecular)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetSpecular)(eng_obj_ptr obj, float specular) = NULL;
float(*ENG_CAPI_PropertyLight_GetDiffuse)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetDiffuse)(eng_obj_ptr obj, float diffuse) = NULL;
float(*ENG_CAPI_PropertyLight_GetSpotAngle)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetSpotAngle)(eng_obj_ptr obj, float spotAngle) = NULL;
float(*ENG_CAPI_PropertyLight_GetSpotAngleSmooth)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetSpotAngleSmooth)(eng_obj_ptr obj, float spotAngleSmooth) = NULL;
float(*ENG_CAPI_PropertyLight_GetPickerSize)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetPickerSize)(eng_obj_ptr obj, float pickerSize) = NULL;
float(*ENG_CAPI_PropertyLight_GetMinEffectiveDiffuse)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetMinEffectiveDiffuse)(eng_obj_ptr obj, float minEffectiveDiffuse) = NULL;
float(*ENG_CAPI_PropertyLight_GetMaxEffectiveRange)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyLight_SetMaxEffectiveRange)(eng_obj_ptr obj, float maxEffectiveRange) = NULL;

// Q 2016.8.11
int(*ENG_CAPI_Camera_PrepareInterface)(eng_obj_ptr) = NULL;
int(*ENG_CAPI_Camera_GetPickRay)(eng_obj_ptr, int, int, int, int, float, Vector3&, Vector3&) = NULL;
int(*ENG_CAPI_Camera_SetupView)(eng_obj_ptr, int, int) = NULL;
void(*ENG_CAPI_Camera_Pan)(eng_obj_ptr, float, float) = NULL;
void(*ENG_CAPI_Camera_ApplyAllProperty)(eng_obj_ptr) = NULL;
Matrix (*ENG_CAPI_Camera_GetProjectionMatrix)(eng_obj_ptr) = NULL;
Matrix (*ENG_CAPI_Camera_GetViewMatrix)(eng_obj_ptr) = NULL;
Matrix (*ENG_CAPI_Camera_GetViewProjectionMatrix)(eng_obj_ptr) = NULL;

// Q 2016.8.16
float(*ENG_CAPI_PropertyCamera_GetNearViewPlane)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetNearViewPlane)(eng_obj_ptr, float) = NULL;
float(*ENG_CAPI_PropertyCamera_GetFarViewPlane)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetFarViewPlane)(eng_obj_ptr, float) = NULL;
float(*ENG_CAPI_PropertyCamera_GetFarViewPlaneSky)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetFarViewPlaneSky)(eng_obj_ptr, float) = NULL;
float(*ENG_CAPI_PropertyCamera_GetFocalLength)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetFocalLength)(eng_obj_ptr, float) = NULL;
float(*ENG_CAPI_PropertyCamera_GetAspectRatio)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetAspectRatio)(eng_obj_ptr, float) = NULL;
float(*ENG_CAPI_PropertyCamera_GetDepthOfField)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetDepthOfField)(eng_obj_ptr, float) = NULL;
float(*ENG_CAPI_PropertyCamera_GetFocusingDistance)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetFocusingDistance)(eng_obj_ptr, float) = NULL;
float(*ENG_CAPI_PropertyCamera_GetOrthographicViewSize)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetOrthographicViewSize)(eng_obj_ptr, float) = NULL;
Vector2(*ENG_CAPI_PropertyCamera_GetOffset)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetOffset)(eng_obj_ptr, Vector2) = NULL;
bool(*ENG_CAPI_PropertyCamera_GetEnableCulling)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetEnableCulling)(eng_obj_ptr, bool) = NULL;
Color(*ENG_CAPI_PropertyCamera_GetBackColor)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetBackColor)(eng_obj_ptr, Color) = NULL;
int(*ENG_CAPI_PropertyCamera_GetBackgroundType)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetBackGroundType)(eng_obj_ptr, int) = NULL;
bool(*ENG_CAPI_PropertyCamera_GetDrawGrid)(eng_obj_ptr) = NULL;
void(*ENG_CAPI_PropertyCamera_SetDrawGrid)(eng_obj_ptr, bool) = NULL;

//================================================================================
//PropertyFog
int(*ENG_CAPI_PropertyFog_GetFogMode)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyFog_SetFogMode)(eng_obj_ptr obj, int FogMode) = NULL;

float(*ENG_CAPI_PropertyFog_GetFogNearPlane)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyFog_SetFogNearPlane)(eng_obj_ptr obj, float fogNearPlane) = NULL;

float(*ENG_CAPI_PropertyFog_GetFogFarPlane)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyFog_SetFogFarPlane)(eng_obj_ptr obj, float FogFarPlane) = NULL;

float(*ENG_CAPI_PropertyFog_GetFogDensity)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyFog_SetFogDensity)(eng_obj_ptr obj, float FogDensity) = NULL;

Color(*ENG_CAPI_PropertyFog_GetFogColor)(eng_obj_ptr obj) = NULL;
void(*ENG_CAPI_PropertyFog_SetFogColor)(eng_obj_ptr obj, Color FogColor) = NULL;

//================================================================================
//World

TransformGroup *(*ENG_CAPI_World_GetTransformGroup)(eng_obj_ptr obj) = NULL;
Camera* (*ENG_CAPI_World_GetDefaultCamera)(eng_obj_ptr obj) = NULL;

//=================================================

// Fbx 구현
// Q 2016.8.17
void(*ENG_CAPI_Fbx_ApplyAllProperty)(eng_obj_ptr obj) = NULL;
int(*ENG_CAPI_Fbx_FrameAnimate)(eng_obj_ptr obj) = NULL;
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
//PropertyTransformGroup 구현 
PropertyTransformGroup::PropertyTransformGroup(ComponentBase *owner)
{
  Owner = owner;
}

string PropertyTransformGroup::GetName()
{
  return Owner->GetPropertyString("Name");
}
void PropertyTransformGroup::SetName(const char *name)
{
  Owner->SetPropertyString("Name", name);
}

bool PropertyTransformGroup::GetShow()
{
  return Owner->GetPropertyBoolean("Show");
}
void PropertyTransformGroup::SetShow(bool show)
{
  Owner->SetPropertyBoolean("Show", show);
}

// Vector3 PropertyTransformGroup::GetPosition()
void PropertyTransformGroup::GetPosition(Vector3* __ret__)
{
  Owner->GetPropertyVector3(__ret__, "Position");
}


// void PropertyTransformGroup::SetPosition(Vector3 pos)
void PropertyTransformGroup::SetPosition(Vector3* pos)
{
  Owner->SetPropertyVector3("Position", pos);
}

// Quaternion PropertyTransformGroup::GetRotation()
void PropertyTransformGroup::GetRotation(Quaternion* __ret__)
{
  Owner->GetPropertyQuaternion(__ret__, "Rotation");
}


// void PropertyTransformGroup::SetRotation(Quaternion rot)
void PropertyTransformGroup::SetRotation(Quaternion* rot)
{
  Owner->SetPropertyQuaternion("Rotation", rot);
}

// Vector3 PropertyTransformGroup::GetScale()
void  PropertyTransformGroup::GetScale(Vector3* __ret__)
{
  Owner->GetPropertyVector3(__ret__, "Scale");
}

// void PropertyTransformGroup::SetScale(Vector3 scale)
void PropertyTransformGroup::SetScale(Vector3* scale)
{
  Owner->SetPropertyVector3("Scale", scale);
}

int PropertyTransformGroup::GetSortType()
{
  return Owner->GetPropertyInt("SortType");
}
void PropertyTransformGroup::SetSortType(int sortType)
{
  Owner->SetPropertyInt("SortType", sortType);
}

int PropertyTransformGroup::GetFixedOrder()
{
  return Owner->GetPropertyInt("FixedOrder");
}
void PropertyTransformGroup::SetFixedOrder(int fixedOrder)
{
  Owner->SetPropertyInt("FixedOrder", fixedOrder);
}

int PropertyTransformGroup::GetCullType()
{
  return Owner->GetPropertyInt("CullType");
}
void PropertyTransformGroup::SetCullType(int cullType)
{
  Owner->SetPropertyInt("CullType" , cullType);
}

int PropertyTransformGroup::GetUseUserTransform()
{
  return Owner->GetPropertyInt("UseUserTransform");
}
void PropertyTransformGroup::SetUseUserTransform(int useUserTransform)
{
  Owner->SetPropertyInt("UseUserTransform", useUserTransform);
}

// Matrix PropertyTransformGroup::GetUserTransform()
void PropertyTransformGroup::GetUserTransform(Matrix* __ret__)
{
  Owner->GetPropertyMatrix(__ret__, "UserTransform");
}

// void PropertyTransformGroup::SetUserTransform(Matrix userTransform)
void PropertyTransformGroup::SetUserTransform(Matrix* userTransform)
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




// Vector3 ComponentBase::GetPropertyVector3( const char * propertyName )
void ComponentBase::GetPropertyVector3(Vector3* __ret__, const char * propertyName )
{
  *__ret__ =
    (!ENG_CAPI_ComponentBase_GetPropertyVector3) ?
    Vector3(0,0,0) :
    ENG_CAPI_ComponentBase_GetPropertyVector3( id, propertyName );
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
void ComponentBase::GetPropertyVector2(Vector2* __ret__, const char * propertyName)
{
  *__ret__ = 
    (!ENG_CAPI_ComponentBase_GetPropertyVector2)  ? 
    Vector2(0, 0) :
    ENG_CAPI_ComponentBase_GetPropertyVector2(id, propertyName);
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
void ComponentBase::GetPropertyColor(Color* __ret__, const char* propertyName)
{
  if (!ENG_CAPI_ComponentBase_GetPropertyColor) {
    __ret__->r = 0.0f;
    __ret__->g = 0.0f;
    __ret__->b = 0.0f;
    __ret__->a = 0.0f;
  }
  else {
    *__ret__ = ENG_CAPI_ComponentBase_GetPropertyColor(id, propertyName);
  }
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
void ComponentBase::GetPropertyQuaternion(Quaternion* __ret__, const char * propertyName )
{
  *__ret__ =
    (!ENG_CAPI_ComponentBase_GetPropertyQuaternion) ? 
    Quaternion(0,0,0,1) :
    ENG_CAPI_ComponentBase_GetPropertyQuaternion( id, propertyName );
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
void ComponentBase::GetPropertyMatrix(Matrix* __ret__, const char * propertyName)
{
  *__ret__ = 
    (!ENG_CAPI_ComponentBase_GetPropertyMatrix) ? 
    Matrix() : 
    ENG_CAPI_ComponentBase_GetPropertyMatrix(id, propertyName);
}


// int ComponentBase::SetPropertyMatrix(const char * propertyName, Matrix value)
int ComponentBase::SetPropertyMatrix(const char * propertyName, Matrix* value)
{
  if (!ENG_CAPI_ComponentBase_SetPropertyMatrix)
    return 0;
  else
    return ENG_CAPI_ComponentBase_SetPropertyMatrix(id, propertyName, *value);
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

  if (componentID == 4)
    {
      return new Fbx(compo_uid);
    }

	
  //if (componentID == COMPONENT_WORLD)
  //	return new World(compo_uid);

  //if (componentID == COMPONENT_LIGHT)
  //	return new Light(compo_uid);
	

  /*
    if (clsName == "Script")
    return new Script;
    if (clsName == "World")
    return new World;
    if (clsName == "Camera")
    return new Camera;
    if (clsName == "Light")
    return new Light;
  */

  return NULL;

}

ContainerComponent *Container::FindComponentByType(const char *type)
{
  if (!ENG_CAPI_Container_FindComponentByType)
    return NULL;

  eng_obj_ptr compo_uid = ENG_CAPI_Container_FindComponentByType(id, type);

  if (compo_uid == 0)
    return NULL;

  if (strcmp(type, "Fbx") == 0)
    return new Fbx(compo_uid);

  if (strcmp(type, "Camera"))
    return new Camera(compo_uid);

  if (strcmp(type, "Light"))
    return new Light(compo_uid);


  return NULL;
}

//============================================
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
  PropTransformGroup = new PropertyTransformGroup(this);
}



// Vector3 TransformGroup::GetPosition() 
void TransformGroup::GetPosition(Vector3* __ret__) 
{
  *__ret__ =
    (ENG_CAPI_TransformGroup_GetPosition) ?
    ENG_CAPI_TransformGroup_GetPosition(id):
    Vector3(0,0,0);
}


TransformGroup*
TransformGroup::Find(const char* objectNamePath) 
{
  if (!ENG_CAPI_TransformGroup_Find)
    return NULL;

  TransformGroup* obj = new TransformGroup(0);
  if (obj == NULL)
    return NULL;
  else 
    {
      obj->id = ENG_CAPI_TransformGroup_Find(id, objectNamePath);
      return obj;
    }
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
void TransformGroup::GetLocalRotation(Quaternion* __ret__) {
  *__ret__ = 
    (!ENG_CAPI_TransformGroup_GetLocalRotation) ? 
    Quaternion(0,0,0,1) :
    ENG_CAPI_TransformGroup_GetLocalRotation(id);
}

// Vector3 TransformGroup::GetScale() {
void TransformGroup::GetScale(Vector3* __ret__) {
  *__ret__ =
    ENG_CAPI_TransformGroup_GetScale ?
    ENG_CAPI_TransformGroup_GetScale(id) :
    Vector3(0,0,0);
}

// Vector3 TransformGroup::GetLocalPosition() {
void TransformGroup::GetLocalPosition(Vector3* __ret__) {
  *__ret__ =
    ENG_CAPI_TransformGroup_GetLocalPosition ?
    ENG_CAPI_TransformGroup_GetLocalPosition(id) :
    Vector3(0,0,0);
}

// Vector3 TransformGroup::GetLocalScale() {
void TransformGroup::GetLocalScale(Vector3* __ret__) {
  *__ret__ =
    ENG_CAPI_TransformGroup_GetLocalScale ?
    ENG_CAPI_TransformGroup_GetLocalScale(id) :
    Vector3(0,0,0);
}


// Vector3 TransformGroup::GetUp() {
void TransformGroup::GetUp(Vector3* __ret__) {
  *__ret__ =
    ENG_CAPI_TransformGroup_GetUp ? 
    ENG_CAPI_TransformGroup_GetUp(id):
    Vector3(0,0,0);
}


// Vector3 TransformGroup::GetTarget() {
void TransformGroup::GetTarget(Vector3* __ret__) {
  *__ret__ =
    ENG_CAPI_TransformGroup_GetTarget ?
    ENG_CAPI_TransformGroup_GetTarget(id) :
    Vector3(0,0,0);
}


// Vector3 TransformGroup::WorldToLocalPosition(Vector3 world) {
void TransformGroup::WorldToLocalPosition(Vector3* __ret__, Vector3* world) {
  *__ret__ =
    ENG_CAPI_TransformGroup_WorldToLocalPosition ?
    ENG_CAPI_TransformGroup_WorldToLocalPosition(id, *world) :
    *world;
}


// Vector3 TransformGroup::WorldToLocalDirection(Vector3 world) {
void TransformGroup::WorldToLocalDirection(Vector3* __ret__, Vector3* world) {
  *__ret__ =
    ENG_CAPI_TransformGroup_WorldToLocalDirection ?
    ENG_CAPI_TransformGroup_WorldToLocalDirection(id, *world) :
    *world;
}


// Vector3 TransformGroup::LocalToWorldPosition(Vector3 local) {
void TransformGroup::LocalToWorldPosition(Vector3* __ret__, Vector3* local) {
  *__ret__ =
    ENG_CAPI_TransformGroup_LocalToWorldPosition ? 
    ENG_CAPI_TransformGroup_LocalToWorldPosition(id, *local) :
    *local;
}


// Vector3 TransformGroup::LocalToWorldDirection(Vector3 local) {
void TransformGroup::LocalToWorldDirection(Vector3* __ret__, Vector3* local) {
  *__ret__ =
    ENG_CAPI_TransformGroup_LocalToWorldDirection ?
    ENG_CAPI_TransformGroup_LocalToWorldDirection(id, *local) :
    *local;
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
  if (ENG_CAPI_TransformGroup_FindNearCollision) {
    return ENG_CAPI_TransformGroup_FindNearCollision(id,*posfrom,*posto,intersectnew,dist);
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
    obj->id = ENG_CAPI_TransformGroup_FindNearestCollision(id, *from, *to, intersect, distr);
    return obj;
  }
}

// BoundingBox TransformGroup::GetLocalBox() {
void TransformGroup::GetLocalBox(BoundingBox* __ret__) {
  *__ret__ = ENG_CAPI_TransformGroup_GetLocalBox(id);
}

// BoundingBox TransformGroup::GetWorldBox() {
void TransformGroup::GetWorldBox(BoundingBox* __ret__) {
  *__ret__ = ENG_CAPI_TransformGroup_GetWorldBox(id);
}

// BoundingBox TransformGroup::GetSumBox() {
void TransformGroup::GetSumBox(BoundingBox* __ret__) {
  *__ret__ =  ENG_CAPI_TransformGroup_GetSumBox(id);
}

//================================================================================
//Light

Light::Light(eng_obj_ptr uid) : ContainerComponent(uid) {
  PropLight = new PropertyLight(this);
}


//BoundingBox(*ENG_CAPI_Light_GetLocalBox)(eng_obj_ptr obj) = NULL;
// BoundingBox Light::GetLocalBox()
void Light::GetLocalBox(BoundingBox* __ret__)
{
  *__ret__ =  ENG_CAPI_Light_GetLocalBox(id);
}

//void(*ENG_CAPI_Light_ApplyAllProperty)(eng_obj_ptr obj) = NULL;
void Light::ApplyAllProperty()
{
  return ENG_CAPI_Light_ApplyAllProperty(id);
}

//================================================================================
//PropertyLight

PropertyLight::PropertyLight(ComponentBase *owner)
{
  Owner = owner;
}

//int(*ENG_CAPI_PropertyLight_GetLightType)(eng_obj_ptr obj) = NULL;
int PropertyLight::GetLightType()
{
  return Owner->GetPropertyInt("LightType");
}

//void(*ENG_CAPI_PropertyLight_SetLightType)(eng_obj_ptr obj, int lightType) = NULL;
void PropertyLight::SetLightType(int lightType)
{
  Owner->SetPropertyInt("LightType" , lightType);
}

//Color(*ENG_CAPI_PropertyLight_GetLightColor)(eng_obj_ptr obj) = NULL;
// Color PropertyLight::GetLightColor()
void PropertyLight::GetLightColor(Color* __ret__)
{
  Owner->GetPropertyColor(__ret__, "LightType");
}

//void(*ENG_CAPI_PropertyLight_SetLightColor)(eng_obj_ptr obj, Color lightColor) = NULL;
// void PropertyLight::SetLightColor(Color lightColor)
void PropertyLight::SetLightColor(Color* lightColor)
{
  Owner->SetPropertyColor("LightColor", lightColor);
}


//int(*ENG_CAPI_PropertyLight_GetLightRange)(eng_obj_ptr obj) = NULL;
int PropertyLight::GetLightRange()
{
  return Owner->GetPropertyInt("LightRange");
}

//void(*ENG_CAPI_PropertyLight_SetLightRange)(eng_obj_ptr obj, int LightRange) = NULL;
void PropertyLight::SetLightRange(int LightRange)
{
  Owner->SetPropertyInt("LightRange", LightRange);
}

//float(*ENG_CAPI_PropertyLight_GetAmbient)(eng_obj_ptr obj) = NULL;
float PropertyLight::GetAmbient()
{
  return Owner->GetPropertyFloat("Ambient");
}

//void(*ENG_CAPI_PropertyLight_SetAmbient)(eng_obj_ptr obj, float ambient) = NULL;
void PropertyLight::SetAmbient(float ambient)
{
  Owner->SetPropertyFloat("Ambient", ambient);
}

//float(*ENG_CAPI_PropertyLight_GetSpecular)(eng_obj_ptr obj) = NULL;
float PropertyLight::GetSpecular()
{
  return Owner->GetPropertyFloat("Specular");
}

//void(*ENG_CAPI_PropertyLight_SetSpecular)(eng_obj_ptr obj, float specular) = NULL;
void PropertyLight::SetSpecular(float specular)
{
  Owner->SetPropertyFloat("Specular", specular);
}

//float(*ENG_CAPI_PropertyLight_GetDiffuse)(eng_obj_ptr obj) = NULL;
float PropertyLight::GetDiffuse()
{
  return Owner->GetPropertyFloat("Diffuse");
}

//void(*ENG_CAPI_PropertyLight_SetDiffuse)(eng_obj_ptr obj, float diffuse) = NULL;
void PropertyLight::SetDiffuse(float diffuse)
{
  Owner->SetPropertyFloat("Diffuse", diffuse);
}

//float(*ENG_CAPI_PropertyLight_GetSpotAngle)(eng_obj_ptr obj) = NULL;
float PropertyLight::GetSpotAngle()
{
  return Owner->GetPropertyFloat("SpotAngle");
}


//void(*ENG_CAPI_PropertyLight_SetSpotAngle)(eng_obj_ptr obj, float spotAngle) = NULL;
void PropertyLight::SetSpotAngle(float spotAngle)
{
  Owner->SetPropertyFloat("SpotAngle", spotAngle);
}

//float(*ENG_CAPI_PropertyLight_GetSpotAngleSmooth)(eng_obj_ptr obj) = NULL;
float PropertyLight::GetSpotAngleSmooth()
{
  return Owner->GetPropertyFloat("SpotAngleSmooth");
}

//void(*ENG_CAPI_PropertyLight_SetSpotAngleSmooth)(eng_obj_ptr obj, float spotAngleSmooth) = NULL;
void PropertyLight::SetSpotAngleSmooth(float spotAngleSmooth)
{
  Owner->SetPropertyFloat("SpotAngleSmooth", spotAngleSmooth);
}

//float(*ENG_CAPI_PropertyLight_GetPickerSize)(eng_obj_ptr obj) = NULL;
float PropertyLight::GetPickerSize()
{
  return Owner->GetPropertyFloat("PickerSize");
}

//void(*ENG_CAPI_PropertyLight_SetPickerSize)(eng_obj_ptr obj, float pickerSize) = NULL;
void PropertyLight::SetPickerSize(float pickerSize)
{
  Owner->SetPropertyFloat("PickerSize", pickerSize);
}


//float(*ENG_CAPI_PropertyLight_GetMinEffectiveDiffuse)(eng_obj_ptr obj) = NULL;
float PropertyLight::GetMinEffectiveDiffuse()
{
  return Owner->GetPropertyFloat("MinEffectiveDiffuse");
}

//void(*ENG_CAPI_PropertyLight_SetMinEffectiveDiffuse)(eng_obj_ptr obj, float minEffectiveDiffuse) = NULL;
void PropertyLight::SetMinEffectiveDiffuse(float minEffectiveDiffuse)
{
  Owner->SetPropertyFloat("minEffectiveDiffuse", minEffectiveDiffuse);
}

//float(*ENG_CAPI_PropertyLight_GetMaxEffectiveRange)(eng_obj_ptr obj) = NULL;
float PropertyLight::GetMaxEffectiveRange()
{
  return Owner->GetPropertyFloat("MaxEffectiveRange");
}

//void(*ENG_CAPI_PropertyLight_SetMaxEffectiveRange)(eng_obj_ptr obj, float maxEffectiveRange) = NULL;
void PropertyLight::SetMaxEffectiveRange(float maxEffectiveRange)
{
  Owner->SetPropertyFloat("MaxEffectiveRange", maxEffectiveRange);
}








//============================================
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
  return ENG_CAPI_Camera_GetPickRay(id, x, y, width, height, length, *pickRayOrig, *pickRayDir);
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

void
Camera::ApplyAllProperty() {
  if (!ENG_CAPI_Camera_ApplyAllProperty)
    return;
  return ENG_CAPI_Camera_ApplyAllProperty(id);
}

// Matrix Camera::GetProjectionMatrix() {
void Camera::GetProjectionMatrix(Matrix* __ret__) {
  if (ENG_CAPI_Camera_GetProjectionMatrix) {
    *__ret__ = ENG_CAPI_Camera_GetProjectionMatrix(id);
  }
}

// Matrix Camera::GetViewMatrix() {
void Camera::GetViewMatrix(Matrix* __ret__) {
  if (ENG_CAPI_Camera_GetViewMatrix)
    *__ret__ = ENG_CAPI_Camera_GetViewMatrix(id);
}

// Matrix Camera::GetViewProjectionMatrix() {
void Camera::GetViewProjectionMatrix(Matrix* __ret__) {
  if (ENG_CAPI_Camera_GetViewProjectionMatrix)
    *__ret__ = ENG_CAPI_Camera_GetViewProjectionMatrix(id);
}

PropertyCamera::PropertyCamera(ComponentBase *owner)
{
  Owner = owner;
}

PropertyCamera::~PropertyCamera()
{
}

float
PropertyCamera::GetNearViewPlane()
{
  return Owner->GetPropertyFloat("NearViewPlane");
}

void 
PropertyCamera::SetNearViewPlane(float plane)
{
  Owner->SetPropertyFloat("NearViewPlane", plane);
}

float 
PropertyCamera::GetFarViewPlane()
{
  return Owner->GetPropertyFloat("FarViewPlane");
}

void 
PropertyCamera::SetFarViewPlane(float plane)
{
  Owner->SetPropertyFloat("FarViewPlane", plane);
}

float 
PropertyCamera::GetFarViewPlaneSky()
{
  return Owner->GetPropertyFloat("FarViewPlaneSky");
}

void 
PropertyCamera::SetFarViewPlaneSky(float plane)
{
  Owner->SetPropertyFloat("FarViewPlaneSky", plane);
}

float 
PropertyCamera::GetFocalLength()
{
  return Owner->GetPropertyFloat("FocalLength");
}

void 
PropertyCamera::SetFocalLength(float length)
{
  Owner->SetPropertyFloat("FocalLength", length);
}

float 
PropertyCamera::GetAspectRatio()
{
  return Owner->GetPropertyFloat("AspectRatio");
}

void 
PropertyCamera::SetAspectRatio(float ratio)
{
  Owner->SetPropertyFloat("AspectRatio", ratio);
}

float 
PropertyCamera::GetDepthOfField()
{
  Owner->GetPropertyFloat("DepthOfField");
}

void 
PropertyCamera::SetDepthOfField(float dof)
{
  Owner->SetPropertyFloat("DepthOfField", dof);
}

float 
PropertyCamera::GetFocusingDistance()
{
  Owner->GetPropertyFloat("FocusingDistance");
}

void 
PropertyCamera::SetFocusingDistance(float fdist)
{
  Owner->SetPropertyFloat("FocusingDistance", fdist);
}

float 
PropertyCamera::GetOrthographicViewSize()
{
  Owner->GetPropertyFloat("OrthographicViewSize");
}

void 
PropertyCamera::SetOrthographicViewSize(float size)
{
  Owner->SetPropertyFloat("OrthographicViewSize", size);
}

// Vector2 PropertyCamera::GetOffset()
void PropertyCamera::GetOffset(Vector2* __ret__)
{
  Owner->GetPropertyVector2(__ret__, "Offset");
}

//void PropertyCamera::SetOffset(Vector2 offset)
void PropertyCamera::SetOffset(Vector2* offset)
{
  Owner->SetPropertyVector2("Offset", offset);
}

bool
PropertyCamera::GetEnableCulling()
{
  Owner->GetPropertyBoolean("EnableCulling");
}

void 
PropertyCamera::SetEnableCulling(bool enable)
{
  Owner->SetPropertyBoolean("EnableCulling", enable);
}

int 
PropertyCamera::GetBackgroundType()
{
  Owner->GetPropertyInt("BackGroundType");
}

void 
PropertyCamera::SetBackGroundType(int type)
{
  Owner->SetPropertyInt("BackGroundType", type);
}

bool
PropertyCamera::GetDrawGrid()
{
  Owner->GetPropertyBoolean("DrawGrid");
}

void 
PropertyCamera::SetDrawGrid(bool grid)
{
  Owner->SetPropertyBoolean("DrawGrid", grid);
}


//================================================================================
//PropertyFog
PropertyFog::PropertyFog() {}
PropertyFog::~PropertyFog() {}

//int FogMode;
int PropertyFog::GetFogMode()
{
  return Owner->GetPropertyInt("GetFogMode");
}
void PropertyFog::SetFogMode(int FogMode)
{
  Owner->SetPropertyInt("FogMode", FogMode);
}

//float FogNearPlane;
float PropertyFog::GetFogNearPlane()
{
  return Owner->GetPropertyFloat("FogNearPlane");
}
void PropertyFog::SetFogNearPlane(float fogNearPlane)
{
  Owner->SetPropertyFloat("FogNearPlane", fogNearPlane);
}

//float FogFarPlane;
float PropertyFog::GetFogFarPlane()
{
  return Owner->GetPropertyFloat("FogFarPlane");
}
void PropertyFog::SetFogFarPlane(float FogFarPlane)
{
  Owner->SetPropertyFloat("FogFarPlane", FogFarPlane);
}

//float FogDensity;
float PropertyFog::GetFogDensity()
{
  return Owner->GetPropertyFloat("FogDensity");
}
void PropertyFog::SetFogDensity(float FogDensity)
{
  Owner->SetPropertyFloat("FogDensity", FogDensity);
}

//float FogColor;
// Color PropertyFog::GetFogColor()
void PropertyFog::GetFogColor(Color* __ret__)
{
  Owner->GetPropertyColor(__ret__, "FogColor");
}

// void PropertyFog::SetFogColor(Color FogColor)
void PropertyFog::SetFogColor(Color* FogColor)
{
  Owner->SetPropertyColor("FogColor", FogColor);
}



//================================================================================
//World
TransformGroup* World::GetTransformGroup()
{
  if (!ENG_CAPI_World_GetTransformGroup)
    return NULL;
  else
    return ENG_CAPI_World_GetTransformGroup(id);
}

Camera* World::GetDefaultCamera()
{
  if (!ENG_CAPI_World_GetDefaultCamera)
    return NULL;
  else
    return ENG_CAPI_World_GetDefaultCamera(id);
}






// Q2016.8.17
// Fbx

Fbx::Fbx(eng_obj_ptr uid) : ContainerComponent(uid) 
{
}

Fbx::~Fbx()
{
}

void
Fbx::ApplyAllProperty()
{
  if (!ENG_CAPI_Fbx_ApplyAllProperty)
    return;

  ENG_CAPI_Fbx_ApplyAllProperty(id);
}

bool
Fbx::FrameAnimate()
{
  if (!ENG_CAPI_Fbx_FrameAnimate)
    return false;
  else
    return ENG_CAPI_Fbx_FrameAnimate(id);
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


#if 0
// class TransformGroup {
//   class PropertyTransform  {
//     bool Show;
//     Vector3 Position;
//     Quaternion Rotation;
//     Vector3 Scale;
//     //DrawSort SortType;  // enum 
//     int SortType;  // enum 
//     int FixedOrder;
//     //CullType CullType;  // enum 
//     int CullType;  // enum 
//   };
//    
//    public PropertyTransform PropTransform;
// 					 
// 					 
//   public void SetLocalRotation(Quaternion q);
//   public void LookAtLocalDirection(Vector3 direction);
//   public void LookAtPosition(Vector3 position);
//   public void LookAt(Vector3 position, Vector3 target, Vector3 up);
//   public void ShiftPosition(Vector3 shift);
//   public void ViewTop(Vector3 target, float distance);
//   public void ViewBottom(Vector3 target, float distance);
//   public void ViewLeft(Vector3 target, float distance);
//   public void ViewRight(Vector3 target, float distance);
//   public void ViewFront(Vector3 target, float distance);
//   public void ViewRear(Vector3 target, float distance);
//   public void MoveForward(float dist);
//   public void Rotate(float x, float y, Vector3 center);
//   public void SetScale(Vector3 scale);
//   public void SetPosition(Vector3 pos);
//   public void SetLocalPosition(Vector3 pos);
// 
//   public Quaternion GetLocalRotation();
// 
//   public Vector3 GetScale();
//   public Vector3 GetLocalPosition();
//   public Vector3 GetLocalScale();
//   public Vector3 GetPosition();
//   public Vector3 GetDirection();
//   public Vector3 GetUp();
//   public Vector3 GetTarget();
//   public Vector3 WorldToLocalPosition(Vector3 world);
//   public Vector3 WorldToLocalDirection(Vector3 world);
//   public Vector3 LocalToWorldPosition(Vector3 local);
//   public Vector3 LocalToWorldDirection(Vector3 local);
// 
//   public bool IsVisible();
//   public bool IsTransparent();
//   public bool IsCullable();
//   public bool FindNearCollision(Vector3 posfrom, Vector3 posto, ref Vector3 intersectnew, ref float dist);
//   public TransformGroup FindNearestCollision(Vector3 from, Vector3 to, ref Vector3 intersect, ref float distr);
// 
//   public TransformGroup Find(string objectNamePath );
// 
//   public World GetWorld();
// 
//   public BoundingBox GetLocalBox();
//   public BoundingBox GetWorldBox(); 
//   public BoundingBox GetSumBox();
// };
#endif


#if 0
// // obsolete set
// int (*PTransformSetPropertyVector3)(int obj, const char *propName, float x, float y, float z) = NULL;
// int (*PTransformGetPropertyVector3)(int obj, const char *propName, float *x, float *y, float *z) = NULL;
// 
// void* (*ENG_CAPI_TransformGroup_GetWorld)(eng_obj_ptr) = NULL;
// void* //World*
// TransformGroup::GetWorld() {
//   return ENG_CAPI_TransformGroup_GetWorld(id);
// }



#endif


