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

        // Update the unlocked level
        unlockedLevel = PlayerPrefs.GetInt("maxlevel");

        // Set the initial sprite based on the level
        UpdateButtonSprite();
    }

    void Update()
    {
        // Update the unlocked level
        unlockedLevel = PlayerPrefs.GetInt("maxlevel");

        // Update the sprite based on the current level
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
