﻿// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/WigglingSurfaceShader" {
	Properties{
	_Color("Color", Color) = (1,1,1,1)
	_MainTex("Albedo (RGB)", 2D) = "white" {}
	_Glossiness("Smoothness", Range(0,1)) = 0.5
	_Metallic("Metallic", Range(0,1)) = 0.0
	_Size("Size", float) = 1.0
	_TimeDirection("TimeDirection", Range(0, 1)) = 1.0
	_TimeSpeed("TimeSpeed", Range(0, 30)) = 10.0
	_Amplitude("Amplitude", Range(0, 1)) = 0.02
	}
		SubShader{
		Tags { "Queue" = "Transparent" "RenderType" = "Opaque" "DisableBatching" = "True"}
		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha
		Cull back
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows addshadow vertex:vert Lambert alpha
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		#include "UnityCG.cginc"

		sampler2D _MainTex;
		float _TimeDirection;
		float _TimeSpeed;
		float _Amplitude;
		float _Size;

		struct Input {
		float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		static half _Frequency = 2;
		
		struct v2f
		{
			float4 vertex: SV_POSITION;
			float3 normal: SV_POSITION;
		};

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)

			void vert(inout appdata_base v) {
				v2f o;
				o.vertex = mul(unity_WorldToObject, v.vertex); 
				v.vertex.xyz += v.normal * sin((v.vertex.y / _Size) * _Frequency + (_Time.y * _TimeSpeed)) * _Amplitude;
			}

			void surf(Input IN, inout SurfaceOutputStandard o) {
				// Albedo comes from a texture tinted by color
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
			}

			//fixed4 frag(v2f i) : SV_Target
			//{
			//	fixed4 col = tex2D(_MainTex, i.texcoord) * _Color; // multiply by _Color
			//	return col;
			//}
		ENDCG
	}
		FallBack "Diffuse"
}