using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaker : MonoBehaviour
{

    public GameObject destroyed;
    private int impulseStrength = 35;
    private float collisionStrength;
    
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && ImpulseTest(collision)) {
            Instantiate(destroyed, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private bool ImpulseTest(Collision collision) {
        collisionStrength = Mathf.Abs(collision.impulse.x) + Mathf.Abs(collision.impulse.y) + Mathf.Abs(collision.impulse.z);
        if(collisionStrength > impulseStrength) {
            return true;
        } else {
            return false;
        }
    }
}
