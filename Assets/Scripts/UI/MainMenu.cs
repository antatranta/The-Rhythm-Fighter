using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene("Story");
    }

    public void PlayArcade()
    {
        SceneManager.LoadScene("Arcade");
    }

    public void QuitGame()
    {
        Debug.Log("User has quit!");
        Application.Quit();
    }
}
