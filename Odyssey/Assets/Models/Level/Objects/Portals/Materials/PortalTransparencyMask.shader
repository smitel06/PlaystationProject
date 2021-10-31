Shader "Universal Render Pipeline/FX/Custom/mask1" {
	Properties
	{
		//[CurvedWorldBendSettings] _CurvedWorldBendSettings("0|1|1", Vector) = (0, 0, 0, 0)
	}
	SubShader{
		Tags { "RenderPipeline" = "UniversalPipeline" "Queue" = "Transparent-1" }
		ColorMask 0
		ZWrite On
		
		Pass {}
			
	}
}