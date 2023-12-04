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
    [SerializeField] AudioSource SFXVolume;
    [SerializeField] const string AudioSliderValue = "AudioSliderValue";
    private void Awake()
    {
        AudioMix.GetFloat(VolumeParameter, out float currentVolume);

        AudioSlider.SetValueWithoutNotify(Mathf.Pow(10, currentVolume / VolumeMulti));

        AudioSlider.onValueChanged.AddListener(SliderValueChange);
    }

    private void Start()
    {
        AudioSlider.value = (PlayerPrefs.GetFloat(AudioSliderValue));
    }

    public void SliderValueChange(float value)
    {
        AudioMix.SetFloat(VolumeParameter, Mathf.Log10(value) * VolumeMulti);

        PlayerPrefs.SetFloat(AudioSliderValue, AudioSlider.value);
    }

    private void OnDestroy()
    {
        AudioSlider.onValueChanged.RemoveListener(SliderValueChange);
    }
}