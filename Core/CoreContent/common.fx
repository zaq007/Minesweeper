struct VS_OUTPUT {
    float4 position   : POSITION;
    float4 color      : COLOR0;
    float4 color_add  : COLOR1;
    float2 uv         : TEXCOORD0;
#ifdef PARALLEL_UNIVERSE
    float2 fx1        : TEXCOORD1;
    float2 fx2        : TEXCOORD2;
#endif
};

float4x4 object_to_proj_matrix;
//float4 global_color_scale;
float4 global_color_add;
#ifdef MRT_REWIND
float4 rewindable_alpha;
#endif

texture diffuse_texture;

sampler DiffuseTextureSampler = 
sampler_state {
    Texture = <diffuse_texture>;    
    MipFilter = NONE;
    MinFilter = LINEAR;
    MagFilter = LINEAR;
    AddressU = Wrap;
    AddressV = Wrap;
};

sampler DiffuseTextureSamplerPointFiltered = 
sampler_state {
    Texture = <diffuse_texture>;    
    MipFilter = NONE;
    MinFilter = POINT;
    MagFilter = POINT;
    AddressU = Wrap;
    AddressV = Wrap;
};

#ifdef PARALLEL_UNIVERSE
texture parallel_texture;

sampler ParallelTextureSampler = 
sampler_state {
    Texture = <parallel_texture>;    
    MipFilter = NONE;
    MinFilter = LINEAR;
    MagFilter = LINEAR;
    AddressU = Wrap;
    AddressV = Wrap;
};

float4 fade_out;
float4 apply_parallel(float4 color, VS_OUTPUT v)
{
    float4 tex1 = tex2D(ParallelTextureSampler, v.fx1);
    float4 tex2 = tex2D(ParallelTextureSampler, v.fx2);
    color.rgb += tex1*tex2/2 * fade_out;
    //color.rgb += (tex1+tex2)/4;
    return color;
}

float aspect = 720.0/1280.0;
float4 phase_scroll;

#define PARALLEL_SPACING  16.0
#define prep_parallel(v) \
    v.fx1 = (v.position.xy * float2(1,aspect)*PARALLEL_SPACING) - phase_scroll.xy; \
    v.fx2 = (v.position.xy * float2(1,aspect)*PARALLEL_SPACING) - phase_scroll.zw
    // note that the exact value of this constant must be propogated
    // into the source code, apply_shader_fx_really()

#else

#define prep_parallel(x)
#define apply_parallel(x,y)  (x)

#endif

#ifdef YCBCR
texture cbcr_texture;

sampler CbCrTextureSampler = 
sampler_state {
    Texture = <cbcr_texture>;    
    MipFilter = NONE;
    MinFilter = LINEAR;
    MagFilter = LINEAR;
    AddressU = Wrap;
    AddressV = Wrap;
};

sampler CbCrTextureSamplerPointFiltered = 
sampler_state {
    Texture = <cbcr_texture>;    
    MipFilter = NONE;
    MinFilter = POINT;
    MagFilter = POINT;
    AddressU = Wrap;
    AddressV = Wrap;
};

#ifdef PARALLEL_UNIVERSE
float4 sample_diffuse(float2 coord)
{
    //    float4 raw = tex2D(DiffuseTextureSampler, coord);

    float a = tex2D(DiffuseTextureSampler, coord).a;

    #ifdef SEPARATE_ALPHA
    a = tex2D(AlphaTextureSampler, coord);
    #endif

    float k = 0.3f;
    float4 result = { k, k, k, a };

    return result;
}

float4 sample_diffuse_point_filtered(float2 coord) {
    return sample_diffuse(coord);
}


#else  // !PARALLEL_UNIVERSE

float4 sample_diffuse_helper(float2 coord, sampler diffuse_sampler, sampler cbcr_sampler)
{
    float4 raw = tex2D(DiffuseTextureSampler, coord);
    float4 crcb = tex2D(CbCrTextureSampler, coord);
    float4 result = { raw.r, raw.r, raw.r, raw.a };
    float3 cr_scale = { 1.40200, -0.71414, 0 };
    float3 cb_scale = { 0, -0.34414, 1.772 };
    //crcb.r = 0.5;//crcb.r*0.5+0.25;
    //crcb.a = 1;//crcb.a*0.5+0.25;
    crcb.r -= 0.5;
    crcb.a -= 0.5;
    result.rgb += cb_scale * crcb.r;
    result.rgb += cr_scale * crcb.a;
    #ifdef SEPARATE_ALPHA
    result.a = tex2D(AlphaTextureSampler, coord);
    #endif

    return clamp(result,0,1);
}

float4 sample_diffuse(float2 coord)
{
    return sample_diffuse_helper(coord, DiffuseTextureSampler, CbCrTextureSampler);
}

float4 sample_diffuse_point_filtered(float2 coord)
{
    return sample_diffuse_helper(coord, DiffuseTextureSamplerPointFiltered, CbCrTextureSamplerPointFiltered);
}
#endif // !PARALLEL_UNIVERSE
#else

#ifdef PARALLEL_UNIVERSE
//
// @HACK: Because we know the characters are all RGB textures, we actually
// make the RGB parallel universe version of sample_diffuse have some color
// in it (because the desired effect is just flat gray for everything
// except characters).  Possibly this should be done by replacing the
// character shader instead.  This will break if we ever change the
// character bitmaps *or* try to run in RGB mode again (Which is a distinct
// possibility for the PC version.)
//
float4 sample_diffuse(float2 coord)
{
    float4 to_y = { 0.257, 0.504, 0.098, 0 };
    float4 tex = tex2D(DiffuseTextureSampler, coord);

    float y = to_y * tex + (16.0 / 255.0);
    clamp(y, 0, 1);

    float4 result;
    result.rgb = float3(y, y, y);
    result.a = tex.a;

    result.rgb = lerp(result.rgb, tex.rgb, 0.3f);  // Add some color.
    return result;
}

float4 sample_diffuse_point_filtered(float2 coord) {
    return sample_diffuse(coord);
}
#else
float4 sample_diffuse(float2 coord)
{
	return tex2D(DiffuseTextureSampler, coord);
}

float4 sample_diffuse_point_filtered(float2 coord)
{
	return tex2D(DiffuseTextureSamplerPointFiltered, coord);
}
#endif // PARALLEL_UNIVERSE
#endif // YCBCR

struct PS_OUTPUT {
    float4 color : COLOR0;  // Pixel color    
#ifdef MRT_REWIND
    float4 color2 : COLOR1;  // Rewindability -- @TODO should be float1 ?
#endif
};


