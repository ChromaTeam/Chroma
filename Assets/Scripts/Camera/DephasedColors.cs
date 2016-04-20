using UnityEngine;
using System.Collections;

namespace ChromaTeam
{

    [ExecuteInEditMode]
    [AddComponentMenu("Custom/DephasedColors")]
    public class DephasedColors : UnityStandardAssets.ImageEffects.ImageEffectBase
	{
        public Vector2 RedOffset;
		public Vector2 GreenOffset;
		public Vector2 BlueOffset;
        
        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination)
		{
            material.SetVector("_RedOffset", RedOffset);
            material.SetVector("_GreenOffset", GreenOffset);
            material.SetVector("_BlueOffset", BlueOffset);
            Graphics.Blit (source, destination, material);
        }
    }
}
