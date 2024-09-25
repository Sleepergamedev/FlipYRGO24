using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerMainScene : MonoBehaviour
{
    public Button playAgainButton;
    public Button menuButton;
    public TMP_Text uiScore; 
    ValueManager valueManager;
    // Start is called before the first frame update
    void Start()
    {
        valueManager = FindFirstObjectByType<ValueManager>();
        playAgainButton.onClick.AddListener(ReloadScene);
        menuButton.onClick.AddListener(LoadMenuScene);
        
    }

    private void Update()
    {
        ScoreUpdate(valueManager.metresFlown);
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
