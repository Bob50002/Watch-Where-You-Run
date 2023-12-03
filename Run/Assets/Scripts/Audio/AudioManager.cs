using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer AudioMix;
    [SerializeField] Slider AudioSlider;
    [SerializeField] string VolumeParameter = "Volume";
    [SerializeField] float VolumeMulti = 20f;

    private void Awake()
    {
        AudioMix.GetFloat(VolumeParameter, out float currentVolume);

        AudioSlider.SetValueWithoutNotify(Mathf.Pow(10, currentVolume / VolumeMulti));

        AudioSlider.onValueChanged.AddListener(SliderValueChange);
    }

    public void SliderValueChange(float value)
    {
        AudioMix.SetFloat(VolumeParameter, Mathf.Log10(value) * VolumeMulti);
    }

    private void OnDestroy()
    {
        AudioSlider.onValueChanged.RemoveListener(SliderValueChange);
    }
}