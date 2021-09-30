using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetVolumeST (System.Single soundTrackVolume)
    {
        audioMixer.SetFloat("soundTrackVolumeMixer", soundTrackVolume);
    }

    public void SetVolumeSFX(System.Single soundFXVolume)
    {
        audioMixer.SetFloat("soundFXVolumeMixer", soundFXVolume);
    }
}
