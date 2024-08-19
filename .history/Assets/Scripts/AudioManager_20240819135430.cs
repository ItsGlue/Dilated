using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSound, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake() {
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

    public void PlayMusic(string name) 
    {
        Sound s = Array.Find(musicSound, x => x.name == name);
        if (s != null)
        {
            Debug.Log("Found music track: " + name);  // Confirm that the track is found
            musicSource.clip = s.clip;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music track not found: " + name);  // Warn if the track isn't found
        }
    }

    public void PlaySFX(string name) 
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        musicSource.clip = s.clip;
        musicSource.Play();
    }


}
