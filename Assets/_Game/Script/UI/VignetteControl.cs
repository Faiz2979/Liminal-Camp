using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteControl : MonoBehaviour
{
    [SerializeField] private Volume _postProssesingVolume;
    private Vignette _vignette;
    private float _previousIntensity;
    void Start()
    {
        // Try to get the Vignette effect from the volume profile
        if (_postProssesingVolume.profile.TryGet(out _vignette))
        {
            _vignette.intensity.overrideState = true;
            _vignette.color.overrideState = true;
        }
        else
        {
            Debug.LogError("Vignette effect not found in the PostProcessProfile.");
        }
    }

    public void EditVignetteIntensity(float intensity)
    {
        if(_previousIntensity == float.NaN)
        {
        _previousIntensity = 1;
        }
        _vignette.intensity.value = Mathf.Lerp(_previousIntensity, intensity, 0.5f);
        _previousIntensity = intensity;
    }
}
