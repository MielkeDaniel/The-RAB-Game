using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressableButton : MonoBehaviour
{
    [SerializeField] private Vector3 checkpointPosition; 
    private bool isChecked = false;

    //This function checks if the Button has collided with the Trigger
    //When the Button collides with the Trigger for the first time a sound is played, the color gets changed and a Checkpoint is set
    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("Button")) {
            if (!isChecked) {
                SFXManager.instance.playButtonSound();
                collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
                GameManager.instance.setCheckpoint(checkpointPosition);
                isChecked = true;
            }
        }
    }
}
