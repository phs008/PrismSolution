#pragma once
#ifdef _INHERITANCE_PATTERN
#include "MTransformGroup.h"
#else
#include "MContainer.h"
#endif // _INHERITANCE_PATTERN
#include "MWorld.h"
#include <Object\Fbx\All.h>
namespace MVRWrapper
{
	ref class MFbxComponent;
	public ref class MFbx : MContainer
	{
	private:
		MFbxComponent^ _Fbx = nullptr;
	public:
		MFbx();
		MFbx(System::String^ FFBXPath);
		MFbx(System::String^ FFBXPath, MContainer^ parentContainer);
		property MFbxComponent^ FbxComponent
		{
			MFbxComponent^ get();
			void set(MFbxComponent^ param);
		}
		void SetFBX(System::String^ FFBXPath);
		static bool ImportFBXSource(System::String^ FbxPath);
	};
}

