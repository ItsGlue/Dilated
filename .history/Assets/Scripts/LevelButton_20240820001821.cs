using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Sprite unlocked;
    public Sprite locked;

    public int buttonLevel;
    private int unlockedLevel;

    private Image buttonImage;

    void Start()
    {
        // Get the Image component attached to the button
        buttonImage = GetComponent<Image>();
        unlockedLevel = PlayerPrefs.GetInt("maxlevel");
        UpdateButtonSprite();
    }

    void Update()
    {
        unlockedLevel = PlayerPrefs.GetInt("maxlevel");
        UpdateButtonSprite();
    }

    private void UpdateButtonSprite()
    {
        if (buttonLevel <= unlockedLevel)
        {
            buttonImage.sprite = unlocked;
        }
        else
        {
            buttonImage.sprite = locked;
        }
    }
}
