Shader "Custom/Liquid" {

	Properties {
		_MainTex ("Empty", 2D) = "white" {}
        _WaterSpeed ("Water's speed", Range(0, 10)) = 5
        _OilSpeed ("Oil's speed", Range(0, 10)) = 2.5
        _WaterColor ("Water's color", Color) = (0, 0, 1, 1)
        _OilColor ("Oil's color", Color) = (0, 1, 1, 1)
        _IsWater ("Whether the liquid is water(>0.5)", Range(0, 1)) = 1
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
        fixed _WaterSpeed, _OilSpeed;
        fixed4 _WaterColor, _OilColor;
        fixed _IsWater;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
            fixed _Speed; fixed4 _Color;
            if (_IsWater > 0.5) _Speed = _WaterSpeed, _Color = _WaterColor;
            else _Speed = _OilSpeed, _Color = _OilColor;
            o.Albedo = _Color.rgb * 4.8;
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
