Shader "Custom/ray" {

	Properties {
		_MainTex ("Size", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
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

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;
		sampler2D _MainTex;

		void surf (Input IN, inout SurfaceOutput o) {
            fixed4 c = _Color * 4.8;
            float y = abs(IN.uv_MainTex.y - 0.5) * 100;
            c.a = pow(min(1, c.a / y), 2.2);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}

		ENDCG

	}

	FallBack "Diffuse"

}
