#pragma  once
#include <Windows.h>
#include <BasicType/All.h>
#include <DataCollection/All.h>
#include <Context/Context.h>
#include <Component/All.h>
#include <RegisterRuntime.h>
#include <Renderer/DX/RenderWindowDX.h>
#include <Renderer/DX/RenderDeviceDX.h>
#include "MContext.h"
#include "MRenderWindow.h"
namespace MVRWrapper
{
	MContext::MContext()
	{
		if (Code3::Context::ContextObject().ThisContext == NULL)
		{
			Code3::Context::CreateNewContext();
			//Code3::Utility::GetFileTool().ProjectFolder.SetRelativePath(&Code3::Utility::GetFileTool().DocumentFolder, "frontline/default");
			Code3::Scene::RegisterRuntime();
			Code3::Context::ContextObject().ThisContext->GetRenderDevice()->StartDevice();
			if(Code3::Context::ContextObject().ThisContext->GetRenderDevice()->DeviceStarted)
				Code3::Context::ContextObject().ThisContext->LoadSharedResource();
			
		}
	}
	void MContext::RegisterWindow(MRenderWindow^ window)
	{
		Code3::Context::ContextObject().ThisContext->GetRenderDeviceDX()->RegisterWindow(window->GetNative());
	}
	void MContext::UnRegisterWindow(MRenderWindow^ window)
	{
		Code3::Context::ContextObject().ThisContext->GetRenderDeviceDX()->UnregisterWindow(window->GetNative());
	}
	void MContext::InitializeSound(int handle)
	{
		HWND hwnd = (HWND)handle;
		Code3::Context::ContextObject().ThisContext->InitializeSound(hwnd);
	}
}