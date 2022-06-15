using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private float time;
    private Rigidbody playerRb;
    private Vector3 checkPoint;

    public void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    public void setCheckpoint(Vector3 checkpoint) {
        this.checkPoint = checkpoint;
    }

    public void setPlayer(Rigidbody player) {
        this.playerRb = player;
    }

    public void respawnOnCheckpoint() {
            playerRb.velocity = Vector3.zero;
            playerRb.transform.position = checkPoint;
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

     public void initLifeCount (Image[] hearts, int lifes) { 
         for(int i = 0; i < hearts.Length; i++) {
            if(i < lifes) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
         }
     }
}
