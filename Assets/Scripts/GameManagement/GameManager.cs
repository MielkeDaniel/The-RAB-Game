using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

// This class manages the game state and is reachable from everywhere as a singleton 
// and will not be destroyed when a new scene loades

// The class will have access to the Player gameobject as it is also responsible for respawning the player on a checkpoint in the game 
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

    // Set checkpoint coordinates
    public void setCheckpoint(Vector3 checkpoint) {
        this.checkPoint = checkpoint;
    }

    // set the current player instance (called once each scene load in the start method if the player object)
    public void setPlayer(Rigidbody player) {
        this.playerRb = player;
    }

    // respawn the player at the checkpoint
    public void respawnOnCheckpoint() {
        playerRb.velocity = Vector3.zero;
        playerRb.transform.position = checkPoint;
    }

    // the countTimer is needed in the gamemanager, as it manages and stores the high scores from all the runs
    public void countTimer(Text timerText) { 
        // time starts at 0 and add´s up each frame using time.deltatime
        time += Time.deltaTime;

        // convert the time to readable format in minutes, seconds and milliseconds
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = time % 1 * 100;
        
        // display the time in the HUD
        timerText.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    // resets the timer value to 0
    public void resetTimer() { 
        this.time = 0;
    }

    // reload the current scene
    public void resetScene() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
