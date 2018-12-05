Shader "Custom/Repeat" {

	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
        _PrivotX ("PrivotX", float) = 0.0
        _Width ("Width", float) = 1.0
	}

	SubShader {

		Tags {   
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
        }

        Cull Back

		CGPROGRAM

		#pragma surface surf Lambert alpha:fade 

		sampler2D _MainTex;

		struct Input {
            float2 uv_MainTex;
            float3 worldPos;
		};

		fixed4 _Color;
        fixed _PrivotX;
        fixed _Width;

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, fixed2((IN.worldPos.x - _PrivotX) % _Width, IN.uv_MainTex.y));
			o.Albedo = c.rgb * 4.8;
			o.Alpha = c.a;
		}

		ENDCG

	}

	FallBack "Diffuse"
}
