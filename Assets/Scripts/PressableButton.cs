using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressableButton : MonoBehaviour
{
    [SerializeField] private Vector3 checkpointPosition; 

    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("Button")) {
            GameManager.instance.setCheckpoint(checkpointPosition);
        }
    }

}
