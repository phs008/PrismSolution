#pragma once
#include "MProperty.h"
namespace MVRWrapper
{
	ref class MContainerComponent;
	public ref class MPropertyGroup
	{
	private:
		MContainerComponent^ _parentContainerComponent;
	internal:
		Code3::Component::PropertyGroup* _pPropertyGroup;
		System::Collections::Generic::List<MProperty^>^ _PropertyList;
		MPropertyGroup();
		MPropertyGroup(Code3::Component::PropertyGroup* param);
	public:
		MPropertyGroup(MContainerComponent^ parentcontainerComponent,Code3::Component::PropertyGroup* param);
		int PropertyCount();
		virtual MProperty^ GetAt(int idx);
		void SaveToFile();
		/*property System::Collections::Generic::List<MProperty^>^ PropertyList
		{
			virtual System::Collections::Generic::List<MProperty^>^ get();
			virtual void set(System::Collections::Generic::List<MProperty^>^ param);
		}*/
		System::String^ GroupName();
	};
}

