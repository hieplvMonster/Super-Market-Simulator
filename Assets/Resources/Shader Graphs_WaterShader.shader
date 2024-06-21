Shader "Shader Graphs/WaterShader" {
	Properties {
		Color_36218622185947c6a5ae36366d8e21d8 ("Deep Color", Vector) = (0.03921569,0.09803922,0.2745098,0.7058824)
		Color_93e06cd551a5449091bcde90b46765a0 ("Shallow Color", Vector) = (0.03804734,0.5490196,0.5490196,0.1960784)
		Vector1_6f56a0970372485390c6587863c2374e ("Depth", Float) = -3.5
		Vector1_6c82dffdd68049bcb019d3a9c64c92a0 ("Strenght", Range(0, 2)) = 0.2
		Vector1_6269b1025b26473ca8bc61634f34b537 ("Smoothness", Range(0, 1)) = 0.95
		_Metalic ("Metalic", Range(0, 1)) = 0.5
		Vector1_7273530c27a34c9f8ee5723b84f96baa ("Displacement", Float) = 0.2
		[NoScaleOffset] Texture2D_6d0f902902b04ba687ee00a51db7ba6d ("Main Normal", 2D) = "white" {}
		[NoScaleOffset] Texture2D_786b67b3efe14204b2f06f9afb9d8cf1 ("Second Normal", 2D) = "white" {}
		Vector1_687f54e8c371429f86b9eaab0e7dfe3e ("Normal Strenght", Range(0, 1)) = 0.05
		Vector2_4351ac2be1d74054986ec5378db9d578 ("Normal Tiling", Vector) = (10,10,0,0)
		[ToggleUI] Boolean_d3c978b0d14a4f66be175a9b89855be0 ("Use Reflection (Experimental)", Float) = 0
		[NoScaleOffset] Texture2D_28de85506601443d82b6148f21ccc69c ("Reflection Texture", 2D) = "white" {}
		Vector1_dada42ebfac44076897b6de67441ba32 ("Reflection Power", Float) = 0.3
		Vector1_55003dfa023448c3bffa42f3ca4a99a4 ("Distortion Power", Float) = 1
		_Foam_Color ("Foam Color", Vector) = (0,0,0,0)
		_Foam_Distance ("Foam Distance", Float) = 0
		_Foam_Cut_Off ("Foam Cut Off", Float) = 0
		_DisplacementSpeed ("DisplacementSpeed", Float) = 1
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
}