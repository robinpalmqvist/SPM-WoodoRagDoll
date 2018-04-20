﻿Shader "Robin/DissolveShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_DissolveTex("DissolveTexture", 2D) = "white" {}
		_DissolveY("Dissolve Y", Float) = 0
		_DissolveSize("Dissolve Size", Float) = 2
		_StartingY("Starting Y", Float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				
				float4 vertex : SV_POSITION;
				float3 worldPos : TEXCOORD1;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _DissolveTex;
			float _DissolveY;
			float _DissolveSize;
			float _StartingY;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				//float transition = _DissolveY - i.worldPos.y;
				clip(_StartingY + (transition + (tex2D(_DissolveTex, i.uv)) * _DissolveSize));
				fixed4 col = tex2D(_MainTex, i.uv);
				
				// apply fog
				
				return col;
			}
			ENDCG
		}
	}
}
