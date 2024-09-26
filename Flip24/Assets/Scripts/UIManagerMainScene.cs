using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;

public class UIManagerMainScene : MonoBehaviour
{
    public Button playAgainButton;
    public Button menuButton;
    public GameObject highScoreBoard;
    public GameObject scoreBoard; 
    public TMP_Text uiScore;
    public TMP_Text scoreBoardScore; 
    ValueManager valueManager;
    HighScoreManager highScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        valueManager = FindFirstObjectByType<ValueManager>();
        highScoreManager = FindFirstObjectByType<HighScoreManager>();
        playAgainButton.onClick.AddListener(ReloadScene);
        menuButton.onClick.AddListener(LoadMenuScene);
        
        
    }

    private void Update()
    {
        ScoreUpdate(valueManager.metresFlown);
        if (highScoreManager.highScoreActive && valueManager.isGameOver)
        {
            ShowHighScoreBoard();
        }
        
        if (highScoreManager.highScoreActive == false && valueManager.isGameOver)
        {
            ShowScoreBoard();
            highScoreManager.DisplayHighScores();
        }

    }

    private void ShowHighScoreBoard()
    {
        highScoreBoard.SetActive(true);
    }


    private void ShowScoreBoard()
    {
        highScoreBoard.SetActive(false);
        scoreBoard.SetActive(true);
    }

    public void ScoreBoardScore(int score)
    {
        scoreBoardScore.text = ""+score.ToString();
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single); 
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    private void ScoreUpdate(int score)
    {
        uiScore.text = "Distance: " + score.ToString();
    }

 
}
