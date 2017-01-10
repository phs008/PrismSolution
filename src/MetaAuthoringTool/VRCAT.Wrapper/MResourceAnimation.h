#pragma once
#include <Object\Fbx\ResourceFbxAnimation.h>

namespace MVRWrapper
{
	public ref class MResourceAnimation
	{
	internal:
		Code3::Resource::ResourceFbxAnimation* _pAni;
	public:
		MResourceAnimation(Code3::Resource::ResourceFbxAnimation* ani);
		System::String^ GetAnimationFileResource();
		void SetAnimationFileResource(System::String^ path);
	};
}

