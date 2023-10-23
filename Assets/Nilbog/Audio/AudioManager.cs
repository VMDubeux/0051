using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public static UIController Controller;

    [Header("AudioClips:")]
    public Sound[] MusicSounds, SfxSounds;

    [Header("Audio Sources:")]
    public AudioSource MusicSource, SfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MusicVolume(PlayerPrefs.GetFloat("MusicVolumeValue"));
        PlayMusic("Theme");
        SFXVolume(PlayerPrefs.GetFloat("SfxVolumeValue"));
        ToggleMusic();
        ToggleSFX();
    }

    public void PlayMusic(string Name)
    {
        Sound s = Array.Find(MusicSounds, x => x.Name == Name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            MusicSource.clip = s.Som;
            MusicSource.Play();
        }
    }

    public void PlaySFX(string Name, float Volume)
    {
        Sound s = Array.Find(SfxSounds, x => x.Name == Name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            SfxSource.clip = s.Som;
            SfxSource.PlayOneShot(s.Som, Volume);
        }
    }

 
    public void ToggleMusic()
    {
        PlayerPrefs.GetInt("musicToggleValue");
    }

    public void ToggleSFX()
    {
        PlayerPrefs.GetInt("sfxToggleValue");
    }

    public void MusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        SfxSource.volume = volume;
    }
}
