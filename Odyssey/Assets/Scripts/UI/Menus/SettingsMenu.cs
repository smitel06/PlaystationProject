using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    //sliders
    public Slider soundtrackSlider;
    public Slider soundEffectsSlider;
    public AudioMixer audioMixer;

    
    private void OnEnable()
    {
        //get set values to volume sliders
        float value;
        bool result = audioMixer.GetFloat("soundTrackVolumeMixer", out value);
        soundtrackSlider.value = value;

        result = audioMixer.GetFloat("soundFXVolumeMixer", out value);
        soundEffectsSlider.value = value;
    }


    public void SetVolumeST (System.Single soundTrackVolume)
    {
        audioMixer.SetFloat("soundTrackVolumeMixer", soundTrackVolume);
    }

    public void SetVolumeSFX(System.Single soundFXVolume)
    {
        audioMixer.SetFloat("soundFXVolumeMixer", soundFXVolume);
    }
}
