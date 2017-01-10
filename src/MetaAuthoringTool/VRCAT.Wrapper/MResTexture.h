#pragma once
#include <Resource/ResourceTexture.h>
namespace MVRWrapper
{
	ref class MPropertyGroup;
	ref class MContainerComponent;
	public ref class MResTexture
	{
	private:
		static MResTexture^ _resTexture;
	public:
		static MResTexture^ GetInstance();
		MPropertyGroup^ GetTextureInfo(System::String^ path);
		void TestTextureInfo(MPropertyGroup^ param);
		void OnSave();
	};
}

