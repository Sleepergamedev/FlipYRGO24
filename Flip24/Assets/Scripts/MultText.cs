using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MultText : MonoBehaviour
{
    private ScoreManager scoreScript;
    private float yAxis;
    private byte alpha = 255;
    void Awake()
    {
        scoreScript = FindFirstObjectByType<ScoreManager>();
        GetComponent<TMP_Text>().text = scoreScript.styleFactor.ToString() + "X";
        yAxis = gameObject.transform.localPosition.y;
    }
    void FixedUpdate()
    {
        transform.localPosition = new Vector3(0, yAxis += 60 * Time.deltaTime, 0);
        GetComponent<TMP_Text>().faceColor = new Color32(255, 224, 0, alpha-= 3);
        if (alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
