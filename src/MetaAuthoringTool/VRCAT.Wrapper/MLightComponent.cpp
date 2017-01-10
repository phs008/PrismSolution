#include "MLightComponent.h"
#include <Scene/Light.h>

namespace MVRWrapper
{
	MLightComponent::MLightComponent()
		:MContainerComponent(ComponentEnum::Light)
	{
		_pLight = this->GetNative();
	}
	MLightComponent::MLightComponent(Code3::Component::ContainerComponent* _containerComponent)
		: MContainerComponent(_containerComponent)
	{
		_pLight = this->GetNative();
	}
	Code3::Scene::Light* MLightComponent::GetNative()
	{
		return MContainerComponent::GetNative<Code3::Scene::Light>();
	}
}
