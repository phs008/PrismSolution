#pragma once


class ScaleActor : public EActor
{
private:
    Container* T;
public:
    virtual int Update();
public:
    ScaleActor();
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
