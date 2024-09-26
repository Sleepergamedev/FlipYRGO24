using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class AngleScript : MonoBehaviour
{
    //variabler
    [SerializeField] float lineSpeed;
    [SerializeField] GameObject startPos;
    [SerializeField] GameObject endOfLine;
    public SpriteRenderer powerLineSprite;
    Vector3 currentEulerAngles;
    public Vector3 direction;
    TableShoot shootScript;
    private bool checkActive = true;

    PowerBarController powerBarController;

    void Start()
    {
        //hämta instansen av skriptet
        shootScript = FindFirstObjectByType<TableShoot>();
        powerBarController = FindFirstObjectByType<PowerBarController>();
        powerLineSprite.enabled = false;


    }
    void Update()
    {
        if (checkActive == true)
        {
            currentEulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * lineSpeed;
            transform.eulerAngles = currentEulerAngles;
        }
        //sätt att z axeln roterar med hjälp av euler angles


        //invertera håll ifall rotationen går över max värden
        if (transform.eulerAngles.z >= 90)
        {
            lineSpeed = -lineSpeed;
        }
        if (transform.eulerAngles.z > 91)
        {
            currentEulerAngles.z = 90;
        }
        if (transform.eulerAngles.z > 359)
        {
            currentEulerAngles.z = 0;
        }

        //make arrow visable to the user after power has been declared
        if (shootScript.spaceButtonPressed > 0)
        {
            powerLineSprite.enabled = true;
        }

        //if sats för att hämta vinkeln med hjälp av vektorer och empty game objekts i scenen
        if (Input.GetKeyDown(KeyCode.Space) && shootScript.spaceButtonPressed == 1)
        {
            Debug.Log("Space");
            direction = new Vector3(endOfLine.transform.position.x, endOfLine.transform.position.y) - new Vector3(startPos.transform.position.x, startPos.transform.position.y);
            shootScript.throwDirection = direction;
            checkActive = false;
            if (shootScript.spaceButtonPressed == 1)
            {
                shootScript.spaceButtonPressed = 2;

            }

        }


    }
}
