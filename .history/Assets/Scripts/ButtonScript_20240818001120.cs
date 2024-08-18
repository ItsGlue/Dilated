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
        Debug.LogError("adfsdaf");
        // Check if the triggered collider is the child trigger collider
        if (other == childTriggerCollider)
        {
            Debug.LogError("adfsdaf");
            spriteRenderer.sprite = pressedSprite;
            isPressed = true;
        }
    }

    // Detect when another GameObject exits the child's collider
    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting collider is the child trigger collider
        if (other == childTriggerCollider)
        {
            spriteRenderer.sprite = notPressedSprite;
            isPressed = false;
        }
    }

    public bool IsPressed()
    {
        return isPressed;
    }
}
