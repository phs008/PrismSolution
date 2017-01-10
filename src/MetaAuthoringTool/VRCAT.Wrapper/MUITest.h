#pragma once
#include "MContainer.h"
#include "MUIImage.h"
namespace MVRWrapper
{
	public ref class MUITest : MContainer
	{
	private:
		MUIImage^ imageComponent;
	public:
		MUITest();
		void setTexture(System::String^ imgPath);
	};
}

