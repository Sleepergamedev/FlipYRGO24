using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UIScript : MonoBehaviour
{
    [Header ("Buttons")]
    public Button playButton;
    
    public Button exitButton; 

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(LoadScene);
        
        exitButton.onClick.AddListener(ExitGame);
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
