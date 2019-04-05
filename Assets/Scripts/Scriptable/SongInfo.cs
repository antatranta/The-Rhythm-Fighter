using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Song Information")]
public class SongInfo : ScriptableObject
{
    public AudioClip song;

    [Header("Unique Song ID")]
    public int songID;
    public int collection;
    public int songNum;
    public int difficulty;

    [Header("Song Information")]
    public string songTitle;
    public string artist;
    public string album;

    public string collectionTitle;

    [Header("Song Image")]
    public Sprite songImage;

    [Header("Gameplay Information")]
    public AudioClip[] defaultBeats;
    public float songOffset;
    public float bpm;

    [Header("Tracks of notes")]
    public Track[] tracks;

    private int totalNotes = -1;

    public int TotalNoteCount()
    {
        if (totalNotes > -1) return totalNotes;

        totalNotes = 0;
        foreach (Track track in tracks)
        {
            foreach (Note note in track.notes)
            {
                totalNotes++;
            }
        }

        return totalNotes;
    }

    [System.Serializable]
    public class Track
    {
        public Note[] notes;
    }

    [System.Serializable]
    public class Note
    {
        public float note;
    }
}
