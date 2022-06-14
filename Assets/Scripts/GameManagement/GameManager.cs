using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private float time = 60;
    private int lifes = 3;
    private int health = 100;

    public void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    public void countTimer(Text timerText) { 
        if(time > 0) {
            time -= Time.deltaTime;
        } else {
            time = 0;
            this.resetScene();
            handleLifeCount();
        }

        if(time <= 0) {
            time = 0;
        }
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = time % 1 * 100;
        
        timerText.text = "Time Remaining: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void resetTimer(int levelTime) { 
        this.time = levelTime;
    }

    public void resetScene() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     public void initLifeCount (Image[] hearts) { 
         for(int i = 0; i < hearts.Length; i++) {
            if(i < lifes) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
         }
     }

     public void initHealthCount (Slider slider) {
         Debug.Log(slider);
         slider.value = health;
    }

    public void fireDamageHandler () {
        if(health > 1) {
            health--;
        } else {
            handleLifeCount();
        }
     }

    public void arrowDamageHandler () {
        if(health-80 > 1) {
            health -= 80;
        } else {
            handleLifeCount();
        }
     }

    public void handleLifeCount() { 
        if (lifes > 1) {
            lifes--;
            this.health = 100;
            this.resetScene();
            }
        else {
            resetLifesAndHealth();
            if(SceneManager.GetActiveScene().name == "Tutorial") {
                LevelManager.instance.StartTutorial();
            } else {
                LevelManager.instance.StartLevelOne();
            }
        }
    }

    public void addHealth() {
        this.health += 40;
        if(this.health > 100) {
            this.health = 100;
        }
    }

    public void resetLifesAndHealth() {
        this.lifes = 3;
        this.health = 100;
    }

}
