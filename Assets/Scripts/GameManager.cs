using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private float time = 30;
    private int lifes = 3;

    public void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        SceneManager.LoadScene(1);
    }

    public void countTimer(Text timerText) { 
        if(time > 0) {
            time -= Time.deltaTime;
        } else {
            time = 0;
            this.resetScene();
        }

        if(time <= 0) {
            time = 0;
        }
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = time % 1 * 100;
        
        timerText.text = "Time Remaining: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void resetTimer() { 
        this.time = 30;
    }

    public void resetScene() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     public void initLifeCount (Text lifeCountText) { 
         lifeCountText.text = "Lifes: " +  lifes.ToString();
     }

    public void handleLifeCount() { 
        if (lifes > 1) {
            lifes--;
            this.resetScene();
            }
        else {
            this.lifes = 3;
            LevelManager.instance.StartLevelOne();
        }
    }

}
