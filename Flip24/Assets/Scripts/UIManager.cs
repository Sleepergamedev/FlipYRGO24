using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    public static UIManager Instance => _instance;
    public SpriteRenderer backShade;
    public GameObject judges;
    public Button playAgainButton;
    public Button menuButton; 

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("MORE THAN ONE " + nameof(UIManager) + " IN THE SCENE");
            var objs = GameObject.FindObjectsOfType(typeof(UIManager));
            foreach (var item in objs)
            {
                Debug.LogError(item.name + " Has " + nameof(UIManager), item);
            }
        }
        else
            _instance = this;



    }
    void Start()
    {

    }



}


