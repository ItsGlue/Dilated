using UnityEngine;

public class CompareAndChangeSprite : MonoBehaviour
{
    public Sprite greaterSprite;
    public Sprite lesserOrEqualSprite;

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

    public void UpdateButtonSprite()
    {
        // Compare the two variables
        if (buttoneLevel > variableB)
        {
            spriteRenderer.sprite = greaterSprite;
        }
        else
        {
            spriteRenderer.sprite = lesserOrEqualSprite;
        }
    }
}
