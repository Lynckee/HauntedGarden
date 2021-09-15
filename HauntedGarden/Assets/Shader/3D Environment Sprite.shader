Shader "Sprites/3D Environment Sprite" {
    Properties{
        _MainCol("Main Tint", Color) = (1,1,1,1)
        _MainTex("Main Texture", 2D) = "white" {}
        _DetailCol("Detail Tint", Color) = (1,1,1,1)
        _DetailTex("Detail Texture", 2D) = "white" {}
        _Cutoff("Alpha cutoff", Range(0,1)) = 0.5
    }

        SubShader{
            Tags {"Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" "PreviewType" = "Plane"}
            Cull Off
            LOD 200

            CGPROGRAM
            #pragma surface surf SimpleLambert alphatest:_Cutoff addshadow fullforwardshadows
            #pragma target 3.0

            sampler2D _MainTex;
            fixed4 _MainCol;
            sampler2D _DetailTex;
            fixed4 _DetailCol;

            half4 LightingSimpleLambert(SurfaceOutput s, half3 lightDir, half atten) {
                      half4 c;
                      c.rgb = s.Albedo * _MainCol.rgb * (atten)*_LightColor0.rgb;
                      c.a = s.Alpha;
                      return c;
                  }

            struct Input {
                float2 uv_MainTex;
                float2 uv_DetailTex;
            };

            void surf(Input IN, inout SurfaceOutput o) {
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _MainCol;
                fixed4 d = tex2D(_DetailTex, IN.uv_DetailTex) * _DetailCol;
                o.Albedo = lerp(c.rgb, d.rgb, d.a);
                o.Alpha = c.a;
            }
            ENDCG
        }

            Fallback "Transparent/Cutout/VertexLit"
}