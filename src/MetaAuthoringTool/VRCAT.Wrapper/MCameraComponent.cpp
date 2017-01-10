#include "MCameraComponent.h"
#include <Scene/Camera.h>

namespace MVRWrapper
{
	MCameraComponent::MCameraComponent()
		:MContainerComponent(ComponentEnum::Camera)
	{
		_pCamera = this->GetNative();
	}
	MCameraComponent::MCameraComponent(Code3::Component::ContainerComponent* _containerComponent)
		: MContainerComponent(_containerComponent)
	{
		_pCamera = this->GetNative();;
	}
	Code3::Scene::Camera* MCameraComponent::GetNative()
	{
		return MContainerComponent::GetNative<Code3::Scene::Camera>();
	}
	void MCameraComponent::ChangePropCameraBackColor(float r, float g, float b, float a)
	{
		_pCamera->PropCamera.BackColor.Value = Code3::Math3D::Color(r, g, b, a);
		_pCamera->PropCamera.Apply();
	}
	void MCameraComponent::DrawGrid(bool enable)
	{
		_pCamera->PropCamera.DrawGrid = enable;
	}
	void MCameraComponent::AspectRatio(float Ratio)
	{
		_pCamera->PropCamera.AspectRatio = Ratio;
	}
	void MCameraComponent::WireFrame(bool enable)
	{
		_pCamera->PropCamera.WireFrame = enable;
	}
	void MCameraComponent::ChangeFarViewPlane(float val)
	{
		_pCamera->PropCamera.FarViewPlane.Value = val;
	}
	void MCameraComponent::IsOrthographicView(bool value)
	{
		if (value)
			_pCamera->PropCamera.FocalLength = -1;
		else 
			_pCamera->PropCamera.FocalLength = 50;
	}
}
