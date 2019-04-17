using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPops : MonoBehaviour
{
    public GameObject perfectStroke;
    Text text; 
    // Start is called before the first frame update
    void Start()
    {
        SongManager.onHitEvent += showPopup;
        text = GetComponent<Text>();
        text.enabled = false;
    }

    void showPopup(int trackNumber, SongManager.Rank rank)
    {
        if (rank == SongManager.Rank.PERFECT)
        {
            text.text = "Perfect!";
            text.enabled = true;
        }
        else if (rank == SongManager.Rank.GOOD)
        {
            text.text = "Good!";
            text.enabled = true;
        }
        else if (rank == SongManager.Rank.OKAY)
        {
            text.text = "Okay!";
            text.enabled = true;
        }
        else if (rank == SongManager.Rank.MISS)
        {
            text.text = "Missed!";
            text.enabled = true;
        }
    }

    void Update()
    {
        text.enabled = false;
    }
}
