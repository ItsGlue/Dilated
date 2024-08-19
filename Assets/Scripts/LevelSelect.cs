using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadTitle() {
        SceneManager.LoadScene("Title");
    }
    public void LoadLevel(int num) {
        if (num <= PlayerPrefs.GetInt("maxlevel")) {
            SceneManager.LoadScene(num + 1);
        }
    }
}
