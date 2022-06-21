using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreHandler : MonoBehaviour
{

    GameObject highscore;
    GameObject menu;
    public Text stageOneText;
    public Text finalBossText;
    float stageOneHsFloat;
    float finalBossHsFloat;

    void Start() {
        highscore = GameObject.Find("Highscore");
        menu = GameObject.Find("Menu");
        highscore.SetActive(false);
        //Gets the current highscore from the PlayerPrefs and saves it in a float
        stageOneHsFloat = PlayerPrefs.GetFloat("stageOneHs");

        setHighscore(stageOneHsFloat, stageOneText);

    //----------------------------------------------
        finalBossHsFloat = PlayerPrefs.GetFloat("finalBossHs");

        setHighscore(finalBossHsFloat, finalBossText);
    }

    private void setHighscore(float time, Text highscoreText) {
        //Transforms the stageOneHsFloat in a more readable string
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = time % 1 * 100;
        
        //Checks if the player has completed the game before
        if(time != 0) {
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
