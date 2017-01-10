#pragma once
#include "MPropertyGroup.h"
#include "MContainerComponent.h"
#include "MContainerComponentEnum.h"
#include <VRDINamespace.h>
#include <VRDIClient.h>
#include <Component/Container.h>
#include <EngineDictionary.h>
#include "MContext.h"

namespace MVRWrapper
{
	ref class MTransformGroupComponent;
	public ref class MContainer : MContext
	{
	private:
		MContainer^ _Root;
		MContainer^ _Parent;
		MTransformGroupComponent^ _Transform;
	internal:
		Code3::Component::Container* _pContainer;
	public:
		System::Collections::Generic::List<MContainer^>^ ContiguousContainerList = gcnew System::Collections::Generic::List<MContainer^>();
	public:
		property MContainer^ Root
		{
			MContainer^ get();
			void set(MContainer^ param);
		}
		property MContainer^ Parent
		{
			MContainer^ get();
			void set(MContainer^ param);
		}
		property System::Int64 UID
		{
			System::Int64 get();
		}
		property System::String^ Name
		{
			System::String^ get();
			void set(System::String^ val);
		}
		property MTransformGroupComponent^ Transform
		{
			MTransformGroupComponent^ get();
			void set(MTransformGroupComponent^ parama);
		}
		property bool IsExpanded
		{
			bool get();
			void set(bool isExpanded);
		}
		property bool IsLocked
		{
			bool get();
			void set(bool isLocked);
		}
		property bool IsSelected
		{
			bool get();
			void set(bool isSelected);
		}
		property int Layer
		{
			int get();
			void set(int layer);
		}
		property bool IsShow
		{
			bool get();
			void set(bool isShow);
		}
			 
		System::String^ NativePointToString();
	public:
		MContainer();
	internal:
		Code3::Component::Container* GetNative();
		MContainer(Code3::Component::Container* container);
	public:
		//////////////////////////////////////////////////////////////////////////
		/// Container Node 관련 ///
		//////////////////////////////////////////////////////////////////////////
		MContainer^ GetChild(int idx);
		int GetChildrenCount();
		MContainer^ OnNewChild();
		int AddChild(MContainer^ child);
		void RemoveThis();
		void RemoveChild(MContainer^ child);
		void SetParent(MContainer^ NewParent);
		void DetachFromParent();
	internal:
		MContainerComponent^ MContainer::AddNewComponent(ComponentEnum componentType);
	public:
		//////////////////////////////////////////////////////////////////////////
		/// Component 관련 ///
		//////////////////////////////////////////////////////////////////////////
		MContainerComponent^ AddNewComponent(System::String^ componentName);
		//bool AddComponent(MContainerComponent^ component);
		int GetComponentsCount();
		MContainerComponent^ GetComponent(int idx);
		generic<class T>
		T GetComponent(ComponentEnum componentType);
		void ApplyAllProperty();
		int GetComponentIdx(System::Int64 compareUID);
		bool DeleteComponent(int idx);
		bool HasComponent(System::String^ componentName);
	public:
		//////////////////////////////////////////////////////////////////////////
		/// 기타 PropInstance 처리 함수 ///
		//////////////////////////////////////////////////////////////////////////
		void Selected(bool selected);
		void ChildContainerSelect(bool select);
		
	public:
		void Test();
	};
}

