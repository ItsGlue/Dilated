using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public Sprite unlocked;
    public Sprite locked;

    public int buttonLevel;
    private int unlockedLevel;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component attached to the button
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Update the button's sprite based on the comparison
    }

    void Update() {
        unlockedLevel = PlayerPrefs.GetInt("maxlevel");
        if (buttonLevel >= unlockedLevel)
        {
            spriteRenderer.sprite = unlocked;
        }
        else
        {
            spriteRenderer.sprite = locked;
        }
    }
}
