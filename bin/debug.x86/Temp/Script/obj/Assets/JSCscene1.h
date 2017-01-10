#pragma once


class JSCscene1 : public EActor
{
private:
    Container* temp;
public:
    virtual int OnMessage(string msg, int arg0, Vector4* arg1, Vector4* arg2);
public:
    virtual int Update();
public:
    JSCscene1();
public:
    virtual const char* __GetClassName__();
    virtual unsigned int __GetFieldNum__();
    virtual const char* __GetFieldName__(unsigned int i);
    virtual const char* __GetFieldType__(unsigned int i);
    virtual const char* __GetFieldAccessor__(unsigned int i);

    virtual int __ReadField__(string fieldName, void* ptr, int* len);
    virtual int __WriteField__(string fieldName, void* ptr, int len, int typeInfo);

private:
    static const	vector<string>	mFieldNames;
    static const	vector<string>	mFieldTypes;
    static const	vector<string>	mFieldAccessors;
};
