#include "common.fx"

VS_OUTPUT vertex_shader(float4 input_position : POSITION, 
                        float4 color : COLOR0,
                        float2 uv: TEXCOORD0) {
    VS_OUTPUT output;
    output.position = mul(input_position, object_to_proj_matrix);
    output.color = color;
    output.color_add = float4(1,1,1,1);
    output.uv = uv;
    prep_parallel(output);
    return output;
}

PS_OUTPUT pixel_shader(VS_OUTPUT input) {
    PS_OUTPUT output;

    float4 texture_color = sample_diffuse(input.uv);//tex2D(DiffuseTextureSampler, input.uv);

    output.color = input.color * texture_color;
//    output.color = float4(1, 1, 1, 1);
//    output.color = texture_color;

    return output;
}

technique render {
    pass P0 {
        VertexShader = compile vs_1_1 vertex_shader();
        PixelShader  = compile ps_2_0 pixel_shader();

        AlphaBlendEnable = True;
        SrcBlend = SrcAlpha;
        DestBlend = One;
        //AlphaTestEnable = True;

        CullMode = None;
        ZEnable = False;
        ZWriteEnable = False;
    }
}


