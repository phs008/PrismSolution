#include "MCube.h"
#include "MarshalHelper.h"
#include "EngineDictionary.h"
#include <Resource/ResourcePath.h>
#include <Object/RigidMesh/RigidMesh.h>
#include <Object/RigidMesh/Property/PropertyRigidMesh.h>
namespace MVRWrapper
{
#ifdef _INHERITANCE_PATTERN
	MCube::MCube(MWorld^ world)
	{
		this->_pNode = (Code3::Scene::Cube*)world->GetNative()->NewChild(InternString("Cube"));
		this->_pNode->PropInstance.Name = "EmptyNode";
		this->_pNode->SetPosition(Code3::Vector3(0, 0, 0));
		
	}
	void MCube::setMaterial(System::String^ matFile)
	{
		InternString path = MarshalHelper::StringToNativeString(matFile);
		Code3::FileIO::Path p;
		p.SetRelativePath(InternString("project"), path);
		((Code3::Scene::Cube*)this->_pNode)->PropRigidMesh.Material.Value = p;
		this->_pNode->ApplyAllProperty();
	}
#endif
	MCube::MCube()
		:MContainer()
	{
		this->AddNewComponent(ComponentEnum::Cube);
		this->Name = "Cube";
		ApplyAllProperty();
	}
	MCube::MCube(MWorld^ world)
	{
		MContainer^ container = world->OnNewChild();
		this->_pContainer = container->GetNative();
		MContainerComponent^ cubeComponent = container->AddNewComponent(ComponentEnum::Cube);
		this->Name = "Cube";
		ApplyAllProperty();
	}
	void MCube::setMaterial(System::String^ matFile)
	{
		InternString path = MarshalHelper::StringToNativeString(matFile);
		Code3::FileIO::Path p;
		p.SetAbsolutePath(path);
		if (p.MakeRelativePath(&Code3::Resource::GetResourcePath().ResourceFolder))
		{
			/*this->_pContainer->PropRigidMesh.Material.Value = p;
			this->_pNode->ApplyAllProperty();*/
		}

	}
}
