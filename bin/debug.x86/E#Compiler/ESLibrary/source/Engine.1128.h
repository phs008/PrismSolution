#pragma once


#define COMPONENT_TRANSFORMGROUP  0
#define COMPONENT_WORLD 1
#define COMPONENT_CAMERA 2
#define COMPONENT_LIGHT 3


typedef unsigned long long eng_obj_ptr;


struct Vector2 {
  float x;
  float y;
  
  Vector2() {}
  
  Vector2(float x, float y) : x(x), y(y)  {
  }

	void $CopyForStructureType$(Vector2* rhs)
	{
		this->x = rhs->x;
		this->y = rhs->y;
	}
};

struct Vector3 {
  float x;
  float y;
  float z;
  
  Vector3() {}
  
  Vector3(float x0, float y0, float z0): x(x0),	y(y0),	z(z0) {
  }

	void $CopyForStructureType$(Vector3* rhs)
	{
		this->x = rhs->x;
		this->y = rhs->y;
		this->z = rhs->z;
	}
};

struct Vector4 {
  float x;
  float y;
  float z;
  float w;
  
  Vector4() {}
  
  Vector4(float x0, float y0, float z0, float w0) : x(x0), y(y0), z(z0), w(w0) {
  }

	void $CopyForStructureType$(Vector4* rhs)
	{
		this->x = rhs->x;
		this->y = rhs->y;
		this->z = rhs->z;
		this->w = rhs->w;
	}
};


struct Quaternion {
  float x;
  float y;
  float z;
  float w;

  Quaternion() {}
  
  Quaternion(float x0, float y0, float z0,float w0): x(x0), y(y0), z(z0), w(w0) {
  }

	void $CopyForStructureType$(Quaternion* rhs)
	{
		this->x = rhs->x;
		this->y = rhs->y;
		this->z = rhs->z;
		this->w = rhs->w;
	}
};


struct BoundingBox {
  Vector3 Vertex[2];

	void $CopyForStructureType$(BoundingBox* rhs)
	{
		this->Vertex[0].$CopyForStructureType$(&(rhs->Vertex[0]));
		this->Vertex[1].$CopyForStructureType$(&(rhs->Vertex[1]));
	}
};


struct Matrix {
  float m[4][4];

	void $CopyForStructureType$(Matrix* rhs)
	{
		for (int i=0; i<4; ++i)
		{
			for (int j=0; j<4; ++j)
			{
				this->m[i][j] = rhs->m[i][j];
			}
		}
	}
};


struct Color {
  float r;
  float g;
  float b;
  float a;

	void $CopyForStructureType$(Color* rhs)
	{
		this->r = rhs->r;
		this->g = rhs->g;
		this->b = rhs->b;
		this->a = rhs->a;
	}
};

// predefined component id


class ComponentBase;

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

  PropertyInstance(ComponentBase *owner);
  virtual ~PropertyInstance() { } 

#include "InterfacePropertyInstanceECppMethodDecl.interface"


};

EXTERN_C DLLAPI void (*ENG_CAPI_PropertyInstance_SetName)(eng_obj_ptr obj, const char *name);
EXTERN_C DLLAPI string (*ENG_CAPI_PropertyInstance_GetName)(eng_obj_ptr obj);

EXTERN_C DLLAPI void (*ENG_CAPI_PropertyInstance_SetLocked)(eng_obj_ptr obj, int locked);
EXTERN_C DLLAPI int (*ENG_CAPI_PropertyInstance_GetLocked)(eng_obj_ptr obj);

EXTERN_C DLLAPI void (*ENG_CAPI_PropertyInstance_SetExpanded)(eng_obj_ptr obj, int expanded);
EXTERN_C DLLAPI int (*ENG_CAPI_PropertyInstance_GetExpanded)(eng_obj_ptr obj);

EXTERN_C DLLAPI void (*ENG_CAPI_PropertyInstance_SetSelected)(eng_obj_ptr obj, int selected);
EXTERN_C DLLAPI int  (*ENG_CAPI_PropertyInstance_GetSelected)(eng_obj_ptr obj);

//=========================================
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

  //  Vector3 GetPropertyVector3( const char * propertyName );
  void GetPropertyVector3(Vector3* __ret__, const char * propertyName );
  //  int SetPropertyVector3( const char * propertyName, Vector3 value );
  int SetPropertyVector3( const char * propertyName, Vector3* value );

  //  Vector2 GetPropertyVector2(const char * propertyName);
  void GetPropertyVector2(Vector2* __ret__, const char * propertyName);
  //  int SetPropertyVector2(const char * propertyName, Vector2 value);
  int SetPropertyVector2(const char * propertyName, Vector2* value);

  //  Color GetPropertyColor(const char* propertyName);
  void GetPropertyColor(Color* __ret__, const char* propertyName);
  //  int SetPropertyColor(const char* propertyName , Color color);
  int SetPropertyColor(const char* propertyName , Color* color);

  //   Quaternion GetPropertyQuaternion( const char * propertyName );
  void GetPropertyQuaternion(Quaternion* __ret__, const char * propertyName );
  //  int SetPropertyQuaternion( const char * propertyName, Quaternion value );
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
  void GetPropertyMatrix(Matrix* __ret__, const char * propertyName);
  //  int SetPropertyMatrix(const char * propertyName, Matrix value);
  int SetPropertyMatrix(const char * propertyName, Matrix* value);
};

EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_KindOf)(eng_obj_ptr obj, const char *className);
EXTERN_C DLLAPI const char * (*ENG_CAPI_ComponentBase_LeafClassName)(eng_obj_ptr obj);

EXTERN_C DLLAPI Vector3 (*ENG_CAPI_ComponentBase_GetPropertyVector3)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyVector3)( eng_obj_ptr obj, const char * propertyName, Vector3 value );

EXTERN_C DLLAPI Vector2(*ENG_CAPI_ComponentBase_GetPropertyVector2)(eng_obj_ptr obj, const char * propertyName);
EXTERN_C DLLAPI int(*ENG_CAPI_ComponentBase_SetPropertyVector2)(eng_obj_ptr obj, const char * propertyName, Vector2 value);

EXTERN_C DLLAPI Color(*ENG_CAPI_ComponentBase_GetPropertyColor)(eng_obj_ptr obj, const char * propertyName);
EXTERN_C DLLAPI int(*ENG_CAPI_ComponentBase_SetPropertyColor)(eng_obj_ptr obj, const char * propertyName, Color value);

EXTERN_C DLLAPI Quaternion (*ENG_CAPI_ComponentBase_GetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName, Quaternion value );

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

EXTERN_C DLLAPI  Matrix (*ENG_CAPI_ComponentBase_GetPropertyMatrix)(eng_obj_ptr obj, const char * propertyName);
EXTERN_C DLLAPI int(*ENG_CAPI_ComponentBase_SetPropertyMatrix)(eng_obj_ptr obj, const char * propertyName, Matrix value);


//=========================================
//ContainerComponent

class ContainerComponent : public ComponentBase
{
public:
  virtual const char* __GetClassName__() {
    return "ContainerComponent";
  }

  ContainerComponent(eng_obj_ptr uid);
  virtual ~ContainerComponent();
};



//=========================================
//Container
class Container : public ComponentBase {
public:
  virtual const char* __GetClassName__() {
    return "Container";
  }

  Container(eng_obj_ptr uid);
  virtual ~Container();

  
  ContainerComponent *GetReservedComponent(int componentID);
  ContainerComponent *FindComponentByType(const char *type);
};
EXTERN_C DLLAPI eng_obj_ptr (*ENG_CAPI_Container_GetReservedComponent)(eng_obj_ptr obj,  int componentID );
EXTERN_C DLLAPI eng_obj_ptr(*ENG_CAPI_Container_FindComponentByType)(eng_obj_ptr obj, const char *type);


//=========================================
//PropertyTransformGroup

class PropertyTransformGroup : public $__Object__$ 
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyTransformGroup";
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

  PropertyTransformGroup(ComponentBase *owner);
  virtual ~PropertyTransformGroup() { } 


  string GetName();
  void SetName(const char *name );

  bool GetShow();
  void SetShow(bool show);

  //  Vector3 GetPosition();
  void GetPosition(Vector3* __ret__);
  //  void SetPosition(Vector3 pos );
  void SetPosition(Vector3* pos );

  //  Quaternion GetRotation();
  void GetRotation(Quaternion* __ret__);
  //  void SetRotation(Quaternion rot);
  void SetRotation(Quaternion* rot);

  //  Vector3 GetScale();
  void GetScale(Vector3* __ret__);
  //  void SetScale(Vector3 scale);
  void SetScale(Vector3* scale);

  int GetSortType();
  void SetSortType(int sortType);

  int GetFixedOrder();
  void SetFixedOrder(int fixedOrder);

  int GetCullType();
  void SetCullType(int cullType);

  int GetUseUserTransform();
  void SetUseUserTransform(int useUserTransform);

  //  Matrix GetUserTransform();
  void GetUserTransform(Matrix* __ret__);
  //  void SetUserTransform(Matrix userTransform);
  void SetUserTransform(Matrix* userTransform);

  //  Matrix GetTransform(); // calculated transform
  void GetTransform(Matrix* __ret__); // calculated transform

};

EXTERN_C DLLAPI const char* (*ENG_CAPI_PropertyTransformGroup_GetName)(eng_obj_ptr obj);
EXTERN_C DLLAPI void (*ENG_CAPI_PropertyTransformGroup_SetName)(eng_obj_ptr obj, const char *name);

EXTERN_C DLLAPI bool (*ENG_CAPI_PropertyTransformGroup_GetShow)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransformGroup_SetShow)(eng_obj_ptr obj, bool name);

EXTERN_C DLLAPI Vector3(*ENG_CAPI_PropertyTransformGroup_GetPosition)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransformGroup_SetPosition)(eng_obj_ptr obj, Vector3 pos);

EXTERN_C DLLAPI Quaternion(*ENG_CAPI_PropertyTransformGroup_GetRotation)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransformGroup_SetRotation)(eng_obj_ptr obj, Quaternion rot);

EXTERN_C DLLAPI Vector3(*ENG_CAPI_PropertyTransformGroup_GetScale)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransformGroup_SetScale)(eng_obj_ptr obj, Vector3 rot);

EXTERN_C DLLAPI int(*ENG_CAPI_PropertyTransformGroup_GetSortType)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransformGroup_SetSortType)(eng_obj_ptr obj, int sortType);

EXTERN_C DLLAPI int(*ENG_CAPI_PropertyTransformGroup_GetFixedOrder)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransformGroup_SetFixedOrder)(eng_obj_ptr obj, int fixedOrder);

EXTERN_C DLLAPI int(*ENG_CAPI_PropertyTransformGroup_GetCullType)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransformGroup_SetCullType)(eng_obj_ptr obj, int cullType);

EXTERN_C DLLAPI int(*ENG_CAPI_PropertyTransformGroup_GetUseUserTransform)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransformGroup_SetUseUserTransform)(eng_obj_ptr obj, int useUserTransform);

EXTERN_C DLLAPI Matrix(*ENG_CAPI_PropertyTransformGroup_GetUserTransform)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyTransformGroup_SetUserTransform)(eng_obj_ptr obj, Matrix userTransform);

EXTERN_C DLLAPI Matrix(*ENG_CAPI_PropertyTransformGroup_GetTransform)(eng_obj_ptr obj);

//=========================================
//TransformGroup


class TransformGroup : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "TransformGroup";
  }
  
public:
  TransformGroup(eng_obj_ptr uid);
  virtual ~TransformGroup() {} 

  PropertyTransformGroup *PropTransformGroup;


  TransformGroup* Find(char* objectNamePath);
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
  void GetLocalRotation(Quaternion* __ret__);

  //  Vector3 GetScale();
  void GetScale(Vector3* __ret__);
  //  Vector3 GetLocalPosition();
  void GetLocalPosition(Vector3* __ret__);
  //  Vector3 GetLocalScale();
  void GetLocalScale(Vector3* __ret__);
  //  Vector3 GetPosition();
  void GetPosition(Vector3* __ret__);
  //int  GetPosition();
  
  //Vector3 GetDirection();
  void GetDirection(Vector3* __ret__);
  //  Vector3 GetUp();
  void GetUp(Vector3* __ret__);
  //  Vector3 GetTarget();
  void GetTarget(Vector3* __ret__);
  //  Vector3 WorldToLocalPosition(Vector3 world);
  void WorldToLocalPosition(Vector3* __ret__, Vector3* world);
  //  Vector3 WorldToLocalDirection(Vector3 world);
  void WorldToLocalDirection(Vector3* __ret__, Vector3* world);
  //  Vector3 LocalToWorldPosition(Vector3 local);
  void LocalToWorldPosition(Vector3* __ret__, Vector3* local);
  //  Vector3 LocalToWorldDirection(Vector3 local);
  void LocalToWorldDirection(Vector3* __ret__, Vector3* local);

  int IsVisible();
  int IsTransparent();
  int IsCullable();
  //  Vector3* <== ref type ??
  //  int FindNearCollision(Vector3 posfrom, Vector3 posto, Vector3* intersectnew, float* dist);
  int FindNearCollision(Vector3* posfrom, Vector3* posto, Vector3*& intersectnew, float* dist);
  //  TransformGroup* FindNearestCollision(Vector3 from, Vector3 to, Vector3* intersect,  float* distr);
  TransformGroup* FindNearestCollision(Vector3* from, Vector3* to, Vector3*& intersect,  float* distr);

  TransformGroup* Find(const char* objectNamePath );

  //void* GetWorld();

  //  BoundingBox GetLocalBox();
  void GetLocalBox(BoundingBox* __ret__);
  //  BoundingBox GetWorldBox(); //
  void GetWorldBox(BoundingBox* __ret__); //
  //  BoundingBox GetSumBox();
  void GetSumBox(BoundingBox* __ret__);
};

EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr obj );
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_SetLocalRotation)(eng_obj_ptr obj, Quaternion q);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_LookAtLocalDirection)(eng_obj_ptr obj, Vector3 direction);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_LookAtPosition)(eng_obj_ptr obj, Vector3 position);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_LookAt)(eng_obj_ptr obj, Vector3 position, Vector3 target, Vector3 up);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ShiftPosition)(eng_obj_ptr obj, Vector3 shift);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewTop)(eng_obj_ptr obj, Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewBottom)(eng_obj_ptr obj, Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewLeft)(eng_obj_ptr obj, Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewRight)(eng_obj_ptr obj, Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewFront)(eng_obj_ptr obj, Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_ViewRear)(eng_obj_ptr obj, Vector3 target, float distance);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_MoveForward)(eng_obj_ptr obj, float dist);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_Rotate)(eng_obj_ptr obj, float x, float y, Vector3 center);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_SetScale)(eng_obj_ptr obj, Vector3 scale);
EXTERN_C DLLAPI void(*ENG_CAPI_TransformGroup_SetPosition)(eng_obj_ptr obj, Vector3 pos);
EXTERN_C DLLAPI Quaternion(*ENG_CAPI_TransformGroup_GetLocalRotation)(eng_obj_ptr obj);
EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_GetScale)(eng_obj_ptr obj);
EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_GetLocalPosition)(eng_obj_ptr obj);
EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_GetLocalScale)(eng_obj_ptr obj);
EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_GetUp)(eng_obj_ptr obj);
EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_GetTarget)(eng_obj_ptr obj);
EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_WorldToLocalPosition)(eng_obj_ptr obj, Vector3 world);
EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_WorldToLocalDirection)(eng_obj_ptr obj, Vector3 world);
EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_LocalToWorldPosition)(eng_obj_ptr obj, Vector3 local);
EXTERN_C DLLAPI Vector3(*ENG_CAPI_TransformGroup_LocalToWorldDirection)(eng_obj_ptr obj, Vector3 local);
EXTERN_C DLLAPI int(*ENG_CAPI_TransformGroup_IsVisible)(eng_obj_ptr obj);
EXTERN_C DLLAPI int(*ENG_CAPI_TransformGroup_IsTransparent)(eng_obj_ptr obj);
EXTERN_C DLLAPI int(*ENG_CAPI_TransformGroup_IsCullable)(eng_obj_ptr obj);

EXTERN_C DLLAPI int(*ENG_CAPI_TransformGroup_FindNearCollision)(eng_obj_ptr obj, Vector3 posfrom, Vector3 posto, Vector3* intersectnew, float* dist);
EXTERN_C DLLAPI eng_obj_ptr(*ENG_CAPI_TransformGroup_Find)(eng_obj_ptr obj, const char* objectNamePath);
EXTERN_C DLLAPI eng_obj_ptr(*ENG_CAPI_TransformGroup_FindNearestCollision)(eng_obj_ptr obj, Vector3 from, Vector3 to, Vector3* intersect, float* distr);

EXTERN_C DLLAPI BoundingBox(*ENG_CAPI_TransformGroup_GetLocalBox)(eng_obj_ptr obj);
EXTERN_C DLLAPI BoundingBox(*ENG_CAPI_TransformGroup_GetWorldBox)(eng_obj_ptr obj);
EXTERN_C DLLAPI BoundingBox(*ENG_CAPI_TransformGroup_GetSumBox)(eng_obj_ptr obj);




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

  PropertyCamera(ComponentBase *owner);
  virtual ~PropertyCamera();


  float GetNearViewPlane();
  void SetNearViewPlane(float plane);

  float GetFarViewPlane();
  void SetFarViewPlane(float plane);

  float GetFarViewPlaneSky();
  void SetFarViewPlaneSky(float plane);

  float GetFocalLength();
  void SetFocalLength(float length);


  float GetAspectRatio();
  void SetAspectRatio(float ratio);

  float GetDepthOfField();
  void SetDepthOfField(float dof);

  float GetFocusingDistance();
  void SetFocusingDistance(float fdist);

  float GetOrthographicViewSize();
  void SetOrthographicViewSize(float size);

  //  Vector2 GetOffset();
  void GetOffset(Vector2* __ret__);
  //  void SetOffset(Vector2 offset);
  void SetOffset(Vector2* offset);

  bool GetEnableCulling();
  void SetEnableCulling(bool enable);

  int GetBackgroundType();
  void SetBackGroundType(int type);

  bool GetDrawGrid();
  void SetDrawGrid(bool grid);
};

// Q 2016.8.13
EXTERN_C DLLAPI float(*ENG_CAPI_PropertyCamera_GetNearViewPlane)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetNearViewPlane)(eng_obj_ptr obj, float plane);
EXTERN_C DLLAPI float(*ENG_CAPI_PropertyCamera_GetFarViewPlane)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetFarViewPlane)(eng_obj_ptr obj, float plane);
EXTERN_C DLLAPI float(*ENG_CAPI_PropertyCamera_GetFarViewPlaneSky)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetFarViewPlaneSky)(eng_obj_ptr obj, float planeSky);
EXTERN_C DLLAPI float(*ENG_CAPI_PropertyCamera_GetFocalLength)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetFocalLength)(eng_obj_ptr obj, float Length);
EXTERN_C DLLAPI float(*ENG_CAPI_PropertyCamera_GetAspectRatio)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetAspectRatio)(eng_obj_ptr obj, float ratio);
EXTERN_C DLLAPI float(*ENG_CAPI_PropertyCamera_GetDepthOfField)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetDepthOfField)(eng_obj_ptr obj, float dof);
EXTERN_C DLLAPI float(*ENG_CAPI_PropertyCamera_GetFocusingDistance)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetFocusingDistance)(eng_obj_ptr obj, float distance);
EXTERN_C DLLAPI float(*ENG_CAPI_PropertyCamera_GetOrthographicViewSize)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetOrthographicViewSize)(eng_obj_ptr obj, float size);
EXTERN_C DLLAPI Vector2(*ENG_CAPI_PropertyCamera_GetOffset)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetOffset)(eng_obj_ptr obj, Vector2 offset);
EXTERN_C DLLAPI bool(*ENG_CAPI_PropertyCamera_GetEnableCulling)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetEnableCulling)(eng_obj_ptr obj, bool culling);
EXTERN_C DLLAPI Color(*ENG_CAPI_PropertyCamera_GetBackColor)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetBackColor)(eng_obj_ptr obj, Color backColor);
EXTERN_C DLLAPI int(*ENG_CAPI_PropertyCamera_GetBackgroundType)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetBackGroundType)(eng_obj_ptr obj, int type);
EXTERN_C DLLAPI bool(*ENG_CAPI_PropertyCamera_GetDrawGrid)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyCamera_SetDrawGrid)(eng_obj_ptr obj, bool grid);




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
  void GetProjectionMatrix(Matrix* __ret__);

  // 뷰 매트릭스를 반환한다
  // Matrix GetViewMatrix();
  void GetViewMatrix(Matrix* __ret__);

  // 뷰 매트릭스와 투영 매트릭스의 곱을 반환한다
  // Matrix GetViewProjectionMatrix();
  void GetViewProjectionMatrix(Matrix* __ret__);

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

  // 모든 변화를 적용시킨다
  virtual void ApplyAllProperty();
};

// Q 2016.8.11
EXTERN_C DLLAPI int(*ENG_CAPI_Camera_PrepareInterface)(eng_obj_ptr);
EXTERN_C DLLAPI int(*ENG_CAPI_Camera_GetPickRay)(eng_obj_ptr, int, int, int, int, float, Vector3&, Vector3&);
EXTERN_C DLLAPI int(*ENG_CAPI_Camera_SetupView)(eng_obj_ptr, int, int);
EXTERN_C DLLAPI void(*ENG_CAPI_Camera_Pan)(eng_obj_ptr, float, float);
EXTERN_C DLLAPI void(*ENG_CAPI_Camera_ApplyAllProperty)(eng_obj_ptr);
EXTERN_C DLLAPI Matrix(*ENG_CAPI_Camera_GetProjectionMatrix)(eng_obj_ptr);
EXTERN_C DLLAPI Matrix(*ENG_CAPI_Camera_GetViewMatrix)(eng_obj_ptr);
EXTERN_C DLLAPI Matrix(*ENG_CAPI_Camera_GetViewProjectionMatrix)(eng_obj_ptr);



// obsolete set

//EXTERN_C DLLAPI int  (*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr);
//EXTERN_C DLLAPI int (*PTransformSetPropertyVector3)(int obj, const char *propName, float x, float y, float z);
//EXTERN_C DLLAPI int (*PTransformGetPropertyVector3)(int obj, const char *propName, float *x, float *y, float *z);
//EXTERN_C DLLAPI void*       (*ENG_CAPI_TransformGroup_GetWorld)(eng_obj_ptr);



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

  PropertyLight(ComponentBase *owner);
  virtual ~PropertyLight() { }

  //Scene::TypeLightType LightType;
  int GetLightType();
  void SetLightType(int lightType);
		
  ////라이트 색상
  //Component::TypeColor LightColor;
  //   Color GetLightColor();
  void GetLightColor(Color* __ret__);
  //  void SetLightColor(Color lightColor);
  void SetLightColor(Color* lightColor);

  ////라이트 거리
  //Scene::TypeLightRange LightRange;
  //Local = 1; Global = 2;
  int GetLightRange();
  void SetLightRange(int LightRange); 

  ////주변광 값
  //Component::TypeFloat  Ambient;
  float GetAmbient();
  void SetAmbient(float ambient);

  ////반사광 값
  //Component::TypeFloat  Specular;
  float GetSpecular();
  void SetSpecular(float specular);

  ////색상 값
  //Component::TypeFloat  Diffuse;
  float GetDiffuse();
  void SetDiffuse(float diffuse);

  ////스포트라이트 각도 안쪽   // theta
  //Component::TypeFloat  SpotAngle;
  float GetSpotAngle();
  void SetSpotAngle(float spotAngle);

  ////바깥쪽 add  // phi
  //Component::TypeFloat  SpotAngleSmooth;
  float GetSpotAngleSmooth();
  void SetSpotAngleSmooth(float spotAngleSmooth);

  ////라이트 인식
  //Component::TypeFloat  PickerSize;
  float GetPickerSize();
  void SetPickerSize(float pickerSize);

  //// Dynamic Lighting 계산시 영향 받는 거리를 계산 하기 위한 최소 Diffuse 값 
  //Component::TypeFloat  MinEffectiveDiffuse;
  float GetMinEffectiveDiffuse();
  void SetMinEffectiveDiffuse(float minEffectiveDiffuse);

  //// Dynamic Lighting 계산시 영향 받는 거리를 계산 하기 위한 최대 거리 값
  //Component::TypeFloat  MaxEffectiveRange;
  float GetMaxEffectiveRange();
  void SetMaxEffectiveRange(float maxEffectiveRange);
	
};

EXTERN_C DLLAPI int (*ENG_CAPI_PropertyLight_GetLightType)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetLightType)(eng_obj_ptr obj, int lightType);

EXTERN_C DLLAPI Color(*ENG_CAPI_PropertyLight_GetLightColor)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetLightColor)(eng_obj_ptr obj, Color lightColor);

EXTERN_C DLLAPI int(*ENG_CAPI_PropertyLight_GetLightRange)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetLightRange)(eng_obj_ptr obj, int LightRange);

EXTERN_C DLLAPI float (*ENG_CAPI_PropertyLight_GetAmbient)(eng_obj_ptr obj);
EXTERN_C DLLAPI void (*ENG_CAPI_PropertyLight_SetAmbient)(eng_obj_ptr obj, float ambient);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyLight_GetSpecular)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetSpecular)(eng_obj_ptr obj, float specular);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyLight_GetDiffuse)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetDiffuse)(eng_obj_ptr obj, float diffuse);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyLight_GetSpotAngle)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetSpotAngle)(eng_obj_ptr obj, float spotAngle);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyLight_GetSpotAngleSmooth)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetSpotAngleSmooth)(eng_obj_ptr obj, float spotAngleSmooth);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyLight_GetPickerSize)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetPickerSize)(eng_obj_ptr obj, float pickerSize);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyLight_GetMinEffectiveDiffuse)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetMinEffectiveDiffuse)(eng_obj_ptr obj, float minEffectiveDiffuse);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyLight_GetMaxEffectiveRange)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyLight_SetMaxEffectiveRange)(eng_obj_ptr obj, float maxEffectiveRange);


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
  void GetLocalBox(BoundingBox* __ret__);
  void ApplyAllProperty();
};


EXTERN_C DLLAPI BoundingBox (*ENG_CAPI_Light_GetLocalBox)(eng_obj_ptr obj);
EXTERN_C DLLAPI void (*ENG_CAPI_Light_ApplyAllProperty)(eng_obj_ptr obj);


class PropertyFog : public $__Object__$
{
public:
  virtual const char* __GetClassName__() {
    return "PropertyFog";
  }
public:
  //	static Component::PropertyDefault DefaultValue;

  PropertyFog();
  virtual ~PropertyFog();

  ComponentBase *Owner;

  //int FogMode;
  int GetFogMode();
  void SetFogMode(int FogMode);

  //float FogNearPlane;
  float GetFogNearPlane();
  void SetFogNearPlane(float fogNearPlane);

  //float FogFarPlane;
  float GetFogFarPlane();
  void SetFogFarPlane(float FogFarPlane);

  //float FogDensity;
  float GetFogDensity();
  void SetFogDensity(float FogDensity);

  //float FogColor;
  //  Color GetFogColor();
  void GetFogColor(Color* __ret__);
  //  void SetFogColor(Color FogColor);
  void SetFogColor(Color* FogColor);
};

EXTERN_C DLLAPI int(*ENG_CAPI_PropertyFog_GetFogMode)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyFog_SetFogMode)(eng_obj_ptr obj, int FogMode);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyFog_GetFogNearPlane)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyFog_SetFogNearPlane)(eng_obj_ptr obj, float fogNearPlane);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyFog_GetFogFarPlane)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyFog_SetFogFarPlane)(eng_obj_ptr obj, float FogFarPlane);

EXTERN_C DLLAPI float(*ENG_CAPI_PropertyFog_GetFogDensity)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyFog_SetFogDensity)(eng_obj_ptr obj, float FogDensity);

EXTERN_C DLLAPI Color(*ENG_CAPI_PropertyFog_GetFogColor)(eng_obj_ptr obj);
EXTERN_C DLLAPI void(*ENG_CAPI_PropertyFog_SetFogColor)(eng_obj_ptr obj , Color FogColor);

//World 

class World : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "World";
  }
  PropertyFog PropFog; 

  Container* GetDefaultLight(); //TODO CSI
  TransformGroup *GetTransformGroup();
  Camera *GetDefaultCamera();

  bool FrameAnimate();
};

EXTERN_C DLLAPI TransformGroup *(*ENG_CAPI_World_GetTransformGroup)(eng_obj_ptr obj);
EXTERN_C DLLAPI Camera* (*ENG_CAPI_World_GetDefaultCamera)(eng_obj_ptr obj);





class Fbx : public ContainerComponent {
public:
  virtual const char* __GetClassName__() {
    return "Fbx";
  }

public:
  Fbx(eng_obj_ptr uid);
  virtual ~Fbx();

  void ApplyAllProperty();

  bool FrameAnimate();

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

EXTERN_C DLLAPI void(*ENG_CAPI_Fbx_ApplyAllProperty)(eng_obj_ptr obj);
EXTERN_C DLLAPI int(*ENG_CAPI_Fbx_FrameAnimate)(eng_obj_ptr obj);
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
