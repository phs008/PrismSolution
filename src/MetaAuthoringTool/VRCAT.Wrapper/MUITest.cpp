#include "MUITest.h"
namespace MVRWrapper
{
	MUITest::MUITest()
		:MContainer()
	{
		this->AddNewComponent(ComponentEnum::UIComponent);
		imageComponent = (MUIImage^)this->AddNewComponent(ComponentEnum::UIImage);
		this->Name = "UI";
		ApplyAllProperty();
	}
	void MUITest::setTexture(System::String^ imgPath)
	{
		this->imageComponent->setImage(imgPath);
	}
}
