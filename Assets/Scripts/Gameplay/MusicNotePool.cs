using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An object pool for music notes
public class MusicNotePool : MonoBehaviour
{
    public static MusicNotePool instance;
    public GameObject notePrefab;
    public int initialAmount;
    private List<MusicNoteController> noteList;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        noteList = new List<MusicNoteController>();

        for (int i = 0; i < initialAmount; i++)
        {
            GameObject obj = Instantiate(notePrefab);

            obj.SetActive(false);

            noteList.Add(obj.GetComponent<MusicNoteController>());
        }
    }

    public MusicNoteController GetNote(float startPosX, float startPosY, float endPosY, float removePosY, float startPosZ, float noteBeat)
    {
        foreach (MusicNoteController note in noteList)
        {
            if (note.gameObject.activeInHierarchy)
            {
                note.Initialize(startPosX, startPosY, endPosY, removePosY, startPosZ, noteBeat);
                note.gameObject.SetActive(true);

                return note;
            }
        }

        MusicNoteController musicNote = (Instantiate(notePrefab)).GetComponent<MusicNoteController>();
        musicNote.Initialize(startPosX, startPosY, endPosY, removePosY, startPosZ, noteBeat);

        noteList.Add(musicNote);

        return musicNote;
    }
}
