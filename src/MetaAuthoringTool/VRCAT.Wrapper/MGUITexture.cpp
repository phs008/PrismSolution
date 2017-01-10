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


#include "MGUITexture.h"


//j2y
namespace MVRWrapper
{
	//------------------------------------------------------------------------------------------------------------------------------------------------------
	MGUITexture::MGUITexture()
	{
		//CreateUI Container를 가져와야한다.
		//Make GUI Panel & Camera
		auto panel_con = Code3::EGuiTools::CreateUI(this->_pContainer,false,0);
		
		
#pragma region [Texture && Animation]
		
		auto Texture = Code3::EGuiTools::AddComponent<Code3::EGuiTexture>(Code3::EGuiTools::AddChild(panel_con->OwnerContainer));
		Texture->SetMainTexture(Code3::EGuiTools::LoadTexture("enginedata/GUI/Window/Gui_IMG_DC_list_bg.png"));
		Texture->SetName("Texture");

#pragma endregion


		ApplyAllProperty();
	}
	//------------------------------------------------------------------------------------------------------------------------------------------------------
	MGUITexture::~MGUITexture()
	{
	}


}
