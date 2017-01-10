#pragma once
#include "MPropertyGroup.h"
#include <ConfigFile.h>
namespace MVRWrapper
{
	public ref class MEngineConfig
	{
	private:
		Code3::Resource::ConfigFile* _pConfigFile;
		static MEngineConfig^ _engineConfig;
		MEngineConfig();
	public:
		static MEngineConfig^ GetInstance()
		{
			if (_engineConfig == nullptr)
				_engineConfig = gcnew MEngineConfig();
			return _engineConfig;
		}
		MPropertyGroup^ GetConfigPropertyGroup();
		void SaveConfig();
		void SetRenderPBR(bool isPBRRender);
	};
}

