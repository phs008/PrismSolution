#pragma once
#include "MContainerComponent.h"
namespace MVRWrapper
{
	public ref class MLightComponent : MContainerComponent
	{
	private:
		Code3::Scene::Light* _pLight;
	internal:
		Code3::Scene::Light* GetNative();
		MLightComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MLightComponent();
		
	};
}

