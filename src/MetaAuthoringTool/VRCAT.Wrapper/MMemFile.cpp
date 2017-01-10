#include "MMemFile.h"
#include "MContainer.h"
#include <BasicType/UID.h>
namespace MVRWrapper
{
	MMemFile::MMemFile()
	{
		//MemFile f;
		_pMemFile = new MemFile();
	}
	void MMemFile::MContainerCopy(MContainer^ container)
	{
		Archive arc(_pMemFile);
		container->GetNative()->Save(&arc);
		_pMemFile->SeekToBegin();
	}
	MContainer^ MMemFile::MContainerPasty()
	{
		Archive arc(_pMemFile);
		arc.ShiftLoadUID = Code3::BasicType::NewUID();
		MContainer^ returnVal = gcnew MContainer();
		returnVal->GetNative()->Load(&arc);
		_pMemFile->SeekToBegin();
		returnVal->Selected(false);
		return returnVal;
	}
}
