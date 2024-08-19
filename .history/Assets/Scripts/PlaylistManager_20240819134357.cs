using UnityEngine;
using System.Collections.Generic;

public class PlaylistManager : MonoBehaviour
{
    public List<AudioClip> songs;

    private List<int> songOrder;
    private int currentIndex = 0;
    private static PlaylistManager instance;

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
        // Check if the musicSource from AudioManager is not playing
        if (!AudioManager.Instance.musicSource.isPlaying)
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
        // Play the current song using the AudioManager's PlayMusic method
        AudioManager.Instance.PlayMusic(songs[songOrder[currentIndex]].name);
    }

    void PlayNextSong()
    {
        currentIndex++;
        if (currentIndex >= songs.Count)
        {
            currentIndex = 0;
            ShuffleSongs();
        }

        PlayCurrentSong();
    }
}
