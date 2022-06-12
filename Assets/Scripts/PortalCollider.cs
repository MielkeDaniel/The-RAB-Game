using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollider : MonoBehaviour
{
    public float x;
    public float y;
    public float z; 

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {
            collider.gameObject.transform.position = new Vector3(x, y, z);
        }
    }
}
