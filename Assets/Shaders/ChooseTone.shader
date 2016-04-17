Shader "Custom/ChooseTone" {
	Properties {
		_Color ("Color", Color) = (0.25,0.75,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Threshold ("Threshold", Range(0,3.1416)) = 0
		_Intensity ("Intensity", Range(0.0,1.0)) = 0.5
		_Saturation ("Saturation", Range(0.0,1.0)) = 1
	}

	SubShader {
		Pass {
			ZTest Always Cull Off ZWrite Off
					
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			float3 rgb_to_hsv_no_clip(float3 RGB)
			{
			float3 HSV;
			
			float minChannel, maxChannel;
			if (RGB.x > RGB.y) {
			maxChannel = RGB.x;
			minChannel = RGB.y;
			}
			else {
			maxChannel = RGB.y;
			minChannel = RGB.x;
			}
			
			if (RGB.z > maxChannel) maxChannel = RGB.z;
			if (RGB.z < minChannel) minChannel = RGB.z;
			
					HSV.xy = 0;
					HSV.z = maxChannel;
					float delta = maxChannel - minChannel;             //Delta RGB value
					if (delta != 0) {                    // If gray, leave H  S at zero
					HSV.y = delta / HSV.z;
					float3 delRGB;
					delRGB = (HSV.zzz - RGB + 3*delta) / (6.0*delta);
					if      ( RGB.x == HSV.z ) HSV.x = delRGB.z - delRGB.y;
					else if ( RGB.y == HSV.z ) HSV.x = ( 1.0/3.0) + delRGB.x - delRGB.z;
					else if ( RGB.z == HSV.z ) HSV.x = ( 2.0/3.0) + delRGB.y - delRGB.x;
					}
					return (HSV);
			}
	
			float3 hsv_to_rgb(float3 HSV)
			{
					float3 RGB = HSV.z;
			
					float var_h = HSV.x * 6;
					float var_i = floor(var_h);   // Or ... var_i = floor( var_h )
					float var_1 = HSV.z * (1.0 - HSV.y);
					float var_2 = HSV.z * (1.0 - HSV.y * (var_h-var_i));
					float var_3 = HSV.z * (1.0 - HSV.y * (1-(var_h-var_i)));
					if      (var_i == 0) { RGB = float3(HSV.z, var_3, var_1); }
					else if (var_i == 1) { RGB = float3(var_2, HSV.z, var_1); }
					else if (var_i == 2) { RGB = float3(var_1, HSV.z, var_3); }
					else if (var_i == 3) { RGB = float3(var_1, var_2, HSV.z); }
					else if (var_i == 4) { RGB = float3(var_3, var_1, HSV.z); }
					else                 { RGB = float3(HSV.z, var_1, var_2); }
			
			return (RGB);
			}

			uniform sampler2D _MainTex;
            uniform fixed4 _Color;
            uniform float _Intensity;
            uniform float _Saturation;
            uniform float _Threshold;

			fixed4 frag (v2f_img i) : SV_Target
			{	
				fixed4 original = tex2D(_MainTex, i.uv);
				
				fixed3 originalhsv = rgb_to_hsv_no_clip(original.rgb);
				fixed3 colorhsv = rgb_to_hsv_no_clip(_Color.rgb);
				
				fixed4 output = fixed4(0,0,0,0);

				output.rgb = (original.rgb * _Color.rgb * _Intensity * (abs(originalhsv.x - colorhsv.x) - _Threshold + 3.1416)/6.2832) + // Calcul du produit des couleurs
								(hsv_to_rgb(fixed3(0,0,originalhsv.z)) * _Intensity * (_Threshold - abs(originalhsv.x - colorhsv.x) + 3.1416)/6.2832) + // Calcul des niveaux de gris
								original.rgb * (1 - _Intensity); // Calcul de la valeur originale
								
				fixed3 outputhsv = rgb_to_hsv_no_clip(output.rgb);
				
				outputhsv.y *= _Saturation; // Modulation de la saturation
				
				output.rgb = hsv_to_rgb(outputhsv);
				
				output.a = original.a;
				
				return output;
			}
			ENDCG

		}
	}

	Fallback off
}

