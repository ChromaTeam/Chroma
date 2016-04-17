using System;
using UnityEngine;

namespace ChromaTeam
{
    [ExecuteInEditMode]
    [AddComponentMenu("Custom/ChooseTone")]
    public class ChooseTone : UnityStandardAssets.ImageEffects.ImageEffectBase
	{
        [Range(-3.1416f,3.1416f)]
        public float threshold;
        [Range(0,1)]
        public float saturation;
        [Range(0,1)]
        public float intensity;
        public Color color;
        
        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination)
		{
            material.SetFloat("_Threshold", threshold);
            material.SetFloat("_Saturation", saturation);
            material.SetFloat("_Intensity", intensity);
            material.SetColor("_Color", color);
            Graphics.Blit (source, destination, material);
        }
    }
}