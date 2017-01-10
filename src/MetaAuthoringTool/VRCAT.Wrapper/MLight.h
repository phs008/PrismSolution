#pragma once
#include "MContainer.h"

namespace MVRWrapper
{
	ref class MWorld;
	public ref class MLight : MContainer
	{
	public:
		MLight();
		MLight(MWorld^ anotherWorld);
	};
}
