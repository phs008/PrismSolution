
#include "EngineMath.h"


#include "Math3D.Vector2.cpp"
#include "Math3D.Vector3.cpp"
#include "Math3D.Vector4.cpp"
#include "Math3D.BoundingBox.cpp"
#include "Math3D.Quaternion.cpp"
#include "Math3D.Matrix4x4.cpp"
#include "Math3D.Color.cpp"





namespace EngineMath3D
{


	Vector2::Vector2( ::Vector2 v )
	{
		x = v.x;
		y = v.y;
	}



	Vector3::Vector3( ::Vector3 v )
	{
		x = v.x;
		y = v.y;
		z = v.z;
	}




	Vector4::Vector4( ::Vector4 v )
	{
		x = v.x;
		y = v.y;
		z = v.z;
		w = v.w;
	}



	Quaternion::Quaternion( ::Quaternion v )
	{
		x = v.x;
		y = v.y;
		z = v.z;
		w = v.w;
	}



	Matrix::Matrix( ::Matrix v )
	{
		memcpy(m, v.m, sizeof(m));
	}






	Color::Color( ::Color v )
	{
		r = v.r;
		g = v.g;
		b = v.b;
		a = v.a;
	}

	
	BoundingBox::BoundingBox( ::BoundingBox v )
	{
		//memcpy(Vertex, v.Vertex, sizeof(Vertex));
	}



}


