#include "MKinectImageComponent.h"

namespace MVRWrapper
{
	MKinectImageComponent::MKinectImageComponent()
		:MContainerComponent(ComponentEnum::KinectImageComponent)
	{
		_pKinectImageComponent = (Code3::Device::KinectImageComponent*)GetComponent();
		if (_pKinectImageComponent)
		{
			_pKinectImageComponent->PropImage.ImageType = Code3::Device::TypeKinectImageType::Overlay;
		}
	}
	MKinectImageComponent::MKinectImageComponent(Code3::Component::ContainerComponent* _containerComponent)
		:MContainerComponent(_containerComponent)
	{
		_pKinectImageComponent = (Code3::Device::KinectImageComponent*)_containerComponent;
		if (_pKinectImageComponent)
		{
			_pKinectImageComponent->PropImage.ImageType = Code3::Device::TypeKinectImageType::Overlay;
		}
	}
}
