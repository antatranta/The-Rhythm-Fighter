using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongTransition : MonoBehaviour
{
    public GameObject songInfoMessengerPrefab;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (SongInfoMessenger.Instance == null)
        {
            Instantiate(songInfoMessengerPrefab);
        }
    }

    public void FadeToGame(SongInfo songInfo) 
    {
        SongInfoMessenger.Instance.currentSong = songInfo;
        animator.SetTrigger("Fade_Out_Game");
    }

    public void PlaySong()
    {
        SceneManager.LoadScene("Game");
    }
}
