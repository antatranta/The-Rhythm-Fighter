using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioDemo : MonoBehaviour
{
    AudioSource playback;
    public AudioClip atsuku, lostWoods, songStorms, woodsSlowed;
    // Start is called before the first frame update
    void Start()
    {
        playback = GetComponent<AudioSource>();
    }

    public void atsukuDemo()
    {
        playback.clip = atsuku;
        playback.Play();
    }

    public void lostWoodsDemo()
    {
        playback.clip = lostWoods;
        playback.Play();
    }

    public void songStorm()
    {
        playback.clip = songStorms;
        playback.Play();
    }

    public void lostSlowed()
    {
        playback.clip = lostWoods;
        playback.pitch = 0.67f;
        playback.Play();
    }

    public void stopDemo()
    {
        playback.Stop();
        playback.pitch = 1f;
    }

    
}
