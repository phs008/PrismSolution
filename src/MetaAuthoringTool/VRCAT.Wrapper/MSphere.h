#pragma once
#include "MContainer.h"
#include "MWorld.h"
#include "MRigidMeshComponent.h"
namespace MVRWrapper
{
	public ref class MSphere : MContainer
	{
	private:
		MRigidMeshComponent^ _RigidComponent = nullptr;
	public:
		MSphere();
		MSphere(MWorld^ world);
		void setMaterial(System::String^ marFile);
	};
}

