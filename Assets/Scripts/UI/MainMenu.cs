using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    public void FadeToSongSelection()
    {
        animator.SetTrigger("Fade_Out_Song_Selection");
    }

    public void PlayGame() 
    {
        SceneManager.LoadScene("Song Selection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
