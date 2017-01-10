#pragma once
#include "MContainerComponent.h"
#include <Resource/Script/ScriptComponent.h>
namespace MVRWrapper
{
	ref class MContainer;
	public ref class MScriptComponent : MContainerComponent
	{
	private:
		Code3::Script::ScriptComponent * _pScript;
	internal:
		Code3::Script::ScriptComponent* GetNative();
		MScriptComponent(Code3::Component::ContainerComponent* _containerComponent);
	public:
		MScriptComponent();
	public:
		void SetScript(System::String^ scriptPath);
		MPropertyGroup^ GetActorProperties();
		static void UpdateProjectScriptList(MContainer^ rootContainer);
	};
}

