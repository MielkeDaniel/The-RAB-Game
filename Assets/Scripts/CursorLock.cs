using UnityEngine;

public class CursorLock : MonoBehaviour
{

    private bool cursorLocked;
    void Start()
    {
        cursorLocked = false;
    }

    void OnGui()
    {
        if(!cursorLocked){
            cursorLocked = true;
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}