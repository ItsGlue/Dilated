using UnityEngine;

public class CompareAndChangeSprite : MonoBehaviour
{
    public Sprite unlocked;
    public Sprite locked;

    public int buttonLevel;
    public int unlockedLevel;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component attached to the button
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Update the button's sprite based on the comparison
        UpdateButtonSprite();
    }

    void Update() {
        unlocked
    }

    public void UpdateButtonSprite()
    {
        // Compare the two variables
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
