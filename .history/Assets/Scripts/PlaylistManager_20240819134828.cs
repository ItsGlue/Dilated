using UnityEngine;
using System.Collections.Generic;

public class PlaylistManager : MonoBehaviour
{
    public List<string> songNames;  // List of song names as strings

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
        for (int i = 0; i < songNames.Count; i++)
        {
            songOrder.Add(i);
        }

        // Shuffle the song order list
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
        // Play the current song using the AudioManager's PlayMusic method with the song name
        string currentSongName = songNames[songOrder[currentIndex]];
        AudioManager.Instance.PlayMusic(currentSongName);
    }

    void PlayNextSong()
    {
        currentIndex++;
        if (currentIndex >= songNames.Count)
        {
            currentIndex = 0;
            ShuffleSongs();
        }

        PlayCurrentSong();
    }
}
