using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class songSelection : MonoBehaviour
{
    public SongInfo songInfo;
    
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = songInfo.songTitle;
    }
}
