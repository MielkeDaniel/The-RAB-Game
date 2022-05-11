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
        LevelManager.instance.StartLevelOne();
    }

    public void StartLevelTwo()
    {
        LevelManager.instance.StartLevelTwo();
    }

    public void StartLevelThree()
    {
        LevelManager.instance.StartLevelThree();
    }

    public void StartLevelFour()
    {
        LevelManager.instance.StartLevelFour();
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