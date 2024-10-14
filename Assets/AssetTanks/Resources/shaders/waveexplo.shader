Shader "Custom/WaveExplo" {
	Properties {
		_MainTex ("", 2D) = "white" {}
		_CenterX ("CenterX", Range(-1, 2)) = 0.5
		_CenterY ("CenterY", Range(-1, 2)) = 0.5
		_Radius ("Radius", Range(-1, 1)) = 0.2
		_Amplitude ("Amplitude", Range(-10, 10)) = 0.05
		_Aspect ("Aspect", Range(-10, 10)) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}