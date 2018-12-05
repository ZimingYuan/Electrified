Shader "Custom/Circle" {

	Properties {
        _Radiu ("Circle's radiu", Float) = 0.5
        _Center ("Circle's center(W is no use)", Vector) = (0.5, 0.5, 0.0, 0.0)
        _Color ("Color of the dark environment", Color) = (0.0, 0.0, 0.0, 1.0)
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

        fixed _Radiu;
        fixed4 _Color, _Center;

		struct Input {
            float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutput o) {
            o.Albedo = _Color * 4.8;
            fixed3 Center = _Center.xyz; Center.y += 0.2;
            if (distance(Center, IN.worldPos) < _Radiu)
			    o.Alpha = 0.0;
            else
                o.Alpha = 1.0;
		}

		ENDCG

	}

	FallBack "Diffuse"
}
