using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu"); // load back into main menu
    }

    public void Game()
    {
        SceneManager.LoadScene("Level 1-1"); // load back into main menu
    }

    public void Quit()
    {
        Application.Quit();
    }

}
