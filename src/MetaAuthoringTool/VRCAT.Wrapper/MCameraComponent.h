#pragma once
#include "MContainerComponent.h"
#include "MRenderWindow.h"
namespace MVRWrapper
{
	public ref class MCameraComponent : MContainerComponent
	{
	private:
		Code3::Scene::Camera* _pCamera;
	internal:
		Code3::Scene::Camera* GetNative();
		MCameraComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MCameraComponent();
		
	public:
		void ChangePropCameraBackColor(float r, float g, float b, float a);
		void DrawGrid(bool enable);
		void WireFrame(bool enable);
		void AspectRatio(float Ratio);
		void ChangeFarViewPlane(float value);
		void IsOrthographicView(bool value);
	};
}

