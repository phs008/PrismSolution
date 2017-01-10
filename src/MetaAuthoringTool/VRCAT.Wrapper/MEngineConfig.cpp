#include "MEngineConfig.h"

namespace MVRWrapper
{
	MEngineConfig::MEngineConfig()
	{
		this->_pConfigFile = Code3::Resource::GetConfig();
	}
	MPropertyGroup^ MEngineConfig::GetConfigPropertyGroup()
	{
		MPropertyGroup^ returnVal = gcnew MPropertyGroup(nullptr, (Code3::Component::PropertyGroup*)&this->_pConfigFile->PropConfig);
		return returnVal;
	}
	void MEngineConfig::SaveConfig()
	{
		this->_pConfigFile->SaveProgramConfig();
	}
	void MEngineConfig::SetRenderPBR(bool isPBRRender)
	{
		this->_pConfigFile->PropConfig.RenderPBR = isPBRRender;
		this->_pConfigFile->SaveProgramConfig();
	}

}
