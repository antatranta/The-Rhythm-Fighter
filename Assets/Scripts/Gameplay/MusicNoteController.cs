using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoteController : MonoBehaviour
{
    public SpriteRenderer noteSprite;
    private float startPosY;
    private float endPosY;
    private float removePosY;
    private float noteBeat;
    //private bool paused;

    // Start is called before the first frame update
    public void Initialize(float startPosX, float startPosY, float endPosY, float removePosY, float startPosZ, float noteBeat)
    {
        this.startPosY = startPosY;
        this.endPosY = endPosY;
        this.removePosY = removePosY;
        this.noteBeat = noteBeat;

        //paused = false;

        // set position of the note
        transform.position = new Vector3(startPosX, startPosY, startPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, startPosY + (endPosY - startPosY) * (1f - (noteBeat - SongManager.songPosInBeats) / SongManager.beatsShownOnScreen), transform.position.z);

        // remove itself when out of screen aka completely miss
        if (transform.position.y < removePosY)
        {
            gameObject.SetActive(false);
        }
    }

    public void Perfect()
    {
        gameObject.SetActive(false);
    }

    public void Good()
    {
        gameObject.SetActive(false);
    }

    public void Okay()
    {
        gameObject.SetActive(false);
    }

    public void Miss()
    {
        gameObject.SetActive(false);
    }
}
