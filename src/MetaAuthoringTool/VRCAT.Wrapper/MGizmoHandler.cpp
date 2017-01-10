#include "MGizmoHandler.h"
#include "MContainer.h"
#include "MRenderWindow.h"
#include <Object/Gizmo/Gizmo.h>
namespace MVRWrapper
{
	MGizmoHandler::MGizmoHandler()
	{
		_pGizmoCenter = Code3::Scene::GizmoCenter::GetInstance();
	}
	void MGizmoHandler::SetObject(MContainer^ container)
	{
		selectedContainer = container;
		_pGizmoCenter->DetatchObject();
		_pGizmoCenter->SetObject(container->GetNative());
	}
	void MGizmoHandler::AddGizmoHandle(MRenderWindow^ renderWindow)
	{
		_pGizmoCenter->AddHandler(renderWindow->GetGizmoHandler());
	}
	void MGizmoHandler::SetGizmoType(int type)
	{
		_pGizmoCenter->SetGizmoType(type);
	}
	void MGizmoHandler::DetachAllGizmo()
	{
		_pGizmoCenter->DetatchObject();
		
	}
	void MGizmoHandler::SetEnable(bool enable)
	{
		_pGizmoCenter->SetEnable(enable);
	}
	/*bool MGizmoHandler::GetGizmoSelection()
	{
		GizmoSelection selectVal = _pGizmo->GetGizmoSelection();
		if (selectVal == GSNone)
			return false;
		else
			return true;
	}*/
	/*void MGizmoHandler::SetGizmoPosition(MVector3^ vec)
	{
		_pGizmoConnector->SetGizmoPosition(vec->GetNativeValue());
	}*/
}
