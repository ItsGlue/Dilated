using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Sprite notPressedSprite;
    public Sprite pressedSprite;

    private SpriteRenderer parentSpriteRenderer;
    private bool isPressed = false;
    public GameObject ScalePoint;
    private ScalePoint scaleScript;

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
            parentSpriteRenderer.sprite = pressedSprite;
            //sfx
            AudioManager.Instance.PlayMusic("AppleTree");
            isPressed = true;
            scaleScript.ActiveSprite();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (parentSpriteRenderer != null)
        {
            parentSpriteRenderer.sprite = notPressedSprite;
            isPressed = false;
            scaleScript.InactiveSprite();
        }
    }

    public bool IsPressed()
    {
        return isPressed;
    }
}
