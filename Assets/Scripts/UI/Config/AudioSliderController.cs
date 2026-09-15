
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController :MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    public void OnMasterChanged(float value)
    {
        value = masterSlider.value;
        AudioController.Instance.SetMasterVolume(value);
    }
    public void OnMusicChanged(float value)
    {
        value = musicSlider.value;
        AudioController.Instance.SetMusicVolume(value);
    }
    public void OnSFXChanged(float value)
    {
        value = SFXSlider.value;
        AudioController.Instance.SetSFXVolume(value);
    }
}