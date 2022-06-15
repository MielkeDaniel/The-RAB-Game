/*
 * This script communicates with the LevelManager and is responsible for loading certain scenes
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartLevelOne()
    {
        LevelManager.instance.StartLevelOne();
    }

    public void StartTutorial()
    {
        LevelManager.instance.StartTutorial();
    }

    public void StartFinalBoss()
    {
        LevelManager.instance.StartFinalBoss();
    }

    public void MainMenu() {
        LevelManager.instance.MainMenu();
    }

    //exit the game by clicking quit button
    public void QuitGame()
    {
        Application.Quit();
    }
}