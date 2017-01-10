#include <Object/Fbx/Fbx.h>
#include <FbxImporter.h>
#include <Resource/ResourcePath.h>
#include <Object/Fbx/Base/FbxSceneRoot.h>
#include "MFbxComponent.h"
#include "MResourceMaterial.h"
#include "MResourceAnimation.h"
#include "MarshalHelper.h"

namespace MVRWrapper
{
	MFbxComponent::MFbxComponent()
		:MContainerComponent(ComponentEnum::Fbx)
	{
		_pFbx = this->GetNative();
	}
	MFbxComponent::MFbxComponent(Code3::Component::ContainerComponent* _containerComponent)
		: MContainerComponent(_containerComponent)
	{
		_pFbx = this->GetNative();
	}
	Code3::Fbx::Fbx* MFbxComponent::GetNative()
	{
		return MContainerComponent::GetNative<Code3::Fbx::Fbx>();
	}
	void MFbxComponent::SetFbxFile(System::String^ fbxPath)
	{
		InternString path = MarshalHelper::StringToNativeString(fbxPath);
		Code3::FileIO::Path p;
		p.SetAbsolutePath(path);
		if (p.MakeRelativePath(&Code3::Resource::GetResourcePath().ResourceFolder))
		{
			this->_pFbx->PropFbxFile.FbxFile.Value = p;
			this->_pFbx->ApplyAllProperty();
		}
	}
	int MFbxComponent::GetMaterialSize()
	{
		return _pFbx->PropFbxFile.ResFbx.Instance->ResMaterials.GetSize();
	}
	MResourceMaterial^ MFbxComponent::GetResourceMtl(int idx)
	{
		MResourceMaterial^ returnVal;
		Code3::Resource::ResourceMaterial* mtlResource = _pFbx->PropFbxFile.ResFbx.Instance->ResMaterials[idx];
		returnVal = gcnew MResourceMaterial(mtlResource);
		return returnVal;
	}
	int MFbxComponent::GetAnimationSize()
	{
		///_pFbx->AnimationList.AnimationFiles.GetSize();
		return _pFbx->PropFbxFile.ResFbx.Instance->ResAnimations.GetSize();
	}
	MResourceAnimation^ MFbxComponent::GetResourceAni(int idx)
	{
		MResourceAnimation^ returnVal;
		Code3::Resource::ResourceFbxAnimation* aniResource = _pFbx->PropFbxFile.ResFbx.Instance->ResAnimations[idx];
		returnVal = gcnew MResourceAnimation(aniResource);
		return returnVal;
	}
	void MFbxComponent::SetTestAnimation(System::String^ faniPath)
	{
		const char* faniAbsolutePath = MarshalHelper::StringToNativeChar(faniPath);
		Code3::FileIO::Path pani = faniAbsolutePath;
		_pFbx->PropFbxFile.ResFbx.Instance->TestAnimation.Create(pani);
		_pFbx->SetActiveAnimation(-2);
	}
	void MFbxComponent::SaveToFile()
	{
		_pFbx->PropFbxFile.ResFbx.Instance->SaveToFile(_pFbx->PropFbxFile.ResFbx.Instance->SourceFile);
	}
	void MFbxComponent::ChangeAnimation(System::String^ faniPath, int animationIdx)
	{
		InternString s = MarshalHelper::StringToNativeString(faniPath);
		_pFbx->PropFbxFile.ResFbx.Instance->AnimationFileNames[animationIdx] = s;
	}
	void MFbxComponent::ChangeMaterial(System::String^ matPath, int matIdx)
	{
		InternString s = MarshalHelper::StringToNativeString(matPath);
		_pFbx->PropFbxFile.ResFbx.Instance->MaterialFileNames[matIdx] = s;
	}
	void MFbxComponent::AddNewAnimation(System::String^ aniFile)
	{
		const char* c = MarshalHelper::StringToNativeChar(aniFile);
		if (_pFbx->PropFbxFile.ResFbx.Instance)
		{
			_pFbx->PropFbxFile.ResFbx.Instance->AnimationFileNames.Add(c);
			_pFbx->PropFbxFile.ResFbx.Instance->SaveToFile(_pFbx->PropFbxFile.ResFbx.Instance->SourceFile);
		}
	}
	void MFbxComponent::RemoveAnimation(System::String^ removePath)
	{
		int removeIdx = -1;
		const char * compareChr = MarshalHelper::StringToNativeChar(removePath);
		for (int i = 0; i < _pFbx->PropFbxFile.ResFbx.Instance->AnimationFileNames.GetSize(); i++)
		{
			Code3::BasicType::String s = _pFbx->PropFbxFile.ResFbx.Instance->AnimationFileNames.ElementAt(i);
			if (!s.Compare(compareChr))
			{
				removeIdx = i;
				break;
			}
		}
		if (removeIdx != -1)
		{
			_pFbx->PropFbxFile.ResFbx.Instance->AnimationFileNames.RemoveAt(removeIdx);
			_pFbx->PropFbxFile.ResFbx.Instance->SaveToFile(_pFbx->PropFbxFile.ResFbx.Instance->SourceFile);
		}
	}
	void MFbxComponent::test()
	{
		//pFbx->PropFbxFile.ResFbx.Instance->AnimationFileNames[i] = xxxx
		//_pFbx->PropFbxFile.ResFbx.Instance->GetMaterial(0)->prop
	}
}
