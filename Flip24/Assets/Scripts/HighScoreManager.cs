using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public int maxHighScores = 5;
    ScoreManager scoreManager;

    bool scoreLogged;
    int newScore; 

    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        nameInputField.onEndEdit.AddListener(OnNameInput);
        
    }

   

    public void LogHighScore(int score)
    {
        Debug.Log(score); 
        int lowestHighScore = int.MaxValue;
        bool hasExistingScores = false;

        for (int i = 1; i <= maxHighScores; i++)
        {
            int currentScore = PlayerPrefs.GetInt($"HighScore{i}", 0);
            if (currentScore > 0)
            {
                hasExistingScores = true;
                if (currentScore < lowestHighScore)
                {
                    lowestHighScore = currentScore;
                }
            }
        }
        Debug.Log(lowestHighScore); 
        Debug.Log(hasExistingScores);

        if (!hasExistingScores || score > lowestHighScore)
        {
            // Show input field for name
            nameInputField.gameObject.SetActive(true);
            newScore = score; 
        }
    }
    private void OnNameInput(string input)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SubmitHighScore(input, newScore);
            Debug.Log(input + newScore); 

        }
    }

    public void SubmitHighScore(string newHighScoreName, int newHighScore)
    {
        string playerName = newHighScoreName;
        int newScore = newHighScore; 

        //Create a list which will store the high scores.
        List<(string name, int score)> highScores = new List<(string name, int score)>();

        // Get existing scores
        for (int i = 1; i <= maxHighScores; i++)
        {
            string name = PlayerPrefs.GetString($"HighScoreName{i}", "");
            int score = PlayerPrefs.GetInt($"HighScore{i}", 0);
            if (score > 0)
            {
                highScores.Add((name, score));
            }
        }

        // Add new score to list
        highScores.Add((playerName, newScore));

        // Sort scores in descending order and take top maxHighScores
        highScores = highScores.OrderByDescending(x => x.score).Take(maxHighScores).ToList();

        // Save sorted scores
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetString($"HighScoreName{i + 1}", highScores[i].name);
            PlayerPrefs.SetInt($"HighScore{i + 1}", highScores[i].score);
        }

        PlayerPrefs.Save();

        // Hide input field
        nameInputField.gameObject.SetActive(false);
        scoreLogged = true; 
    }

    public void DisplayHighScores()
    {
        for (int i = 1; i <= maxHighScores; i++)
        {
            string name = PlayerPrefs.GetString($"HighScoreName{i}", "---");
            int score = PlayerPrefs.GetInt($"HighScore{i}", 0);
            Debug.Log($"#{i}: {name} - {score}");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            DisplayHighScores();    
        }
    }
}





