#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "Math3D.BoundingBox.h"
#include <math.h>
#include <stdlib.h>

BoundingBox::BoundingBox()
{
}


BoundingBox::BoundingBox (EngineMath3D::BoundingBox  v)
{
}


const vector<string> BoundingBox::mFieldNames = {};
const vector<string> BoundingBox::mFieldTypes = {};
const vector<string> BoundingBox::mFieldAccessors = {};


const char* BoundingBox::__GetClassName__()
{
return "BoundingBox";}


unsigned int BoundingBox::__GetFieldNum__()
{
return 0;}


const char* BoundingBox::__GetFieldName__(unsigned int i)
{
if (i >= mFieldNames.size())	return nullptr;else							return mFieldNames[i].c_str();}


const char* BoundingBox::__GetFieldType__(unsigned int i)
{
if (i >= mFieldTypes.size())	return nullptr;else							return mFieldTypes[i].c_str();}


const char* BoundingBox::__GetFieldAccessor__(unsigned int i)
{
if (i >= mFieldAccessors.size())	return nullptr;else								return mFieldAccessors[i].c_str();}


int BoundingBox::__ReadField__(string fieldName, void* ptr, int* len)
{
return 0;}


int BoundingBox::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
{
void* buf = nullptr;

if (buf == nullptr)
{
return 1;
}

memcpy(buf, ptr, len);
return 0;
}
