#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "JSCscene1.h"


int JSCscene1::OnMessage(string msg, int arg0, Vector4* arg1, Vector4* arg2)
{
    if ((msg=="LButtonDown"))
    {
        ScriptComponent* cubeAscript = (ScriptComponent*)temp->FindComponentByType("ScriptComponent");
        if ((cubeAscript!=nullptr))
        {
            cubeAscript->TimedMessage("MoveCubeMan", 1.0f, 0, new Vector4(0.0, 0.0, 0.0, 0.0), new Vector4(0.0, 0.0, 0.0, 0.0));
        }
    }
    return 0;
}


int JSCscene1::Update()
{
    return 0;
}


JSCscene1::JSCscene1()
{
}


const vector<string> JSCscene1::mFieldNames = {"temp"};
const vector<string> JSCscene1::mFieldTypes = {"Container"};
const vector<string> JSCscene1::mFieldAccessors = {"private"};


const char* JSCscene1::__GetClassName__()
{
    return "JSCscene1";
}


unsigned int JSCscene1::__GetFieldNum__()
{
    return 1;
}


const char* JSCscene1::__GetFieldName__(unsigned int i)
{
    if (i >= mFieldNames.size())	return nullptr;
    else							return mFieldNames[i].c_str();
}


const char* JSCscene1::__GetFieldType__(unsigned int i)
{
    if (i >= mFieldTypes.size())	return nullptr;
    else							return mFieldTypes[i].c_str();
}


const char* JSCscene1::__GetFieldAccessor__(unsigned int i)
{
    if (i >= mFieldAccessors.size())	return nullptr;
    else								return mFieldAccessors[i].c_str();
}


int JSCscene1::__ReadField__(string fieldName, void* ptr, int* len)
{
    string arrayFieldName = "";
    int arrayIndex = 0;
    SeparateArrayFieldName(fieldName, arrayFieldName, arrayIndex);

    if (fieldName == "temp")
    {
        if (temp)
        {
            memcpy(ptr, (void*)&temp->id, sizeof(temp->id));
            *len = sizeof(temp->id);
            return 1;
        }
        else
        {
            return 0;
        }
    }

    return 0;
}


int JSCscene1::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
{
    void* buf = nullptr;

    string arrayFieldName = "";
    int arrayIndex = 0;
    SeparateArrayFieldName(fieldName, arrayFieldName, arrayIndex);

    if (fieldName == "temp")
    {
        temp = new Container(0);
        temp->id = *((eng_obj_ptr*)ptr);
        return 0;
    }

    if (buf == nullptr)
    {
        return 1;
    }

    memcpy(buf, ptr, len);
    return 0;
}