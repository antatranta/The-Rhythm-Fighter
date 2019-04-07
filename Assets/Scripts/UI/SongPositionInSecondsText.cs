using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongPositionInSecondsText : MonoBehaviour
{
    public Text positionOfSong;
    // Start is called before the first frame update
    void Start()
    {
        positionOfSong.text = SongManager.songPosition.ToString("0.0000");
    }

    // Update is called once per frame
    void Update()
    {
        positionOfSong.text = SongManager.songPosition.ToString("0.0000");
    }
}
