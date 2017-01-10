#include "MFbx.h"
#include "MWorld.h"
#include "MarshalHelper.h"
#include <FbxImporter.h>
#include "MFbxComponent.h"
#include "MTransformGroupComponent.h"
#include <EngineDictionary.h>
namespace MVRWrapper
{
	MFbx::MFbx()
		:MContainer()
	{}
	MFbx::MFbx(System::String^ FFBXPath)
	{
		MContainer^ container = MWorld::GetInstance()->OnNewChild();
		this->_pContainer = container->GetNative();
		container->AddNewComponent(ComponentEnum::TransformGroup);
		this->_Fbx = (MFbxComponent^)container->AddNewComponent(ComponentEnum::Fbx);
		this->_Fbx->SetFbxFile(FFBXPath);
		ApplyAllProperty();
		//this->Transform->SetPosition(MVector3::Zero());
	}
	MFbx::MFbx(System::String^ FFBXPath, MContainer^ parentContainer)
	{
		MContainer^ container = parentContainer->OnNewChild();
		this->_pContainer = container->GetNative();
		container->AddNewComponent(ComponentEnum::TransformGroup);
		this->_Fbx = (MFbxComponent^)container->AddNewComponent(ComponentEnum::Fbx);
		this->_Fbx->SetFbxFile(FFBXPath);
		ApplyAllProperty();
	}
	void MFbx::SetFBX(System::String^ FFBXPath)
	{
		this->_Fbx = (MFbxComponent^)this->AddNewComponent(ComponentEnum::Fbx);
		this->_Fbx->SetFbxFile(FFBXPath);
		ApplyAllProperty();
	}
	MFbxComponent^ MFbx::FbxComponent::get()
	{
		if (_Fbx != nullptr)
			return _Fbx;
		else
			throw gcnew System::Exception("FBXComponent`s null");
	}
	void MFbx::FbxComponent::set(MFbxComponent^ param)
	{
		_Fbx = param;
	}
	bool MFbx::ImportFBXSource(System::String^ FbxPath)
	{
		MContext::MContext();
		InternString path = MarshalHelper::StringToNativeString(FbxPath);
		Code3::FileIO::Path fbxSource;
		fbxSource.SetAbsolutePath(path.GetString());
		return Code3::Fbx::ImportFBXResourceToFolder(fbxSource, fbxSource.GetUpperPath(), false);
	}
}
