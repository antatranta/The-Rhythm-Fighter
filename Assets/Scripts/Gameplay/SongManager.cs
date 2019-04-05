using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SongManager : MonoBehaviour
{
    public static float bpm;
    // the current position of the song in seconds
    public static float songPosition;
    // the current position of the song in beats
    public static float songPosInBeats;
    // the duration of a beat (better known as a crotchet)
    public float secPerBeat;
    // how much time has passed since the song started
    private float dspTimeSong;
    private float offset = 0.2f;
    // the actual song / audio source
    private AudioSource song;
    public static float beatsShownOnScreen = 5f;

    // Start is called before the first frame update
    public void Start()
    {
        song = GetComponent<AudioSource>();

        secPerBeat = 60f / bpm;

        dspTimeSong = (float)AudioSettings.dspTime;

        song.Play();
    }

    // Update is called once per frame
    public void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspTimeSong) * song.pitch - offset;

        songPosInBeats = songPosition / secPerBeat;
    }
}