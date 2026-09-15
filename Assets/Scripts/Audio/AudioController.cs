

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController:MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField] private AudioMixer audioMixer;
    [Header("MasterVolume")]
    [Range(0,1f)]public float masterVolume=0.5f;
    [SerializeField] private Slider masterVolumeSlider;
    [Header("MusicVolume")]
    [Range(0,1f)]public float musicVolume=0.5f;
    [SerializeField] private Slider MusicVolumeSlider;
    [Header("SFXVolume")]
    [Range(0,1f)]public float SFXVolume=0.5f;
    [SerializeField] private Slider SFXVolumeSlider;

    private void Awake()
    {
        Instance =this;
    }

    private void Start()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume",0.5f);

        musicVolume= PlayerPrefs.GetFloat("MusicVolume",0.5f);

        SFXVolume = PlayerPrefs.GetFloat("SFXVolume",0.5f);

        SetMasterVolume(masterVolume);
        SetMusicVolume(musicVolume);
        SetSFXVolume(SFXVolume);
    }

    public void SetMasterVolume(float value)
    {
        masterVolume=value;
        masterVolumeSlider.value=masterVolume;
        audioMixer.SetFloat("MasterVolume",ConvertToDb(masterVolume));
        PlayerPrefs.SetFloat("MasterVolume",masterVolume);
    }
    public void SetMusicVolume(float value)
    {
        musicVolume=value;
        MusicVolumeSlider.value=musicVolume;
        audioMixer.SetFloat("MusicVolume",ConvertToDb(musicVolume));
        PlayerPrefs.SetFloat("MusicVolume",musicVolume);
    }
    public void SetSFXVolume(float value)
    {
        SFXVolume=value;
        SFXVolumeSlider.value=SFXVolume;
        audioMixer.SetFloat("SFXVolume",ConvertToDb(SFXVolume));
        PlayerPrefs.SetFloat("SFXVolume",SFXVolume);
    }
    private float ConvertToDb(float value)
    {
        if (value <= 0) return -80f;
        return Mathf.Log10(value) * 20f;
    }

}