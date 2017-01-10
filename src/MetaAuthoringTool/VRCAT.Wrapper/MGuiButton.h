#pragma once
#include "MContainer.h"
#include "EGuiBaseObject.h"

//j2y
namespace MVRWrapper
{
	class GuiButton
	{
	public:
		Container* _root = nullptr;
		Code3::EGuiButton* _button = nullptr;
		Code3::EGuiTexture* _backTex = nullptr;
		Code3::EGuiTexture* _label = nullptr;

	};
	

	public ref class MGUIButton : MContainer
	{

		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		// Base Frame
		//
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	public:
		MGUIButton();
		~MGUIButton();

	
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		// Widget Factory
		//
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	public:
		GuiButton* MakeButton(Container *parent);
		GuiButton* MakeButton(Container *parent, const Code3::Vector3& pos);
		Code3::EGuiTexture* MakeTexture(Container *parent);
		
	};
}

