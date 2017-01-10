#pragma once
#include <Object/Gizmo/GizmoCenter.h>
#include <Object/Gizmo/Gizmo.h>
#include "MVector3.h"



namespace MVRWrapper
{
	ref class MRenderWindow;
	ref class MContainer;
	public ref class MGizmoHandler
	{
	public:
		static MGizmoHandler^ GetInstance()
		{
			if (_Instance == nullptr)
				_Instance = gcnew MGizmoHandler();
			return _Instance;
		}
	private:
		static MGizmoHandler^ _Instance;
	private:
		Code3::Scene::GizmoCenter* _pGizmoCenter;
		MContainer^ selectedContainer;
	private:
		MGizmoHandler();
	public:
		void SetGizmoType(int type);
		void SetObject(MContainer^ container);
		void AddGizmoHandle(MRenderWindow^ renderWindow);
		void DetachAllGizmo();
		void SetEnable(bool enable);
		//void SetGizmoPosition(MVector3^ vec);
		//bool GetGizmoSelection();
	};
}

