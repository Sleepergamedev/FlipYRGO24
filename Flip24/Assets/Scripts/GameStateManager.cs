using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    private ValueManager valueScript;
    [SerializeField] GameObject tablePos;
    void Start()
    {
        valueScript = FindFirstObjectByType<ValueManager>();
        UIManager.Instance.backShade.gameObject.SetActive(false);
        UIManager.Instance.judges.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (valueScript.isGameOver == true)
        {
            Debug.Log("game over");
            UIManager.Instance.backShade.gameObject.SetActive(true);
            UIManager.Instance.backShade.gameObject.transform.position = new Vector3(tablePos.transform.position.x, 0, 0);
            UIManager.Instance.judges.gameObject.SetActive(true);
            UIManager.Instance.judges.gameObject.transform.position = new Vector3(tablePos.transform.position.x, 0, 0);
        }
    }

}
