using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreSave : MonoBehaviour
{
    string fileName = "highscore.data";
    public ScoreLoad scoreloader;

    public Text recentScore;

    List<int> HighScore; //Declare here in proper position
    int ScoreAmount; //Declaring in start was always 0


    public void Start()
    {
        recentScore = GameObject.Find("Canvas/Score").GetComponent<Text>();
        StreamReader sr = new StreamReader("scoreTemp.data"); //sr = streamreader
        HighScore = new List<int>();
        ScoreAmount = int.Parse(sr.ReadLine());
        recentScore.text = "Your score: " + ScoreAmount;
        sr.Close();
        SaveScore();
    }

    // Start is called before the first frame update
    public void SaveScore()
    {
        for (int i = 0; i < scoreloader.CompareScore.Count; i++)
        {
            HighScore.Add(scoreloader.CompareScore[i]);
        }
        
        StreamWriter OurFile = File.CreateText(fileName);

        for (int i = 0; i < HighScore.Count; i++)
        {
            if (ScoreAmount > HighScore[i])
            { 
                HighScore.Insert(i, ScoreAmount); 
                break;
            }
        }
        
        while (HighScore.Count > 5)
        {
            HighScore.RemoveAt(5);
        }

        for (int i = 0; i < HighScore.Count; i++)
        {  
            OurFile.WriteLine(HighScore[i]);
        }
        OurFile.Close();
        scoreloader.UpdateScore(); //Update in display
    }

}
