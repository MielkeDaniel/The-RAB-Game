using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private float time;
    private int lifes = 3;
    private int health = 100;
    private Vector3 checkPoint;
    private Rigidbody playerRb;
    private Image[] hearts;

    public void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    public void setHeartImgs(Image[] hearts) {
        this.hearts = hearts;
    }

    public void setCheckpoint(Vector3 checkpoint) {
        this.checkPoint = checkpoint;
    }

    public void setPlayer(Rigidbody player) {
        this.playerRb = player;
    }

    public void handleLifeCount() {
        if (lifes > 1) {
            Debug.Log("lifeloss");
            lifes--;
            health = 100;
            playerRb.velocity = Vector3.zero;
            playerRb.transform.position = checkPoint;
            this.initLifeCount(hearts);
        } else {
            resetLifesAndHealth();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



    public void countTimer(Text timerText) { 
        time += Time.deltaTime;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = time % 1 * 100;
        
        timerText.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
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
        if(health - 80 > 1) {
            health -= 80;
        } else {
            handleLifeCount();
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
