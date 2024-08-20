using UnityEngine;

public class CompareAndChangeSprite : MonoBehaviour
{
    public Sprite greaterSprite;
    public Sprite lesserOrEqualSprite;

    public int variableA;  // First input variable
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
        if (variableA > variableB)
        {
            spriteRenderer.sprite = greaterSprite;
        }
        else
        {
            spriteRenderer.sprite = lesserOrEqualSprite;
        }
    }

    // Optional: Call this method to change the values of variableA and variableB and update the sprite accordingly
    public void SetVariables(int newA, int newB)
    {
        variableA = newA;
        variableB = newB;
        UpdateButtonSprite();
    }
}
