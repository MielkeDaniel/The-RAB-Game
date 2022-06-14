/*
 * This menu is used at the start scene and after a level is completed.
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //load next scene after a level is completed or after game started
    public void StartLevelOne()
    {
        GameManager.instance.resetLifesAndHealth();
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