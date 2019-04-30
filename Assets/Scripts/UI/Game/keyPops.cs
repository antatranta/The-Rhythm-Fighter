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
            text.text = "PERFECT!";
            text.enabled = true;
        }
        else if (rank == SongManager.Rank.GOOD)
        {
            text.text = "GOOD!";
            text.enabled = true;
        }
        else if (rank == SongManager.Rank.OKAY)
        {
            text.text = "OKAY!";
            text.enabled = true;
        }
        else if (rank == SongManager.Rank.MISS)
        {
            text.text = "MISS!";
            text.enabled = true;
            
        }

        StartCoroutine(PopUpDelay());
    }

    IEnumerator PopUpDelay()
    {
        yield return new WaitForSecondsRealtime(1);
        text.enabled = false;
    }

    void OnDestroy() {
        SongManager.onHitEvent -= showPopup;
    }
}
