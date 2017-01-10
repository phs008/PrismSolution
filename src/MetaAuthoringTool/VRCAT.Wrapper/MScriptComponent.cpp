#include "MScriptComponent.h"
#include "MContainer.h"
#include <FileIO/File.h>
#include <Resource/Script/TypeScript.h>
#include <Resource/Script/PropertyScript.h>
#include <Resource/ResourcePath.h>
#include <Utility/FileTool.h>

namespace MVRWrapper
{
	MScriptComponent::MScriptComponent()
		:MContainerComponent(ComponentEnum::ScriptComponent)
	{
		_pScript = this->GetNative();
	}
	MScriptComponent::MScriptComponent(Code3::Component::ContainerComponent* _containerComponent)
		: MContainerComponent(_containerComponent)
	{
		_pScript = this->GetNative();
	}
	Code3::Script::ScriptComponent* MScriptComponent::GetNative()
	{
		return MContainerComponent::GetNative<Code3::Script::ScriptComponent>();
	}
	void MScriptComponent::SetScript(System::String^ scriptPath)
	{
		/*char* ansiVal = (char*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(scriptPath->ToString()).ToPointer();
		Code3::BasicType::String* s = new Code3::BasicType::String(ansiVal);*/
		const char * s = MarshalHelper::StringToNativeChar(scriptPath);
		Code3::FileIO::Path p;
		p.SetAbsolutePath(s);
		if (p.MakeRelativePath(&Code3::Utility::GetFileTool().ProjectFolder))
		{
			_pScript->PropScript.Script.Value = p;
			_pScript->PropScript.Script.ApplyChange();
		}
		
	}
	MPropertyGroup^ MScriptComponent::GetActorProperties()
	{
		Code3::Component::PropertyGroup *scriptProperty = _pScript->PropScript.Script.GetActorProperties();
		MPropertyGroup^ returnVal = nullptr;
		if (scriptProperty)
			returnVal = gcnew MPropertyGroup(this, scriptProperty);
		return returnVal;
	}
	void MScriptComponent::UpdateProjectScriptList(MContainer^ rootContainer)
	{
		Code3::Script::UpdateProjectScriptList(rootContainer->_pContainer);
	}
}
