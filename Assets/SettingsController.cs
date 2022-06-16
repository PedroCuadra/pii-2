using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{

    [SerializeField] Slider musicVolumeSlider;
    static string MUSIC_VOLUME_KEY = "MUSIC_VOLUME";

    [SerializeField] Slider soundVolumeSlider;
    static string SOUND_VOLUME_KEY = "SOUND_VOLUME";

    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Toggle fullscreenToggle;
    static string FULLSCREEN_KEY = "FULLSCREEN";

    void Start(){
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0.5f);
        OnMusicVolumeChange();

        soundVolumeSlider.value = PlayerPrefs.GetFloat(SOUND_VOLUME_KEY, 0.5f); 
        OnSoundVolumeChange();       

        fullscreenToggle.isOn = PlayerPrefs.GetInt(FULLSCREEN_KEY, 0) == 1;
        OnFullscreenChange();
    }

    private float LinearToDecibel(float linear)
    {
        // linear goes from 0 to 1 and decibel goes from -80 to 0
        return Mathf.Clamp(Mathf.Log10(linear) * 20, -80, 0);
    }
    
    public void OnMusicVolumeChange(){
        float volume = LinearToDecibel(musicVolumeSlider.value);
        audioMixer.SetFloat(MUSIC_VOLUME_KEY, volume);
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
    }

    public void OnSoundVolumeChange(){
        float volume = LinearToDecibel(soundVolumeSlider.value);
        audioMixer.SetFloat(SOUND_VOLUME_KEY, volume);
        PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, soundVolumeSlider.value);
    }

    public void OnFullscreenChange(){
        Screen.fullScreen = fullscreenToggle.isOn;
        PlayerPrefs.SetInt(FULLSCREEN_KEY, fullscreenToggle.isOn ? 1 : 0);
    }
}
