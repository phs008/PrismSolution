#include "MUIImage.h"
#include <Component/ComponentBase.h>
#include <Resource/ResourcePath.h>
namespace MVRWrapper
{
	MUIImage::MUIImage()
		:MContainerComponent(ComponentEnum::UIImage)
	{
		_pUIImage = (Code3::UI::UIImage*)this->GetComponent();
	}
	MUIImage::MUIImage(Code3::Component::ContainerComponent* _containerComponent)
		: MContainerComponent(_containerComponent)
	{
		_pUIImage = (Code3::UI::UIImage*)this->GetComponent();
	}
	Code3::UI::UIImage * MUIImage::GetNative()
	{
		return MContainerComponent::GetNative<Code3::UI::UIImage>();
	}
	void MUIImage::setImage(System::String^ imgPath)
	{
		Code3::Component::PropertyGroup* group = _pUIImage->FindGroup(Code3::Dictionary::Material);
		if (group)
		{
			InternString path = MarshalHelper::StringToNativeString(imgPath);
			Code3::Resource::TypeTexture nTex;
			nTex.Value.SetAbsolutePath(path);
			if (nTex.Value.MakeRelativePath(&Code3::Resource::GetResourcePath().ResourceFolder))
			{
				group->SetProperty<Code3::Resource::TypeTexture>(Code3::Dictionary::TextureDiffuse, nTex);
			}
		}
	}
}
