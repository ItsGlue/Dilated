using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    public Sprite notPressedSprite;
    public Sprite pressedSprite;

    private SpriteRenderer parentSpriteRenderer;
    private bool isPressed = false;

    void Start()
    {
        // Get the SpriteRenderer from the parent GameObject
        parentSpriteRenderer = GetComponentInParent<SpriteRenderer>();
        
        if (parentSpriteRenderer == null)
        {
            Debug.LogError("Parent SpriteRenderer is not found!");
        }
        else
        {
            // Set the initial sprite to notPressedSprite
            parentSpriteRenderer.sprite = notPressedSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (parentSpriteRenderer != null)
        {
            parentSpriteRenderer.sprite = pressedSprite;
            isPressed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (parentSpriteRenderer != null)
        {
            parentSpriteRenderer.sprite = notPressedSprite;
            isPressed = false;
        }
    }

    public bool IsPressed()
    {
        return isPressed;
    }
}
