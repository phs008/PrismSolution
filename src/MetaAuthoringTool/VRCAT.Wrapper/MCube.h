#pragma once
#ifdef  _INHERITANCE_PATTERN
#include "MTransformGroup.h"
#else
#include "MContainer.h"
#endif //  _
#include "MWorld.h"
namespace MVRWrapper
{
#ifdef _INHERITANCE_PATTERN
	public ref class MCube : MTransformGroup
	{
	public:
		MCube(MWorld^ world);
		void setMaterial(System::String^ matFile);
	};
#endif // DEBUG
	public ref class MCube : MContainer
	{
	public:
		MCube();
		MCube(MWorld^ world);
		void setMaterial(System::String^ matFile);
	};
}

