Shader "Custom/prick" {

	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Number ("Number (Int)", Int) = 1
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
		};

		fixed4 _Color;
        fixed _Number;

		void surf (Input IN, inout SurfaceOutput o) {
            fixed x = (IN.uv_MainTex.x - floor(IN.uv_MainTex.x / (1 / _Number)) * (1 / _Number)) / (1 / _Number);
			fixed4 c = tex2D(_MainTex, fixed2(x, IN.uv_MainTex.y));
			o.Albedo = c.rgb * 2.4;
			o.Alpha = c.a;
		}

		ENDCG

	}

	FallBack "Diffuse"
}
