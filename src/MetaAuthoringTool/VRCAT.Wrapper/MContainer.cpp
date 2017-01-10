#include "MContainer.h"
#include "MFbxComponent.h"
#include "MCameraComponent.h"
#include "MTransformGroupComponent.h"
#include "MScriptComponent.h"
#include "MLightComponent.h"
#include "MCubeComponent.h"
#include "MRigidMeshComponent.h"
#include "MUIComponent.h"
#include "MUIImage.h"
#include "MSoundComponent.h"
#include "MKinectImageComponent.h"
#include "MKinectSkeletonComponent.h"
#include "MarshalHelper.h"
#include "MLogHandler.h"
#include <EngineDictionary.h>
#include <Component/ContainerComponent.h>
#include <Scene/Camera.h>
#include <Scene/TransformGroup.h>
#include <Object/Sound/DX/Sound.h>
#include <Object/Fbx/Fbx.h>
#include <BasicType/InternString.h>

namespace MVRWrapper
{
#pragma region Property
	bool MContainer::IsExpanded::get()
	{
		return _pContainer->PropInstance.Expanded.Value;
	}
	void MContainer::IsExpanded::set(bool isExpanded)
	{
		_pContainer->PropInstance.Expanded.Value = isExpanded;
	}
	bool MContainer::IsLocked::get()
	{
		return _pContainer->PropInstance.Locked.Value;
	}
	void MContainer::IsLocked::set(bool isLocked)
	{
		_pContainer->PropInstance.Locked.Value = isLocked;
	}
	bool MContainer::IsSelected::get()
	{
		return _pContainer->PropInstance.Selected.Value;
	}
	void MContainer::IsSelected::set(bool isSelected)
	{
		_pContainer->PropInstance.Selected.Value = isSelected;
	}
	bool MContainer::IsShow::get()
	{
		return _pContainer->PropInstance.Show.Value;
	}
	void MContainer::IsShow::set(bool isShow)
	{
		_pContainer->PropInstance.Show.Value = isShow;
	}
	int MContainer::Layer::get()
	{
		return _pContainer->PropInstance.Layer.Value;
	}
	void MContainer::Layer::set(int layer)
	{
		_pContainer->PropInstance.Layer.Value = layer;
	}

	MContainer^ MContainer::Root::get()
	{
		if (_Root == nullptr)
			_Root = gcnew MContainer(_pContainer->Root);
		return _Root;
	}
	void MContainer::Root::set(MContainer^ param)
	{
		_Root = param;
	}
	MContainer^ MContainer::Parent::get()
	{
		if (_Parent == nullptr)
			_Parent = gcnew MContainer(_pContainer->Parent);
		return _Parent;
	}
	void MContainer::Parent::set(MContainer^ param)
	{
		_Parent = param;
	}
	MContainer::MContainer()
		:MContext()
	{
		_pContainer = new Code3::Component::Container();
		AddNewComponent(ComponentEnum::TransformGroup);
	}
	MContainer::MContainer(Code3::Component::Container* container)
		:MContainer()
	{
		_pContainer = container;
	}
	System::Int64 MContainer::UID::get()
	{
		return _pContainer->LinkableUID;
	}
	System::String^ MContainer::Name::get()
	{
		return gcnew System::String(_pContainer->PropInstance.Name.Value);
	}
	void MContainer::Name::set(System::String^ val)
	{
		_pContainer->PropInstance.Name.Value = MarshalHelper::StringToNativeString(val);
	}
	MTransformGroupComponent^ MContainer::Transform::get()
	{
		if (_Transform == nullptr)
		{
			Code3::Scene::TransformGroup *trans = _pContainer->FindComponentByTypeCast<Code3::Scene::TransformGroup>(InternString("TransformGroup"));
			if (trans)
			{
				_Transform = gcnew MTransformGroupComponent(trans);
				return _Transform;
			}
		}
		else
			return _Transform;
	}
	void MContainer::Transform::set(MTransformGroupComponent^ param)
	{
		_Transform = param;
		/*Code3::Scene::TransformGroup* temp = (Code3::Scene::TransformGroup *)_pContainer->Find(Code3::Dictionary::TransformGroup);
		temp = param->GetNative();*/
		ApplyAllProperty();
	}
	System::String^ MContainer::NativePointToString()
	{
		return System::IntPtr(_pContainer).ToString();
	}
	Code3::Component::Container* MContainer::GetNative()
	{
		return _pContainer;
	}
#pragma  endregion

#pragma region ContainerNodeManagement
	MContainer^ MContainer::OnNewChild()
	{
		Code3::Component::Container* childContainer = _pContainer->NewChild(InternString("Container"));
		return gcnew MContainer(childContainer);
	}
	void MContainer::SetParent(MContainer^ NewParent)
	{
		if (this->_pContainer->Parent)
		{
			int removeIdx = this->_pContainer->Parent->FindIndex(this->_pContainer);
			this->_pContainer->Parent->DetachChild(removeIdx);
		}
		NewParent->AddChild(this);
		this->Parent = NewParent;
		this->ApplyAllProperty();
	}
	void MContainer::RemoveThis()
	{
		if (this->Root != nullptr)
			_pContainer->DeleteThis();
	}
	void MContainer::RemoveChild(MContainer^ child)
	{
		child->_pContainer->DeleteThis();
	}
	int MContainer::GetChildrenCount()
	{
		return _pContainer->GetChildrenCount();
	}
	MContainer^ MContainer::GetChild(int idx)
	{
		return gcnew MContainer(_pContainer->GetChild(idx));
	}
	int MContainer::AddChild(MContainer^ child)
	{
		return _pContainer->AddChild(child->_pContainer);
	}
	void MContainer::DetachFromParent()
	{
		int idx = _pContainer->Parent->FindIndex(_pContainer);
		_pContainer->Parent->DetachChild(idx);
	}
#pragma endregion

#pragma region Component
	MContainerComponent^ MContainer::AddNewComponent(System::String^ componentName)
	{
		if (componentName->Equals("TransformGroup"))
		{
			Code3::BasicType::InternString i = "TransformGroup";
			Code3::Component::ContainerComponent* cp = _pContainer->FindComponentByKind(i);
			if (cp)
			{
				MLog::GetInstance()->SetLog("TransformGroup 는 이미 추가되어있습니다.");
				return nullptr;
			}
		}
		Code3::Component::ContainerComponent* _nativeComponent = _pContainer->AddNewComponent(InternString(MarshalHelper::StringToNativeChar(componentName)));
		_nativeComponent->ApplyAllProperty();
		MContainerComponent^ returnVal = nullptr;
		if(componentName->Equals("Light"))
			returnVal = gcnew MLightComponent(_nativeComponent);
		else if(componentName->Equals("Camera"))
			returnVal = gcnew MCameraComponent(_nativeComponent);
		else if (componentName->Equals("TransformGroup"))
			returnVal = gcnew MTransformGroupComponent(_nativeComponent);
		else if (componentName->Equals("RigidMesh"))
			returnVal = gcnew MRigidMeshComponent(_nativeComponent);
		else if (componentName->Equals("Cube"))
			returnVal = gcnew MCubeComponent(_nativeComponent);
		else if (componentName->Equals("Fbx"))
			returnVal = gcnew MFbxComponent(_nativeComponent);
		else if (componentName->Equals("ScriptComponent"))
			returnVal = gcnew MScriptComponent(_nativeComponent);
		else if (componentName->Equals("SoundComponent"))
			returnVal = gcnew MSoundComponent(_nativeComponent);
		else if (componentName->Equals("KinectImageComponent"))
			returnVal = gcnew MKinectImageComponent(_nativeComponent);
		else if (componentName->Equals("KinectSkeletonComponent"))
			returnVal = gcnew MKinectSkeletonComponent(_nativeComponent);
		else
			returnVal = gcnew MContainerComponent(_nativeComponent);
		return returnVal;
	}
	MContainerComponent^ MContainer::AddNewComponent(ComponentEnum componentType)
	{
		System::String^ componentName = System::Enum::GetName(ComponentEnum::typeid, (System::Object^)componentType);
		return AddNewComponent(componentName);
	}
	int MContainer::GetComponentsCount()
	{
		return _pContainer->GetComponentCount();
	}
	MContainerComponent^ MContainer::GetComponent(int idx)
	{
		Code3::Component::ContainerComponent* comp = _pContainer->Components[idx];
		Code3::BasicType::InternString compareString = comp->LeafClassName();
		if (compareString == Code3::Dictionary::TransformGroup)
			return gcnew MTransformGroupComponent(comp);
		else if (compareString == Code3::Dictionary::Fbx)
			return gcnew MFbxComponent(comp);
		else if (compareString == Code3::Dictionary::Camera)
			return gcnew MCameraComponent(comp);
		else if (compareString == Code3::Dictionary::ScriptComponent)
			return gcnew MScriptComponent(comp);
		else if (compareString == Code3::Dictionary::RigidMesh)
			return gcnew MRigidMeshComponent(comp);
		else if (compareString == Code3::Dictionary::Sound)
			return gcnew MSoundComponent(comp);
		else if (compareString == Code3::Dictionary::KinectImageComponent)
			return gcnew MKinectImageComponent(comp);
		else if (compareString == Code3::Dictionary::KinectSkeletonComponent)
			return gcnew MKinectSkeletonComponent(comp);
		else
			return gcnew MContainerComponent(comp);
	}
	generic<class T>
	T MContainer::GetComponent(ComponentEnum componentType)
	{
		System::String^ componentName = System::Enum::GetName(ComponentEnum::typeid, (System::Object^)componentType);
		InternString name = MarshalHelper::StringToNativeString(componentName);
		MContainerComponent^ returnVal = nullptr;
		switch (componentType)
		{
		case MVRWrapper::ComponentEnum::Light:
			returnVal = gcnew MLightComponent(_pContainer->FindComponentByTypeCast<Code3::Scene::Light>(name));
			break;
		case MVRWrapper::ComponentEnum::Camera:
			returnVal = gcnew MCameraComponent(_pContainer->FindComponentByTypeCast<Code3::Scene::Camera>(name));
			break;
		case MVRWrapper::ComponentEnum::TransformGroup:
			returnVal = gcnew MCameraComponent(_pContainer->FindComponentByTypeCast<Code3::Scene::TransformGroup>(name));
			break;
		case MVRWrapper::ComponentEnum::RigidMesh:
			returnVal = gcnew MRigidMeshComponent(_pContainer->FindComponentByTypeCast<Code3::Scene::RigidMesh>(name));
			break;
		case MVRWrapper::ComponentEnum::Cube:
			returnVal = gcnew MCubeComponent(_pContainer->FindComponentByTypeCast<Code3::Scene::Cube>(name));
			break;
		case MVRWrapper::ComponentEnum::Fbx:
			returnVal = gcnew MFbxComponent(_pContainer->FindComponentByTypeCast<Code3::Fbx::Fbx>(name));
			break;
		case MVRWrapper::ComponentEnum::SoundComponent:
			returnVal = gcnew MSoundComponent(_pContainer->FindComponentByTypeCast<Code3::Scene::Sound>(name));
			break;
		case MVRWrapper::ComponentEnum::ScriptComponent:
			returnVal = gcnew MScriptComponent(_pContainer->FindComponentByTypeCast<Code3::Script::ScriptComponent>(name));
			break;
		case MVRWrapper::ComponentEnum::KinectImageComponent:
			returnVal = gcnew MKinectImageComponent(_pContainer->FindComponentByTypeCast<Code3::Device::KinectImageComponent>(name));
			break;
		case MVRWrapper::ComponentEnum::KinectSkeletonComponent:
			returnVal = gcnew MKinectSkeletonComponent(_pContainer->FindComponentByTypeCast<Code3::Device::KinectSkeletonComponent>(name));
			break;
		}
		return (T)returnVal;
	}
	void MContainer::ApplyAllProperty()
	{
		_pContainer->ApplyAllProperty();
	}
	int MContainer::GetComponentIdx(System::Int64 compareUID)
	{
		int returnVal = -1;
		for (int i = 0; i < _pContainer->GetComponentCount(); i++)
		{
			System::Int64 uid = (System::Int64)_pContainer->Components[i]->LinkableUID;
			Code3::BasicType::InternString ia = _pContainer->Components[i]->LeafClassName();
			if (compareUID == uid)
			{
				returnVal = i;
				break;
			}
		}
		return returnVal;
	}
	bool MContainer::DeleteComponent(int idx)
	{
		return _pContainer->RemoveComponent(idx);
	}
	bool MContainer::HasComponent(System::String^ componentName)
	{
		InternString name = MarshalHelper::StringToNativeString(componentName);
		Code3::Component::ContainerComponent* com = _pContainer->FindComponentByType(name);
		if (com != NULL)
			return true;
		else
			return false;
	}
#pragma  endregion

#pragma  region 기타 함수
	void MContainer::Selected(bool selected)
	{
		_pContainer->PropInstance.Selected = selected;
	}
	void MContainer::ChildContainerSelect(bool select)
	{
		if (select)
			_pContainer->SelectAll();
		else
			_pContainer->DeselectAll();
	}
#pragma endregion

#pragma  region 테스트 함수
	void MContainer::Test()
	{
		/*Code3::Scene::TransformGroup t;
		t->GetScale();*/
		
		//Code3::Scene::TransformGroup* t = static_cast<Code3::Scene::TransformGroup*>(_pContainer->FindComponentByType("TrnasformGroup"));
		//t->Rotate(10, 10, t->GetPosition());
		//Code3::Scene::Camera* cam = static_cast<Code3::Scene::Camera*>(_pContainer->FindComponentByType("Camera"));
		/*_pContainer->IsSelected();
		_pContainer->SetSelect(true);*/
		
	}
#pragma endregion
}
