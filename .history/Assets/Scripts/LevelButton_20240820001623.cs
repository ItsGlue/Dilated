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
        if (buttonLevel >= unlockedLevel)
        {
            spriteRenderer.sprite = unlocked;
        }
        else
        {
            spriteRenderer.sprite = locked;
        }
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
