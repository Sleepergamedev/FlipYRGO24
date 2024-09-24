using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    ValueManager valueManagerScript;
    public float finalScore;
    private float styleFactor;
    void Start()
    {
        valueManagerScript = FindFirstObjectByType<ValueManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CalculateJudgeScore();
        }
    }

    void CalculateJudgeScore()
    {
        if (valueManagerScript.isFlipped180 == true)
        {
            styleFactor = 1.5f;
        }
        if (valueManagerScript.isFlipped270 == true || valueManagerScript.isFlipped90 == true)
        {
            styleFactor = 5f;
        }
        else
        {
            styleFactor = 1f;
        }
        finalScore = valueManagerScript.metresFlown * styleFactor;
        Debug.Log("your final score is: " + finalScore);
    }
}
