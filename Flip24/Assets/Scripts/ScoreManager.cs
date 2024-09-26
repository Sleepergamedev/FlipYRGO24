using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    ValueManager valueManagerScript;
    public int finalScore;
    public int styleFactor;
    HighScoreManager highScoreManager;
    UIManagerMainScene mainSceneUi;

    bool showingScore;
    void Start()
    {
        styleFactor = 1;
        valueManagerScript = FindFirstObjectByType<ValueManager>();
        highScoreManager = FindFirstObjectByType<HighScoreManager>();
        mainSceneUi = FindFirstObjectByType<UIManagerMainScene>();
    }

    void Update()
    {
        if (valueManagerScript.isGameOver && !showingScore)
        {
            showingScore = true;
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
        finalScore = valueManagerScript.metresFlown * styleFactor;
        highScoreManager.LogHighScore(finalScore);
        mainSceneUi.ScoreBoardScore(finalScore);
        Debug.Log(styleFactor);
        Debug.Log("your final score is: " + finalScore);
    }
}
