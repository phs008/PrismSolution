#pragma once



class Vector2;
class Vector3;
class Vector4;
class Quaternion;
class Color;
class BoundingBox;

class Matrix;

namespace EngineMath3D
{

	struct Vector2 {
		float x;
		float y;
		Vector2( ) { } 
		Vector2( ::Vector2 v );
	};

	struct Vector3 {
		float x;
		float y;
		float z;
		Vector3( ) { } 
		Vector3( ::Vector3 v );
	};

	struct Vector4 {
		float x;
		float y;
		float z;
		float w;
		Vector4( ) { } 
		Vector4( ::Vector4 v );
  
	};


	struct Quaternion {
		float x;
		float y;
		float z;
		float w;

		Quaternion() { }
		Quaternion( ::Quaternion v );

	};


	struct BoundingBox 
	{
		Vector3 Vertex[2];

		BoundingBox() { }

		BoundingBox( ::BoundingBox v);

	};


	struct Matrix 
	{
		float m[4][4];

		Matrix () { }
		Matrix (::Matrix v);
	};


	struct Color 
	{
		float r;
		float g;
		float b;
		float a;

		Color() { } 
		Color( ::Color v );
		
	};


}







#include "Math3D.Vector2.h"
#include "Math3D.Vector3.h"
#include "Math3D.Vector4.h"
#include "Math3D.Quaternion.h"
#include "Math3D.Color.h"
#include "Math3D.Matrix4x4.h"
#include "Math3D.BoundingBox.h"





