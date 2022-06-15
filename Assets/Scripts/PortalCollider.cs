using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollider : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z; 

    // Transform the player to the given coordinates when the player enters/collides with the portal
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {
            SFXManager.instance.playTeleportSound();
            collider.gameObject.transform.position = new Vector3(x, y, z);
        }
    }
}
