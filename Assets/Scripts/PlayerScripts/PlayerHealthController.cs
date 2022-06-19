using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


// This script is attached to the player and is responsible to manage 
// the player's health and lifecount when being damaged by several sources
public class PlayerHealthController : MonoBehaviour
{
    public Slider slider;
    private int lifes = 3;
    private int health = 100;
    public Image[] hearts;
    GameObject GameOver;
    public Image fadeImage;

    // Start is called before the first frame update and sets the slider´s value to 100, which equals 100% and initializes the lifecount
    void Start() {
        slider.value = health;
        this.initLifeCount();
        GameOver = GameObject.Find("GameOver");
        GameOver.SetActive(false);
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
    }

    // The hearts array is filled with images, which are used to display the player's lifecount in the hud 
    // The image API contains an enabled property, which is used to display the heart or not
    // For each index of the hearts array, the enabled property will be set to true or false, depending on the value of the lifes variable (1, 2 or 3) 
    public void initLifeCount () { 
        for(int i = 0; i < hearts.Length; i++) {
            if(i < lifes) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    // This function handles the case, when the palyer dies (falls in the water or it´s health is reduced to 0)
    private void resetPlayer() {
        // In case the player has lifes left, the palyer will respawn on the last checkpoint with 100 health back but loses a life
        if (lifes > 1) {
            GameManager.instance.respawnOnCheckpoint();
            lifes--;
            health = 100;
            slider.value = health;
            StartCoroutine(fade());
            this.initLifeCount();
        } else {
            // In case the player has no lifes left, the scene will be reloaded all the way and the player has to redo all his progress
            lifes = 3;
            health = 100;
            Time.timeScale = 0;
            GameManager.instance.respawnOnCheckpoint();
            GameOver.SetActive(true);
        }
    }

    //This function slowly sets the alpha of a black Image to 1 and then back to 0 to generate a fading animation when the player dies
    private IEnumerator fade() {
        float alpha = 0f;
        while(fadeImage.color.a < 1) {
            alpha += Time.deltaTime;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
        }

        while(fadeImage.color.a > 0) {
            alpha -= Time.deltaTime;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }
    }

    // The fire´s particle system spawns many particles - each of them contains a collider and has the "fire"-tag 
    // Each collision will reduce the player´s health by 2 LP, in case the player has less than 3 LP, the palyer will die
    void OnParticleCollision(GameObject other) {
        if(other.tag == "Fire") {
             if (health > 3) {
                health -= 2;
                // set the slider´s value to the current health
                slider.value = health;
            } else {
                this.resetPlayer();
            }
        }
    }

    // Collecting the heart will increase the player´s health by 80 LP and the heart object will be removed from the scene
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Heart")) {
            this.health += 80;
            slider.value = health;
            SFXManager.instance.playHeartPickup();
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("LifePickup")) {
            this.lifes += 1;
            this.initLifeCount();
            SFXManager.instance.playHeartPickup();
            Destroy(other.gameObject);
        }
    }


    // Colliding with an arrow will cause the palyer to loose 80LP will die in case he has less than 80LP
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Arrow")) {
            if (health - 80 >= 1) {
                health -= 50;
                slider.value = health;
            } else {
                this.resetPlayer();
            }
        }

    // In case the player falls into the water, he will die
    if (collision.gameObject.CompareTag("Water")) {
            this.resetPlayer();
        }
    }

}