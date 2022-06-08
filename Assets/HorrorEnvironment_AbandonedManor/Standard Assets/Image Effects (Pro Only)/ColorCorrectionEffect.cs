using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Color Correction (Ramp)")]
public class ColorCorrectionEffect : MonoBehaviour {
	public Texture  textureRamp;

	// Called by camera to apply image effect
	//void OnRenderImage (RenderTexture source, RenderTexture destination) {
	//	material.SetTexture ("_RampTex", textureRamp);
	//	Graphics.Blit (source, destination, material);
	//}
}