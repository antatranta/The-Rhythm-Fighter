using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SongManager : MonoBehaviour
{
    public float bpm;
    public float songPosition;
    public float songPosInBeats;
    public float secPerBeat;
    private float dspTimeSong;
    private float offset = 0.2f;

    // Start is called before the first frame update
    public void Start()
    {
        secPerBeat = 60f / bpm;

        dspTimeSong = (float)AudioSettings.dspTime;

        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    public void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspTimeSong) - offset;

        songPosInBeats = songPosition / secPerBeat;
    }
}