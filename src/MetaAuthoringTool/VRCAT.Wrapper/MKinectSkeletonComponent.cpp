#include "MKinectSkeletonComponent.h"
namespace MVRWrapper
{
	MKinectSkeletonComponent::MKinectSkeletonComponent()
		:MContainerComponent(ComponentEnum::KinectSkeletonComponent)
	{
		_pKinectSkeletonComponent = (Code3::Device::KinectSkeletonComponent*)GetComponent();
	}
	MKinectSkeletonComponent::MKinectSkeletonComponent(Code3::Component::ContainerComponent* _containerComponent)
		: MContainerComponent(_containerComponent)
	{
		_pKinectSkeletonComponent = (Code3::Device::KinectSkeletonComponent*)GetComponent();
	}
		
}
