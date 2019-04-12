using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SongManager : MonoBehaviour
{
    public enum Rank {PERFECT, GOOD, OKAY, MISS};

    public delegate void OnHitAction(int trackNumber, Rank rank);
    public static event OnHitAction onHitEvent;

    public float[] spawnPosX;
    public float startPosY;
    public float endPosY;
    public float removePosY;
    public float perfectRankYBegin;
    public float perfectRankYEnd;
    public float goodRankYBegin;
    public float goodRankYEnd;
    public float okayRankYBegin;
    public float okayRankYEnd;
    public static float bpm;
    // the current position of the song in seconds
    public static float songPosition;
    // the current position of the song in beats
    public static float songPosInBeats;
    // the duration of a beat (better known as a crotchet)
    public static float secPerBeat;
    // number of of beats/notes shown on screen
    public static float beatsShownOnScreen = 5f;

    public GameHandler healthUpdate;

    public SongInfo songInfo;
    private SongInfo.Track[] tracks;
    // how much time has passed since the song started
    private float dspTimeSong;
    // the actual song / audio source
    private AudioSource song;
    private Queue<MusicNoteController>[] queueForTracks;
    // index for each track
    private int[] trackNextIndices;
    private int length;

    public GameObject perfectPop;


    void PlayerInput(int trackNumber)
    {
        if (queueForTracks[trackNumber].Count != 0)
        {
            MusicNoteController frontNote = queueForTracks[trackNumber].Peek();

            float noteHitPos = Mathf.Abs(frontNote.gameObject.transform.position.y - endPosY);

            if (noteHitPos < perfectRankYBegin && noteHitPos > perfectRankYEnd)
            {
                frontNote.Perfect();

                if (onHitEvent != null)
                {
                    onHitEvent(trackNumber, Rank.PERFECT);
                }
                if (perfectPop)
                {
                    perfectPop.SetActive(true);
                }

                queueForTracks[trackNumber].Dequeue();
            }
            else if (noteHitPos < goodRankYBegin && noteHitPos > goodRankYEnd)
            {
                frontNote.Good();

                if (onHitEvent != null)
                {
                    onHitEvent(trackNumber, Rank.GOOD);
                }

                queueForTracks[trackNumber].Dequeue();
            }
            else if (noteHitPos < okayRankYBegin && noteHitPos > okayRankYEnd)
            {
                frontNote.Okay();

                if (onHitEvent != null)
                {
                    onHitEvent(trackNumber, Rank.OKAY);
                }

                queueForTracks[trackNumber].Dequeue();
            }
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        // listens to player input
        PlayerInputController.inputtedEvent += PlayerInput;

        bpm = songInfo.bpm;
        secPerBeat = 60f / bpm;

        length = spawnPosX.Length;
        trackNextIndices = new int[length];
        queueForTracks = new Queue<MusicNoteController>[length];
        for (int i = 0; i < length; i++)
        {
            trackNextIndices[i] = 0;
            queueForTracks[i] = new Queue<MusicNoteController>();
        }

        tracks = songInfo.tracks;

        // songInfo from UI selection
        song = GetComponent<AudioSource>();
        song.clip = songInfo.song;

        dspTimeSong = (float)AudioSettings.dspTime;

        song.Play();
    }

    // Update is called once per frame
    public void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspTimeSong) * song.pitch - songInfo.songOffset;

        songPosInBeats = songPosition / secPerBeat;

        // check if we need to instantiate new prefabs of notes
        float notesToShow = (songPosition / secPerBeat) + beatsShownOnScreen;

        // for loop to iterate through the tracks to spawn more music notes
        for (int i = 0; i < length; i++)
        {
            int nextIndex = trackNextIndices[i];
            SongInfo.Track currentTrack = tracks[i];

            if (nextIndex < currentTrack.notes.Length && currentTrack.notes[nextIndex].note < notesToShow)
            {
                SongInfo.Note currentNote = currentTrack.notes[nextIndex];

                MusicNoteController musicNote = MusicNotePool.instance.CreateAndGetNote(spawnPosX[i], startPosY, endPosY, removePosY, 0, currentNote.note);

                queueForTracks[i].Enqueue(musicNote);

                trackNextIndices[i]++;
            }
        }

        // loop the queue to check if any of the notes reached the finish line
        for (int i = 0; i < length; i++)
        {
            if (queueForTracks[i].Count == 0)
            {
                continue;
            }

            MusicNoteController currentNote = queueForTracks[i].Peek();

            if (currentNote.transform.position.y <= endPosY - goodRankYEnd)
            {
                queueForTracks[i].Dequeue();

                if (onHitEvent != null)
                {
                    onHitEvent(i, Rank.MISS);
                }
            }
        }
    }

    private void OnDestroy() 
    {
        PlayerInputController.inputtedEvent -= PlayerInput;
    }
}