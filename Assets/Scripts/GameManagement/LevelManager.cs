using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


// This class manages the loading of scenes and is reachable from everywhere as a singleton 
// and will not be destroyed when a new scene loades
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
