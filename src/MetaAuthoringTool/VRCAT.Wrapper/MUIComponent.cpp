#include "MUIComponent.h"
#include "MContainerComponent.h"
namespace MVRWrapper
{
	MUIComponent::MUIComponent()
		:MContainerComponent(ComponentEnum::UIComponent)
	{
		_pUIComponent = (Code3::UI::UIComponent*)this->GetComponent();
	}
	MUIComponent::MUIComponent(Code3::Component::ContainerComponent* _containerComponent)
		:MContainerComponent(_containerComponent)
	{
		_pUIComponent = (Code3::UI::UIComponent*)this->GetComponent();
	}
	Code3::UI::UIComponent* MUIComponent::GetNative()
	{
		return MContainerComponent::GetNative<Code3::UI::UIComponent>();
	}
}
