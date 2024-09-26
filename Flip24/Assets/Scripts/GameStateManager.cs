using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    private ValueManager valueManager;
    [SerializeField] GameObject tablePos;
    private Rigidbody2D rb;
    [SerializeField] TMP_Text speedText;
    void Start()
    {
        rb = tablePos.GetComponent<Rigidbody2D>();
        valueManager = FindFirstObjectByType<ValueManager>();
        UIManager.Instance.backShade.gameObject.SetActive(false);
        UIManager.Instance.judges.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Speed: " + Mathf.Abs(Mathf.RoundToInt(rb.velocity.x + rb.velocity.y)).ToString() + "m/s";
        if (valueManager.isGameOver == true)
        {
            Debug.Log("game over");
            UIManager.Instance.backShade.gameObject.SetActive(true);
            UIManager.Instance.backShade.gameObject.transform.position = new Vector3(tablePos.transform.position.x, 0, 0);
            UIManager.Instance.judges.gameObject.SetActive(true);
            UIManager.Instance.judges.gameObject.transform.position = new Vector3(tablePos.transform.position.x, 0, 0);
        }
    }

}
