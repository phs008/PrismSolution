#include <Component/All.h>
#include <Windows.h>
#include <Context\Context.h>
#include <RegisterRuntime.h>
#include <Renderer\DX\RenderWindowDX.h>
#include <Renderer\DX\RenderDeviceDX.h>
#include <Scene\Camera.h>
#include <Object\Fbx\FbxNodeMesh.h>
#include "MRenderWindow.h"
#include "MWorld.h"
#include "MCamera.h"
#include "MTransformGroupComponent.h"
#include "MCameraComponent.h"
using namespace Code3::Context;
using namespace Code3::Renderer;
namespace MVRWrapper
{
	Code3::Renderer::RenderWindowDX* MRenderWindow::GetNative()
	{
		return this->_pRenderWindow;
	}
	MRenderWindow::MRenderWindow(int handle)
		:MContext()
	{
		_pRenderWindow = new Code3::Renderer::RenderWindowDX();
		_pRenderWindow->Handle = (HWND)handle;
		_pGizmoHander = _pRenderWindow->GizmoHandler;
		//_pGizmo = _pRenderWindow->gizmo;

		MContext::RegisterWindow(this);
		//ContextObject().ThisContext->GetRenderDeviceDX()->RegisterWindow(_pRenderWindow);
		/*link = new Code3::Resource::ShaderComponentLinkSet(Code3::Context::ContextObject().ThisContext);
		link->Add(&_pRenderWindow->Screen);
		line1 = new Code3::Renderer::LineDrawer2D(link);
		line1->SetColor(Code3::Math3D::Color(1, 1, 1, 1));
		line2 = new Code3::Renderer::LineDrawer2D(link);
		line2->SetColor(Code3::Math3D::Color(1, 1, 1, 1));
		line3 = new Code3::Renderer::LineDrawer2D(link);
		line3->SetColor(Code3::Math3D::Color(1, 1, 1, 1));
		line4 = new Code3::Renderer::LineDrawer2D(link);
		line4->SetColor(Code3::Math3D::Color(1, 1, 1, 1));*/
	}

	void MRenderWindow::PreRender()
	{
		_pRenderWindow->PreRender();
	}
	void MRenderWindow::PostRender()
	{
		_pRenderWindow->PostRender();
	}
	void MRenderWindow::FrameAnimate(MWorld^ world)
	{
		if (world == nullptr)
			MWorld::GetInstance()->FrameAnimate();
		else
			world->FrameAnimate();
	}

	void MRenderWindow::Render(MContainer^ cam)
	{
		_pRenderWindow->Render(MWorld::GetInstance()->GetNative(), cam->GetNative());
		//DrawRectangle();
		//lineDrawer->MoveTo(Code3::Math3D::Vector2(0, 0));
		//lineDrawer->LineTo(Code3::Math3D::Vector2(200, 200));

		//Code3::Renderer::LineDrawer3D lineDrawer3(&link);

		//lineDrawer3.SetColor(Code3::Math3D::Color(1, 1, 1, 1));
		//lineDrawer3.MoveTo(Code3::Math3D::Vector2(0, 0));
		//lineDrawer3.LineTo(Code3::Math3D::Vector2(200, 200));

	}

	void MRenderWindow::SetRectangleStartPoint(float x, float y)
	{
		startX = x;
		startY = y;
	}
	void MRenderWindow::SetRectangleDeltaPoint(float x, float y)
	{
		deltaX = x;
		deltaY = y;
	}
	void MRenderWindow::DrawRectangle()
	{
		if (deltaY < startY)
		{
			/// 4-4분면
			if (deltaX < startX)
			{
				line1->MoveTo(startX, startY);
				line1->LineTo(startX, deltaY);
				line2->MoveTo(startX, deltaY);
				line2->LineTo(deltaX, deltaY);
				line3->MoveTo(deltaX, deltaY);
				line3->LineTo(deltaX, startY);
				line4->MoveTo(deltaX, startY);
				line4->LineTo(startX, startY);
			}
			/// 1-4분면
			else
			{
				line1->MoveTo(startX, startY);
				line1->LineTo(deltaX, startY);
				line2->MoveTo(deltaX, startY);
				line2->LineTo(deltaX, deltaY);
				line3->MoveTo(deltaX, deltaY);
				line3->LineTo(startX, deltaY);
				line4->MoveTo(startX, deltaY);
				line4->LineTo(startX, startY);
			}
		}
		else
		{
			/// 2-4분면
			if (deltaX > startX)
			{
				line1->MoveTo(startX, startY);
				line1->LineTo(startX, deltaY);
				line2->MoveTo(startX, deltaY);
				line2->LineTo(deltaX, deltaY);
				line3->MoveTo(deltaX, deltaY);
				line3->LineTo(deltaX, startY);
				line4->MoveTo(deltaX, startY);
				line4->LineTo(startX, startY);
			}
			/// 3-4분면
			else
			{
				line1->MoveTo(startX, startY);
				line1->LineTo(deltaX, startY);
				line2->MoveTo(deltaX, startY);
				line2->LineTo(deltaX, deltaY);
				line3->MoveTo(deltaX, deltaY);
				line3->LineTo(startX, deltaY);
				line4->MoveTo(startX, deltaY);
				line4->LineTo(startX, startY);
			}
		}
	}


	void MRenderWindow::Render(MWorld^ world, MContainer^ cam)
	{
		_pRenderWindow->Render(world->GetNative(), cam->GetNative());
	}
	void MRenderWindow::Resize(int width, int height)
	{
		Code3::Context::ContextObject().ThisContext->GetRenderDeviceDX()->ResizeWindow(_pRenderWindow, width, height);
	}
	int MRenderWindow::ScreenWidth::get()
	{
		return this->_pRenderWindow->Screen.Width;
	}
	int MRenderWindow::ScreenHeight::get()
	{
		return this->_pRenderWindow->Screen.Height;
	}
	Code3::Scene::GizmoHandler* MRenderWindow::GetGizmoHandler()
	{
		return _pRenderWindow->GizmoHandler;
	}

	void MRenderWindow::GizmoMouseClick(int x, int y, MCamera^ cam, int width, int height)
	{
		_pRenderWindow->GizmoMouseClick(x, y, cam->Cam->GetNative(), width, height);
	}

	void MRenderWindow::GizmoMouseMove(int x, int y, MCamera^ cam, int width, int height)
	{
		_pRenderWindow->GizmoMouseMove(x, y, cam->Cam->GetNative(), width, height);
		if (_pGizmo == NULL)
			_pGizmo = _pRenderWindow->Gizmo;
	}
	void MRenderWindow::GizmoMouseDrag(int x, int y, MCamera^ cam, int width, int height)
	{
		_pRenderWindow->GizmoMouseDrag(x, y, cam->Cam->GetNative(), width, height);
	}
	void MRenderWindow::GizmoMouseRelease()
	{
		_pRenderWindow->GizmoMouseRelease();
	}
	void MRenderWindow::DrawGizmo(MWorld^ world, MCamera^ cam)
	{
		_pRenderWindow->DrawGizmo(world->GetNative(), cam->GetNative());
	}
	bool MRenderWindow::GetGizmoSelection()
	{
		GizmoSelection selectVal = _pGizmo->GetGizmoSelection();
		if (selectVal == GSNone)
			return false;
		return true;
	}

	MContainer^ MRenderWindow::SelectPolygonPickObject(int pointX, int pointY,MCamera^ mCamera)
	{
		MContainer^ returnVal = nullptr;
		MWorld::GetInstance()->GetNative()->DeselectAll();

		Code3::Scene::Camera *camera = mCamera->Cam->GetNative();
		Code3::Scene::TransformGroup *transform = mCamera->Transform->GetNative();
		
		int width = _pRenderWindow->Screen.GetLogicalWidth();
		int Height = _pRenderWindow->Screen.GetLogicalHeight();
		Code3::Math3D::Vector3 org, dir;
		if (camera->GetPickRay(pointX, pointY, width, Height, 1000.0f, org, dir))
		{
			Code3::Component::Container *foundObject = NULL;
			Code3::Math3D::Vector3 collisionPos;
			float nearestDistance = FLT_MAX;

			bool r = SelectPolygonPickObjectSub(camera, MWorld::GetInstance()->GetNative(), org, dir, true, &collisionPos, &nearestDistance, &foundObject, true);
			if (r && foundObject)
			{
				returnVal = gcnew MContainer(foundObject);
				/*foundObject->SetSelect(true);
				Code3::Component::OnAnyPropertyInstanceSelectedChange(foundObject);*/
			}
		}
		return returnVal;
	}
	bool MRenderWindow::SelectPolygonPickObjectSub(Code3::Scene::Camera * camera, Code3::Component::Container* container, Code3::Math3D::Vector3 org, Code3::Math3D::Vector3 dir, bool leafOnly, Code3::Math3D::Vector3* collisionPos, float *collisionDistance, Code3::Component::Container **foundObject, bool checkPolygon)
	{
		Code3::Scene::TransformGroup* objTrans = container->GetReservedComponentCast<Code3::Scene::TransformGroup>(COMPONENT_TRANSFORMGROUP);
		float dist = 0;
		Code3::Math3D::Vector3 collision;
		Code3::Geometry::BoundingBox box;
		if (objTrans)
		{
			box = objTrans->GetSumBox();
			if (!box.FindNearCollision(org, org + dir, &collision, &dist))
				return false;
		}

		if (!container->IsLocked() && container->FindComponentByKindCast<Code3::Fbx::FbxNodeMesh>(Code3::Dictionary::FbxNodeMesh))
		{
			if (checkPolygon)
			{
				Code3::Fbx::FbxNodeMesh* mesh = container->FindComponentByKindCast<Code3::Fbx::FbxNodeMesh>(Code3::Dictionary::FbxNodeMesh);
				if (mesh)
				{
					mesh->UpdateSWSkinBuffers(true, camera);
					if (mesh->PolygonLineIntersection(org, dir, collisionPos))
					{
						Code3::Math3D::Vector3 distv = org - *collisionPos;
						float d = distv.LengthSq();
						*collisionDistance = d;
						*foundObject = container;
						return true;
					}
					else
						;
				}
			}
		}

		if ((!container->IsLocked())
			&& (container->FindComponentByKindCast<Code3::Scene::Light>(Code3::Dictionary::Light)
				|| container->FindComponentByKindCast<Code3::Scene::Camera>(Code3::Dictionary::Camera)
				|| container->FindComponentByKindCast<Code3::Scene::RigidMesh>(Code3::Dictionary::RigidMesh)
				//|| container->FindComponentByKindCast<Fbx::Fbx>(Dictionary::Fbx)
				//|| container->FindComponentByKindCast<Fbx::Fbx>(Dictionary::FbxNodeMesh)
				)
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
			Code3::Math3D::Vector3 nearCollisionPos;

			for (int i = 0; i < container->Children.GetSize(); i++)
			{
				Code3::Math3D::Vector3 subCollisionPos;
				float subDist;
				Code3::Component::Container *foundContainer = NULL;


				//if (SelectPickedObjectSub(container->Children[i], org, dir, leafOnly, &subCollisionPos, &subDist, &foundContainer, true)) // 161107 ljw
				if (SelectPolygonPickObjectSub(camera, container->Children[i], org, dir, leafOnly, &subCollisionPos, &subDist, &foundContainer, checkPolygon))
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
}
