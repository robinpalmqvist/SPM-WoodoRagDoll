﻿Shader "Yvette/SphericalMask" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Position ("World Position", Vector) = (0,0,0,0)
		_Radius ("Sphere Radius", Range(0,100)) = 0
		_Softness ("Sphere Softness", Range(0,100)) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		//Spherical Mask
		float4 _Position;
		half _Radius;
		half _Softness;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			// Grayscale
			// non optimized version: float grayscale = (c.r + c.g + c.b) / 3;
			// half is half of a float, used when small numbers aren't necessary. Positions are for exampe specific, hand should be floats instead.
			half grayscale = (c.r + c.g + c.b) * 0.333;
			fixed3 c_g = fixed3(grayscale, grayscale, grayscale);

			half d = distance(_Position, IN.worldPos);
			half sum = saturate((d - _Radius) / - _Softness);
			// saturate will always result in a number between 0 and 1;
			fixed4 lerpColor = lerp(fixed4(c_g, 1), c, sum);


			o.Albedo = lerpColor.rgb;

			//o.Albedo = c_g;
			//o.Albedo = c.rgb;

			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
