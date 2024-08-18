using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    // The two sprites to switch between
    public Sprite notPressedSprite;
    public Sprite pressedSprite;

    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    // Boolean to track if the button is pressed
    private bool isPressed = false;

    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Set the initial sprite
        spriteRenderer.sprite = notPressedSprite;
    }

    // Detect when another GameObject enters the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Set the sprite to pressedSprite when something is on the button
        spriteRenderer.sprite = pressedSprite;
        isPressed = true;
    }

    // Detect when another GameObject exits the collider
    void OnTriggerExit2D(Collider2D other)
    {
        // Set the sprite back to notPressedSprite when the object leaves the button
        spriteRenderer.sprite = notPressedSprite;
        isPressed = false;
    }

    // Optional: Check the button state
    public bool IsPressed()
    {
        return isPressed;
    }
}
