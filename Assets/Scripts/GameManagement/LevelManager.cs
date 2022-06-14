using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    public void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        SceneManager.LoadScene(1);
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void StartLevelOne()
    {
        SceneManager.LoadScene(3);
    }

    public void StartFinalBoss()
    {
        SceneManager.LoadScene(4);
    }


    public void MainMenu() {
        SceneManager.LoadScene(1);
    }

    //exit the game by clicking quit button
    public void QuitGame()
    {
        Application.Quit();
    }
}
