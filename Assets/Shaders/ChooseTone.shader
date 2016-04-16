Shader "Custom/ChooseTone" {
	Properties {
		_Color ("Color", Color) = (0.25,0.75,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Intensity ("Intensity", Range(0.0,1.0)) = 0.5
	}

	SubShader {
		Pass {
			ZTest Always Cull Off ZWrite Off
					
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
            uniform fixed4 _Color;
            uniform float _Intensity;

			fixed4 frag (v2f_img i) : SV_Target
			{	
				fixed4 original = tex2D(_MainTex, i.uv);
				
				fixed4 output = fixed4(0,0,0,0);
				output.rgb = original.rgb * (1 - _Intensity) + original.rgb * _Color.rgb * _Intensity;
				output.a = original.a;
				
				return output;
			}
			ENDCG

		}
	}

	Fallback off
}

