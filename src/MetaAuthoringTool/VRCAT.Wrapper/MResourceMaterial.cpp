#include "MResourceMaterial.h"
#include "MarshalHelper.h"
#include <Resource/ResourcePath.h>
namespace MVRWrapper
{
	MResourceMaterial::MResourceMaterial()
	{
		this->_pMtl = new Code3::Resource::ResourceMaterial();
	}
	MResourceMaterial::MResourceMaterial(Code3::Resource::ResourceMaterial* mtl)
	{
		this->_pMtl = mtl;
	}
	MPropertyGroup^ MResourceMaterial::GetMatPropertyGroup()
	{
		MPropertyGroup^ returnVal = gcnew MPropertyGroup();
		returnVal->_pPropertyGroup = &this->_pMtl->Instance->PropMaterial;
		return returnVal;
	}
	System::String^ MResourceMaterial::GetMatFileResource()
	{
		return MarshalHelper::NativeStringToString(this->_pMtl->FileName->GetPathName().GetString());
	}
	void MResourceMaterial::SetMatFileResource(System::String^ mtlpath)
	{
		InternString path = MarshalHelper::StringToNativeChar(mtlpath);
		Code3::FileIO::Path p;
		p.SetAbsolutePath(path);
		if (p.MakeRelativePath(&Code3::Resource::GetResourcePath().ResourceFolder))
		{
			this->_pMtl->Create(p);
		}
	}
	void MResourceMaterial::SaveToFile()
	{
		_pMtl->Instance->SaveToFile(_pMtl->Instance->SourceFile);
	}
}
