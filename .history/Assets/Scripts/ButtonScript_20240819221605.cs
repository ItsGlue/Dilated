using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Sprite notPressedSprite;
    public Sprite pressedSprite;

    private SpriteRenderer parentSpriteRenderer;
    private bool isPressed = false;
    public GameObject ScalePoint;
    private SpriteRenderer scaleSpriteRenderer;
    private ScalePoint scaleScript;

    private int colliderCount = 0;

    void Start()
    {
        parentSpriteRenderer = GetComponentInParent<SpriteRenderer>();
        parentSpriteRenderer.sprite = notPressedSprite;
        scaleSpriteRenderer = ScalePoint.GetComponent<SpriteRenderer>();
        scaleScript = ScalePoint.GetComponent<ScalePoint>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (parentSpriteRenderer != null)
        {
            colliderCount++;

            if (colliderCount == 1)
            {
                //sfx
                //AudioManager.Instance.PlaySFX("Button");
                SetButtonState(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (parentSpriteRenderer != null)
        {
            colliderCount--;

            if (colliderCount == 0)
            {
                SetButtonState(false);
            }
        }
    }

    private void SetButtonState(bool pressed)
    {
        if (pressed)
        {
            parentSpriteRenderer.sprite = pressedSprite;
            scaleScript.ActiveSprite();
            isPressed = true;
        }
        else
        {
            parentSpriteRenderer.sprite = notPressedSprite;
            scaleScript.InactiveSprite();
            isPressed = false;
        }
    }

    public bool IsPressed()
    {
        return isPressed;
    }
}
