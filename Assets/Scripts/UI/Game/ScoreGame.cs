using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGame : MonoBehaviour
{

    public int TheScore; //static var can be referenced from another script
    [SerializeField] public GameObject ScoreDisplay; //variable to display score

    //Use this for initialization
    void Start()
    {
        //Allows addscore to be repeated; function, how long to wait to add score, how often or speed 
        TheScore = 0;
        //InvokeRepeating("timeScore", 1, 0.1f);
        SongManager.onHitEvent += incrementScore;
    }

    void timeScore() //Add score continously over time (time-based)
    {
        //TheScore += 1;
        //Reference object from earlier
        ScoreDisplay.GetComponent<Text>().text = "Score: " + TheScore.ToString();
    }

    //Increment based on rank level input
    void incrementScore(int trackNumber, SongManager.Rank rank)
    {
        if (rank == SongManager.Rank.PERFECT)
        {
            TheScore += 300;
            ScoreDisplay.GetComponent<Text>().text = "Score: " + TheScore.ToString();
        }
        else if (rank == SongManager.Rank.GOOD)
        {
            TheScore += 200;
            ScoreDisplay.GetComponent<Text>().text = "Score: " + TheScore.ToString();
        }
        else if (rank == SongManager.Rank.OKAY)
        {
            TheScore += 100;
            ScoreDisplay.GetComponent<Text>().text = "Score: " + TheScore.ToString();
        }
    }

    void OnDestroy() 
    {
        SongManager.onHitEvent -= incrementScore;
    }
}