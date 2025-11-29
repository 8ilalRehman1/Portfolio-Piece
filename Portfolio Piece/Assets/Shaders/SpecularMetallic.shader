Shader "SpecularMetallic"
{
    Properties
    {
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Color("Color", Color) = (1.0,1.0,1.0)
        _SpecColor("Spec Color", Color) = (1.0,1.0,1.0)
        _Shininess("Shininess", Float) = 10
    }
    SubShader
    {
        Pass{
            Tags {"LightMode" = "ForwardBase"}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // user defined variables
            uniform float4 _Color;
            uniform float4 _SpecColor;
            uniform float _Shininess;
            uniform float _Metallic;

            // unity defined variables
            uniform float4 _LightColor0;
            // structs
            struct vertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct vertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float4 normalDir : TEXCOORD1;
            };
            //vertex function
            vertexOutput vert(vertexInput v) {
                vertexOutput o;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.normalDir = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject));
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }
            float4 frag(vertexOutput i) : COLOR
            {
                // vectors
                float3 normalDirection = normalize(i.normalDir.xyz);
                float atten = 1.0;

                // lighting
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 diffuseReflection = atten * _LightColor0.xyz * max(0.0, dot(normalDirection, lightDirection));

                // specular direction
                float3 lightReflectDirection = reflect(-lightDirection, normalDirection);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 lightSeeDirection = max(0.0, dot(lightReflectDirection, viewDirection));
                float3 shininessPower = pow(lightSeeDirection, _Shininess);

                // Metallic workflow
                float3 baseColor = _Color.rgb;
                float3 specColor = lerp(_SpecColor.rgb, baseColor, _Metallic);   // metals tint specular by base color
                float3 diffuseColor = baseColor * (1.0 - _Metallic);             // metals lose diffuse

                float3 specularReflection = atten * specColor * shininessPower;
                float3 lightFinal = diffuseReflection * diffuseColor + specularReflection + UNITY_LIGHTMODEL_AMBIENT;

                return float4(lightFinal, 1.0);
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
