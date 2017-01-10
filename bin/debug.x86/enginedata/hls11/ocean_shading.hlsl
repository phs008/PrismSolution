// Copyright (c) 2011 NVIDIA Corporation. All rights reserved.
//
// TO  THE MAXIMUM  EXTENT PERMITTED  BY APPLICABLE  LAW, THIS SOFTWARE  IS PROVIDED
// *AS IS*  AND NVIDIA AND  ITS SUPPLIERS DISCLAIM  ALL WARRANTIES,  EITHER  EXPRESS
// OR IMPLIED, INCLUDING, BUT NOT LIMITED  TO, NONINFRINGEMENT,IMPLIED WARRANTIES OF
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.  IN NO EVENT SHALL  NVIDIA 
// OR ITS SUPPLIERS BE  LIABLE  FOR  ANY  DIRECT, SPECIAL,  INCIDENTAL,  INDIRECT,  OR  
// CONSEQUENTIAL DAMAGES WHATSOEVER (INCLUDING, WITHOUT LIMITATION,  DAMAGES FOR LOSS 
// OF BUSINESS PROFITS, BUSINESS INTERRUPTION, LOSS OF BUSINESS INFORMATION, OR ANY 
// OTHER PECUNIARY LOSS) ARISING OUT OF THE  USE OF OR INABILITY  TO USE THIS SOFTWARE, 
// EVEN IF NVIDIA HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.
//
// Please direct any bugs or questions to SDKFeedback@nvidia.com

//-----------------------------------------------------------------------------
// Global variables
//-----------------------------------------------------------------------------

#define PATCH_BLEND_BEGIN		800
#define PATCH_BLEND_END			20000

// Shading parameters
cbuffer cbShading : register(b2)
{
	float3		g_WaterbodyColor;
	float		unused1;
	float3		g_BendParam;
	float		g_PerlinSize;
	float3		g_PerlinAmplitude;
	float		unused3;
	float3		g_PerlinOctave;
	float		unused4;
	float3		g_PerlinGradient;
	float		g_TexelLength_x2;
	float		g_UVScale;
	float		g_UVOffset;
};

// Per draw call constants
cbuffer cbChangePerCall : register(b4)
{
	// Transform matrices
	float4x4	g_matLocal;
	float4x4	g_matLocal3D;
	float4x4	g_matWorldViewProj;
	float4x4	g_matWorld;
	float4x4	g_matWorld3D;

	// Misc per draw call constants
	float2		g_UVBase;
	float2		g_PerlinMovement;
	float3		g_LocalEye;

	float		g_DrawPhase;
	float		g_Glossiness;
	float		g_Metalness;
}


//-----------------------------------------------------------------------------------
// Texture & Samplers
//-----------------------------------------------------------------------------------
Texture2D	g_texDisplacement	: register(t0); // FFT wave displacement map in VS
Texture2D	g_texPerlin			: register(t1); // FFT wave gradient map in PS
Texture2D	g_texGradient		: register(t2); // Perlin wave displacement & gradient map in both VS & PS

// FFT wave displacement map in VS, XY for choppy field, Z for height field
SamplerState g_samplerDisplacement	: register(s0);

// Perlin noise for composing distant waves, W for height field, XY for gradient
SamplerState g_samplerPerlin	: register(s1);

// FFT wave gradient map, converted to normal value in PS
SamplerState g_samplerGradient	: register(s2);


//-----------------------------------------------------------------------------
// Name: OceanSurfVS
// Type: Vertex shader                                      
// Desc: Ocean shading vertex shader. Check SDK document for more details
//-----------------------------------------------------------------------------
struct VS_OUTPUT
{
    float4 Position	 : SV_POSITION;
    float2 TexCoord	 : TEXCOORD0;
    float3 LocalPos	 : TEXCOORD1;
	float4 Position_World : POSITION1;

};
struct VertexIn
{
	// Per-vertex data
	float3 Position : POSITION;
	float3 Normal   : NORMAL;
	float2 TexCoord : TEXCOORD;
};

VS_OUTPUT OceanSurfVS(float2 vPos : POSITION)
{
	VS_OUTPUT Output;
	
	// Local position
	float4 pos_local = mul(float4(vPos, 0, 1), g_matLocal);
	
	// UV
	float2 uv_local = pos_local.xy * g_UVScale + g_UVOffset;
	
	// Blend displacement to avoid tiling artifact
	float3 eye_vec = pos_local.xyz - g_LocalEye;
	float dist_2d = length(eye_vec.xy);
	float blend_factor = (PATCH_BLEND_END - dist_2d) / (PATCH_BLEND_END - PATCH_BLEND_BEGIN);
	blend_factor = clamp(blend_factor, 0, 1);

	// Add perlin noise to distant patches
	float perlin = 0;
	if (blend_factor < 1)
	{
		float2 perlin_tc = uv_local * g_PerlinSize + g_UVBase;
		float perlin_0 = g_texPerlin.SampleLevel(g_samplerPerlin, perlin_tc * g_PerlinOctave.x + g_PerlinMovement, 0).w;
		float perlin_1 = g_texPerlin.SampleLevel(g_samplerPerlin, perlin_tc * g_PerlinOctave.y + g_PerlinMovement, 0).w;
		float perlin_2 = g_texPerlin.SampleLevel(g_samplerPerlin, perlin_tc * g_PerlinOctave.z + g_PerlinMovement, 0).w;
		
		perlin = perlin_0 * g_PerlinAmplitude.x + perlin_1 * g_PerlinAmplitude.y + perlin_2 * g_PerlinAmplitude.z;
	}

	// Displacement map
	float3 displacement = 0;
	if (blend_factor > 0)
		displacement = g_texDisplacement.SampleLevel(g_samplerDisplacement, uv_local, 0).xyz;
	displacement = lerp(float3(0, 0, perlin), displacement, blend_factor);
	pos_local.xyz += displacement;
	Output.Position = mul(pos_local, g_matWorldViewProj);

	// calculate 3d
	float4 pos_local3D = mul(float4(vPos.x, 0, vPos.y, 1), g_matLocal3D);
	float3 displacement3D = 0;
	if (blend_factor > 0)
		displacement3D = g_texDisplacement.SampleLevel(g_samplerDisplacement, uv_local, 0).xyz;
	displacement3D = float3(displacement3D.x, 0, displacement3D.y);
	displacement3D = lerp(float3(0, 0, perlin), displacement3D, blend_factor);
	pos_local3D.xyz += displacement3D;
	Output.Position_World = mul(float4(pos_local3D.x, pos_local3D.y, pos_local3D.z, 1), g_matWorld3D);

	Output.LocalPos = pos_local.xyz;
	Output.TexCoord = uv_local;
	return Output;
}


//-----------------------------------------------------------------------------
// Name: OceanSurfPS
// Type: Pixel shader                                      
// Desc: Ocean shading pixel shader. Check SDK document for more details
//-----------------------------------------------------------------------------

float2 packNormal(float3 n) {
	if (n.z == -1) {
		n.x += 0.001;
		n = normalize(n);
	}
	return normalize(n.xy) * sqrt(n.z * 0.5 + 0.5);
}

struct PsOut {
	float2 RT1 : SV_TARGET0;
	float4 RT2 : SV_TARGET1;
	float4 RT3 : SV_TARGET2;
};

float4 OceanSurfPS(VS_OUTPUT In) : SV_Target
{
	float3 body_color = g_WaterbodyColor;

	if (g_DrawPhase == 201)
	{
		//return float4(1, 1, 1, 1);
		return float4(body_color, g_Metalness);
	}

	if (g_DrawPhase == 103)
	{
		return In.Position_World;
	}

	// Calculate eye vector.
	float3 eye_vec = g_LocalEye - In.LocalPos;
	float3 eye_dir = normalize(eye_vec);
	
	// --------------- Blend perlin noise for reducing the tiling artifacts
	// Blend displacement to avoid tiling artifact
	float dist_2d = length(eye_vec.xy);
	float blend_factor = (PATCH_BLEND_END - dist_2d) / (PATCH_BLEND_END - PATCH_BLEND_BEGIN);
	blend_factor = clamp(blend_factor * blend_factor * blend_factor, 0, 1);

	// Compose perlin waves from three octaves
	float2 perlin_tc = In.TexCoord * g_PerlinSize + g_UVBase;
	float2 perlin_tc0 = (blend_factor < 1) ? perlin_tc * g_PerlinOctave.x + g_PerlinMovement : 0;
	float2 perlin_tc1 = (blend_factor < 1) ? perlin_tc * g_PerlinOctave.y + g_PerlinMovement : 0;
	float2 perlin_tc2 = (blend_factor < 1) ? perlin_tc * g_PerlinOctave.z + g_PerlinMovement : 0;

	float2 perlin_0 = g_texPerlin.Sample(g_samplerPerlin, perlin_tc0).xy;
	float2 perlin_1 = g_texPerlin.Sample(g_samplerPerlin, perlin_tc1).xy;
	float2 perlin_2 = g_texPerlin.Sample(g_samplerPerlin, perlin_tc2).xy;
	//
	float2 perlin = (perlin_0 * g_PerlinGradient.x + perlin_1 * g_PerlinGradient.y + perlin_2 * g_PerlinGradient.z);

	// Texcoord mash optimization: Texcoord of FFT wave is not required when blend_factor > 1
	float2 fft_tc = (blend_factor > 0) ? In.TexCoord : 0;
	//float2 fft_tc = float2(0, 0);
	float2 grad = g_texGradient.Sample(g_samplerGradient, fft_tc).xy;
	grad = lerp(perlin, grad, blend_factor);

	// Calculate normal here.
	//float3 normal = normalize(float3(0,1,0));
	float3 normal = normalize(float3(grad.x, g_TexelLength_x2 * 1, grad.y));
	normal = mul(g_matWorld3D, float4(normal, 0.0)).xyz;

	if (g_DrawPhase == 202)
	{
		return float4(normal, g_Glossiness);
	}
	
	return float4(1.0, 0.1, 0.1, 0.1);
}

//-----------------------------------------------------------------------------
// Name: WireframePS
// Type: Pixel shader                                      
// Desc:
//-----------------------------------------------------------------------------
float4 WireframePS() : SV_Target
{
	return float4(0.9f, 0.9f, 0.9f, 1);
}
