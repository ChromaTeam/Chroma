using System;
using UnityEngine;

namespace ChromaTeam
{
    [ExecuteInEditMode]
    [AddComponentMenu("Custom/ChooseTone")]
    public class ChooseTone : UnityStandardAssets.ImageEffects.ImageEffectBase
	{
        [Range(0,1)]
        public float intensity;
        public Color color;
        
        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination)
		{
            material.SetFloat("_Intensity", intensity);
            material.SetColor("_Color", color);
            Graphics.Blit (source, destination, material);
        }
    }
}