#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "RotationActor.h"


int RotationActor::Update()
{
    TransformGroup* trans = (TransformGroup*)T->FindComponentByType("TransformGroup");
    if ((trans!=nullptr))
    {
        Vector3* Pos;
        trans->Rotate(5, 0, trans->GetPosition());
        return 1;
    }
    else
    {
        return 0;
    }
}


RotationActor::RotationActor()
{
}


const vector<string> RotationActor::mFieldNames = {"T", "a", "j"};
const vector<string> RotationActor::mFieldTypes = {"Container", "int", "int"};
const vector<string> RotationActor::mFieldAccessors = {"private", "private", "private"};


const char* RotationActor::__GetClassName__()
{
    return "RotationActor";
}


unsigned int RotationActor::__GetFieldNum__()
{
    return 3;
}


const char* RotationActor::__GetFieldName__(unsigned int i)
{
    if (i >= mFieldNames.size())	return nullptr;
    else							return mFieldNames[i].c_str();
}


const char* RotationActor::__GetFieldType__(unsigned int i)
{
    if (i >= mFieldTypes.size())	return nullptr;
    else							return mFieldTypes[i].c_str();
}


const char* RotationActor::__GetFieldAccessor__(unsigned int i)
{
    if (i >= mFieldAccessors.size())	return nullptr;
    else								return mFieldAccessors[i].c_str();
}


int RotationActor::__ReadField__(string fieldName, void* ptr, int* len)
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

    if (fieldName == "a")
    {
        memcpy(ptr, (void*)&a, sizeof(a));
        *len = sizeof(a);
    }

    if (fieldName == "j")
    {
        memcpy(ptr, (void*)&j, sizeof(j));
        *len = sizeof(j);
    }

    return 0;
}


int RotationActor::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
{
    void* buf = nullptr;

    if (fieldName == "T")
    {
        T = new Container(0);
        T->id = *((eng_obj_ptr*)ptr);
        return 0;
    }

    if (fieldName == "a")
    {
        buf = &a;
    }

    if (fieldName == "j")
    {
        buf = &j;
    }

    if (buf == nullptr)
    {
        return 1;
    }

    memcpy(buf, ptr, len);
    return 0;
}
