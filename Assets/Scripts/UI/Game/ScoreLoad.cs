using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreLoad : MonoBehaviour
{
    string fileName = "highscore.data";
    string ScoreLoads;
    public Text HighScoreText1;
    public Text HighScoreText2;
    public Text HighScoreText3;
    public Text HighScoreText4;
    public Text HighScoreText5;

    string line;

    public List <int> CompareScore;
    // Start is called before the first frame update
    void Awake()
    {
        init_text();
        List<string> Line = new List<string> (); 
        StreamReader sr = new StreamReader(fileName); //sr = streamreader
        line = sr.ReadLine();
        while (line != null)
        {
            //Line will be first line in .data file
            Line.Add(line);    
            ScoreLoads = line;
            line = sr.ReadLine();
        }
        sr.Close();

        if (Line.Count > 0)
            HighScoreText1.text = Line[0];
        if (Line.Count > 1)
            HighScoreText2.text = Line[1];
        if (Line.Count > 2)
            HighScoreText3.text = Line[2];
        if (Line.Count > 3)
            HighScoreText4.text = Line[3];
        if (Line.Count > 4)
            HighScoreText5.text = Line[4];

        //CompareScore = int.Parse(ScoreLoads); //converting str to int and sent to comparescore
        CompareScore.Add(int.Parse(HighScoreText1.text)); //.text str val convert
        CompareScore.Add(int.Parse(HighScoreText2.text)); //.text str val convert
        CompareScore.Add(int.Parse(HighScoreText3.text)); //.text str val convert
        CompareScore.Add(int.Parse(HighScoreText4.text)); //.text str val convert
        CompareScore.Add(int.Parse(HighScoreText5.text)); //.text str val convert

    }

    public void UpdateScore()
    {
        Awake();
    }

    void init_text()
    {
        HighScoreText1 = GameObject.Find("HighScoreList/HighScore1").GetComponent<Text>();
        HighScoreText2 = GameObject.Find("HighScoreList/HighScore2").GetComponent<Text>();
        HighScoreText3 = GameObject.Find("HighScoreList/HighScore3").GetComponent<Text>();
        HighScoreText4 = GameObject.Find("HighScoreList/HighScore4").GetComponent<Text>();
        HighScoreText5 = GameObject.Find("HighScoreList/HighScore5").GetComponent<Text>();
    }
}
