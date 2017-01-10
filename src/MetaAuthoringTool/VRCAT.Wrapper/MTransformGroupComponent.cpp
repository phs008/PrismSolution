#include "MTransformGroupComponent.h"
#include <Scene/TransformGroup.h>

using namespace Code3::Math3D;
namespace MVRWrapper
{
	MTransformGroupComponent::MTransformGroupComponent()
		:MContainerComponent(ComponentEnum::TransformGroup)
	{
		this->_pTransformGroup = GetNative();
		_Ntransform = &this->_pTransformGroup->PropTransform;
	}
	MTransformGroupComponent::MTransformGroupComponent(Code3::Component::ContainerComponent* _containerComponent)
		: MContainerComponent(_containerComponent)
	{
		this->_pTransformGroup = GetNative();
		_Ntransform = &this->_pTransformGroup->PropTransform;
	}
	Code3::Scene::TransformGroup* MTransformGroupComponent::GetNative()
	{
		return MContainerComponent::GetNative<Code3::Scene::TransformGroup>();
	}
	void MTransformGroupComponent::LookAt(MVector3^ pos, MVector3^ target, MVector3^ up)
	{
		_pTransformGroup->LookAt(pos->GetNativeValue(), target->GetNativeValue(), up->GetNativeValue());
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::MoveForward(float distance)
	{
		_pTransformGroup->MoveForward(distance);
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::Move(float x, float y, float distance)
	{
		Vector3 dir = _pTransformGroup->GetDirection();
		dir.Normalize();

		Vector3 left;
		Vector3 up = _pTransformGroup->GetUp();
		left = up.Cross(dir);
		Vector3 pos = _pTransformGroup->GetPosition();
		pos += left * x * distance;
		pos += up * y * distance;
		_pTransformGroup->SetPosition(pos);
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::Rotate(float x, float y)
	{
		_pTransformGroup->Rotate(x, y, _pTransformGroup->GetPosition());
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::ViewTop(float distance)
	{
		_pTransformGroup->ViewTop(_pTransformGroup->GetPosition(), distance);
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::ViewBotton(float distance)
	{
		_pTransformGroup->ViewBottom(_pTransformGroup->GetPosition(), distance);
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::ViewLeft(float distance)
	{
		_pTransformGroup->ViewLeft(_pTransformGroup->GetPosition(), distance);
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::ViewRight(float distance)
	{
		_pTransformGroup->ViewRight(_pTransformGroup->GetPosition(), distance);
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::ViewFront(float distance)
	{
		_pTransformGroup->ViewFront(_pTransformGroup->GetPosition(), distance);
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::ViewRear(float distance)
	{
		_pTransformGroup->ViewRear(_pTransformGroup->GetPosition(), distance);
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::Focus(MTransformGroupComponent^ target)
	{
		Code3::Geometry::BoundingBox bbox = target->_pTransformGroup->SumBox;
		_pTransformGroup->SetPosition(bbox.GetCenter());
		_pTransformGroup->MoveForward(-bbox.GetDiagonalLength()*2.0f);
		_pTransformGroup->ApplyAllProperty();
	}
	/*MVector3^ MTransformGroupComponent::GetCenter()
	{
		MVector3^ center = gcnew MVector3(_pTransformGroup->SumBox.GetCenter());
		return center;
	}*/
	void MTransformGroupComponent::SetPosition(MVector3^ pos)
	{
		_pTransformGroup->SetPosition(pos->GetNativeValue());
		_pTransformGroup->ApplyAllProperty();
	}
	MVector3^ MTransformGroupComponent::Position::get()
	{
		MVector3^ returnVal = gcnew MVector3(&_pTransformGroup->PropTransform.Position);
		return returnVal;
	}
	void MTransformGroupComponent::Position::set(MVector3^ val)
	{
		_pTransformGroup->PropTransform.Position.Value = val->GetNativeValue();

		/*_pTransformGroup->PropTransform.Position.Value.x = val->GetNativeValue().x;
		_pTransformGroup->PropTransform.Position.Value.y = val->GetNativeValue().y;
		_pTransformGroup->PropTransform.Position.Value.z = val->GetNativeValue().z;*/


		_pTransformGroup->ApplyAllProperty();

		/*_pTransformGroup->PropTransform.Position.Value = val->GetNativeValue();
		_pTransformGroup->ApplyAllProperty();*/
	}
	MQuaternion^ MTransformGroupComponent::Rotation::get()
	{
		MQuaternion^ returnVal = gcnew MQuaternion(&_pTransformGroup->PropTransform.Rotation);
		return returnVal;
	}
	void MTransformGroupComponent::Rotation::set(MQuaternion^ val)
	{
		_pTransformGroup->PropTransform.Rotation.Value = val->GetNativeValue();
		_pTransformGroup->ApplyAllProperty();
	}
	MVector3^ MTransformGroupComponent::Scale::get()
	{
		MVector3^ returnVal = gcnew MVector3(&_pTransformGroup->PropTransform.Scale);
		return returnVal;
	}
	void MTransformGroupComponent::Scale::set(MVector3^ val)
	{
		_pTransformGroup->PropTransform.Scale.Value = val->GetNativeValue();
		_pTransformGroup->ApplyAllProperty();
	}
	void MTransformGroupComponent::UpdateTransform()
	{
		_pTransformGroup->PropTransform.UpdateTransform();
	}
}
