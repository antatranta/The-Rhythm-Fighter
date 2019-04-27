using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class albumCover : MonoBehaviour
{
    public SongInfo songInfo;
    Image image;
    public Sprite aka;
    public Sprite woodsImage;
    public Sprite stormsImage;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    public void akaImage()
    {
        image.sprite = aka;
        image.enabled = true;
    }

    public void lostWoods()
    {
        image.sprite = woodsImage;
        image.enabled = true;
    }

    public void songOfStorms()
    {
        image.sprite = stormsImage;
        image.enabled = true;
    }

    public void mouseOff()
    {
        image.sprite = null;
        image.enabled = false;
    }
}
