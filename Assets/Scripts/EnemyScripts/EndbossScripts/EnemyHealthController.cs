using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{

    public Image[] hearts;
    private int lifes = 3;
    private int impulseStrength = 35;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && ImpulseTest(collision)) {
            lifes--;
            if(lifes == 0) {
                Destroy(this.gameObject);
            }
            for(int i = 0; i < hearts.Length; i++) {
                if(i < lifes) {
                    hearts[i].enabled = true;
                } else {
                    hearts[i].enabled = false;
                }
         }
         
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
