#include "MResTexture.h"
#include "MContainerComponent.h"
#include "MPropertyGroup.h"
#include "MarshalHelper.h"

namespace MVRWrapper
{
	MResTexture^ MResTexture::GetInstance()
	{
		if (_resTexture == nullptr)
			_resTexture = gcnew MResTexture();
		return _resTexture;
	}
	MPropertyGroup^ MResTexture::GetTextureInfo(System::String^ path)
	{
		InternString p = MarshalHelper::StringToNativeString(path);
		Code3::FileIO::Path source;
		source.SetAbsolutePath(p);
		Code3::Resource::ResourceTexture *t = new Code3::Resource::ResourceTexture();
		t->Load(source);

		
		if (t->Instance)
		{
			MPropertyGroup^ returnVal = gcnew MPropertyGroup(&t->Instance->Info.PropTexture);
			return returnVal;
		}
	}
	void MResTexture::TestTextureInfo(MPropertyGroup^ param)
	{
		Code3::Component::PropertyGroup* p = param->_pPropertyGroup;
	}
	void MResTexture::OnSave()
	{
	}
}
