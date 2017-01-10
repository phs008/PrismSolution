#pragma once
#ifdef _INHERITANCE_PATTERN
#include "MTransformGroup.h"
#else
#include "MContainer.h"
#endif
namespace MVRWrapper
{
#ifdef _INHERITANCE_PATTERN
	public ref class MCamera : MTransformGroup
	{
	public:
		MCamera(bool IsToolCamera);
		void ApplyAllProperty();
		void MoveForward(float distance);
		void Move(float x, float y, float distance);
		void Rotate(float x, float y);
		void ViewTop(float distance);
		void ViewBotton(float distance);
		void ViewLeft(float distance);
		void ViewRight(float distance);
		void ViewFront(float distance);
		void ViewRear(float distance);
		void ChangePropCameraBackColor(float r, float g, float b, float a);
		void AspectRatio(float Ratio);
		void DrawGrid(bool enable);
		void Focus(MTransformGroup^ target);
	internal:
		MCamera(Code3::Scene::Camera* node);
		Code3::Scene::Camera* GetNative();
	
	};
#else
	ref class MCameraComponent;
	public ref class MCamera : MContainer
	{
	private: 
		MCameraComponent^ _Cam = nullptr;
	public:
		MCamera(bool IsToolCamera);
		property MCameraComponent^ Cam
		{
			MCameraComponent^ get();
			void set(MCameraComponent^ param);
		}
	};
#endif
}

