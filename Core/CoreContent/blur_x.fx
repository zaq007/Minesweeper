// NO_VARIATIONS  <= this is a hint to the FX compiler, don't delete it

#include "blur.fx"

struct VS_OUTPUT {
    float4 position   : POSITION;
    float2 uv         : TEXCOORD0;
};

float4x4 object_to_proj_matrix;

texture diffuse_texture;

// main screen data
sampler DiffuseTextureSampler = 
sampler_state {
    Texture = <diffuse_texture>;    
    MipFilter = NONE;
    MinFilter = LINEAR;
    MagFilter = LINEAR;
    AddressU = Clamp;
    AddressV = Clamp;
};

float4 texel_size;

struct PS_OUTPUT {
    float4 color : COLOR0;  // Pixel color    
};

VS_OUTPUT vertex_shader(float4 input_position : POSITION, 
                        float2 uv: TEXCOORD0,
                        float2 uv2: TEXCOORD1,
                        float2 uv3: TEXCOORD2) {
    VS_OUTPUT output;
    output.position = mul(input_position, object_to_proj_matrix);
    output.uv = uv;
    return output;
}

PS_OUTPUT pixel_shader(VS_OUTPUT input)
{
	PS_OUTPUT output;
	float2 x_off = { texel_size.x, 0 };
	float2 tc = input.uv;
	float sum=0;

	//x_off.x = 1.0/1280;
	
	sum += tex2D(DiffuseTextureSampler, tc + x_off * B_P0).r * B_W0;
	sum += tex2D(DiffuseTextureSampler, tc + x_off * B_P1).r * B_W1;
	sum += tex2D(DiffuseTextureSampler, tc + x_off * B_P2).r * B_W2;
	sum += tex2D(DiffuseTextureSampler, tc + x_off * B_P3).r * B_W3;
 	sum += tex2D(DiffuseTextureSampler, tc + x_off * B_P4).r * B_W4;
 	sum += tex2D(DiffuseTextureSampler, tc + x_off * B_P5).r * B_W5;
 	sum += tex2D(DiffuseTextureSampler, tc + x_off * B_P6).r * B_W6;
 	sum += tex2D(DiffuseTextureSampler, tc + x_off * B_P7).r * B_W7;

	output.color.rg = sum;
	output.color.ba = 0;
    return output;
}

technique render {
    pass P0 {
        VertexShader = compile vs_2_0 vertex_shader();
        PixelShader  = compile ps_2_0 pixel_shader();

        AlphaBlendEnable = False;
        //AlphaTestEnable = False;

        CullMode = CW;  // allow mesh to invert and see what that looks like... answer: lame
        ZEnable = False;
        ZWriteEnable = False;
    }
}
