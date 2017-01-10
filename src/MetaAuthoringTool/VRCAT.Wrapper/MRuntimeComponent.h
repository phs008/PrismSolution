#pragma once
namespace MVRWrapper
{
	public ref class MRuntimeComponent
	{
	private:
		static MRuntimeComponent^ _Instance;
		System::Collections::Generic::List<System::String^>^ _ComponentList;
		MRuntimeComponent();
	public:
		static MRuntimeComponent^ GetInstance();
		property System::Collections::Generic::List<System::String^>^ ComponentList
		{
			System::Collections::Generic::List<System::String^>^ get();
		}
	};
}

