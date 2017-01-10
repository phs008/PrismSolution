#pragma once
#include "MContainerComponent.h"
#include <Device/KinectSkeletonComponent.h>
//#include <Device/VRDeviceComponent.h>
namespace MVRWrapper
{
	public ref class MKinectSkeletonComponent : MContainerComponent
	{
	private:
		Code3::Device::KinectSkeletonComponent* _pKinectSkeletonComponent;
	internal:
		MKinectSkeletonComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MKinectSkeletonComponent();
	};
}

