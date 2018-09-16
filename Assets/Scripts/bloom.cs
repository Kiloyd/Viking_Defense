using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class bloom : PostEffectBase
{
    public int downSample = 1;
    public int sampleScale = 1;
    public Color colorthreshold = Color.gray;
    public Color bloomColor = Color.white;

    [Range(0, 1)]
    public float bloomFactor = 0.5f;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (_Material)
        {
            RenderTexture temp1 = RenderTexture.GetTemporary(source.width >> downSample, source.height >> downSample, 0, source.format);
            RenderTexture temp2 = RenderTexture.GetTemporary(source.width >> downSample, source.height >> downSample, 0, source.format);

            Graphics.Blit(source, temp1);

            _Material.SetVector("_colorThreshold", colorthreshold);
            Graphics.Blit(temp1, temp2, _Material, 0);

            _Material.SetVector("_offsets", new Vector4(0, sampleScale, 0, 0));
            Graphics.Blit(temp2, temp1, _Material, 1);
            _Material.SetVector("_offsets", new Vector4(sampleScale, 0, 0, 0));
            Graphics.Blit(temp1, temp2, _Material, 1);

            _Material.SetTexture("_BlurTex", temp2);
            _Material.SetVector("_bloomColor", bloomColor);
            _Material.SetFloat("_bloomFactor", bloomFactor);

            Graphics.Blit(source, destination, _Material, 2);

            RenderTexture.ReleaseTemporary(temp1);
            RenderTexture.ReleaseTemporary(temp2);
        }
    }
}
