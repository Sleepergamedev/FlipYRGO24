using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UIScript : MonoBehaviour
{
    [Header ("Buttons")]
    public Button playButton;
    public Button creditsButton;
    public Button exitButton; 

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(LoadScene);
        creditsButton.onClick.AddListener(CreditsWindow); 
        exitButton.onClick.AddListener(ExitGame);
    }

    private void CreditsWindow()
    {
        
    }

    void LoadScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single); 
    }
    private void ExitGame()
    {
        Application.Quit();
    }

    
}
