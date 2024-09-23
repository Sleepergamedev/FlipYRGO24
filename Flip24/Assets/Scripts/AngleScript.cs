using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class AngleScript : MonoBehaviour
{
    [SerializeField] float lineSpeed;
    [SerializeField] GameObject startPos;
    [SerializeField] GameObject endOfLine;
    Vector3 currentEulerAngles;
    public Vector3 direction;
    TableShoot shootScript;

    void Start()
    {
        shootScript = FindFirstObjectByType<TableShoot>();
    }
    void Update()
    {
        currentEulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * lineSpeed;
        transform.eulerAngles = currentEulerAngles;
        if (transform.eulerAngles.z >= 90)
        {
            lineSpeed = -lineSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = new Vector3(endOfLine.transform.position.x, endOfLine.transform.position.y) - new Vector3(startPos.transform.position.x, startPos.transform.position.y);
            shootScript.throwDirection = direction;
        }


    }
}
