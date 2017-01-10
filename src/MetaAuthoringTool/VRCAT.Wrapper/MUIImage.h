#pragma once
#include "MContainerComponent.h"
#include <Object/UI/UIImage.h>
namespace MVRWrapper
{
	public ref class MUIImage : MContainerComponent
	{
	private:
		Code3::UI::UIImage* _pUIImage;
	internal:
		Code3::UI::UIImage* GetNative();
		MUIImage(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MUIImage();
		void setImage(System::String^ imgPath);
	};
}

