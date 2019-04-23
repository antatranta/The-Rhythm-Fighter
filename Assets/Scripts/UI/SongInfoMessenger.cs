using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SongInfoMessenger : MonoBehaviour
{
    public static SongInfoMessenger Instance = null;

    [NonSerialized] public SongInfo currentSong;

    void Start()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

}
