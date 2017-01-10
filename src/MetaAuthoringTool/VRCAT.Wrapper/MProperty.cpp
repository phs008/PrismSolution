#include "MProperty.h"
#include "MCommonHeader.h"
#include "MPropertyGroup.h"
#include <Scene\Property\PropertyLight.h>
#include <PlatformEnum.h>
#include <Component/TypeComponent.h>
#include <Resource/ResourcePath.h>
namespace MVRWrapper
{
	MProperty::MProperty(MPropertyGroup^ _ParentPropertyGroup, Code3::Component::Property* param)
	{
		this->ParentPropertyGroup = _ParentPropertyGroup;
		_pProperty = param;
	}
	System::String^ MProperty::FieldName::get()
	{
		return MarshalHelper::NativeStringToString(_pProperty->FieldName);
	}
	
	System::String^ MProperty::Name::get()
	{
		return MarshalHelper::NativeStringToString(_pProperty->Name);
	}
	
	System::String^ MProperty::UnitName::get()
	{
		return MarshalHelper::NativeStringToString(_pProperty->UnitName);
	}
	
	System::String^ MProperty::ValueToString::get()
	{
		String valStr = "";
		_pProperty->Value->ToString(valStr);
		InternString s = valStr;
		return MarshalHelper::NativeStringToString(s);
	}

	System::Collections::Generic::List<array<System::Object^>^>^ MProperty::GetEnumerator()
	{
		System::Collections::Generic::List<array<System::Object^>^>^ returnVal = gcnew System::Collections::Generic::List<array<System::Object^>^>();
		Code3::Component::TypeEnumerator *e = _pProperty->Value->GetEnumerator();
		for (int i = 0; i < e->GetCount(); i++)
		{
			Code3::Component::TypeEnum* te = e->GetAtInt(i);
			array<System::Object^> ^ typeVal = { MarshalHelper::NativeStringToString(te->Name) , te->Value };
			returnVal->Add(typeVal);
		}
		return returnVal;
	}
	
	System::Object^ MProperty::Value::get()
	{
		System::String^ propertyName = MarshalHelper::NativeStringToString(_pProperty->Name);
		//System::Console::WriteLine(propertyName);
		System::Object^ returnVal = nullptr;
		if (propertyName == "Script")
		{
			/// Script 의 경우 MString 으로 enum 을 가져오는 현상 때문에 일단 PropertyEnum 을 다시 세팅
			Code3::Component::TypeBase::EnumType t = _pProperty->Value->Type;
			(int)_pProperty->Value->Type == Code3::Component::TypeBase::EnumTypeBool ? MPropertyEnumType = MPropertyEnum::MBool : (_pProperty->Value->GetEnumerator() != nullptr && _pProperty->Value->GetEnumerator()->GetCount() > 0) ? MPropertyEnumType = MPropertyEnum::MObjectEnum : MPropertyEnumType = (MPropertyEnum)_pProperty->Value->Type;
		}
			/// 스택 메모리 경우 
		switch ((int)MPropertyEnumType)
		{
		case (int)MPropertyEnum::MBool:
			returnVal = ((Code3::Component::TypeBool*)(_pProperty->Value))->Value;
			break;
		case (int)MPropertyEnum::MInt:
			returnVal = ((Code3::Component::TypeInt*)(_pProperty->Value))->Value;
			break;
		case (int)MPropertyEnum::MObjectEnum:
			if (_pProperty->Value->KindOf(Code3::Component::TypeBase::EnumTypeString))
			{
				int returnIdx = -1;
				Code3::BasicType::String compareS = ((Code3::Component::TypeString*)(_pProperty->Value))->Value;
				Code3::Component::TypeEnumerator *e = _pProperty->Value->GetEnumerator();
				for (int i = 0; i < e->GetCount(); i++)
				{
					Code3::Component::TypeEnum* te = e->GetAtInt(i);
					if (!te->Name.Compare(compareS.GetString()))
					{
						returnIdx = i;
						break;
					}
				}
				if (returnIdx == -1)
					returnVal = 0;
				else
					returnVal = returnIdx;
			}
			else
				returnVal = ((Code3::Component::TypeInt*)(_pProperty->Value))->Value;
			break;
		case (int)MPropertyEnum::MFloat:
			returnVal = ((Code3::Component::TypeFloat*)(_pProperty->Value))->Value;
			break;
		case (int)MPropertyEnum::MDouble:
			returnVal = ((Code3::Component::TypeDouble*)(_pProperty->Value))->Value;
			break;
		case (int)MPropertyEnum::MString:
			returnVal = gcnew System::String(((Code3::Component::TypeString*)(_pProperty->Value))->Value);
			break;
		case (int)MPropertyEnum::MPath:
		case (int)MPropertyEnum::MTextureFile:
		case (int)MPropertyEnum::MFbxFile:
		case (int)MPropertyEnum::MMaterialFile:
		case (int)MPropertyEnum::MVertexShader:
			returnVal = gcnew System::String((((Code3::Component::TypePath*)_pProperty->Value)->Value).GetPathName().GetString());
			break;
		case (int)MPropertyEnum::MAnimationFile:
			returnVal = gcnew System::String((((Code3::Component::TypePath*)_pProperty->Value)->Value).GetPathName().GetString());
			break;;
		case (int)MPropertyEnum::MScriptFIle:
			returnVal = gcnew System::String((((Code3::Script::TypeScript*)_pProperty->Value)->Value).GetPathName().GetString());
			break;
		case (int)MPropertyEnum::MEnumTypeComponent:
			returnVal = ((Code3::Component::TypeComponent<Code3::Component::Container>*)_pProperty->Value)->Value;
			break;
		}
		
		/// 데이터 영역 변수 가 새로 생성될경우 값을 마샬링 해서 
		if (returnVal != nullptr)
			_Value = returnVal;

		/// Heap 영역 변수 경우 Singleton 으로 생성하고 MProperty 가 갖고 있는 형태
		if (_Value != nullptr)
			return _Value;
		switch (_pProperty->Value->Type)
		{
			case Code3::Component::TypeBase::EnumTypeRange:
				returnVal = gcnew MRange((Code3::Component::TypeRange*)_pProperty->Value);
			break;;
			case Code3::Component::TypeBase::EnumType::EnumTypeVector2:
				returnVal = gcnew MVector2((Code3::Component::TypeVector2*)_pProperty->Value);
				break;
			case Code3::Component::TypeBase::EnumType::EnumTypeVector3:
				returnVal = gcnew MVector3((Code3::Component::TypeVector3*)_pProperty->Value);
				break;
			case Code3::Component::TypeBase::EnumType::EnumTypeVector4:
				returnVal = gcnew MVector4((Code3::Component::TypeVector4*)_pProperty->Value);
				break;
			case Code3::Component::TypeBase::EnumType::EnumTypeQuaternion:
				returnVal = gcnew MQuaternion((Code3::Component::TypeQuaternion*)_pProperty->Value);
				break;
			case Code3::Component::TypeBase::EnumType::EnumTypeColor:
				returnVal = gcnew MColor((Code3::Component::TypeColor*)_pProperty->Value);
				break;
		}
		_Value = returnVal;
		return _Value;
	}
	void MProperty::Value::set(System::Object^ param)
	{
//		switch (_pProperty->Value->Type)
		switch (MPropertyEnumType)
		{
		case MPropertyEnum::MBool:
			((Code3::Component::TypeBool*)(_pProperty->Value))->Value = (bool)param;
			break;
		case MPropertyEnum::MInt:
			((Code3::Component::TypeInt*)(_pProperty->Value))->Value = (int)param;
			break;
		case MPropertyEnum::MFloat:
			((Code3::Component::TypeFloat*)(_pProperty->Value))->Value = (float)param;
			break;
		case MPropertyEnum::MDouble:
			((Code3::Component::TypeDouble*)(_pProperty->Value))->Value = (double)param;
			break;
		case MPropertyEnum::MString:
			((Code3::Component::TypeString*)(_pProperty->Value))->Value = MarshalHelper::StringToNativeString(param->ToString());
			break;
		case MPropertyEnum::MObjectEnum:
			if (_pProperty->Value->KindOf(Code3::Component::TypeBase::EnumTypeString))
			{
				int index = (int)param;
				Code3::Component::TypeEnumerator *e = _pProperty->Value->GetEnumerator();
				Code3::Component::TypeEnum* te = e->GetAtInt(index);
				((Code3::Component::TypeString*)(_pProperty->Value))->Value = te->Name;
			}
			else
				((Code3::Component::TypeInt*)(_pProperty->Value))->Value = (int)param;
			break;
		case MPropertyEnum::MEnumTypeComponent:
			((Code3::Component::TypeComponent<Code3::Component::Container> *)_pProperty->Value)->Value = (System::Int64)param;
			break;
		case MPropertyEnum::MPath:
		case MPropertyEnum::MFbxFile:
		case MPropertyEnum::MVertexShader:
		case MPropertyEnum::MTextureFile:
		case MPropertyEnum::MMaterialFile:
		case MPropertyEnum::MScriptFIle:
			char* ansiVal = (char*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(param->ToString()).ToPointer();
			Code3::FileIO::Path newPath;
			newPath.SetAbsolutePath(ansiVal);
			if (newPath.MakeRelativePath(&Code3::Resource::GetResourcePath().ResourceFolder))
			{
				if (MPropertyEnumType == MPropertyEnum::MScriptFIle)
					((Code3::Script::TypeScript*)_pProperty->Value)->Value = newPath;
				else
					((Code3::Component::TypePath*)_pProperty->Value)->Value = newPath;
			}
			else
			{
				if (MPropertyEnumType == MPropertyEnum::MScriptFIle)
					((Code3::Script::TypeScript*)_pProperty->Value)->Value = ansiVal;
				else
					((Code3::Component::TypePath*)_pProperty->Value)->Value = ansiVal;
			}
			break;
		}
		_pProperty->Value->ApplyChange();
	}
	
	MPropertyGroup^ MProperty::GetTypeScriptPropertyGroup()
	{
		Code3::Component::PropertyGroup* scriptPG = ((Code3::Script::TypeScript*)_pProperty->Value)->GetActorProperties();
		if (scriptPG != NULL)
			return gcnew MPropertyGroup(nullptr, scriptPG);
		else
			return nullptr;
	}
	MPropertyEnum MProperty::EnumType::get()
	{
		Code3::Component::TypeBase::EnumType t = _pProperty->Value->Type;
		if ((int)_pProperty->Value->Type == Code3::Component::TypeBase::EnumTypeBool)
			MPropertyEnumType = MPropertyEnum::MBool;
		else if (_pProperty->Value->GetEnumerator() != nullptr && _pProperty->Value->GetEnumerator()->GetCount() > 0)
			MPropertyEnumType = MPropertyEnum::MObjectEnum;
		else if (_pProperty->Value->KindOf(Code3::Platform::EnumTypeAnimationFile))
			MPropertyEnumType = MPropertyEnum::MAnimationFile;
		else
		{
			/*if (_pProperty->Value->KindOf(Code3::Component::TypeBase::EnumTypePath))
				MPropertyEnumType = MPropertyEnum::MPath;*/
			if (_pProperty->Value->KindOf(Code3::Component::TypeBase::EnumTypeInt))
				MPropertyEnumType = MPropertyEnum::MInt;
			else
				MPropertyEnumType = (MPropertyEnum)_pProperty->Value->Type;
		}
		return MPropertyEnumType;
	}
}
