#include "MCubeComponent.h"

namespace MVRWrapper
{
	MCubeComponent::MCubeComponent()
		:MContainerComponent(ComponentEnum::Cube)
	{
		_pCube = this->GetNative();
	}
	MCubeComponent::MCubeComponent(Code3::Component::ContainerComponent* _containerComponent)
		: MContainerComponent(_containerComponent)
	{
		_pCube = this->GetNative();
	}
	Code3::Scene::Cube* MCubeComponent::GetNative()
	{
		return MContainerComponent::GetNative<Code3::Scene::Cube>();
	}
	void MCubeComponent::TestSetMaterial(System::String^ matPath)
	{
		const char * path = MarshalHelper::StringToNativeChar(matPath);
		_pCube->PropRigidMesh.Material.Value.SetAbsolutePath(path);
		_pCube->PropRigidMesh.Material.ApplyChange();
	}
}
