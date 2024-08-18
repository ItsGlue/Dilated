using UnityEngine;

public class RotateOnHover : MonoBehaviour
{
    public float hoverRotationSpeed = 90f;
    public float alignRotationSpeed = 180f;
    private bool isHovering = false;
    private bool aligningRotation = false;
    private Quaternion targetRotation;

    void Update()
    {
        if (isHovering)
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
        StartAligningToNearest45Plus90();
    }

    void StartAligningToNearest45Plus90()
    {
        float zRotation = transform.eulerAngles.z;
        float nearest45Plus90 = Mathf.Round((zRotation - 45f) / 90f) * 90f + 45f;

        targetRotation = Quaternion.Euler(0, 0, nearest45Plus90);
        aligningRotation = true;
    }
}
