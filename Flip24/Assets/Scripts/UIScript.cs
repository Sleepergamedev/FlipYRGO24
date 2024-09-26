using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIScript : MonoBehaviour
{
    [Header ("Buttons")]
    public Button playButton;
    
    public Button exitButton;

    public Button creditsButton;

    public GameObject creditsPanel;

    //private
    bool toggleCredits; 

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(LoadScene);

        exitButton.onClick.AddListener(ExitGame);

        creditsButton.onClick.AddListener(ToggleCredits);
    }

    private void ToggleCredits()
    {
        toggleCredits = !toggleCredits;
        ToggleCredits(toggleCredits); 
    }

    private void ToggleCredits(bool toggleCredits)
    {
        if (toggleCredits)
        {
            creditsPanel.SetActive(true);
        }
        else { creditsPanel.SetActive(false); }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single); 
    }
    private void ExitGame()
    {
        Application.Quit();
    }

    
}
