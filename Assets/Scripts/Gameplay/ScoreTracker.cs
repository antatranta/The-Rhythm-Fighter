using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    static float Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    static float getScore()
    {
        return Score;
    }

    static void resetScore()
    {
        Score = 0;
    }

    static void changeScore(float changeInScore)
    {
        Score += changeInScore;
    }
}
