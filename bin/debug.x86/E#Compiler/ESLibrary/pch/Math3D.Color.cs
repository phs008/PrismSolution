using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;



//------------------------------------------------------------
// Copyright. 2004-2015 Code3 Corp.  http://www.code3.co.kr
// 
// Author : Heechan Park
// Summary : 
// 
//------------------------------------------------------------ 



	public class Color
	{

		public float r;
		public float g;
		public float b;
		public float a;

		static public Color Zero() { return new Color(0, 0, 0, 0); }

		public Color()
		{
		}

		//public Color(float [] pf)
		//{
		//	if(pf == null)  
		//		return;

		//	r = pf[0];
		//	g = pf[1];
		//	b = pf[2];
		//	a = pf[3];
		//}

		public Color(uint col)
		{
			float f = 1.0f / 255.0f;
			r = f * (float)(uint)(col >> 16);
			g = f * (float)(uint)(col >>  8);
			b = f * (float)(uint)col;
			a = f * (float)(uint)(col >> 24);
		}

		public Color(float fr, float fg, float fb, float fa)
		{
			r = fr;
			g = fg;
			b = fb;
			a = fa;
		}

		//public Color(Vector4 v)
		//{
		//	r = v.x;
		//	g = v.y;
		//	g = v.z;
		//	a = v.w;
		//}

		//public Color(Vector3 v)
		//{
		//	r = v.x;
		//	g = v.y;
		//	g = v.z;
		//	a = 1.0f;
		//}

		public uint MakeInt()
		{
			//uint _r = r >= 1.0f ? 0xff : r <= 0.0f ? 0x00 : (uint)(r * 255.0f + 0.5f);
			//uint _g = g >= 1.0f ? 0xff : g <= 0.0f ? 0x00 : (uint)(g * 255.0f + 0.5f);
			//uint _b = b >= 1.0f ? 0xff : b <= 0.0f ? 0x00 : (uint)(b * 255.0f + 0.5f);
			//uint _a = a >= 1.0f ? 0xff : a <= 0.0f ? 0x00 : (uint)(a * 255.0f + 0.5f);

			//return (_a << 24) | (_r << 16) | (_g << 8) | _b;
		}


		static public Color operator +(Color v)
		{
			return v;
		}

		static public Color operator -(Color v)
		{
			return new Color(-v.r, -v.g, -v.b, -v.a);
		}

		static public Color operator + (Color v0, Color v)
		{
			return new Color(v0.r + v.r, v0.g + v.g, v0.b + v.b, v0.a + v.a);
		}

		static public Color operator -(Color v0, Color v)
		{
			return new Color(v0.r - v.r, v0.g - v.g, v0.b - v.b, v0.a - v.a);
		}

		static public Color operator * (Color v, float f)
		{
			return new Color(v.r * f, v.g * f, v.b * f, v.a * f);
		}

		static public Color operator / (Color v, float f)
		{
			return new Color(v.r / f, v.g / f, v.b / f, v.a / f);
		}

		static public Color operator *(float f, Color v)
		{
			return new Color(f * v.r, f * v.g, f * v.b, f * v.a);
		}

		static public bool operator == (Color v, Color v1)
		{
			return v1.r == v.r && v1.g == v.g && v1.b == v.b && v1.a == v.a;
		}

		static public bool operator !=(Color v, Color v1)
		{
			return v1.r != v.r || v1.g != v.g || v1.b != v.b || v1.a != v.a;
		}





		static public Color Scale(Color pv, float s)
		{
			Color result = new Color();
			result.r = s * (pv.r);
			result.g = s * (pv.g);
			result.b = s * (pv.b);
			result.a = s * (pv.a);
			return result;
		}

		public void Scale(float s)
		{
			r = s * r;
			g = s * g;
			b = s * b;
			a = s * a;
		}

		static public Color Subtract(Color pv1, Color pv2)
		{
			Color result = new Color();
			result.r = pv1.r - pv2.r;
			result.g = pv1.g - pv2.g;
			result.b = pv1.b - pv2.b;
			result.a = pv1.a - pv2.a;
			return result;
		}

		public void Subtract(Color pv2)
		{
			r = r - pv2.r;
			g = g - pv2.g;
			b = b - pv2.b;
			a = a - pv2.a;
		}



		static public Color AdjustContrast(Color pc, float s)
		{
			Color result = new Color();
			result.r = 0.5f + s * (pc.r - 0.5f);
			result.g = 0.5f + s * (pc.g - 0.5f);
			result.b = 0.5f + s * (pc.b - 0.5f);
			result.a = pc.a;
			return result;
		}


		public void AdjustContrast(float s)
		{
			r = 0.5f + s * (r - 0.5f);
			g = 0.5f + s * (g - 0.5f);
			b = 0.5f + s * (b - 0.5f);
		}



		static public Color AdjustSaturation(Color pc, float s)
		{
			Color result = new Color();
			float grey;

			grey = pc.r * 0.2125f + pc.g * 0.7154f + pc.b * 0.0721f;
			result.r = grey + s * (pc.r - grey);
			result.g = grey + s * (pc.g - grey);
			result.b = grey + s * (pc.b - grey);
			result.a = pc.a;
			return result;
		}


		public void AdjustSaturation(float s)
		{
			Color result = AdjustSaturation(this, s);
			r = result.r;
			g = result.g;
			b = result.b;
			a = result.a;
		}

		static public Color Lerp(Color pv1, Color pv2, float s)
		{
			Color result = new Color();
			result.r = (1 - s) * (pv1.r) + s * (pv2.r);
			result.g = (1 - s) * (pv1.g) + s * (pv2.g);
			result.b = (1 - s) * (pv1.b) + s * (pv2.b);
			result.a = (1 - s) * (pv1.a) + s * (pv2.a);
			return result;
		}




		static public Color Modulate(Color pc1, Color pc2 )
		{
			Color result = new Color();
			result.r = (pc1.r) * (pc2.r);
			result.g = (pc1.g) * (pc2.g);
			result.b = (pc1.b) * (pc2.b);
			result.a = (pc1.a) * (pc2.a);
			return result;
		}


		public Color Negative()
		{
			Color result = new Color();
			result.r = 1.0f - r;
			result.g = 1.0f - g;
			result.b = 1.0f - b;
			result.a = a;
			return result;
		}
}




/*
 * 

#define NXCOLOR_ARGB(a,r,g,b) \
    ((NXCOLOR)((((a)&0xff)<<24)|(((r)&0xff)<<16)|(((g)&0xff)<<8)|((b)&0xff)))

#define NXCOLOR_RGBA(r,g,b,a) NXCOLOR_ARGB(a,r,g,b)
#define NXCOLOR_XRGB(r,g,b)   NXCOLOR_ARGB(0xff,r,g,b)

#define NXCOLOR_XYUV(y,u,v)   NXCOLOR_ARGB(0xff,y,u,v)
#define NXCOLOR_AYUV(a,y,u,v) NXCOLOR_ARGB(a,y,u,v)

// maps floating point channels (0.f to 1.f range) to NXCOLOR
#define NXCOLOR_COLORVALUE(r,g,b,a) \
    NXCOLOR_RGBA((uint)((r)*255.f),(uint)((g)*255.f),(uint)((b)*255.f),(uint)((a)*255.f))


#define COLORREF_TO_RGBA(r)  RGB(GetBValue(r), GetGValue(r), GetRValue(r))
#define RGBA_TO_COLORREF(r)  RGB(GetBValue(r), GetGValue(r), GetRValue(r))


#define COLORREF_TO_Vector3(rgb) Vector3( GetRValue(rgb)/255.0f, GetGValue(rgb)/255.0f, GetBValue(rgb)/255.0f )
#define COLORREF_TO_NXCOLOR(rgb) NXCOLOR( GetRValue(rgb)/255.0f, GetGValue(rgb)/255.0f, GetBValue(rgb)/255.0f, 1.0f )
#define NXCOLOR_TO_COLORREF(c) RGB( (c.r)*255.f, (c.g)*255.f, (c.b)*255.f);

#define NXCOLOR_TO_Vector4(rgb) Vector4( rgb.r, rgb.g, rgb.b, rgb.a )


*/


