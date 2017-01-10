#pragma once


typedef unsigned long long eng_obj_ptr;

#define COMPONENT_TRANSFORMGROUP  0
#define COMPONENT_WORLD 1
#define COMPONENT_CAMERA 2
#define COMPONENT_LIGHT 3


#if 0
public class PropertyTransform
{
  bool Show;
  Vector3 Position;
  Quaternion Rotation;
  Vector3 Scale;
  DrawSort SortType;  // enum 
  int FixedOrder;
  CullType CullType;  // enum 
};
#endif


struct Vector3 {
  float x;
  float y;
  float z;
	Vector3() {}
	Vector3(float x0, float y0, float z0):
		x(x0),	y(y0),	z(z0)
	{
	}
};


struct Quaternion {
  float x;
  float y;
  float z;
  float w;

	Quaternion() {}
	Quaternion(float x0, float y0, float z0,float w0):
		x(x0),	y(y0),	z(z0),	w(w0)
	{
	}
};


struct BoundingBox {
  Vector3 Vertex[2];
};

struct Matrix
{
	float m[4][4];
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


	string GetName();
	void SetName(const char *name );

	int GetLocked();
	void SetLocked(int locked);

	int GetExpanded();
	void SetExpanded(int expanded);

	int GetSelected();
	void SetSelected(int selected);


};




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

	Vector3 GetPropertyVector3( const char * propertyName );
	int SetPropertyVector3( const char * propertyName, Vector3 value );

	Quaternion GetPropertyQuaternion( const char * propertyName );
	int SetPropertyQuaternion( const char * propertyName, Quaternion value );

	int GetPropertyBoolean( const char * propertyName );
	int SetPropertyBoolean( const char * propertyName, int value );

	int GetPropertyInt( const char * propertyName );
	int SetPropertyInt( const char * propertyName, int value );

	string GetPropertyString( const char * propertyName );
	int SetPropertyString( const char * propertyName, const char *value );

};




EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_KindOf)(eng_obj_ptr obj, const char *className);
EXTERN_C DLLAPI const char * (*ENG_CAPI_ComponentBase_LeafClassName)(eng_obj_ptr obj);

EXTERN_C DLLAPI Vector3 (*ENG_CAPI_ComponentBase_GetPropertyVector3)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyVector3)( eng_obj_ptr obj, const char * propertyName, Vector3 value );

EXTERN_C DLLAPI Quaternion (*ENG_CAPI_ComponentBase_GetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName, Quaternion value );

EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_GetPropertyInt)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyInt)( eng_obj_ptr obj, const char * propertyName, int value );

EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_GetPropertyBoolean)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyBoolean)( eng_obj_ptr obj, const char * propertyName, int value );

EXTERN_C DLLAPI const char * (*ENG_CAPI_ComponentBase_GetPropertyString)( eng_obj_ptr obj, const char * propertyName );
EXTERN_C DLLAPI int (*ENG_CAPI_ComponentBase_SetPropertyString)( eng_obj_ptr obj, const char * propertyName, const char *value );





class ContainerComponent : public ComponentBase
{
public:
 virtual const char* __GetClassName__() {
    return "ContainerComponent";
 }

 ContainerComponent(eng_obj_ptr uid);
 virtual ~ContainerComponent();
};






class Container : public ComponentBase {
public:
  virtual const char* __GetClassName__() {
    return "Container";
	}

	Container(eng_obj_ptr uid);
	virtual ~Container();

  
	ContainerComponent *GetReservedComponent(int componentID);

};


EXTERN_C DLLAPI eng_obj_ptr (*ENG_CAPI_Container_GetReservedComponent)(eng_obj_ptr obj,  int componentID );



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

	int GetShow();
	void SetShow(int show);

	Vector3 GetPosition();
	void SetPosition(Vector3 pos );

	Quaternion GetRotation();
	void SetRotation(Quaternion rot);

	Vector3 GetScale();
	void SetScale(Vector3 scale);

	int GetSortType();
	void SetSortType(int sortType);

	int GetFixedOrder();
	void SetFixedOrder(int fixedOrder);

	int GetCullType();
	void SetCullType(int cullType);

	int GetUseUserTransform();
	void SetUseUserTransform(int useUserTransform);

	Matrix GetUserTransform();
	void SetUserTransform(Matrix userTransform);

	Matrix GetTransform(); // calculated transform

};








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
  void SetLocalRotation(Quaternion q);
  void LookAtLocalDirection(Vector3 direction);
  void LookAtPosition(Vector3 position);
  void LookAt(Vector3 position, Vector3 target, Vector3 up);
  void ShiftPosition(Vector3 shift);
  void ViewTop(Vector3 target, float distance);
  void ViewBottom(Vector3 target, float distance);
  

  void ViewLeft(Vector3 target, float distance);
  void ViewRight(Vector3 target, float distance);
  void ViewFront(Vector3 target, float distance);
  void ViewRear(Vector3 target, float distance);
  void MoveForward(float dist);
  void Rotate(float x, float y, Vector3 center);
  void SetScale(Vector3 scale);
  void SetPosition(Vector3 pos);
  void SetLocalPosition(Vector3 pos);

  Quaternion GetLocalRotation();

  Vector3 GetScale();
  Vector3 GetLocalPosition();
  Vector3 GetLocalScale();
  Vector3 GetPosition();
  //int  GetPosition();
  Vector3 GetDirection();
  Vector3 GetUp();
  Vector3 GetTarget();
  Vector3 WorldToLocalPosition(Vector3 world);
  Vector3 WorldToLocalDirection(Vector3 world);
  Vector3 LocalToWorldPosition(Vector3 local);
  Vector3 LocalToWorldDirection(Vector3 local);

  int IsVisible();
  int IsTransparent();
  int IsCullable();
  int FindNearCollision(Vector3 posfrom, Vector3 posto, Vector3* intersectnew, float* dist);
  TransformGroup* FindNearestCollision(Vector3 from, Vector3 to, Vector3* intersect,  float* distr);

  TransformGroup* Find(const char* objectNamePath );

  //void* GetWorld();

  BoundingBox GetLocalBox();
  BoundingBox GetWorldBox(); //
  BoundingBox GetSumBox();
};




// temporary test function 


EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr);    
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_SetLocalRotation)(eng_obj_ptr,Quaternion);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_LookAtLocalDirection)(eng_obj_ptr,Vector3);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_LookAtPosition)(eng_obj_ptr,Vector3);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_LookAt)(eng_obj_ptr,Vector3,Vector3,Vector3);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_ShiftPosition)(eng_obj_ptr,Vector3);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_ViewTop)(eng_obj_ptr,Vector3,float);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_ViewBottom)(eng_obj_ptr,Vector3,float);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_ViewLeft)(eng_obj_ptr,Vector3,float);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_ViewRight)(eng_obj_ptr,Vector3,float);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_ViewFront)(eng_obj_ptr,Vector3,float);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_ViewRear)(eng_obj_ptr,Vector3,float);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_MoveForward)(eng_obj_ptr,float);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_Rotate)(eng_obj_ptr,float,float,Vector3);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_SetScale)(eng_obj_ptr,Vector3);
EXTERN_C DLLAPI void (*ENG_CAPI_TransformGroup_SetPosition)(eng_obj_ptr,Vector3);
EXTERN_C DLLAPI Quaternion (*ENG_CAPI_TransformGroup_GetLocalRotation)(eng_obj_ptr);
EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_GetScale)(eng_obj_ptr) ;
EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_GetLocalPosition)(eng_obj_ptr);
EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_GetLocalScale)(eng_obj_ptr);
EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_GetUp)(eng_obj_ptr);
EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_GetTarget)(eng_obj_ptr) ;
EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_WorldToLocalPosition)(eng_obj_ptr,Vector3);
EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_WorldToLocalDirection)(eng_obj_ptr,Vector3) ;
EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_LocalToWorldPosition)(eng_obj_ptr,Vector3) ;
EXTERN_C DLLAPI Vector3 (*ENG_CAPI_TransformGroup_LocalToWorldDirection)(eng_obj_ptr,Vector3);
EXTERN_C DLLAPI int     (*ENG_CAPI_TransformGroup_IsVisible)(eng_obj_ptr);
EXTERN_C DLLAPI int     (*ENG_CAPI_TransformGroup_IsTransparent)(eng_obj_ptr);
EXTERN_C DLLAPI int     (*ENG_CAPI_TransformGroup_IsCullable)(eng_obj_ptr) ;

EXTERN_C DLLAPI int         (*ENG_CAPI_TransformGroup_FindNearCollision)(eng_obj_ptr, Vector3, Vector3, Vector3*, float*);
EXTERN_C DLLAPI eng_obj_ptr (*ENG_CAPI_TransformGroup_Find)(eng_obj_ptr, const char*);
EXTERN_C DLLAPI eng_obj_ptr (*ENG_CAPI_TransformGroup_FindNearestCollision)(eng_obj_ptr, Vector3, Vector3, Vector3*, float*);

EXTERN_C DLLAPI BoundingBox (*ENG_CAPI_TransformGroup_GetLocalBox)(eng_obj_ptr);
EXTERN_C DLLAPI BoundingBox (*ENG_CAPI_TransformGroup_GetWorldBox)(eng_obj_ptr);
EXTERN_C DLLAPI BoundingBox (*ENG_CAPI_TransformGroup_GetSumBox)(eng_obj_ptr);


// obsolete set

//EXTERN_C DLLAPI int  (*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr);
//EXTERN_C DLLAPI int (*PTransformSetPropertyVector3)(int obj, const char *propName, float x, float y, float z);
//EXTERN_C DLLAPI int (*PTransformGetPropertyVector3)(int obj, const char *propName, float *x, float *y, float *z);
//EXTERN_C DLLAPI void*       (*ENG_CAPI_TransformGroup_GetWorld)(eng_obj_ptr);


