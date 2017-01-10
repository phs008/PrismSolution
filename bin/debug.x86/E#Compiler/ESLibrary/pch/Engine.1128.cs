public struct Vector2
{
	public float x;
	public float y;

	public Vector2() {}

	public Vector2(float x0, float y0)
	{
		x = x0;
		y = y0;
	}
}


public struct Vector3
{
	public float x;
	public float y;
	public float z;

	public Vector3() {}

	public Vector3(float x0, float y0, float z0)
	{
		x = x0;
		y = y0;
		z = z0;
	}
}


public struct Vector4
{
	public float x;
	public float y;
	public float z;
	public float w;

	public Vector4() {}

	public Vector4(float x0, float y0, float z0, float w0)
	{
		x = x0;
		y = y0;
		z = z0;
		w = w0;
	}
}


public struct Quaternion
{
	public float x;
	public float y;
	public float z;
	public float w;

	public Quaternion() {}

	public Quaternion(float x0, float y0, float z0, float w0)
	{
		x = x0;
		y = y0;
		z = z0;
		w = w0;
	}
}


public struct BoundingBox
{
	// public Vector3[] Vertex = new Vector3[2];	// TODO
}


public struct Matrix
{
	// public float[,] m = new float[4,4];	// TODO
}


public struct Color
{
	public float r;
	public float g;
	public float b;
	public float a;
}



public class PropertyInstance
{
	public ComponentBase Owner;

	public PropertyInstance(ComponentBase owner)
	{
		Owner = owner;
	}

	
	public int Expanded
	{
		get; //return ENG_CAPI_PropertyInstance_GetExpanded(id);
		set; //	ENG_CAPI_PropertyInstance_SetExpanded(id, value);
	}
	
	
	
	public int Layer
	{
		get; //return ENG_CAPI_PropertyInstance_GetLayer(id);
		set; //	ENG_CAPI_PropertyInstance_SetLayer(id, value);
	}
	
	
	
	public int Locked
	{
		get; //return ENG_CAPI_PropertyInstance_GetLocked(id);
		set; //	ENG_CAPI_PropertyInstance_SetLocked(id, value);
	}
	
	
	
	public string Name
	{
		get; //return ENG_CAPI_PropertyInstance_GetName(id);
		set; //	ENG_CAPI_PropertyInstance_SetName(id, value);
	}
	
	
	
	public int Selected
	{
		get; //return ENG_CAPI_PropertyInstance_GetSelected(id);
		set; //	ENG_CAPI_PropertyInstance_SetSelected(id, value);
	}
	
	
	
	public int Show
	{
		get; //return ENG_CAPI_PropertyInstance_GetShow(id);
		set; //	ENG_CAPI_PropertyInstance_SetShow(id, value);
	}
	
	
	
}


public class ComponentBase
{
	public ulong id;

	public PropertyInstance PropInstance;

	public ComponentBase(ulong id);

	public int KindOf(string className);
	public string LeafClassName();


	public Vector3 GetPropertyVector3(string propertyName);
	public int SetPropertyVector3(string propertyName, Vector3 value);

	public Vector2 GetPropertyVector2(string propertyName);
	public int SetPropertyVector2(string propertyName, Vector2 value);

	public Color GetPropertyColor(string propertyName);
	public int SetPropertyColor(string propertyName, Color color);

	public Quaternion GetPropertyQuaternion(string propertyName);
	public int SetPropertyQuaternion(string propertyName, Quaternion value);

	public int GetPropertyInt(string propertyName);
	public int SetPropertyInt(string propertyName, int value);

	public float GetPropertyFloat(string propertyName);
	public int SetPropertyFloat(string propertyName, float value);

	public long GetPropertyInt64(string propertyName);
	public int SetPropertyInt64(string propertyName, long value);

	public double GetPropertyDouble(string propertyName);
	public int SetPropertyDouble(string propertyName, double value);

	public bool GetPropertyBoolean(string propertyName);
	public int SetPropertyBoolean(string propertyName, bool value);

	public string GetPropertyString(string propertyName);
	public int SetPropertyString(string propertyName, string value);

	public Matrix GetPropertyMatrix(string propertyName);
	public int SetPropertyMatrix(string propertyName, Matrix value);
}


public class ContainerComponent : ComponentBase
{
	public ContainerComponent(ulong uid);
}


public class Container : ComponentBase
{
	public Container(ulong uid);

	public ContainerComponent GetReservedComponent(int componentID);
	public ContainerComponent FindComponentByType(string typeName);
}


public class PropertyTransformGroup
{
	public ComponentBase Owner;

	public PropertyTransformGroup(ComponentBase owner);

	public string GetName();
	public void SetName(string name);

	public bool GetShow();
	public void SetShow(bool show);

	public Vector3 GetPosition();
	public void SetPosition(Vector3 pos);

	public Quaternion GetRotation();
	public void SetRotation(Quaternion rot);

	public Vector3 GetScale();
	public void SetScale(Vector3 scale);

	public int GetSortType();
	public void SetSortType(int sortType);

	public int GetFixedOrder();
	public void SetFixedOrder(int fixedOrder);

	public int GetCullType();
	public void SetCullType(int cullType);

	public int GetUseUserTransform();
	public void SetUseUserTransform(int useUserTransform);

	public Matrix GetUserTransform();
	public void SetUserTransform(Matrix userTransform);

	public Matrix GetTransform();
}


public class TransformGroup : ContainerComponent
{
	public TransformGroup(ulong uid);

	public PropertyTransformGroup PropTransformGroup;

	public TransformGroup Find(string objectNamePath);
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

	public int IsVisible();
	public int IsTransparent();
	public int IsCullable();
	public int FindNearCollision(Vector3 posfrom, Vector3 posto, ref Vector3 intersectnew, ref float dist);
	public TransformGroup FindNearestCollision(Vector3 from, Vector3 to, ref Vector3 intersect, ref float distr);

	// TransformGroup* Find(const char* objectNamePath);	// TODO

	public BoundingBox GetLocalBox();
	public BoundingBox GetWorldBox();
	public BoundingBox GetSumBox();
}


public class PropertyCamera
{
	public ComponentBase Owner;

	public PropertyCamera(ComponentBase owner);

	public float GetNearViewPlane();
	public void SetNearViewPlane(float plane);

	public float GetFarViewPlane();
	public void SetFarViewPlane(float plane);

	public float GetFarViewPlaneSky();
	public void SetFarViewPlaneSky(float plane);

	public float GetFocalLength();
	public void SetFocalLength(float length);

	public float GetAspectRatio();
	public void SetAspectRatio(float ratio);

	public float GetDepthOfField();
	public void SetDepthOfField(float dof);

	public float GetFocusingDistance();
	public void SetFocusingDistance(float fdist);

	public float GetOrthographicViewSize();
	public void SetOrthographicViewSize(float size);

	public Vector2 GetOffset();
	public void SetOffset(Vector2 offset);

	public bool GetEnableCulling();
	public void SetEnableCulling(bool enable);

	public int GetBackgroundType();
	public void SetBackGroundType(int typeValue);

	public bool GetDrawGrid();
	public void SetDrawGrid(bool grid);
}


public class Camera : ContainerComponent
{
	public Camera(ulong uid);

	public bool PrepareInterface();

	public PropertyCamera PropCamera;

	// 투영 매트릭스를 반환한다
	public Matrix GetProjectionMatrix();

	// 뷰 매트릭스를 반환한다
	public Matrix GetViewMatrix();

	// 뷰 매트릭스와 투영 매트릭스의 곱을 반환한다
	public Matrix GetViewProjectionMatrix();

	// x, y : 화면상의 마우스 포지션
	// width, height : 화면의 넓이와 길이
	// length : 반환되는 ray의 길이
	// pickRayOrig, pickRayDir : 함수의 반환값 레이의 시작 위치와 레이의 방향 및 크기를 반환한다
	public bool GetPickRay(int x, int y, int width, int height, float length, ref Vector3 pickRayOrig, ref Vector3 pickRayDir);

	// 뷰 매트릭스를 생성한다
	public bool SetupView(int w, int h);	// update view matrix;

	// 카메라 수평 이동
	public void Pan(float x, float y);

	// 모든 변화를 적용시킨다
	public virtual void ApplyAllProperty();
}


public class PropertyLight
{
	public ComponentBase Owner;

	public PropertyLight(ComponentBase owner);

	//Scene::TypeLightType LightType;
	public int GetLightType();
	public void SetLightType(int lightType);

	////라이트 색상
	//Component::TypeColor LightColor;
	public Color GetLightColor();
	public void SetLightColor(Color lightColor);

	////라이트 거리
	//Scene::TypeLightRange LightRange;
	//Local = 1; Global = 2;
	public int GetLightRange();
	public void SetLightRange(int LightRange);

	////주변광 값
	//Component::TypeFloat Ambient;
	public float GetAmbient();
	public void SetAmbient(float ambient);

	////반사광 값
	//Component::TypeFloat  Specular;
	public float GetSpecular();
	public void SetSpecular(float specular);

	////색상 값
	//Component::TypeFloat  Diffuse;
	public float GetDiffuse();
	public void SetDiffuse(float diffuse);

	////스포트라이트 각도 안쪽   // theta
	//Component::TypeFloat  SpotAngle;
	public float GetSpotAngle();
	public void SetSpotAngle(float spotAngle);

	////바깥쪽 add  // phi
	//Component::TypeFloat  SpotAngleSmooth;
	public float GetSpotAngleSmooth();
	public void SetSpotAngleSmooth(float spotAngleSmooth);

	////라이트 인식
	//Component::TypeFloat  PickerSize;
	public float GetPickerSize();
	public void SetPickerSize(float pickerSize);

	//// Dynamic Lighting 계산시 영향 받는 거리를 계산 하기 위한 최소 Diffuse 값
	//Component::TypeFloat  MinEffectiveDiffuse;
	public float GetMinEffectiveDiffuse();
	public void SetMinEffectiveDiffuse(float minEffectiveDiffuse);

	//// Dynamic Lighting 계산시 영향 받는 거리를 계산 하기 위한 최대 거리 값
	//Component::TypeFloat  MaxEffectiveRange;
	public float GetMaxEffectiveRange();
	public void SetMaxEffectiveRange(float maxEffectiveRange);
}


public class Light : ContainerComponent
{
	public Light(ulong uid);

	public PropertyLight PropLight;

	public BoundingBox GetLocalBox();
	public void ApplyAllProperty();
}


public class PropertyFog
{
	public PropertyFog();

	public ComponentBase Owner;

	//int FogMode;
	public int GetFogMode();
	public void SetFogMode(int FogMode);

	//float FogNearPlane;
	public float GetFogNearPlane();
	public void SetFogNearPlane(float fogNearPlane);

	//float FogFarPlane;
	public float GetFogFarPlane();
	public void SetFogFarPlane(float FogFarPlane);

	//float FogDensity;
	public float GetFogDensity();
	public void SetFogDensity(float FogDensity);

	//float FogColor;
	public Color GetFogColor();
	public void SetFogColor(Color FogColor);
}


public class World : ContainerComponent
{
	public PropertyFog PropFog;

	public Container GetDefaultLight();
	public TransformGroup GetTransformGroup();
	public Camera GetDefaultCamera();

	public bool FrameAnimate();
}


public class Fbx : ContainerComponent
{
	public Fbx(ulong uid);

	public void ApplyAllProperty();

	public bool FrameAnimate();

	public void Play();
	public void Pause();
	public void Stop();

	public void ClearActiveAnimation();
	public bool SetActiveAnimation(string animationName);
	public bool SetActiveAnimation(int idx);

	public void UpdateAnimationEnumerator();

	public bool IsFbxVisible();
	public bool IsFbxTransparent();

	public void CheckFbxFlip();

	public int GetAnimationMode();
	public void SetAnimationMode(int mode);

	public int GetActiveAnimationIndex();
	public void SetActiveAnimationIndex(int index);

	public int GetAnimationCurrentTime();
	public void SetAnimationCurrentTime(int time);
}
