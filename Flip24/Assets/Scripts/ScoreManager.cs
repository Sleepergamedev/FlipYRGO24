using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    ValueManager valueManagerScript;
    public int finalScore;
    private int styleFactor;
    HighScoreManager highScoreManager;
    void Start()
    {
        valueManagerScript = FindFirstObjectByType<ValueManager>();
        highScoreManager = FindFirstObjectByType<HighScoreManager>();
    }

    void Update()
    {
        if (valueManagerScript.isGameOver)
        {
            CalculateJudgeScore();
        }
    }

    void CalculateJudgeScore()
    {
        if (valueManagerScript.isFlipped180 == true)
        {
            styleFactor = 5;
        }
        if (valueManagerScript.isFlipped270 == true || valueManagerScript.isFlipped90 == true)
        {
            styleFactor = 5;
        }
        else
        {
            styleFactor = 1;
        }
        finalScore = valueManagerScript.metresFlown * styleFactor;
        highScoreManager.LogHighScore(finalScore); 

        Debug.Log("your final score is: " + finalScore);
    }
}
