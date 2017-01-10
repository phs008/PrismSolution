#include "MRuntimeComponent.h"
#include <RuntimeClass/RuntimeClass.h>
#include <EngineDictionary.h>
#include "MarshalHelper.h"
namespace MVRWrapper
{
	MRuntimeComponent::MRuntimeComponent()
	{
		/*if(_Instance == nullptr)
			_Instance = gcnew */
	}
	MRuntimeComponent^ MRuntimeComponent::GetInstance()
	{
		if (_Instance == nullptr)
			_Instance = gcnew MRuntimeComponent();
		return _Instance;
	}
	System::Collections::Generic::List<System::String^>^ MRuntimeComponent::ComponentList::get()
	{
		if (_ComponentList == nullptr)
		{
			_ComponentList = gcnew System::Collections::Generic::List<System::String ^>();
			Code3::DataCollection::InternStringArray classList;
			Code3::RuntimeClass::GetRuntimeContext()->GetAllRuntimeClasses(Code3::Dictionary::ContainerComponent, &classList, true);
			for (int i = 0; i < classList.GetSize(); i++)
			{
				const char* componentName = (const char*)classList.GetAt(i);
				if (componentName != "World")
					_ComponentList->Add(MarshalHelper::NativeStringToString(componentName));
			}
		}
		return _ComponentList;
	}
}
