using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public Slider slider;
    private int lifes = 3;
    private int health = 100;
    public Image[] hearts;

    void Start() {
        slider.value = health;
        GameManager.instance.initLifeCount(hearts, health);
    }

    private void resetPlayer() {
        if (lifes > 1) {
            GameManager.instance.respawnOnCheckpoint();
            lifes--;
            health = 100;
            slider.value = health;
            GameManager.instance.initLifeCount(hearts, lifes);
        } else {
            lifes = 3;
            health = 100;
            GameManager.instance.resetScene();
        }
    }

    void OnParticleCollision(GameObject other) {
        if(other.tag == "Fire") {
             if (health > 2) {
                health -= 2;
                slider.value = health;
            } else {
                this.resetPlayer();
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Heart")) {
            this.health += 80;
            slider.value = health;
            SFXManager.instance.playHeartPickup();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Arrow")) {
            if (health - 80 >= 1) {
                health -= 80;
                slider.value = health;
            } else {
                this.resetPlayer();
            }
        }

        if (collision.gameObject.CompareTag("Water")) {
            this.resetPlayer();
        }
    }

}