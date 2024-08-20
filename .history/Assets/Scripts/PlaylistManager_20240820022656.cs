using UnityEngine;
using System.Collections.Generic;

public class PlaylistManager : MonoBehaviour
{
    public List<string> songNames; 

    private List<int> songOrder;
    private int currentIndex = 0;
    private static PlaylistManager instance;

    public static PlaylistManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlaylistManager>();

                if (instance == null)
                {
                    GameObject playlistManager = new GameObject("PlaylistManager");
                    instance = playlistManager.AddComponent<PlaylistManager>();
                }

                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogError("AudioManager instance is not found!");
            return;
        }
        ShuffleSongs();
        PlayCurrentSong();
    }

    void Update()
    {
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
        string currentSongName = songNames[songOrder[currentIndex]];
        Debug.Log("Playing song: " + currentSongName);  
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
