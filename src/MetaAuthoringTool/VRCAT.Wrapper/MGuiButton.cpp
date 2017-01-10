#include "EGuiPCH.h"
#include "EGuiRoot.h"
#include "EGuiTools.h"
#include "EGuiMath.h"
#include "EGuiDrawCall.h"
#include "EGuiCamera.h"
#include "EGuiPanel.h"
#include "EGuiTexture.h"
#include "EGuiButton.h"
#include "EGuiCollider.h"

#include "EGuiEventDelegate.h"
#include "EGuiDragScrollView.h"

#include "MGuiButton.h"


//j2y
namespace MVRWrapper
{
	//------------------------------------------------------------------------------------------------------------------------------------------------------
	MGUIButton::MGUIButton()
	{
		//CreateUI Container를 가져와야한다.
		//Make GUI Panel & Camera
		auto panel_con = Code3::EGuiTools::CreateUI(this->_pContainer,false,0);
		
		//button 생성
		MakeButton(panel_con->OwnerContainer, Code3::Vector3::Zero());


		ApplyAllProperty();
	}
	//------------------------------------------------------------------------------------------------------------------------------------------------------
	MGUIButton::~MGUIButton()
	{
	}



#pragma region [Widget] Make Button Containers

	//------------------------------------------------------------------------------------------------------------------------------------------------------
	GuiButton* MGUIButton::MakeButton(Container *parent)
	{
		auto con = Code3::EGuiTools::AddChild(parent);
		auto button = Code3::EGuiTools::AddComponent<Code3::EGuiButton>(con);
		auto uitex = MakeTexture(button->OwnerContainer);
		auto col = Code3::EGuiTools::AddComponent<Code3::EGuiCollider>(button->OwnerContainer);

		uitex->SetBorder(EngineNamespace::Vector4(10, 10, 10, 10));
		button->tweenTarget = uitex->OwnerContainer;
		///button->initButtonsprite("ListBox/Button1_1", 0);
		button->SetNormalSprite2D(Code3::EGuiTools::LoadTexture("enginedata/GUI/ListBox/Button1_1.png"));
		button->hoverSprite2D = Code3::EGuiTools::LoadTexture("enginedata/GUI/ListBox/Button1_2.png");
		button->pressedSprite2D = Code3::EGuiTools::LoadTexture("enginedata/GUI/ListBox/Button1_3.png");
		button->SetName("Button");

		auto ButtonContainers = new GuiButton();
		ButtonContainers->_root = con;
		ButtonContainers->_button = button;
		ButtonContainers->_backTex = uitex;

		return ButtonContainers;
	}

	//------------------------------------------------------------------------------------------------------------------------------------------------------
	GuiButton* MGUIButton::MakeButton(Container *parent, const Code3::Vector3& pos/*, std::function<void(Container*)> onclick*/)
	{
		auto btn = MakeButton(parent);
		auto buttonEvent = btn->_button;

		//Label
		btn->_label = Code3::EGuiTools::AddComponent<Code3::EGuiTexture>(Code3::EGuiTools::AddChild(btn->_root));
		btn->_label->SetDepth(btn->_backTex->GetDepth() + 1);
		btn->_label->SetName("Label");

		//button bg
		btn->_backTex->SetName("ButtonBG");

		//버튼 event 처리 람다식 에러
		//buttonEvent->onClick.push_back(new Code3::EGuiEventDelegate(onclick, buttonEvent->OwnerContainer));
		buttonEvent->GetTransformGroup()->SetLocalPosition(pos);

		return btn;
	}
	// Make Texture
	//------------------------------------------------------------------------------------------------------------------------------------------------------
	Code3::EGuiTexture* MGUIButton::MakeTexture(Container *parent)
	{
		auto con = Code3::EGuiTools::AddChild(parent);
		auto uitex = Code3::EGuiTools::AddComponent<Code3::EGuiTexture>(con);

		uitex->MakePixelPerfect();

		return uitex;
	}


#pragma endregion

}
