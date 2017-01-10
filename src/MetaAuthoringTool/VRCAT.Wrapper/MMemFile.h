#pragma once
#include <FileIO/MemFile.h>
#include <FileIO/Archive.h>
using namespace Code3::FileIO;
namespace MVRWrapper
{
	ref class MContainer;
	public ref class MMemFile
	{
	private:
		MemFile* _pMemFile;
	private:
		static MMemFile^ _this;
	public:
		MMemFile();
	public:
		static MMemFile^ GetInstance()
		{
			if (_this == nullptr)
				_this = gcnew MMemFile();
			return _this;
		}
		void MContainerCopy(MContainer^ container);
		MContainer^ MContainerPasty();
	};
}

