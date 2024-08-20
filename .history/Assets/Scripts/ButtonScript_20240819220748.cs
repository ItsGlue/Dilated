using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Sprite notPressedSprite;
    public Sprite pressedSprite;

    private SpriteRenderer parentSpriteRenderer;
    private bool isPressed = false;
    public GameObject ScalePoint;
    private ScalePoint scaleScript;

    // Track the number of colliders in contact with the button
    private int colliderCount = 0;

    void Start()
    {
        parentSpriteRenderer = GetComponentInParent<SpriteRenderer>();
        parentSpriteRenderer.sprite = notPressedSprite;
        scaleScript = ScalePoint.GetComponent<ScalePoint>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (parentSpriteRenderer != null)
        {
            // Increment the count of colliders touching the button
            colliderCount++;
            
            // Change sprite and activate script if this is the first collider
            if (colliderCount == 1)
            {
                parentSpriteRenderer.sprite = pressedSprite;
                //sfx
                //AudioManager.Instance.PlaySFX("Button");
                isPressed = true;
                scaleScript.ActiveSprite();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (parentSpriteRenderer != null)
        {
            // Decrement the count of colliders touching the button
            colliderCount--;

            // If no colliders are touching the button, reset the sprite and deactivate script
            if (colliderCount == 0)
            {
                parentSpriteRenderer.sprite = notPressedSprite;
                isPressed = false;
                scaleScript.InactiveSprite();
            }
        }
    }

    public bool IsPressed()
    {
        return isPressed;
    }
}
