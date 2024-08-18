using UnityEngine;

public class RotateOnHover : MonoBehaviour
{
    public float hoverRotationSpeed = 90f;
    public float clickRotationSpeed = 180f;
    public float alignRotationSpeed = 180f;
    private bool isHovering = false;
    private bool isClicking = false;
    private bool aligningRotation = false;
    private Quaternion targetRotation;

    void Update()
    {
        if (isClicking)
        {
            transform.Rotate(Vector3.forward, clickRotationSpeed * Time.deltaTime);
        }
        else if (isHovering)
        {
            transform.Rotate(Vector3.forward, hoverRotationSpeed * Time.deltaTime);
        }

        if (aligningRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, alignRotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                aligningRotation = false;
            }
        }
    }

    void OnMouseEnter()
    {
        isHovering = true;
        aligningRotation = false;
    }

    void OnMouseExit()
    {
        isHovering = false;
        if (!isClicking)
        {
            StartAligningToNearest45Plus90();
        }
    }

    void OnMouseDown()
    {
        if (isHovering)
        {
            isClicking = true;
            aligningRotation = false;
        }
    }

    void OnMouseUp()
    {
        if (isClicking)
        {
            isClicking = false;
            if (!isHovering)
            {
                StartAligningToNearest45Plus90();
            }
        }
    }

    void StartAligningToNearest45Plus90()
    {
        float zRotation = transform.eulerAngles.z;
        float nearest45Plus90 = Mathf.Round((zRotation - 45f) / 90f) * 90f + 45f;

        targetRotation = Quaternion.Euler(0, 0, nearest45Plus90);
        aligningRotation = true;
    }

    public void ChangeSprite()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite is not assigned.");
        }
    }
}
