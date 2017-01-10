#pragma once
#include <Renderer\DX\RenderWindowDX.h>
#include <Object\Gizmo\GizmoHandler.h>
#include <Renderer\Base\LineDrawer.h>
#include "MCamera.h"
#include "MWorld.h"
#include "MContext.h"
namespace MVRWrapper
{
	
	public ref class MRenderWindow : MContext
	{
	public:
		MRenderWindow(int handle);
		~MRenderWindow()
		{
			MContext::UnRegisterWindow(this);
		}
		void PreRender();
		void Render(MContainer^ cam);
		void PostRender();
		void FrameAnimate(MWorld^ world);
		void Render(MWorld^ world, MContainer^ cam);
		void Resize(int width, int height);
		property int ScreenWidth
		{
			int	get();
		}
		property int ScreenHeight
		{
			int get();
		}

		void GizmoMouseClick(int x, int y, MCamera^ cam, int width, int height);
		void GizmoMouseMove(int x, int y, MCamera^ cam, int width, int height);
		void GizmoMouseDrag(int x, int y, MCamera^ cam, int width, int height);
		void GizmoMouseRelease();
		void DrawGizmo(MWorld^ world, MCamera^ cam);
		bool GetGizmoSelection();
		MContainer^ SelectPolygonPickObject(int pointX, int pointY, MCamera^ camera);
		void SetRectangleStartPoint(float x, float y);
		void SetRectangleDeltaPoint(float x, float y);
		void DrawRectangle();
	internal:
		Code3::Renderer::RenderWindowDX* GetNative();
		Code3::Scene::GizmoHandler* GetGizmoHandler();
		Code3::Resource::ShaderComponentLinkSet *link;
		Code3::Renderer::LineDrawer2D *line1;
		Code3::Renderer::LineDrawer2D *line2;
		Code3::Renderer::LineDrawer2D *line3;
		Code3::Renderer::LineDrawer2D *line4;
	private:
		Code3::Renderer::RenderWindowDX* _pRenderWindow;
		Code3::Scene::GizmoHandler* _pGizmoHander;
		Code3::Scene::Gizmo* _pGizmo;
		float startX = 0, startY = 0;
		float deltaX = 0, deltaY = 0;
	private:
		
		bool SelectPolygonPickObjectSub(Code3::Scene::Camera * camera, Code3::Component::Container* container, Code3::Math3D::Vector3 org, Code3::Math3D::Vector3 dir, bool leafOnly,
			Code3::Math3D::Vector3* collisionPos, float *collisionDistance, Code3::Component::Container **foundObject, bool checkPolygon);
	};
}

