#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"


int (*ENG_CAPI_ComponentBase_KindOf)(eng_obj_ptr obj, const char *className) = NULL;
const char *(*ENG_CAPI_ComponentBase_LeafClassName)(eng_obj_ptr obj) = NULL;

Vector3 (*ENG_CAPI_ComponentBase_GetPropertyVector3)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyVector3)( eng_obj_ptr obj, const char * propertyName, Vector3 value ) = NULL;

Quaternion (*ENG_CAPI_ComponentBase_GetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyQuaternion)( eng_obj_ptr obj, const char * propertyName, Quaternion value ) = NULL;

eng_obj_ptr (*ENG_CAPI_Container_GetReservedComponent)(eng_obj_ptr obj,  int componentID ) = NULL;


int (*ENG_CAPI_ComponentBase_GetPropertyInt)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyInt)( eng_obj_ptr obj, const char * propertyName, int value ) = NULL;

int (*ENG_CAPI_ComponentBase_GetPropertyBoolean)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyBoolean)( eng_obj_ptr obj, const char * propertyName, int value ) = NULL;

const char * (*ENG_CAPI_ComponentBase_GetPropertyString)( eng_obj_ptr obj, const char * propertyName ) = NULL;
int (*ENG_CAPI_ComponentBase_SetPropertyString)( eng_obj_ptr obj, const char * propertyName, const char *value ) = NULL;




Vector3 (*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr) = NULL;
//int     (*ENG_CAPI_TransformGroup_GetPosition)(eng_obj_ptr) = NULL;
void    (*ENG_CAPI_TransformGroup_SetLocalRotation)(eng_obj_ptr,Quaternion) = NULL;
void    (*ENG_CAPI_TransformGroup_LookAtLocalDirection)(eng_obj_ptr,Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_LookAtPosition)(eng_obj_ptr,Vector3) = NULL;
void    (*ENG_CAPI_TransformGroup_LookAt)(eng_obj_ptr,Vector3,Vector3,Vector3) = NULL;
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







//---------------------------------------------------------------------------------


PropertyInstance::PropertyInstance(ComponentBase *owner)
{
	Owner = owner;
}



string PropertyInstance::GetName()
{
	return Owner->GetPropertyString("Name");
}



void PropertyInstance::SetName(const char *name )
{
	Owner->SetPropertyString("Name", name);
}


int PropertyInstance::GetLocked()
{
	return Owner->GetPropertyBoolean("Locked");
}



void PropertyInstance::SetLocked(int locked)
{
	Owner->SetPropertyBoolean("Locked", locked);
}



int PropertyInstance::GetExpanded()
{
	return Owner->GetPropertyBoolean("Expanded");
}


void PropertyInstance::SetExpanded(int expanded)
{
	Owner->SetPropertyBoolean("Expanded", expanded);
}



int PropertyInstance::GetSelected()
{
	return Owner->GetPropertyBoolean("Selected");
}



void PropertyInstance::SetSelected(int selected)
{
	Owner->SetPropertyBoolean("Selected", selected);
}





//---------------------------------------------------------------------------------


PropertyTransformGroup::PropertyTransformGroup(ComponentBase *owner)
{
	Owner = owner;
}




//---------------------------------------------------------------------------------

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




Vector3 ComponentBase::GetPropertyVector3( const char * propertyName )
{
	if (!ENG_CAPI_ComponentBase_GetPropertyVector3)
		return Vector3(0,0,0);
	else
		return ENG_CAPI_ComponentBase_GetPropertyVector3( id, propertyName );
}



int ComponentBase::SetPropertyVector3( const char * propertyName, Vector3 value )
{
	if (!ENG_CAPI_ComponentBase_SetPropertyVector3)
		return 0;
	else
		return ENG_CAPI_ComponentBase_SetPropertyVector3( id, propertyName , value);

}




Quaternion ComponentBase::GetPropertyQuaternion( const char * propertyName )
{
	if (!ENG_CAPI_ComponentBase_GetPropertyQuaternion)
		return Quaternion(0,0,0,1);
	else
		return ENG_CAPI_ComponentBase_GetPropertyQuaternion( id, propertyName );
}



int ComponentBase::SetPropertyQuaternion( const char * propertyName, Quaternion value )
{
	if (!ENG_CAPI_ComponentBase_SetPropertyQuaternion)
		return 0;
	else
		return ENG_CAPI_ComponentBase_SetPropertyQuaternion( id, propertyName , value);

}



int ComponentBase::GetPropertyBoolean( const char * propertyName )
{
	if (!ENG_CAPI_ComponentBase_GetPropertyBoolean)
		return 0;
	else
		return ENG_CAPI_ComponentBase_GetPropertyBoolean( id, propertyName );
}


int ComponentBase::SetPropertyBoolean( const char * propertyName, int value )
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




string ComponentBase::GetPropertyString( const char * propertyName )
{
	if (!ENG_CAPI_ComponentBase_GetPropertyString)
		return 0;
	else
	{
		string s = ENG_CAPI_ComponentBase_GetPropertyString( id, propertyName );
		return s;
	}
}


int ComponentBase::SetPropertyString( const char * propertyName, const char *value )
{
	if (!ENG_CAPI_ComponentBase_SetPropertyString)
		return 0;
	else
		return ENG_CAPI_ComponentBase_SetPropertyString( id, propertyName , value);
}


//---------------------------------------------------------------------------------



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


//---------------------------------------------------------------------------------

Container::Container(eng_obj_ptr uid) : ComponentBase(uid)
{

}



Container::~Container()
{

}




//---------------------------------------------------------------------------------

TransformGroup::TransformGroup(eng_obj_ptr uid)
	: ContainerComponent(uid)
{
	PropTransformGroup = new PropertyTransformGroup(this);
}



Vector3
TransformGroup::GetPosition() 
{
	if (ENG_CAPI_TransformGroup_GetPosition)
		return ENG_CAPI_TransformGroup_GetPosition(id);
	else
	{
		return Vector3(0,0,0);
	}
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


void
TransformGroup::SetLocalRotation(Quaternion q) {
	if (!ENG_CAPI_TransformGroup_SetLocalRotation)
		return ;
		
  ENG_CAPI_TransformGroup_SetLocalRotation(id, q);
}

void
TransformGroup::LookAtLocalDirection(Vector3 direction) 
{
	if (!ENG_CAPI_TransformGroup_LookAtLocalDirection)
		return ;

	ENG_CAPI_TransformGroup_LookAtLocalDirection(id, direction);
}

void
TransformGroup::LookAtPosition(Vector3 position) {
	if (!ENG_CAPI_TransformGroup_LookAtPosition)
		return ;

  ENG_CAPI_TransformGroup_LookAtPosition(id, position);
}

void
TransformGroup::LookAt(Vector3 position, Vector3 target, Vector3 up) {
	if (!ENG_CAPI_TransformGroup_LookAt)
		return ;

  ENG_CAPI_TransformGroup_LookAt(id, position, target, up);
}


void
TransformGroup::ShiftPosition(Vector3 shift) {
	if (!ENG_CAPI_TransformGroup_ShiftPosition)
		return ;

  ENG_CAPI_TransformGroup_ShiftPosition(id, shift);
}


void
TransformGroup::ViewTop(Vector3 target, float distance) {
	if (!ENG_CAPI_TransformGroup_ViewTop)
		return ;
  ENG_CAPI_TransformGroup_ViewTop(id, target, distance);
}


void
TransformGroup::ViewBottom(Vector3 target, float distance) {
	if (!ENG_CAPI_TransformGroup_ViewBottom)
		return ;
  ENG_CAPI_TransformGroup_ViewBottom(id, target, distance);
}


void
TransformGroup::ViewLeft(Vector3 target, float distance) {
	if (!ENG_CAPI_TransformGroup_ViewLeft)
		return ;
  ENG_CAPI_TransformGroup_ViewLeft(id, target, distance);
}


void
TransformGroup::ViewRight(Vector3 target, float distance) {
	if (!ENG_CAPI_TransformGroup_ViewRight)
		return ;
  ENG_CAPI_TransformGroup_ViewRight(id, target, distance);
}

void
TransformGroup::ViewFront(Vector3 target, float distance) {
	if (!ENG_CAPI_TransformGroup_ViewFront)
		return ;
  ENG_CAPI_TransformGroup_ViewFront(id, target, distance);
}

void
TransformGroup::ViewRear(Vector3 target, float distance) {
	if (!ENG_CAPI_TransformGroup_ViewRear)
		return ;
  ENG_CAPI_TransformGroup_ViewRear(id, target, distance);
}

void
TransformGroup::MoveForward(float dist) {
	if (!ENG_CAPI_TransformGroup_MoveForward)
		return ;
  ENG_CAPI_TransformGroup_MoveForward(id, dist);
}


void
TransformGroup::Rotate(float x, float y, Vector3 center) {
	if (!ENG_CAPI_TransformGroup_Rotate)
		return ;
  ENG_CAPI_TransformGroup_Rotate(id, x, y, center);
}

void
TransformGroup::SetScale(Vector3 scale) {
	if (!ENG_CAPI_TransformGroup_SetScale)
		return ;
  ENG_CAPI_TransformGroup_SetScale(id, scale);
}

void
TransformGroup::SetPosition(Vector3 pos) {
	if (!ENG_CAPI_TransformGroup_SetPosition)
		return ;
  ENG_CAPI_TransformGroup_SetPosition(id, pos);
}


Quaternion
TransformGroup::GetLocalRotation() {
	if (!ENG_CAPI_TransformGroup_GetLocalRotation)
		return Quaternion(0,0,0,1);
  return ENG_CAPI_TransformGroup_GetLocalRotation(id);
}

Vector3
TransformGroup::GetScale() {
	if (!ENG_CAPI_TransformGroup_GetScale)
		return Vector3(0,0,0);
  return ENG_CAPI_TransformGroup_GetScale(id);
}

Vector3
TransformGroup::GetLocalPosition() {
	if (!ENG_CAPI_TransformGroup_GetLocalPosition)
		return Vector3(0,0,0);
  return ENG_CAPI_TransformGroup_GetLocalPosition(id);
}

Vector3
TransformGroup::GetLocalScale() {
	if (!ENG_CAPI_TransformGroup_GetLocalScale)
		return Vector3(0,0,0);
  return ENG_CAPI_TransformGroup_GetLocalScale(id);
}


Vector3
TransformGroup::GetUp() {
	if (!ENG_CAPI_TransformGroup_GetUp)
		return Vector3(0,0,0);
  return ENG_CAPI_TransformGroup_GetUp(id);
}


Vector3
TransformGroup::GetTarget() {
	if (!ENG_CAPI_TransformGroup_GetTarget)
		return Vector3(0,0,0);
  return ENG_CAPI_TransformGroup_GetTarget(id);
}

Vector3
TransformGroup::WorldToLocalPosition(Vector3 world) {
	if (!ENG_CAPI_TransformGroup_WorldToLocalPosition)
		return world;
  return ENG_CAPI_TransformGroup_WorldToLocalPosition(id, world);
}


Vector3
TransformGroup::WorldToLocalDirection(Vector3 world) {
	if (!ENG_CAPI_TransformGroup_WorldToLocalDirection)
		return world;
  return ENG_CAPI_TransformGroup_WorldToLocalDirection(id, world);
}


Vector3
TransformGroup::LocalToWorldPosition(Vector3 local) {
	if (!ENG_CAPI_TransformGroup_LocalToWorldPosition)
		return local;
  return ENG_CAPI_TransformGroup_LocalToWorldPosition(id, local);
}


Vector3
TransformGroup::LocalToWorldDirection(Vector3 local) {
	if (!ENG_CAPI_TransformGroup_LocalToWorldDirection)
		return local;
  return ENG_CAPI_TransformGroup_LocalToWorldDirection(id, local);
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


int
TransformGroup::FindNearCollision(Vector3 posfrom, Vector3 posto, Vector3* intersectnew, float* dist) {
	if (!ENG_CAPI_TransformGroup_FindNearCollision)
		return 0;
  return ENG_CAPI_TransformGroup_FindNearCollision(id,posfrom,posto,intersectnew,dist);
}


TransformGroup*
TransformGroup::FindNearestCollision(Vector3 from, Vector3 to, Vector3* intersect, float* distr) {
  TransformGroup* obj = new TransformGroup(0);
  if (obj == NULL)
    return NULL;
  else {
    obj->id = ENG_CAPI_TransformGroup_FindNearestCollision(id, from, to, intersect, distr);
    return obj;
  }
}



BoundingBox
TransformGroup::GetLocalBox() {
  return ENG_CAPI_TransformGroup_GetLocalBox(id);
}

BoundingBox
TransformGroup::GetWorldBox() {
  return ENG_CAPI_TransformGroup_GetWorldBox(id);
}

BoundingBox
TransformGroup::GetSumBox() {
  return ENG_CAPI_TransformGroup_GetSumBox(id);
}




#if 0
class TransformGroup {
  class PropertyTransform  {
    bool Show;
    Vector3 Position;
    Quaternion Rotation;
    Vector3 Scale;
    //DrawSort SortType;  // enum 
    int SortType;  // enum 
    int FixedOrder;
    //CullType CullType;  // enum 
    int CullType;  // enum 
  };
   
   public PropertyTransform PropTransform;
					 
					 
  public void SetLocalRotation(Quaternion q);
  public void LookAtLocalDirection(Vector3 direction);
  public void LookAtPosition(Vector3 position);
  public void LookAt(Vector3 position, Vector3 target, Vector3 up);
  public void ShiftPosition(Vector3 shift);
  public void ViewTop(Vector3 target, float distance);
  public void ViewBottom(Vector3 target, float distance);
  public void ViewLeft(Vector3 target, float distance);
  public void ViewRight(Vector3 target, float distance);
  public void ViewFront(Vector3 target, float distance);
  public void ViewRear(Vector3 target, float distance);
  public void MoveForward(float dist);
  public void Rotate(float x, float y, Vector3 center);
  public void SetScale(Vector3 scale);
  public void SetPosition(Vector3 pos);
  public void SetLocalPosition(Vector3 pos);

  public Quaternion GetLocalRotation();

  public Vector3 GetScale();
  public Vector3 GetLocalPosition();
  public Vector3 GetLocalScale();
  public Vector3 GetPosition();
  public Vector3 GetDirection();
  public Vector3 GetUp();
  public Vector3 GetTarget();
  public Vector3 WorldToLocalPosition(Vector3 world);
  public Vector3 WorldToLocalDirection(Vector3 world);
  public Vector3 LocalToWorldPosition(Vector3 local);
  public Vector3 LocalToWorldDirection(Vector3 local);

  public bool IsVisible();
  public bool IsTransparent();
  public bool IsCullable();
  public bool FindNearCollision(Vector3 posfrom, Vector3 posto, ref Vector3 intersectnew, ref float dist);
  public TransformGroup FindNearestCollision(Vector3 from, Vector3 to, ref Vector3 intersect, ref float distr);

  public TransformGroup Find(string objectNamePath );

  public World GetWorld();

  public BoundingBox GetLocalBox();
  public BoundingBox GetWorldBox(); 
  public BoundingBox GetSumBox();
};
#endif	



#if 0
// obsolete set

int (*PTransformSetPropertyVector3)(int obj, const char *propName, float x, float y, float z) = NULL;
int (*PTransformGetPropertyVector3)(int obj, const char *propName, float *x, float *y, float *z) = NULL;


void* (*ENG_CAPI_TransformGroup_GetWorld)(eng_obj_ptr) = NULL;
void* //World*
TransformGroup::GetWorld() {
  return ENG_CAPI_TransformGroup_GetWorld(id);
}


#endif


