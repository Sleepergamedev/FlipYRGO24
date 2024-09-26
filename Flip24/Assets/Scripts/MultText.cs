using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultText : MonoBehaviour
{
    private ScoreManager scoreScript;
    void Awake()
    {
        scoreScript = FindFirstObjectByType<ScoreManager>();
        GetComponent<TMP_Text>().text = scoreScript.styleFactor.ToString() + "X";
    }
}
