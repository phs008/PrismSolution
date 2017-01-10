#include "MOceanComponent.h"

namespace MVRWrapper
{
	MOceanComponent::MOceanComponent()
		:MContainerComponent(ComponentEnum::Ocean)
	{
		_pOcean = this->GetNative();
	}
	MOceanComponent::MOceanComponent(Code3::Component::ContainerComponent* _containerComponent)
		: MContainerComponent(_containerComponent)
	{
		_pOcean = this->GetNative();
	}
	Code3::Scene::Ocean* MOceanComponent::GetNative()
	{
		return (Code3::Scene::Ocean*)this->GetComponent();
	}
}
