#pragma once
namespace MVRWrapper
{
	ref class MRenderWindow;
	public ref class MContext
	{
	public:
		MContext();
	public:
		static void InitializeSound(int hwnd);
	internal:
		static void RegisterWindow(MRenderWindow^ window);
		static void UnRegisterWindow(MRenderWindow^ window);
	};
}