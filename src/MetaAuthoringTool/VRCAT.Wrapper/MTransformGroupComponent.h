#pragma once
#include "MContainerComponent.h"
namespace MVRWrapper
{
	public ref class MTransformGroupComponent : MContainerComponent
	{
	private:
		Code3::Scene::TransformGroup* _pTransformGroup;
		MQuaternion^ _Rotation = nullptr;
		MVector3^ _Position = nullptr;
		MVector3^ _Scale = nullptr;
	internal:
		MTransformGroupComponent(Code3::Component::ContainerComponent* _containerComponent);
		Code3::Scene::PropertyTransform* _Ntransform;
		
	public:
		MTransformGroupComponent();
	public:
		Code3::Scene::TransformGroup* GetNative();
	public:
		void LookAt(MVector3^ pos, MVector3^ target, MVector3^ up);
		void MoveForward(float distance);
		void Move(float x, float y, float distance);
		void Rotate(float x, float y);
		void ViewTop(float distance);
		void ViewBotton(float distance);
		void ViewLeft(float distance);
		void ViewRight(float distance);
		void ViewFront(float distance);
		void ViewRear(float distance);
		void Focus(MTransformGroupComponent^ target);
		void SetPosition(MVector3^ pos);
		//MVector3^ GetPosition();
		//MVector3^ GetCenter();
		void UpdateTransform();
	public:
		property MVector3^ Position
		{
			MVector3^ get();
			void set(MVector3^ val);
		}
		property MQuaternion^ Rotation
		{
			MQuaternion^ get();
			void set(MQuaternion^ val);
		}
		property MVector3^ Scale
		{
			MVector3^ get();
			void set(MVector3^ val);
		}
	};
}

