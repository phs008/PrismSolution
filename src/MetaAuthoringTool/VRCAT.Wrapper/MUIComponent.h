#pragma once
#include "MContainerComponent.h"
#include <Object/UI/UIComponent.h>
namespace MVRWrapper
{
	public ref class MUIComponent : MContainerComponent
	{
	private:
		Code3::UI::UIComponent* _pUIComponent;
	internal:
		Code3::UI::UIComponent* GetNative();
		MUIComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MUIComponent();
	};
}

