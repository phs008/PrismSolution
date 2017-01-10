#pragma once
#include "MContainerComponent.h"

namespace MVRWrapper
{
	ref class MResourceMaterial;
	ref class MResourceAnimation;
	public ref class MFbxComponent : MContainerComponent
	{
	private:
		Code3::Fbx::Fbx* _pFbx;
	internal:
		MFbxComponent(Code3::Component::ContainerComponent* _containerComponent);
		Code3::Fbx::Fbx* GetNative();
	public:
		MFbxComponent();
		
	public:
		void SetFbxFile(System::String^ fbxPath);
		int GetMaterialSize();
		MResourceMaterial^ GetResourceMtl(int idx);
		int GetAnimationSize();
		MResourceAnimation^ GetResourceAni(int idx);
		void MFbxComponent::SetTestAnimation(System::String^ faniPath);
		void ChangeAnimation(System::String^ faniPath, int animationIdx);
		void ChangeMaterial(System::String^ matPath, int matIdx);
		void SaveToFile();
		void AddNewAnimation(System::String^ aniFile);
		void RemoveAnimation(System::String^ removePath);
		void test();
	};
}

