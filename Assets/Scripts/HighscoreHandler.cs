using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreHandler : MonoBehaviour
{

    GameObject highscore;
    GameObject menu;
    public Text highscoreText;
    float highscoreFloat;

    void Start() {
        highscore = GameObject.Find("Highscore");
        menu = GameObject.Find("Menu");
        highscore.SetActive(false);
        //Gets the current highscore from the PlayerPrefs and saves it in a float
        highscoreFloat = PlayerPrefs.GetFloat("Highscore");

        //Transforms the highscoreFloat in a more readable string
        float minutes = Mathf.FloorToInt(highscoreFloat / 60);
        float seconds = Mathf.FloorToInt(highscoreFloat % 60);
        float milliseconds = highscoreFloat % 1 * 100;
        
        //Checks if the player has completed the game before
        if(highscoreFloat != 0) {
            highscoreText.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }

    //sets the Menu canvas inactive and the highscore canvas active
    public void OpenHighscore() {
        menu.SetActive(false);
        highscore.SetActive(true);
    }

    //sets the menu canvas active and the highscore canvas inactive
    public void CloseHighscore() {
        highscore.SetActive(false);
        menu.SetActive(true);
    }

}
