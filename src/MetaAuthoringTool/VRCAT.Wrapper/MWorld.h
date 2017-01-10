#pragma once
#include "MContainer.h"
#include "MCamera.h"

namespace MVRWrapper
{
	public ref class MWorld : MContainer
	{
	private:
		static MWorld^ _Instance;
		Code3::Scene::World* _pWorldComponent;
	internal:
		//Code3::Component::Container* GetNative();
	public:
		static MWorld^ GetInstance()
		{
			if (_Instance == nullptr)
				_Instance = gcnew MWorld();
			return _Instance;
			
		}
		MWorld();
		~MWorld()
		{
			delete _pContainer;
		}
	private:
		bool MWorld::SelectedPickedObjectSub(Code3::Component::Container *container, Code3::Vector3 org, Code3::Vector3 dir, Code3::Vector3 *collisionPos,
			float *collisionDistance, Code3::Component::Container **foundObject);
		bool SelectPickedObjectSub(Code3::Component::Container *container, Code3::Vector3 org, Code3::Vector3 dir, bool leafOnly,
			Code3::Vector3 *collisionPos, float *collisionDistance, Code3::Component::Container **foundObject);
		
	public:
		void FrameAnimate();
		static void SetProjectSetting(System::String^ path);
		bool SaveScene(System::String^ path);
		bool LoadScene(System::String^ path);
		
		void NewWorld();
		MContainer^ PickingObject(int pointx, int pointy, int ScreenWidth, int ScreenHeight, MCamera^ cam);
	};
}


