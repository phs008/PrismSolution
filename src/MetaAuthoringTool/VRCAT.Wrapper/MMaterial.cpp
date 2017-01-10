#include "MMaterial.h"
#include "MarshalHelper.h"
#include <Resource\Material\Base\MaterialFile.h>
#include <Resource/ResourcePath.h>
namespace MVRWrapper
{
	MMaterial::MMaterial(System::String^ matFile) : MPropertyGroup()
	{
		InternString path = MarshalHelper::StringToNativeString(matFile);
		Code3::FileIO::Path p;
		p.SetAbsolutePath(path);
		if (p.MakeRelativePath(&Code3::Resource::GetResourcePath().ResourceFolder))
		{
			this->rMat = new Code3::Resource::ResourceMaterial();
			this->rMat->Create(p);
			this->_pPropertyGroup = (Code3::Component::PropertyGroup*)&this->rMat->Instance->PropMaterial;
		}
	}
	/*void MMaterial::SaveToFile()
	{
		if (this->rMat != NULL && this->rMat->Instance != NULL)
		{
			this->rMat->Instance->SaveToFile(this->rMat->Instance->SourceFile);
		}
	}*/
}
