#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "ScaleActor.h"


int ScaleActor::Update()
{
    TransformGroup* trans = (TransformGroup*)T->FindComponentByType("TransformGroup");
    if ((trans!=nullptr))
    {
        Vector3* scaleV;
        scaleV = trans->GetScale();
        if ((scaleV->x<10))
        {
            scaleV->x = 0;
            scaleV->y = 0;
            scaleV->z = 0;
        }
        scaleV->x += 0.05;
        scaleV->y += 0.05;
        scaleV->z += 0.05;
        trans->SetScale(scaleV);
        return 1;
    }
    else
    {
        return 0;
    }
}


ScaleActor::ScaleActor()
{
}


const vector<string> ScaleActor::mFieldNames = {"T"};
const vector<string> ScaleActor::mFieldTypes = {"Container"};
const vector<string> ScaleActor::mFieldAccessors = {"private"};


const char* ScaleActor::__GetClassName__()
{
    return "ScaleActor";
}


unsigned int ScaleActor::__GetFieldNum__()
{
    return 1;
}


const char* ScaleActor::__GetFieldName__(unsigned int i)
{
    if (i >= mFieldNames.size())	return nullptr;
    else							return mFieldNames[i].c_str();
}


const char* ScaleActor::__GetFieldType__(unsigned int i)
{
    if (i >= mFieldTypes.size())	return nullptr;
    else							return mFieldTypes[i].c_str();
}


const char* ScaleActor::__GetFieldAccessor__(unsigned int i)
{
    if (i >= mFieldAccessors.size())	return nullptr;
    else								return mFieldAccessors[i].c_str();
}


int ScaleActor::__ReadField__(string fieldName, void* ptr, int* len)
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


int ScaleActor::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
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