using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class albumCover : MonoBehaviour
{
    public SongInfo songInfo;
    public GameObject album;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = songInfo.songImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
