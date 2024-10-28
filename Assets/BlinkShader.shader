Shader "Unlit/BlinkShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _BlinkSpeed ("Blink Speed", Float) = 2.0
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 color : COLOR;
            };

            fixed4 _Color;
            float _BlinkSpeed;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float blink = abs(sin(_Time.y * _BlinkSpeed));
                fixed4 finalColor = _Color * blink;
                finalColor.a = blink;
                return finalColor;
            }
            ENDHLSL
        }
    }
    FallBack "Diffuse"
}