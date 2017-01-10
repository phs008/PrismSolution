#include "MContainerComponent.h"
#include "MPropertyGroup.h"
#include "MCommonHeader.h"
namespace MVRWrapper
{
	MPropertyGroup::MPropertyGroup()
	{

	}
	 
	MPropertyGroup::MPropertyGroup(Code3::Component::PropertyGroup* param)
	{
		_pPropertyGroup = param;
	}
	MPropertyGroup::MPropertyGroup(MContainerComponent^ parentContainerComponent,Code3::Component::PropertyGroup* param)
	{
		_parentContainerComponent = parentContainerComponent;
		_pPropertyGroup = param;
		_pPropertyGroup->SaveToFile(_pPropertyGroup->SourceFolder);
	}
	int MPropertyGroup::PropertyCount()
	{
		return _pPropertyGroup->GetSize();
	}
	MProperty^ MPropertyGroup::GetAt(int idx)
	{
		MProperty^ returnVal = gcnew MProperty(this, _pPropertyGroup->GetAt(idx));
		return returnVal;
	}
	System::String^ MPropertyGroup::GroupName()
	{
		return MarshalHelper::NativeStringToString(_pPropertyGroup->GroupName);
	}
	void MPropertyGroup::SaveToFile()
	{
		_pPropertyGroup->SaveToFile(_pPropertyGroup->SourceFile);
	}

	/*System::Collections::Generic::List<MProperty^>^ MPropertyGroup::PropertyList::get()
	{
		if (_PropertyList == nullptr)
			_PropertyList = gcnew System::Collections::Generic::List<MProperty^>();
		for (int i = 0; i < _pPropertyGroup->GetSize(); i++)
		{
			MProperty^ newProperty = gcnew MProperty(_pPropertyGroup->GetAt(i));
			_PropertyList->Add(newProperty);
		}
		return _PropertyList;
	}
	void MPropertyGroup::PropertyList::set(System::Collections::Generic::List<MProperty^>^ param)
	{
		_PropertyList = param;
	}*/
}
