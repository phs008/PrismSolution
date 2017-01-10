#pragma once
#include "MContainerComponent.h"
#include <Device/KinectImageComponent.h>

namespace MVRWrapper
{
	public ref class MKinectImageComponent : MContainerComponent
	{
	private:
		Code3::Device::KinectImageComponent* _pKinectImageComponent;
	internal:
		MKinectImageComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MKinectImageComponent();
	};
}

