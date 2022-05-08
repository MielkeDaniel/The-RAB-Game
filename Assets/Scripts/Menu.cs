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
        SceneManager.LoadScene(1);
    }

    public void StartLevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void StartLevelThree()
    {
        SceneManager.LoadScene(3);
    }

    //exit the game by clicking quit button
    public void QuitGame()
    {
        Application.Quit();
    }

}