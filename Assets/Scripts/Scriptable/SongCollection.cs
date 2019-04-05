using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Song Collection")]
public class SongCollection : ScriptableObject
{
    public SongSet[] songSets;

    [System.Serializable]
    public class SongSet
    {
        public SongInfo easy;
        public SongInfo normal;
        public SongInfo hard;
    }
}