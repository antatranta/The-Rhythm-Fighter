using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameUI : MonoBehaviour 
{
    public HealthHandler healthbar;
    public EnemyHealth healthbar2;

    public GameObject pauseScreen;
    public GameObject optionScreen;

    public ScoreGame score;

    void Start()
    {
        if (!File.Exists("Assets/Resources/scoreTemp.data"))
        {
            File.CreateText("Assets/Resources/scoreTemp.data");
        }
        if (!File.Exists("Assets/Resources/highscore.data"))
        {
            File.CreateText("Assets/Resources/highscore.data");
        }
    }

    void Update()
    {
        if (healthbar.health <= 0f)
        {
            YouLose();
            return;
        }
        if (healthbar2.health <= 0f)
        {
            YouWin();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !optionScreen.activeSelf && SongManager.songStarted)
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

    public void YouWin() 
    {
        FileStream fileStream = File.Open("Assets/Resources/scoreTemp.data", FileMode.Open); //Flush File 
        fileStream.SetLength(0);
        fileStream.Close();

        StreamWriter OurFile = File.CreateText("Assets/Resources/scoreTemp.data");
        OurFile.WriteLine("" + score.TheScore);
        OurFile.Close();

        SceneManager.LoadScene("WinScreen");
        return;
    }

    public void YouLose()
    {
        FileStream fileStream = File.Open("Assets/Resources/scoreTemp.data", FileMode.Open); //Flush File 
        fileStream.SetLength(0);
        fileStream.Close(); 

        StreamWriter OurFile = File.CreateText("Assets/Resources/scoreTemp.data");
        OurFile.WriteLine("" + score.TheScore);
        OurFile.Close();

        SceneManager.LoadScene("LoseScreen");
        return;
    }
}