using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    // Reference to the parent button's ButtonSwitch script
    private ButtonSwitch buttonSwitch;

    void Start()
    {
        // Get the ButtonSwitch script from the parent object
        buttonSwitch = GetComponentInParent<ButtonSwitch>();

        if (buttonSwitch == null)
        {
            Debug.LogError("ButtonSwitch script not found on parent!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Notify the parent that the child trigger is activated
        if (buttonSwitch != null)
        {
            buttonSwitch.SetPressed(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Notify the parent that the child trigger is deactivated
        if (buttonSwitch != null)
        {
            buttonSwitch.SetPressed(false);
        }
    }
}
