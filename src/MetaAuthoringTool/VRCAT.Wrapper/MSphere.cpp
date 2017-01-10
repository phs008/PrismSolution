#include "MSphere.h"
#include "MCommonHeader.h"
#include "MTransformGroupComponent.h"

namespace MVRWrapper
{
	MSphere::MSphere()
		:MContainer()
	{
		this->AddNewComponent(ComponentEnum::RigidMesh);
		this->Name = "Sphere";
		ApplyAllProperty();
	}
	MSphere::MSphere(MWorld^ world)
	{
		MContainer^ container = world->OnNewChild();
		this->_pContainer = container->GetNative();
		container->AddNewComponent(ComponentEnum::TransformGroup);
		this->_RigidComponent = (MRigidMeshComponent^)container->AddNewComponent(ComponentEnum::RigidMesh);
		//this->Transform->Position->Y = 5;
		this->Name = "Sphere";
		ApplyAllProperty();
	}
	void MSphere::setMaterial(System::String^ matFile)
	{
		this->_RigidComponent->setMaterial(matFile);
	}
}
