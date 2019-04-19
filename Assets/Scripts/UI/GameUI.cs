using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour 
{
    public HealthBar healthBar;

    public GameObject pauseScreen;
    public GameObject optionScreen;
    public GameObject winScreen;

    void Start()
    {
        SongManager.songCompletedEvent += YouWin;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionScreen.activeSelf && !SongManager.paused)
        {
            if (!SongManager.paused)
            {
                PauseOnKeyPress();
            }
            else
            {
                ResumeOnKeyPress();
            }
        }
    }

    public void PauseOnKeyPress()
    {
        pauseScreen.SetActive(true);

        SongManager.paused = true;
    }

    public void ResumeOnKeyPress()
    {
        pauseScreen.SetActive(false);

        SongManager.paused = false;
    }

    void YouWin() 
    {
        winScreen.SetActive(true);
    }
}