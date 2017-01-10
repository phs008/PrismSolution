#pragma once
#include "MContainerComponent.h"
#include <Object/Sound/DX/Sound.h>
namespace MVRWrapper
{
	public ref class MSoundComponent : MContainerComponent
	{
	private:
		Code3::Scene::Sound* _pSoundComponent;
	internal:
		MSoundComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MSoundComponent();
	};
}

