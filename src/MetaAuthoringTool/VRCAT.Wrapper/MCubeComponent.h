#pragma once
#include "MContainerComponent.h"
namespace MVRWrapper
{
	public ref class MCubeComponent : MContainerComponent
	{
	private:
		Code3::Scene::Cube* _pCube;
	internal:
		Code3::Scene::Cube* GetNative();
		MCubeComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MCubeComponent();
		void TestSetMaterial(System::String^ matPath);
	};
}

