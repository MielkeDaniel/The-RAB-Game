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

    // Start is called before the first frame update
    void Start() {
        highscore = GameObject.Find("Highscore");
        menu = GameObject.Find("Menu");
        highscore.SetActive(false);
        highscoreFloat = PlayerPrefs.GetFloat("Highscore");

        float minutes = Mathf.FloorToInt(highscoreFloat / 60);
        float seconds = Mathf.FloorToInt(highscoreFloat % 60);
        float milliseconds = highscoreFloat % 1 * 100;
        
        if(highscoreFloat != 0) {
            highscoreText.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }

    public void OpenHighscore() {
        menu.SetActive(false);
        highscore.SetActive(true);
    }

    public void CloseHighscore() {
        highscore.SetActive(false);
        menu.SetActive(true);
    }

}
