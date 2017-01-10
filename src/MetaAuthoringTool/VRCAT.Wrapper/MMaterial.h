#pragma once
#include "MPropertyGroup.h"
namespace MVRWrapper
{
	public ref class MMaterial : MPropertyGroup
	{
	private:
		Code3::Resource::ResourceMaterial* rMat;
	public:
		MMaterial(System::String^ matFile);
		/*void SaveToFile();
		void SaveToFile(System::String^ filePath);*/
	};
}

