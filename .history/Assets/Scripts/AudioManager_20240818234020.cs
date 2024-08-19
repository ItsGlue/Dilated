using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSound, sfxSounds;
    public AudioSource musicSource, sfxSource;


    public void PlayMusic(string name) 
    {
        Sound s = Array.Find(musicSound, x => x.name == name);
        musicSource.clip = s.clip;
        musicSource.Play();
    }

    public void PlaySFX(string name) 
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        musicSource.clip = s.clip;
        musicSource.Play();
    }


}
