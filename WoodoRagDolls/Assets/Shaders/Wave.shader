// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Wave"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Main Color", COLOR) = (1,1,1,1)
		_LoadVisibility("Load Visibility", Range(0,1)) = 1
	}
	SubShader
	{
		//Blend One One
		//ZWrite Off
		//Cull Off

		Tags 
		{ 
			"RenderType"="Opaque" 
			"Queue"="Geometry"
		}
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
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 screenuv : TEXCOORD1;
				UNITY_FOG_COORDS(1)
				float3 viewDir : TEXCOORD2;
				float3 objectPos : TEXCOORD3;
				float3 normal : NORMAL;
				float4 vertex : SV_POSITION;
				float depth : DEPTH;
			};


			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _LoadVisibility;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				o.screenuv = ((o.vertex.xy / o.vertex.w) + 1) / 2;
				o.screenuv.y = 1 - o.screenuv.y;
				o.depth = -(UnityObjectToViewPos(v.vertex)).z *_ProjectionParams.w;

				// UNITY_MATRIX_MV

				o.objectPos = v.vertex.xyz;
				o.normal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = normalize(UnityWorldSpaceViewDir(mul(unity_ObjectToWorld, v.vertex)));

				return o;
			}

			sampler2D _CameraDepthNormalsTexture;
			fixed4 _Color;

			float triWave(float t, float offset, float yOffset)
			{
				return saturate(abs(frac(offset + t) * 2 - 1) + yOffset);
			}

			fixed4 texColor(v2f i, float rim)
			{
				fixed4 mainTex = tex2D(_MainTex, i.uv);
				mainTex.r *= triWave(_Time.x * -50, i.objectPos.y, -0.7) * 6;

				// I ended up saturaing the rim calculation because negative values caused weird artifacts
				mainTex.g *= saturate(rim) * (sin(_Time.z + mainTex.b * 5) + 1);
				return mainTex.r * _Color + mainTex.g * _Color;
			}
			
			fixed4 frag(v2f i) : SV_Target
			{
				float screenDepth = DecodeFloatRG(tex2D(_CameraDepthNormalsTexture, i.screenuv).zw);
				float diff = screenDepth - i.depth;
				float intersect = 0;

				if (diff > 0)
					intersect = 1 - smoothstep(0, _ProjectionParams.w * 0.5, diff);

				float rim = 1 - abs(dot(i.normal, normalize(i.viewDir))) * 2;
				//float northPole = (i.objectPos.y - 0.45) * 20;
				float glow = max(intersect, rim);
				//max(max(intersect, rim), northPole);

				fixed4 glowColor = fixed4(lerp(_Color.rgb, fixed3(1, 1, 1), pow(glow, 4)), 1);

				fixed4 hexes = texColor(i, rim);

				//fixed4 col = _Color * _Color.a + glowColor * glow + hexes;
				fixed4 col = _Color * _Color.a + hexes * _LoadVisibility;
				return col;
			}
			ENDCG
		}
	}
}
