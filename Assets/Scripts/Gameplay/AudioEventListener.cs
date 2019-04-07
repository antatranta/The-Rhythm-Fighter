using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AudioEventListener : MonoBehaviour
{
     public string fileName;
     
     private string path;
     private List<float> songTimes;
     private List<float> beatTimes;

    void CreateText()
    {
        path = Application.dataPath + "/" + fileName + ".txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, fileName + "\n\n");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        songTimes = new List<float>();
        beatTimes = new List<float>();
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space))
        {
            //string beatTiming = "Song position in seconds: " + SongManager.songPosition + " Beat inputted: " + SongManager.songPosInBeats + "\n";
            //File.AppendAllText(path, beatTiming);
            songTimes.Add(SongManager.songPosition);
            beatTimes.Add(SongManager.songPosInBeats);
        }
    }

    private void OnDestroy() 
    {
        for (int i = 0; i < songTimes.Count; i++)
        {
            File.AppendAllText(path, "Song position in seconds: " + songTimes[i] + " Beat inputted: " + beatTimes[i] + "\n");
        }
    }
}
