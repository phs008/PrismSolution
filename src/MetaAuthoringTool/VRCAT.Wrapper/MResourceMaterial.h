#pragma once

#include <Resource\ResourceMaterial.h>
#include "MPropertyGroup.h"
namespace MVRWrapper
{
	public ref class MResourceMaterial
	{
	internal:
		Code3::Resource::ResourceMaterial* _pMtl;
	public:
		MResourceMaterial();
		MResourceMaterial(Code3::Resource::ResourceMaterial* mtl);
		MPropertyGroup^ GetMatPropertyGroup();
		System::String^ GetMatFileResource();
		void SetMatFileResource(System::String^ mtlpath);
		void SaveToFile();
	};
}

