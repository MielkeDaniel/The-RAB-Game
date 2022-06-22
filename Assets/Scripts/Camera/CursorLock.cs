using UnityEngine;

public class CursorLock : MonoBehaviour
{

    void Start()
    {
        GameManager.instance.cursorLocked = true;
        GameManager.instance.lockCursor();
    }

    // New Inputsystem-Button: E 
    // If the button was pressed, the cursor will be locked or unlocked depending on the current state of "cursorLocked" 
    void OnGui()
    {
        if(!GameManager.instance.cursorLocked) {
            GameManager.instance.cursorLocked = true;
            GameManager.instance.lockCursor();
        } else {
            GameManager.instance.cursorLocked = false;
            GameManager.instance.unLockCursor();
        }
    }
}