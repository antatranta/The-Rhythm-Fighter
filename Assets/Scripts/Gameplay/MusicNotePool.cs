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
            GameObject note = (GameObject) Instantiate(notePrefab);

            note.SetActive(false);

            noteList.Add(note.GetComponent<MusicNoteController>());
        }
    }

    public MusicNoteController CreateAndGetNote(float startPosX, float startPosY, float endPosY, float removePosY, float startPosZ, float noteBeat)
    {
        // check if there is an inactive instance
		foreach (MusicNoteController note in noteList)
		{
			if (!note.gameObject.activeInHierarchy)
			{
				note.Initialize(startPosX, startPosY, endPosY, removePosY, startPosZ, noteBeat);
				note.gameObject.SetActive(true);
                
				return note;
			}
		}

		// no inactive instance, so insantiate a new GetComponent
		MusicNoteController musicNote = ((GameObject) Instantiate(notePrefab)).GetComponent<MusicNoteController>();

		musicNote.Initialize(startPosX, startPosY, endPosY, removePosY, startPosZ, noteBeat);
		noteList.Add(musicNote);

		return musicNote;
    }
}
