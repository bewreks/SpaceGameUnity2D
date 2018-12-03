Shader "Custom/AnimatedBackground" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_ScrollY("Background Speed", range(0, 10)) = 2
        [Toggle] _DynamicEmissionLM ("Dynamic Emission (Lightmapper)", Int) = 0
		_EmissionColor ("EmissionColor", Color) = (1,1,1,1)
		_EmissionMap ("Emission (RGB)", 2D) = "white" {}
		_EmissionLM ("Emission (Lightmapper)", Float) = 0
		_Noise ("Noise", 2D) = "white" {}
		_Max ("Max", range(0, 1)) = 1
		_Min ("Min", range(0, 1)) = 0.2
		
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
		sampler2D _EmissionMap;
		sampler2D _Noise;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		half _EmissionLM;
		half _ScrollY;
		half _Min;
		half _Max;
		fixed4 _Color;
		fixed4 _EmissionColor;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
            float2 texCoord = IN.uv_MainTex;
            texCoord.y -= _ScrollY * _Time.x;
			fixed4 c = tex2D (_MainTex, texCoord) * _Color;
			fixed4 n = tex2D (_Noise, fixed2(_Time.x, 0));
			fixed4 e = tex2D(_EmissionMap, texCoord);
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			n.r = clamp(n.r, _Min, _Max);
			o.Emission = o.Albedo * _EmissionColor * (e.g + e.b + e.r) * _EmissionLM * n.r;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
