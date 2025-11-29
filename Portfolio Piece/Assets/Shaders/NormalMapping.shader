Shader "NormalMapping"
{
    Properties
    {
        _myDiffuse ("Diffuse Texture", 2D) = "white" {}
        _myNormal ("Normal Map", 2D) = "bump" {}
        _mySlider ("Normal Strength", Range(0,1)) = 1
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _myDiffuse;
        sampler2D _myNormal;
        half _mySlider;

        struct Input
        {
            float2 uv_myDiffuse;
            float2 uv_myNormal;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Diffuse color
            o.Albedo = tex2D(_myDiffuse, IN.uv_myDiffuse).rgb;

            // Proper normal map unpack
            float3 normalTex = UnpackNormal(tex2D(_myNormal, IN.uv_myNormal));

            // Blend between flat normal and texture normal for strength control
            o.Normal = normalize(lerp(float3(0,0,1), normalTex, _mySlider));
        }
        ENDCG
    }
    FallBack "Diffuse"
}