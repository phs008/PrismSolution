#pragma once
#include <Component\TypeBase.h>
#include <Component\Property.h>
#include <Component\PropertyGroup.h>
#include <Windows.h>
#include <Resource\ResourceVRDIClient.h>
#include <Scene\TransformGroup.h>>
#include <Scene\Light.h>
#include <Object\Cube\Cube.h>
#include <PlatformEnum.h>
namespace MVRWrapper
{
	public enum class MPropertyEnum
	{
		MNone = Code3::Component::TypeBase::EnumType::EnumTypeNone,
		MBool = Code3::Component::TypeBase::EnumType::EnumTypeBool,
		MString = Code3::Component::TypeBase::EnumType::EnumTypeString,
		MPath = Code3::Component::TypeBase::TypeBase::EnumType::EnumTypePath,
		MInt = Code3::Component::TypeBase::EnumType::EnumTypeInt,
		MFloat = Code3::Component::TypeBase::EnumType::EnumTypeFloat,
		MDouble = Code3::Component::TypeBase::EnumType::EnumTypeDouble,
		MVector2 = Code3::Component::TypeBase::EnumType::EnumTypeVector2,
		MVector3 = Code3::Component::TypeBase::EnumType::EnumTypeVector3,
		MVecotr4 = Code3::Component::TypeBase::EnumType::EnumTypeVector4,
		MColor = Code3::Component::TypeBase::EnumType::EnumTypeColor,
		MQuaternion = Code3::Component::TypeBase::EnumType::EnumTypeQuaternion,
		MRange = Code3::Component::TypeBase::EnumType::EnumTypeRange,
		MEnumTypeComponent = Code3::Component::TypeBase::EnumType::EnumTypeComponent,
		MObjectEnum = 888,
		MCustomEnum = 777,
		MFbxFile = Code3::Platform::PlatformEnumType::EnumTypeFbxFile,
		MVertexShader = Code3::Platform::PlatformEnumType::EnumTypeVertexShader,
		MPixelShader = Code3::Platform::PlatformEnumType::EnumTypePixelShader,
		MTextureFile = Code3::Platform::PlatformEnumType::EnumTypeTexture,
		MMaterialFile = Code3::Platform::PlatformEnumType::EnumTypeMaterialFile,
		MAnimationFile = Code3::Platform::PlatformEnumType::EnumTypeAnimationFile,
		MScriptFIle = Code3::Platform::EnumTypeScript,
	};
    ref class MPropertyGroup;
	public ref class MProperty
	{
	private:
		System::Object^ _Value;
	internal:
		Code3::Component::Property* _pProperty;
		MPropertyEnum MPropertyEnumType;
	public:
		MPropertyGroup^ ParentPropertyGroup;
	public:
		MProperty(MPropertyGroup^ _ParentPropertyGroup,Code3::Component::Property* _param);
		property System::String^ FieldName
		{
			System::String^ get();
		}
		property System::String^ Name
		{
			System::String^ get();
		}
		property System::String^ UnitName
		{
			System::String^ get();
		}
		
		property System::String^ ValueToString
		{
			System::String^ get();
		}
		
		property System::Object^ Value
		{
			virtual System::Object^ get();
			virtual void set(System::Object^ value);
		}
		
		property MPropertyEnum EnumType
		{
			MPropertyEnum get();
		}
		MPropertyGroup^ GetTypeScriptPropertyGroup();
		System::Collections::Generic::List<array<System::Object^>^>^ GetEnumerator();
		
	};
}
