using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("maxlevel", -1) == -1) {
            PlayerPrefs.SetInt("maxlevel",1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevelOne() {
        SceneManager.LoadScene(2);
    }
    public void LoadLevelSelect() {
        SceneManager.LoadScene("Level Select");
    }
}
