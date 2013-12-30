#include "common.fx"

VS_OUTPUT vertex_shader(float4 input_position : POSITION, 
                        float4 color : COLOR0,
                        float2 uv: TEXCOORD0) {
    VS_OUTPUT output;
    output.position = mul(input_position, object_to_proj_matrix);
    output.color = color;
	float4 color_add = {100, 100, 100, 0.5};
    output.color_add = color_add;
    output.uv = uv;
    prep_parallel(output);
    return output;
}

float4 glow_strength;

PS_OUTPUT pixel_shader(VS_OUTPUT input) {
    PS_OUTPUT output;

    float4 texture_color = sample_diffuse(input.uv);//tex2D(DiffuseTextureSampler, input.uv);
    float4 color = input.color * texture_color + input.color_add;

#ifdef FAST_OUTLINE_SAMPLE
    float edge = texture_color.a;
    // remap 0..0.5..1 to 0..1..0
    edge = 1 - 2*abs(edge - 0.5);
#else
    float2 off = { 1.0/700, 1.0/700 }; // @TODO need to know how big the texture is
    float2 p1 = { input.uv.x + off.x, input.uv.y + off.y };
    float2 p2 = { input.uv.x + off.x, input.uv.y - off.y };
    float2 p3 = { input.uv.x - off.x, input.uv.y + off.y };
    float2 p4 = { input.uv.x - off.x, input.uv.y - off.y };
    float s1 = tex2D(DiffuseTextureSampler, p1).a;
    float s2 = tex2D(DiffuseTextureSampler, p2).a;
    float s3 = tex2D(DiffuseTextureSampler, p3).a;
    float s4 = tex2D(DiffuseTextureSampler, p4).a;
    float edge = (abs(s1 - s4) + abs(s2 - s3))/3;
#endif
    edge *= glow_strength.x;

    // need to premultiply to blend these together nicely
    color.rgb = lerp(0, color, color.a);
    float4 outline = { 1,1,1,1 };
    output.color = lerp(color, outline, edge);

    return output;
}

technique render {
    pass P0 {
        VertexShader = compile vs_1_1 vertex_shader();
        PixelShader  = compile ps_2_0 pixel_shader();

        AlphaBlendEnable = True;
        SrcBlend = One;
        DestBlend = InvSrcAlpha;
       // AlphaTestEnable = True;

        CullMode = None;
        ZEnable = False;
        ZWriteEnable = False;
    }
}


