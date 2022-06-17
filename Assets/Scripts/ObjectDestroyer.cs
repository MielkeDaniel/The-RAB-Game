using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{

    public GameObject destroyed;
    private int impulseStrength = 35;
    
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && ImpulseTest(collision)) {
            Instantiate(destroyed, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private bool ImpulseTest(Collision collision) {
        float collisionStrength = Mathf.Abs(collision.impulse.x) + Mathf.Abs(collision.impulse.y) + Mathf.Abs(collision.impulse.z);
        if(collisionStrength > impulseStrength) {
            return true;
        } else {
            return false;
        }
    }
}
