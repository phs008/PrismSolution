#pragma once
#include "MContainerComponent.h"
namespace MVRWrapper
{
	public ref class MRigidMeshComponent : MContainerComponent
	{
	private:
		Code3::Scene::RigidMesh* _pRigidMesh;
	internal:
		Code3::Scene::RigidMesh* GetNative();
		MRigidMeshComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MRigidMeshComponent();
		void setMaterial(System::String^ matFile);
		void setMesh();
	};
}

