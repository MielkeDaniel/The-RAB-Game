using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{

    public Image[] hearts;
    private int lifes = 3;
    private int impulseStrength = 35;
    public GameObject destroyed;
    private GameObject GameWon;

    void Start() {
        GameWon = GameObject.Find("GameWon");
        GameWon.SetActive(false);
    }

    //When the player collides with the enemy with enough force the enemy loses a life, 
    //if the enemy has no lifes left a destroyed version gets instantiated and the old enemy gets deleted from the scene
    //also the GameWon Canvas gets activated
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && ImpulseTest(collision)) {
            lifes--;
            if(lifes == 0) {
                Instantiate(destroyed, transform.position, transform.rotation);
                Destroy(this.gameObject);
                GameManager.instance.finalBossHighscoreCheck();
                GameManager.instance.stopTimer();
                GameWon.SetActive(true);
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

    //This function tests if the collision had the required force and returns true or false
    //For that it adds up the absolute value of every impulse direction
    private bool ImpulseTest(Collision collision) {
        float collisionStrength = Mathf.Abs(collision.impulse.x) + Mathf.Abs(collision.impulse.y) + Mathf.Abs(collision.impulse.z);
        if(collisionStrength > impulseStrength) {
            return true;
        } else {
            return false;
        }
    }
}
