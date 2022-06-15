using UnityEngine;

public class CursorLock : MonoBehaviour
{
    private bool cursorLocked;

    void Start()
    {
        cursorLocked = false;
    }

    // New Inputsystem-Button: E 
    // If the button was pressed, the cursor will be locked or unlocked depending on the current state of "cursorLocked" 
    void OnGui()
    {
        if(!cursorLocked) {
            cursorLocked = true;
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}