#include "MSoundComponent.h"

namespace MVRWrapper
{
	MSoundComponent::MSoundComponent(Code3::Component::ContainerComponent* _containerComponent)
		:MContainerComponent(_containerComponent)
	{
		_pSoundComponent = (Code3::Scene::Sound*)_containerComponent;
	}
	MSoundComponent::MSoundComponent()
		: MContainerComponent(ComponentEnum::SoundComponent)
	{
		_pSoundComponent = (Code3::Scene::Sound*)GetComponent();
	}
}
