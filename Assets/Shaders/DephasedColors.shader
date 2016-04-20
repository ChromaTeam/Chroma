Shader "Custom/DephasedColors"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_RedOffset ("RedOffset", Vector) = (0,0,0,0)
		_GreenOffset ("GreenOffset", Vector) = (0,0,0,0)
		_BlueOffset ("BlueOffset", Vector) = (0,0,0,0)
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			uniform sampler2D _MainTex;
            uniform fixed2 _RedOffset;
            uniform fixed2 _GreenOffset;
            uniform fixed2 _BlueOffset;

			fixed4 frag (v2f_img i) : SV_Target
			{
				fixed4 rcol = tex2D(_MainTex, i.uv + _RedOffset);
				fixed4 gcol = tex2D(_MainTex, i.uv + _GreenOffset);
				fixed4 bcol = tex2D(_MainTex, i.uv + _BlueOffset);
				fixed4 acol = tex2D(_MainTex, i.uv);
				
				fixed4 col = fixed4(0,0,0,0);
				
				col.rgb = rcol.rgb * fixed3(1,0,0) +
						  gcol.rgb * fixed3(0,1,0) +
						  bcol.rgb * fixed3(0,0,1);
				col.a = acol.a;
				
				return col;
			}
			ENDCG
		}
	}
}
