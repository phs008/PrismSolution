#include "MLight.h"
#include "MWorld.h"
#include "MContainer.h"
#include "MLightComponent.h"
#include <EngineDictionary.h>
using namespace Code3::Scene;

namespace MVRWrapper
{
	MLight::MLight()
		:MContainer()
	{
		MLightComponent^ lightComponent = (MLightComponent^)this->AddNewComponent(ComponentEnum::Light);
		this->Name = "Light";
		ApplyAllProperty();
	}
	MLight::MLight(MWorld^ anotherWorld)
	{
		MContainer^ container = anotherWorld->OnNewChild();
		this->_pContainer = container->GetNative();
		this->AddNewComponent(ComponentEnum::Light);
		this->Name = "Light";
		ApplyAllProperty();
	}
}
