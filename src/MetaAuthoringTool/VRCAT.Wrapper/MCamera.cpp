#include "MCamera.h"
#include "MWorld.h"
#include <Math3D\Color.h>
#include <Scene/Camera.h>
#include "MCameraComponent.h"
#include "MTransformGroupComponent.h"

#include "EGuiTools.h"

using namespace Code3::Component;
using namespace Code3::Math3D;
namespace MVRWrapper
{
#ifdef _INHERITANCE_PATTERN
	MCamera::MCamera(Code3::Scene::Camera* node)
	{
		this->_pNode = node;
	}
	MCamera::MCamera(bool IsToolCamera)
	{
		if (IsToolCamera)
			this->_pNode = new Code3::Scene::Camera();
		else
			this->_pNode = (Code3::Scene::Camera*)MWorld::GetInstance()->GetNative()->NewChild(InternString("Camera"));
		//this->_pNode->PropInstance.Name = "Camera";
	}
	Code3::Scene::Camera* MCamera::GetNative()
	{
		return (Code3::Scene::Camera*)_pNode;
	}
	void MCamera::ApplyAllProperty()
	{
		_pNode->ApplyAllProperty();
	}
	void MCamera::ChangePropCameraBackColor(float r, float g, float b, float a)
	{
		Color c;
		c.r = r;
		c.g = g;
		c.b = b;
		((Code3::Scene::Camera*)_pNode)->PropCamera.BackColor.Value = c;
	}
	void MCamera::MoveForward(float distance)
	{
		_pNode->MoveForward(distance);
	}
	void MCamera::Rotate(float x, float y)
	{
		/*Vector3 center;
		center.x = 0;
		center.y = 0;
		center.z = 0;*/
		_pNode->Rotate(x, y, _pNode->GetPosition());
	}
	void MCamera::Move(float x, float y, float distance)
	{
		Vector3 dir = _pNode->GetDirection();
		dir.Normalize();

		Vector3 left;
		Vector3 up = _pNode->GetUp();
		left = up.Cross(dir);
		Vector3 pos = _pNode->GetPosition();
		pos += left * x * distance;
		pos += up * y * distance;
		_pNode->SetPosition(pos);

// 		_pNode->MoveForward(distance);
// 		Vector3 pos = _pNode->GetPosition();
// 		pos.x += x*distance;
// 		pos.y += y*distance;
// 		_pNode->SetPosition(pos);
	}
	void MCamera::ViewTop(float distance)
	{
		_pNode->ViewTop(_pNode->GetPosition(), distance);
	}
	void MCamera::ViewBotton(float distance)
	{
		_pNode->ViewBottom(_pNode->GetPosition(), distance);
	}
	void MCamera::ViewLeft(float distance)
	{
		_pNode->ViewLeft(_pNode->GetPosition(), distance);
	}
	void MCamera::ViewRight(float distance)
	{
		_pNode->ViewRight(_pNode->GetPosition(), distance);
	}
	void MCamera::ViewFront(float distance)
	{
		_pNode->ViewFront(_pNode->GetPosition(), distance);
	}
	void MCamera::ViewRear(float distance)
	{
		_pNode->ViewRear(_pNode->GetPosition(), distance);
	}
	void MCamera::AspectRatio(float Ratio)
	{
		((Code3::Scene::Camera*)this->_pNode)->PropCamera.AspectRatio = Ratio;
	}
	void MCamera::DrawGrid(bool enable)
	{
		((Code3::Scene::Camera*)this->_pNode)->PropCamera.DrawGrid = enable;
	}
	void MCamera::Focus(MTransformGroup^ target)
	{
		if (nullptr == target)
			return;

		/*Code3::Geometry::BoundingBox bbox = target->_pNode->ObjectSumBox;
		Vector3 vMove = _pNode->GetPosition() - bbox.GetCenter();
		vMove.Normalize();
		vMove.Scale(bbox.GetDiagonalLength() * 2.0f);
		Vector3 vCameraPos = bbox.GetCenter() + vMove;
		_pNode->LookAt(vCameraPos, bbox.GetCenter(), _pNode->GetUp());*/
		
		
		Code3::Geometry::BoundingBox bbox = target->_pNode->SumBox;
		_pNode->SetPosition(bbox.GetCenter());
		_pNode->MoveForward(-bbox.GetDiagonalLength()*2.0f);
	}
#else
	MCamera::MCamera(bool IsToolCamera)
		:MContainer()
	{
		if (IsToolCamera)
		{
			this->_Cam = (MCameraComponent^)AddNewComponent(ComponentEnum::Camera);
			this->_Cam->GetNative()->PropCamera.FocalLength = 50;
		}
		else
		{
			this->_Cam = (MCameraComponent^)AddNewComponent(ComponentEnum::Camera);
			this->_Cam->GetNative()->PropCamera.FocalLength = 50;
		}
		this->Name = "Camera";
		//j2y
		Code3::EGuiTools::SetActiveCamera(this->_Cam->GetNative());
		
		ApplyAllProperty();
	}
	MCameraComponent^ MCamera::Cam::get()
	{
		if (this->_Cam == nullptr)
		{
			_Cam = gcnew MCameraComponent(this->_pContainer->FindComponentByTypeCast<Code3::Scene::Camera>(InternString("Camera")));
		}
		return _Cam;
	}
	void MCamera::Cam::set(MCameraComponent^ param)
	{
		this->_Cam = param;
	}
#endif
}
