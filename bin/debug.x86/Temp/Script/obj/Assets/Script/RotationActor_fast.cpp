#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "RotationActor_fast.h"


int RotationActor_fast::Update()
{
    TransformGroup* trans = (TransformGroup*)T->FindComponentByType("TransformGroup");
    if ((trans!=nullptr))
    {
        Vector3* Pos;
        trans->Rotate(20, 0, trans->GetPosition());
        return 1;
    }
    else
    {
        return 0;
    }
}


RotationActor_fast::RotationActor_fast()
{
}


const vector<string> RotationActor_fast::mFieldNames = {"T"};
const vector<string> RotationActor_fast::mFieldTypes = {"Container"};
const vector<string> RotationActor_fast::mFieldAccessors = {"private"};


const char* RotationActor_fast::__GetClassName__()
{
    return "RotationActor_fast";
}


unsigned int RotationActor_fast::__GetFieldNum__()
{
    return 1;
}


const char* RotationActor_fast::__GetFieldName__(unsigned int i)
{
    if (i >= mFieldNames.size())	return nullptr;
    else							return mFieldNames[i].c_str();
}


const char* RotationActor_fast::__GetFieldType__(unsigned int i)
{
    if (i >= mFieldTypes.size())	return nullptr;
    else							return mFieldTypes[i].c_str();
}


const char* RotationActor_fast::__GetFieldAccessor__(unsigned int i)
{
    if (i >= mFieldAccessors.size())	return nullptr;
    else								return mFieldAccessors[i].c_str();
}


int RotationActor_fast::__ReadField__(string fieldName, void* ptr, int* len)
{
    if (fieldName == "T")
    {
        if (T)
        {
            memcpy(ptr, (void*)&T->id, sizeof(T->id));
            *len = sizeof(T->id);
            return 1;
        }
        else
        {
            return 0;
        }
    }

    return 0;
}


int RotationActor_fast::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
{
    void* buf = nullptr;

    if (fieldName == "T")
    {
        T = new Container(0);
        T->id = *((eng_obj_ptr*)ptr);
        return 0;
    }

    if (buf == nullptr)
    {
        return 1;
    }

    memcpy(buf, ptr, len);
    return 0;
}
