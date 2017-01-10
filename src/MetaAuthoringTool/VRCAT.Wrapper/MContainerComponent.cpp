#include "MContainerComponent.h"
#include "MarshalHelper.h"
#include "MVector2.h"
#include "MVector3.h"
#include "MVector4.h"
#include <Component/ContainerComponent.h>

namespace MVRWrapper
{
	MContainerComponent::MContainerComponent(ComponentEnum componentType)
	{
		System::String^ componentName = System::Enum::GetName(ComponentEnum::typeid, (System::Object^) componentType);

		Code3::Component::ComponentBase *owner = Code3::Component::ComponentBase::New(MarshalHelper::StringToNativeString(componentName));
		if (!owner)
			return;
		static InternString str("ContainerComponent");
		if (!owner->KindOf(str))
		{
			delete owner;
			return;
		}
		if (owner != NULL)
			_pContainerComponent = (Code3::Component::ContainerComponent *)owner;
	}
	MContainerComponent::MContainerComponent(System::String^ ComponentName)
	{
		Code3::Component::ComponentBase *owner = Code3::Component::ComponentBase::New(MarshalHelper::StringToNativeString(ComponentName));
		if (!owner)
			return;
		static InternString str("ContainerComponent");
		if (!owner->KindOf(str))
		{
			delete owner;
			return;
		}
		if (owner != NULL)
			_pContainerComponent = (Code3::Component::ContainerComponent *)owner;
	}
	MContainerComponent::MContainerComponent(Code3::Component::ContainerComponent* containerComponent)
	{
		this->_pContainerComponent = containerComponent;
	}
	System::String^ MContainerComponent::ContainerName::get()
	{
		return MarshalHelper::NativeStringToString(_pContainerComponent->LeafClassName());
	}
	System::Int64 MContainerComponent::UID::get()
	{
		return _pContainerComponent->LinkableUID;
	}
	int MContainerComponent::GetPropertyGroupCount()
	{
		return _pContainerComponent->GetPropertyGroupCount();
	}
	MPropertyGroup^ MContainerComponent::GetPropertyGroup(int idx)
	{
		Code3::Component::PropertyGroup *pGroup = _pContainerComponent->GetPropertyGroup(idx);
		return gcnew MPropertyGroup(this, pGroup);
	}
	bool MContainerComponent::RefreshProperties()
	{
		return _pContainerComponent->RefreshProperties();
	}
}
