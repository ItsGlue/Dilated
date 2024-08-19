using UnityEngine;
using System.Collections.Generic;

public class PlaylistManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> songs;

    private List<int> songOrder;
    private int currentIndex = 0;
    private static PlaylistManager instance;
    private float currentTime;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        ShuffleSongs();
        PlayCurrentSong();
    }

    void Update()
    {
        currentTime = audioSource.time;

        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void ShuffleSongs()
    {
        songOrder = new List<int>();
        for (int i = 0; i < songs.Count; i++)
        {
            songOrder.Add(i);
        }

        for (int i = 0; i < songOrder.Count; i++)
        {
            int temp = songOrder[i];
            int randomIndex = Random.Range(i, songOrder.Count);
            songOrder[i] = songOrder[randomIndex];
            songOrder[randomIndex] = temp;
        }
    }

    void PlayCurrentSong()
    {
        audioSource.clip = songs[songOrder[currentIndex]];
        audioSource.time = currentTime;
        audioSource.Play();
    }

    void PlayNextSong()
    {
        currentIndex++;
        if (currentIndex >= songs.Count)
        {
            currentIndex = 0;
            ShuffleSongs();
        }

        currentTime = 0;
        PlayCurrentSong();
    }
}
