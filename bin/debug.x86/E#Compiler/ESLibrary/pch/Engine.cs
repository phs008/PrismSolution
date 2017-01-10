


//ENGINE_SCRIPT_PROPERTY #8
public class PropertyInstance
{
	public ComponentBase Owner;
	int GroupIndex;

	public PropertyInstance(ComponentBase owner);

	public int GetExpanded( );
	public void SetExpanded(int value);



	public int GetLayer( );
	public void SetLayer(int value);



	public int GetLocked( );
	public void SetLocked(int value);



	public string GetName( );
	public void SetName(string value);



	public int GetSelected( );
	public void SetSelected(int value);



	public int GetShow( );
	public void SetShow(int value);




}

public class ComponentBase
{

	public ulong id;

	public PropertyInstance PropInstance;

	public ComponentBase(ulong id);

	public int KindOf(string className);
	public string LeafClassName();


// ENGINE_SCRIPT_API #10

	public Vector4 GetPropertyVector4(string propertyName);
	public int SetPropertyVector4(string propertyName, Vector4 value);


	public const int ValueCurveLinear = 0;
	public const int ValueCurveConverge = 1;
	public const int ValueCurveConvergeFast = 2;
	public const int ValueCurveSquare = 3;
	public const int ValueCurveCube = 4; // 3rd Power
	public const int ValueCurve4thPower = 5; // 4th power
	public const int ValueCurveElastic = 6;
	public const int ValueCurveElasticSoft = 7;

	public int AnimatePropertyVector4(string propertyName, Vector4 value, float laptime, int curveType);

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

	public int SendMessage(string msg, int arg0, Vector4 arg1, Vector4 arg2);
	public int PostMessage(string msg, int arg0, Vector4 arg1, Vector4 arg2);
	public int TimedMessage(string msg, double interval, int arg0, Vector4 arg1, Vector4 arg2);
	public int PeriodicMessage(string msg, double interval, int count, int arg0, Vector4 arg1, Vector4 arg2);
	public bool CancelMessage(string msg);

}


public class ContainerComponent : ComponentBase
{
	public ContainerComponent(ulong uid);

	public bool OnWork(string work); 
}


public class Container : ComponentBase
{
	public Container(ulong uid);

	public ContainerComponent GetReservedComponent(int componentID);
	public ContainerComponent FindComponentByType(string typeName);
	public ContainerComponent Find(string typeName);
	public ContainerComponent GetRootContainer();

}


public class PropertyTransform
{
	public ComponentBase Owner;
	int GroupIndex;



	public PropertyTransform(ComponentBase owner);

	public int GetUseUserTransform();
	public void SetUseUserTransform(int useUserTransform);

	public Matrix GetUserTransform();
	public void SetUserTransform(Matrix userTransform);

	public Matrix GetTransform();

	public int GetBillboardType( );
	public void SetBillboardType(int value);



	public int GetCullType( );
	public void SetCullType(int value);



	public int GetFixedOrder( );
	public void SetFixedOrder(int value);



	public Vector3 GetPosition( );
	public void SetPosition(Vector3 value);



	public Quaternion GetRotation( );
	public void SetRotation(Quaternion value);



	public Vector3 GetScale( );
	public void SetScale(Vector3 value);



	public int GetShow( );
	public void SetShow(int value);



	public int GetSortType( );
	public void SetSortType(int value);





	

}


public class TransformGroup : ContainerComponent
{
	public TransformGroup(ulong uid);


	public const int CullTypeNone = 0;
	public const int CullTypeBoundingBox = 1;  // boundingBox Frustum check

	public const int BillboardTypeNone = 0;
	public const int BillboardTypeStand = 1;
	public const int BillboardTypeCamera = 2;
	public const int BillboardTypeStandReverse = 3;
	public const int BillboardTypeCameraReverse = 4;


	public PropertyTransform PropTransform;

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
	int GroupIndex;

	public PropertyCamera(ComponentBase owner);


	public const int MapProjectionPlane=0;
	public const int MapProjectionCross=1;
	public const int MapProjectionERP=2;   // Equirectangular Panorama

	
	public float GetAspectRatio( );
	public void SetAspectRatio(float value);



	public Color GetBackColor( );
	public void SetBackColor(Color value);



	public string GetBackgroundTextureFile( );
	public void SetBackgroundTextureFile(string value);



	public int GetBackgroundType( );
	public void SetBackgroundType(int value);



	public int GetClearColor( );
	public void SetClearColor(int value);



	public int GetClearDepth( );
	public void SetClearDepth(int value);



	public float GetDepthOfField( );
	public void SetDepthOfField(float value);



	public int GetDrawGrid( );
	public void SetDrawGrid(int value);



	public int GetEnableCulling( );
	public void SetEnableCulling(int value);



	public float GetFarViewPlane( );
	public void SetFarViewPlane(float value);



	public float GetFarViewPlaneSky( );
	public void SetFarViewPlaneSky(float value);



	public float GetFocalLength( );
	public void SetFocalLength(float value);



	public float GetFocusingDistance( );
	public void SetFocusingDistance(float value);



	public float GetGridAlpha( );
	public void SetGridAlpha(float value);



	public float GetGridInterval( );
	public void SetGridInterval(float value);



	public int GetLayerFilter( );
	public void SetLayerFilter(int value);



	public float GetNearViewPlane( );
	public void SetNearViewPlane(float value);



	public Vector2 GetOffset( );
	public void SetOffset(Vector2 value);



	public float GetOrthographicViewSize( );
	public void SetOrthographicViewSize(float value);



	public float GetRenderOrder( );
	public void SetRenderOrder(float value);



	public int GetStereoCamera( );
	public void SetStereoCamera(int value);



	public float GetStereoEyeOffset( );
	public void SetStereoEyeOffset(float value);



	public Vector2 GetViewPortCenter( );
	public void SetViewPortCenter(Vector2 value);



	public Vector2 GetViewPortSize( );
	public void SetViewPortSize(Vector2 value);



	public int GetWireFrame( );
	public void SetWireFrame(int value);




}


public class Camera : ContainerComponent
{
	public Camera(ulong uid);

	public bool PrepareInterface();

	public PropertyCamera PropCamera;

	// ?? ????? ????
	public Matrix GetProjectionMatrix();

	// ? ????? ????
	public Matrix GetViewMatrix();

	// ? ????? ?? ????? ?? ????
	public Matrix GetViewProjectionMatrix();

	// x, y : ???? ??? ???
	// width, height : ??? ??? ??
	// length : ???? ray? ??
	// pickRayOrig, pickRayDir : ??? ??? ??? ?? ??? ??? ?? ? ??? ????
	public bool GetPickRay(int x, int y, int width, int height, float length, ref Vector3 pickRayOrig, ref Vector3 pickRayDir);

	// ? ????? ????
	public bool SetupView(int w, int h);	// update view matrix;

	// ??? ?? ??
	public void Pan(float x, float y);

	// ?? ??? ?????
	public virtual void ApplyAllProperty();

	public Vector4 WorldCoordToScreenCoord(Vector3 v);
	public Vector3 ScreenCoordToWorldCoord(Vector3 v);
}


public class PropertyLight
{
	public ComponentBase Owner;
	int GroupIndex;

	public PropertyLight(ComponentBase owner);

	public const int LightTypeDirectional=1;
	public const int LightTypePoint=2;
	public const int LightTypeSpot=3;

	public const int LightRangeLocal=1;
	public const int LightRangeGlobal=2;

	public const int LightFallOffQuatratic=0;
	public const int LightFallOffExponential=1;
	public const int LightFallOffLinear=2;


	public float GetEffectiveRange( );
	public void SetEffectiveRange(float value);



	public Color GetLightColor( );
	public void SetLightColor(Color value);



	public int GetLightFallOff( );
	public void SetLightFallOff(int value);



	public float GetLightIntensity( );
	public void SetLightIntensity(float value);



	public int GetLightRange( );
	public void SetLightRange(int value);



	public int GetLightType( );
	public void SetLightType(int value);



	public float GetPickerSize( );
	public void SetPickerSize(float value);



	public float GetSpotAngle( );
	public void SetSpotAngle(float value);



	public float GetSpotAngleSmooth( );
	public void SetSpotAngleSmooth(float value);




}



public class Light : ContainerComponent
{
	public Light(ulong uid);

	public PropertyLight PropLight;

	public BoundingBox GetLocalBox();
}




public class PropertyFog
{
	public PropertyFog();

	public ComponentBase Owner;
	int GroupIndex;

	public Color GetFogColor( );
	public void SetFogColor(Color value);



	public float GetFogFarPlane( );
	public void SetFogFarPlane(float value);



	public int GetFogMode( );
	public void SetFogMode(int value);



	public float GetFogNearPlane( );
	public void SetFogNearPlane(float value);





}


public class World : ContainerComponent
{
	public PropertyFog PropFog;

	public Container GetDefaultLight();
	public TransformGroup GetTransformGroup();
	public Camera GetDefaultCamera();

	public float GetTime();
	public float GetFrameElapseTime();
	public void TimerSetSpeed(float speed);
	public void TimerStart();
	public void TimerStop();

}





public class PropertyFbxAnimation
{
	public PropertyFbxAnimation();

	public ComponentBase Owner;
	int GroupIndex;

	public string GetActiveAnimation( );
	public void SetActiveAnimation(string value);



	public float GetAnimationSpeed( );
	public void SetAnimationSpeed(float value);





}



public class PropertyFbxFile
{
	public PropertyFbxFile();

	public ComponentBase Owner;
	int GroupIndex;

	public string GetFbxFile( );
	public void SetFbxFile(string value);





}



public class Fbx : ContainerComponent
{
	public Fbx(ulong uid);

	public PropertyFbxAnimation PropFbxAnimation;
	public PropertyFbxFile PropFbxFile;

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




public class PropertyMaterial
{
	public PropertyMaterial();

	public ComponentBase Owner;
	int GroupIndex;

	public const int ShadingModelFull=0;
	public const int ShadingModelFlat=1;

	public const int SamplerMinFilterLinear = 0;
	public const int SamplerMinFilterNearest = 1;

	public const int SamplerMagFilterLinear = 0;
	public const int SamplerMagFilterNearest = 1;
	public const int SamplerMagFilterLinearMipmapLinear = 2;
	public const int SamplerMagFilterLinearMipmapNearest = 3;
	public const int SamplerMagFilterNearestMipmapLinear = 4;
	public const int SamplerMagFilterNearestMipmapNearest = 5;

	public const int CullModeNone = 0;
	public const int CullModeCW = 1;
	public const int CullModeCCW = 2;

	public const int AlphaBlendingNone = 0;
	public const int AlphaBlendingAlphaTransparent = 1;
	public const int AlphaBlendingColorTransparent = 2;
	public const int AlphaBlendingColorLight = 3;
	public const int AlphaBlendingAlphaLight = 4;



	public Color GetAlbedoColor( );
	public void SetAlbedoColor(Color value);



	public int GetAlphaBlending( );
	public void SetAlphaBlending(int value);



	public float GetAlphaTest( );
	public void SetAlphaTest(float value);



	public float GetAmbient( );
	public void SetAmbient(float value);



	public Color GetAmbientColor( );
	public void SetAmbientColor(Color value);



	public float GetAmbientColorRate( );
	public void SetAmbientColorRate(float value);



	public int GetCullBackFace( );
	public void SetCullBackFace(int value);



	public float GetDiffuse( );
	public void SetDiffuse(float value);



	public Color GetDiffuseColor( );
	public void SetDiffuseColor(Color value);



	public int GetFog( );
	public void SetFog(int value);



	public float GetGlossiness( );
	public void SetGlossiness(float value);



	public int GetIsPBRMaterial( );
	public void SetIsPBRMaterial(int value);



	public int GetMagFilter( );
	public void SetMagFilter(int value);



	public float GetMetalliness( );
	public void SetMetalliness(float value);



	public int GetMinFilter( );
	public void SetMinFilter(int value);



	public Vector4 GetNormalMapDirection( );
	public void SetNormalMapDirection(Vector4 value);



	public float GetOpacity( );
	public void SetOpacity(float value);



	public string GetPixelShader( );
	public void SetPixelShader(string value);



	public float GetRoughness( );
	public void SetRoughness(float value);



	public int GetShadingModel( );
	public void SetShadingModel(int value);



	public float GetShadowDarkness( );
	public void SetShadowDarkness(float value);



	public float GetShininess( );
	public void SetShininess(float value);



	public float GetSmoothness( );
	public void SetSmoothness(float value);



	public float GetSpecular( );
	public void SetSpecular(float value);



	public string GetTextureDiffuse( );
	public void SetTextureDiffuse(string value);



	public string GetTextureEnv( );
	public void SetTextureEnv(string value);



	public string GetTextureEtc(int index);
	public void SetTextureEtc(string value, int index);



	public string GetTextureGlossiness( );
	public void SetTextureGlossiness(string value);



	public string GetTextureNormal( );
	public void SetTextureNormal(string value);



	public string GetTextureRoughness( );
	public void SetTextureRoughness(string value);



	public string GetTextureShininess( );
	public void SetTextureShininess(string value);



	public string GetTextureSpecular( );
	public void SetTextureSpecular(string value);



	public int GetUseAlbedoTexture( );
	public void SetUseAlbedoTexture(int value);



	public int GetUseMetalSmoothnessTexture( );
	public void SetUseMetalSmoothnessTexture(int value);



	public string GetVertexShader( );
	public void SetVertexShader(string value);



	public int GetWireFrame( );
	public void SetWireFrame(int value);





}



public class PropertyFbxNodeMesh
{
	public PropertyFbxNodeMesh();

	public ComponentBase Owner;
	int GroupIndex;

	public string GetFbxMeshFile( );
	public void SetFbxMeshFile(string value);



	public string GetIndependentMaterial( );
	public void SetIndependentMaterial(string value);





}



public class FbxNodeBase : ContainerComponent
{
	public FbxNodeBase(ulong uid);

	public PropertyFbxFile PropFbxFile;

}


public class FbxNodeRoot : FbxNodeBase
{
	public FbxNodeRoot(ulong uid);


}


public class FbxNodeBone : FbxNodeBase
{
	public FbxNodeBone(ulong uid);


}



public class FbxNodeMesh : FbxNodeBase
{
	public FbxNodeMesh(ulong uid);

	public PropertyFbxNodeMesh PropFbxNodeMesh;
	public PropertyMaterial PropMaterial;

}



public class PropertyCube
{
	public PropertyCube();

	public ComponentBase Owner;
	int GroupIndex;


}


public class Cube : ContainerComponent
{
	
}






public class PropertyScript
{
	public PropertyScript();

	public ComponentBase Owner;
	int GroupIndex;

	public string GetScript( );
	public void SetScript(string value);





}



public class ScriptComponent : ContainerComponent
{
	public ScriptComponent(ulong uid);

	public PropertyScript PropScript;

}



public class PropertySound
{
	public PropertySound();

	public ComponentBase Owner;
	int GroupIndex;

		public int GetPlaying( );
	public void SetPlaying(int value);



	public int GetRepeat( );
	public void SetRepeat(int value);



	public float GetVolume( );
	public void SetVolume(float value);



	public string GetWaveFile( );
	public void SetWaveFile(string value);





}



public class Sound : ContainerComponent
{
	public Sound(ulong uid);

	public PropertySound PropSound;

	public bool PlayWave();

	
}






public class PropertyKinectSkeleton
{
	public PropertyKinectSkeleton();

	public ComponentBase Owner;
	int GroupIndex;

	public Vector3 GetAnkleLeft( );
	public void SetAnkleLeft(Vector3 value);



	public Vector3 GetAnkleRight( );
	public void SetAnkleRight(Vector3 value);



	public Vector3 GetElbowLeft( );
	public void SetElbowLeft(Vector3 value);



	public Vector3 GetElbowRight( );
	public void SetElbowRight(Vector3 value);



	public Vector3 GetFootLeft( );
	public void SetFootLeft(Vector3 value);



	public Vector3 GetFootRight( );
	public void SetFootRight(Vector3 value);



	public Vector3 GetHandLeft( );
	public void SetHandLeft(Vector3 value);



	public Vector3 GetHandRight( );
	public void SetHandRight(Vector3 value);



	public Vector3 GetHandTipLeft( );
	public void SetHandTipLeft(Vector3 value);



	public Vector3 GetHandTipRight( );
	public void SetHandTipRight(Vector3 value);



	public Vector3 GetHead( );
	public void SetHead(Vector3 value);



	public Vector3 GetHipLeft( );
	public void SetHipLeft(Vector3 value);



	public Vector3 GetHipRight( );
	public void SetHipRight(Vector3 value);



	public Vector3 GetKneeLeft( );
	public void SetKneeLeft(Vector3 value);



	public Vector3 GetKneeRight( );
	public void SetKneeRight(Vector3 value);



	public int GetLeftHand( );
	public void SetLeftHand(int value);



	public Vector3 GetNeck( );
	public void SetNeck(Vector3 value);



	public int GetRightHand( );
	public void SetRightHand(int value);



	public Vector3 GetShoulderLeft( );
	public void SetShoulderLeft(Vector3 value);



	public Vector3 GetShoulderRight( );
	public void SetShoulderRight(Vector3 value);



	public Vector3 GetSpineBase( );
	public void SetSpineBase(Vector3 value);



	public Vector3 GetSpineMid( );
	public void SetSpineMid(Vector3 value);



	public Vector3 GetSpineShoulder( );
	public void SetSpineShoulder(Vector3 value);



	public Vector3 GetThumbLeft( );
	public void SetThumbLeft(Vector3 value);



	public Vector3 GetThumbRight( );
	public void SetThumbRight(Vector3 value);



	public int GetTracked( );
	public void SetTracked(int value);



	public Vector3 GetWristLeft( );
	public void SetWristLeft(Vector3 value);



	public Vector3 GetWristRight( );
	public void SetWristRight(Vector3 value);





}




public class KinectSkeletonComponent : ContainerComponent
{
	public KinectSkeletonComponent(ulong uid);

	public PropertyKinectSkeleton PropKinectSkeleton;

}


public class PropertyKinectImage
{
	public PropertyKinectImage();

	public ComponentBase Owner;
	int GroupIndex;



}




public class KinectImageComponent : ContainerComponent
{
	public KinectImageComponent(ulong uid);

	public PropertyKinectImage PropKinectImage;

}



/*
PropertyTexture enum


	public const int MipMapTypeInternal = 0;
	public const int MipMapTypeDX = 1;

	public const int BackgroundTypeNone=0;
	public const int BackgroundTypeWall=1;
	public const int BackgroundTypeSky=2;
	public const int BackgroundTypeBackColor=4;

	public const int FogTypeNone = 0;
	public const int FogTypeLinear = 1;
	public const int FogTypeExp = 2;
	public const int FogTypeExp2 = 3;


PropertyKinectImage enum

	public const int BackgroundTypeNone=0;
	public const int BackgroundTypeColor=1;
	public const int BackgroundTypeDepth=2;
	public const int BackgroundTypeOverlay=3;


*/









