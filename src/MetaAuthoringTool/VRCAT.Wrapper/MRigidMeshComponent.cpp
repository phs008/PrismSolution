#include "stdafx.h"
#include "MRigidMeshComponent.h"
#include <Resource/ResourcePath.h>
namespace MVRWrapper
{
	MRigidMeshComponent::MRigidMeshComponent()
		:MContainerComponent(ComponentEnum::RigidMesh)
	{
		_pRigidMesh = this->GetNative();
		this->setMesh();
	}
	MRigidMeshComponent::MRigidMeshComponent(Code3::Component::ContainerComponent* _containerComponent)
		:MContainerComponent(_containerComponent)
	{
		_pRigidMesh = this->GetNative();
		this->setMesh();
	}
	Code3::Scene::RigidMesh* MRigidMeshComponent::GetNative()
	{
		return MContainerComponent::GetNative<Code3::Scene::RigidMesh>();
	}
	void MRigidMeshComponent::setMaterial(System::String^ matFile)
	{
		InternString path = MarshalHelper::StringToNativeString(matFile);
		Code3::FileIO::Path p;
		p.SetAbsolutePath(path);
		if (p.MakeRelativePath(&Code3::Resource::GetResourcePath().ResourceFolder))
		{
			_pRigidMesh->PropRigidMesh.Material.Value = p;
			_pRigidMesh->PropRigidMesh.Apply();

			//_pRigidMesh->PropRigidMesh.MeshDraw.ResBuffer.Instance->ResMaterial.Instance->SaveToFile(p);
			/*_pRigidMesh->PropRigidMesh.MeshDraw.ResBuffer.Instance->ResMaterial.Instance->SaveToFile(
				_pRigidMesh->PropRigidMesh.MeshDraw.ResBuffer.Instance->ResMaterial.Instance->SourceFile);*/


		}
		//_pRigidMesh->PropRigidMesh.Apply();
	}
	void MRigidMeshComponent::setMesh()
	{
		_pRigidMesh->PropRigidMesh.Mesh.Value.SetRelativePath(Code3::BasicType::InternString("program"), "<sphere>1.0x30x30");
		_pRigidMesh->PropRigidMesh.Apply();
	}
}
