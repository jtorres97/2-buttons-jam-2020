using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerUtil : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetMusicVolume(float soundLevel)
    {
        masterMixer.SetFloat("musicVol", soundLevel);
        PlayerPrefs.SetFloat("SliderMusicVolumeLevel", soundLevel);
    }

    public void SetSoundVolume(float soundLevel)
    {
        masterMixer.SetFloat("soundVol", soundLevel);
        PlayerPrefs.SetFloat("SliderSFXVolumeLevel", soundLevel);
    }
}
