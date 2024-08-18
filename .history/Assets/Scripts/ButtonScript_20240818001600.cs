using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    public Sprite notPressedSprite;
    public Sprite pressedSprite;

    private SpriteRenderer spriteRenderer;
    private bool isPressed = false;

    public Collider2D childTriggerCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = notPressedSprite;

        // Ensure the child collider is set
        if (childTriggerCollider == null)
        {
            Debug.LogError("Child Trigger Collider is not assigned!");
        }
    }

    // Detect when another GameObject enters the child's collider
    void OnTriggerEnter2D(Collider2D other)
    {
        spriteRenderer.sprite = pressedSprite;
        isPressed = true;
    }

    // Detect when another GameObject exits the child's collider
    void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.sprite = notPressedSprite;
        isPressed = false;
    }

    public bool IsPressed()
    {
        return isPressed;
    }
}
