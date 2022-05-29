using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaker : MonoBehaviour
{

    public GameObject destroyed;
    private int impulseStrength = 35;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && ImpulseTest(collision)) {
            Instantiate(destroyed, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private bool ImpulseTest(Collision collision) {
        if(collision.impulse.z > impulseStrength || collision.impulse.z < -impulseStrength || collision.impulse.x > impulseStrength || collision.impulse.x < -impulseStrength || collision.impulse.y > impulseStrength || collision.impulse.y < -impulseStrength) {
            return true;
        } else {
            return false;
        }
    }
}
