#pragma once
#include "MPropertyGroup.h"
#include "MContainerComponentEnum.h"
#include "MCommonHeader.h"
#include <EngineDictionary.h>
namespace MVRWrapper
{
	public ref class MContainerComponent
	{
	private:
		Code3::Component::ContainerComponent* _pContainerComponent;
	public:
		property System::String^ ContainerName
		{
			System::String^ get();
		}
		property System::Int64 UID
		{
			System::Int64 get();
		}
	public:
		int GetPropertyGroupCount();
		MPropertyGroup^ GetPropertyGroup(int idx);
		bool RefreshProperties();
	internal:
		//MContainerComponent(System::String^ className);
		MContainerComponent(ComponentEnum componentType);
		MContainerComponent(System::String^ ComponentName);
		MContainerComponent(Code3::Component::ContainerComponent* component);
	internal:
		template<typename T>
		T *GetNative()
		{
			return static_cast<T*>(_pContainerComponent);
		}
		Code3::Component::ContainerComponent* GetComponent()
		{
			return _pContainerComponent;
		}
	};
}

