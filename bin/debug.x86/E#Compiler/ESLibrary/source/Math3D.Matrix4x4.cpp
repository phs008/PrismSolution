#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "Math3D.Matrix4x4.h"
#include <math.h>
#include <stdlib.h>

Matrix::Matrix()
{
}


Matrix::Matrix (EngineMath3D::Matrix  v)
{
	memcpy(m,  v.m, sizeof(m) );
}


const vector<string> Matrix::mFieldNames = {};
const vector<string> Matrix::mFieldTypes = {};
const vector<string> Matrix::mFieldAccessors = {};


const char* Matrix::__GetClassName__()
{
return "Matrix";}


unsigned int Matrix::__GetFieldNum__()
{
return 0;}


const char* Matrix::__GetFieldName__(unsigned int i)
{
if (i >= mFieldNames.size())	return nullptr;else							return mFieldNames[i].c_str();}


const char* Matrix::__GetFieldType__(unsigned int i)
{
if (i >= mFieldTypes.size())	return nullptr;else							return mFieldTypes[i].c_str();}


const char* Matrix::__GetFieldAccessor__(unsigned int i)
{
if (i >= mFieldAccessors.size())	return nullptr;else								return mFieldAccessors[i].c_str();}


int Matrix::__ReadField__(string fieldName, void* ptr, int* len)
{
return 0;}


int Matrix::__WriteField__(string fieldName, void* ptr, int len, int typeInfo)
{
void* buf = nullptr;

if (buf == nullptr)
{
return 1;
}

memcpy(buf, ptr, len);
return 0;
}
