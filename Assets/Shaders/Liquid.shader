Shader "Custom/Liquid" {

	Properties {
		_MainTex ("Empty", 2D) = "white" {}
        _Speed ("Wave's speed", Range(0, 10)) = 5
        _Color ("Liquid's color", Color) = (1, 1, 1, 1)
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
        fixed _Speed;
        fixed4 _Color;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
            o.Albedo = _Color.rgb * 2.4;
            fixed sin0 = 0.01 * sin(2 * 3.1416 * IN.uv_MainTex.x + _Time.y * _Speed);
            fixed sin1 = 0.02 * sin(4 * 3.1416 * IN.uv_MainTex.x + _Time.y * _Speed);
            fixed sin2 = 0.04 * sin(8 * 3.1416 * IN.uv_MainTex.x + _Time.y * _Speed);
            fixed sin3 = 0.08 * sin(16 * 3.1416 * IN.uv_MainTex.x + _Time.y * _Speed);
            if (IN.uv_MainTex.y - 0.5 <= sin0 + sin1 + sin2 + sin3)
			    o.Alpha = _Color.a;
            else
                o.Alpha = 0;
		}

		ENDCG

	}

	FallBack "Diffuse"
}
