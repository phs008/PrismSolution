#pragma once
#include "MContainerComponent.h"
#include <Object/Ocean/Ocean.h>
namespace MVRWrapper
{
	public ref class MOceanComponent : MContainerComponent
	{
	private:
		Code3::Scene::Ocean* _pOcean;
	internal:
		Code3::Scene::Ocean* GetNative();
		MOceanComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MOceanComponent();
	};
}

