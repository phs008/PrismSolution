#include "MWorld.h"
#include "MCamera.h"
#include "MCameraComponent.h"
#include "MarshalHelper.h"
#include <Context\Context.h>
#include <RegisterRuntime.h>
#include <FileIO\Archive.h>
#include <Scene/World.h>
#include <Scene/Camera.h>
#include <EngineDictionary.h>

#include "EGuiTools.h"
#include "EGuiDrawCall.h"
#include "EGuiRoot.h"

using namespace Code3::Context;
using namespace Code3::Renderer;
using namespace Code3::Scene;
namespace MVRWrapper
{
	MWorld::MWorld()
		:MContainer()
	{
		try
		{
			//LOG_PRINT("월드 진입점에 들어왔습니다.");
			_pContainer->Root = _pContainer;
			Code3::Component::ContainerComponent* _worldComponent = _pContainer->AddNewComponent(Code3::Dictionary::World);
			//_pContainer->AddNewComponent(Code3::Dictionary::Camera);
			_pWorldComponent = static_cast<Code3::Scene::World *>(_worldComponent);
			_pContainer->PropInstance.Name = "WorldContainer";
			//j2y
			Code3::EGuiRoot::Initialize();
			Code3::EGuiTools::SetActiveWorld(_pWorldComponent);
		}
		catch (System::Exception^ e )
		{
			System::Console::WriteLine(e->ToString());
		}
	}
	void MWorld::FrameAnimate()
	{
		_pWorldComponent->FrameAnimate();
		Code3::EGuiRoot::MainUpdate(); //j2y
		Code3::EGuiRoot::LateUpdate(); //j2y
	}
	void MWorld::SetProjectSetting(System::String^ path)
	{
		char * cPath = MarshalHelper::StringToNativeString(path).GetString();
		Code3::Utility::GetFileTool().ProjectFolder.SetAbsolutePath(cPath);
		//LOG_PRINT("Project Setting. %s", cPath);
	}

	MContainer^ MWorld::PickingObject(int pointx, int pointy, int ScreenWidth, int ScreenHeight, MCamera^ cam)
	{
		MContainer^ returnVal = nullptr;
		Code3::Scene::Camera* CameraComponent = cam->Cam->GetNative();
		Code3::Vector3 org, dir;
		if (CameraComponent->GetPickRay(pointx, pointy, ScreenWidth, ScreenHeight, 1000.0f, org, dir))
		{
			Code3::Component::Container *foundObject = NULL;
			Code3::Vector3 collisionPos;
			float nearestDistance;
			bool r = SelectedPickedObjectSub(this->GetNative(), org, dir, &collisionPos, &nearestDistance, &foundObject);
			//bool r = SelectPickedObjectSub(this->GetNative(), org, dir, true, &collisionPos, &nearestDistance, &foundObject);
			if (r && foundObject)
			{
				returnVal = gcnew MContainer(foundObject);
				//foundObject->SetSelect(true);
			}
		}
		return returnVal;
	}

	void MWorld::NewWorld()
	{
		this->_pContainer->RemoveAllChildren();
		this->_pContainer->RemoveComponent(Code3::Dictionary::World);
		this->_Instance = nullptr;
	}

	bool MWorld::SaveScene(System::String^ path)
	{
		Code3::FileIO::Path savePath;
		const char* convertingPath = MarshalHelper::StringToNativeChar(path);
		savePath.SetAbsolutePath(convertingPath);
		bool returnVal = this->GetNative()->SaveToFile(savePath);
		return returnVal;
	}
	bool MWorld::LoadScene(System::String^ path)
	{
		Code3::FileIO::Path loadPath;
		const char* convertingPath = MarshalHelper::StringToNativeChar(path);
		loadPath.SetAbsolutePath(convertingPath);
		bool returnVal = this->_pContainer->LoadFromFile(loadPath);
		//bool returnVal = this->GetNative()->LoadFromFile(loadPath);
		_pWorldComponent = (Code3::Scene::World*)this->GetNative()->FindComponentByType(Code3::Dictionary::World);
		return returnVal;
	}


#pragma region Private Function
	bool MWorld::SelectedPickedObjectSub(Code3::Component::Container *container, Code3::Vector3 org, Code3::Vector3 dir, Code3::Vector3 *collisionPos,
		float *collisionDistance, Code3::Component::Container **foundObject)
	{


		Code3::Scene::TransformGroup *objTrans = container->GetReservedComponentCast<Code3::Scene::TransformGroup>(COMPONENT_TRANSFORMGROUP);

		float dist;
		Code3::Vector3 collision;
		Code3::Geometry::BoundingBox box;

		if (objTrans)
		{
			box = objTrans->GetSumBox();
			if (!box.FindNearCollision(org, org + dir, &collision, &dist))
			{
				return false;
			}
		}


		// found leaf collision
		// 선택 조건에 따라 달라짐
		// 아래는 원하는 종류 (fbx, light, camera) 만 선택됨
		if (container->FindComponentByTypeCast<Code3::Scene::Light>(Code3::Dictionary::Light)
			|| container->FindComponentByTypeCast<Code3::Scene::Camera>(Code3::Dictionary::Camera)
			|| container->FindComponentByTypeCast<Code3::Fbx::Fbx>(Code3::Dictionary::Fbx))
		{
			// recheck
			box.FindNearCollision(org, org + dir, &collision, &dist);

			*collisionPos = collision;
			*collisionDistance = dist;
			*foundObject = container;
			return true;
		}


		Code3::Component::Container *leafFound = NULL;
		*collisionDistance = FLT_MAX;

		for (int i = 0; i < container->Children.GetSize(); i++)
		{
			if (SelectedPickedObjectSub(container->Children[i], org, dir, &collision, &dist, &leafFound))
			{
				if (*collisionDistance > dist)
				{
					*foundObject = leafFound;
					*collisionDistance = dist;
				}
			}
		}

		if (leafFound)
			return true;


		return false;
	}
	bool MWorld::SelectPickedObjectSub(Code3::Component::Container *container, Code3::Vector3 org, Code3::Vector3 dir, bool leafOnly,
		Code3::Vector3 *collisionPos, float *collisionDistance, Code3::Component::Container **foundObject)
	{
		Code3::Scene::TransformGroup *objTrans = container->GetReservedComponentCast<Code3::Scene::TransformGroup>(COMPONENT_TRANSFORMGROUP);

		float dist;
		Code3::Vector3 collision;
		Code3::Geometry::BoundingBox box;

		if (objTrans)
		{
			box = objTrans->GetSumBox();
			if (!box.FindNearCollision(org, org + dir, &collision, &dist))
			{
				return false;
			}
		}


		// found leaf collision
		// 선택 조건에 따라 달라짐
		// 아래는 원하는 종류 (fbx, light, camera) 만 선택됨
		if (container->FindComponentByTypeCast<Code3::Scene::Light>(Code3::Dictionary::Light)
			|| container->FindComponentByTypeCast<Code3::Scene::Camera>(Code3::Dictionary::Camera)
			|| container->FindComponentByTypeCast<Code3::Fbx::Fbx>(Code3::Dictionary::Fbx)
			|| container->FindComponentByTypeCast<Code3::Fbx::Fbx>(Code3::Dictionary::FbxNodeMesh)
			)
		{
			// recheck for debug
			//box.FindNearCollision(org, org+dir, &collision, &dist);

			*collisionPos = collision;
			*collisionDistance = dist;
			*foundObject = container;
		}

		if (leafOnly || *foundObject == NULL)
		{
			float nearDist = FLT_MAX;
			Code3::Component::Container *subNearest = NULL;
			Code3::Vector3 nearCollisionPos;

			for (int i = 0; i < container->Children.GetSize(); i++)
			{
				Code3::Vector3 subCollisionPos;
				float subDist;
				Code3::Component::Container *foundContainer = NULL;

				if (SelectPickedObjectSub(container->Children[i], org, dir, leafOnly, &subCollisionPos, &subDist, &foundContainer))
				{
					if (subDist < nearDist)
					{
						nearCollisionPos = subCollisionPos;
						subNearest = foundContainer;
						nearDist = subDist;
					}
				}
			}

			if (subNearest)
			{
				*collisionDistance = nearDist;
				*collisionPos = nearCollisionPos;
				*foundObject = subNearest;
				return true;
			}

		}

		return *foundObject != NULL;
	}
#pragma endregion
}
