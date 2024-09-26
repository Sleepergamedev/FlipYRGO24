using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextManager : MonoBehaviour
{
    private TMP_Text text;
    private ValueManager valueScript;
    private GameObject table;
    private float fontSize;
    private ScoreManager scoreScript;
    [SerializeField] GameObject multText;
    private bool madeText = false;
    void Start()
    {
        fontSize = GetComponent<TMP_Text>().fontSize;
        table = GameObject.FindWithTag("table");
        text = GetComponent<TMP_Text>();
        scoreScript = FindFirstObjectByType<ScoreManager>();
        valueScript = FindFirstObjectByType<ValueManager>();


    }

    void Update()
    {
        if (valueScript.isFlipped180 && madeText == false && scoreScript.styleFactor > 1)
        {
            Instantiate(multText, transform);
            // multText.transform.SetParent(text.transform);
            madeText = true;
        }
        if (valueScript.isFlipped90 && madeText == false && scoreScript.styleFactor > 1 || valueScript.isFlipped270 && madeText == false && scoreScript.styleFactor > 1)
        {
            Instantiate(multText, transform.position, transform.rotation);
            //   multText.transform.SetParent(text.transform);
            madeText = true;
        }
        text.text = valueScript.metresFlown * scoreScript.styleFactor + " points";

        text.fontSize = fontSize * Mathf.Sin(Time.time) / 8 + 50;
    }
}
