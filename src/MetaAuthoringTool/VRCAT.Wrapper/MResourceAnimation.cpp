#include "MResourceAnimation.h"
#include "MarshalHelper.h"
#include <Resource/ResourcePath.h>
namespace MVRWrapper
{
	MResourceAnimation::MResourceAnimation(Code3::Resource::ResourceFbxAnimation* ani)
	{
		this->_pAni = ani;
	}
	System::String^ MResourceAnimation::GetAnimationFileResource()
	{
		return MarshalHelper::NativeStringToString(this->_pAni->AnimationFile->GetPathName().GetString());
	}
	void MResourceAnimation::SetAnimationFileResource(System::String^ anipath)
	{
		InternString path = MarshalHelper::StringToNativeChar(anipath);
		Code3::FileIO::Path p;
		p.SetAbsolutePath(path);
		if (p.MakeRelativePath(&Code3::Resource::GetResourcePath().ResourceFolder))
		{
			this->_pAni->Create(p);
		}
	}
}
