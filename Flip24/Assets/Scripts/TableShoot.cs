using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class TableShoot : MonoBehaviour
{

    //variabler
    public float throwStrength;
    public float torque;
    public Vector3 throwDirection;
    [SerializeField] Rigidbody2D rb;
    public int spaceButtonPressed;

    void Update()
    {
        //if sats för att skjuta iväg spelaren beroende på spelarens input
        if (Input.GetKeyDown(KeyCode.Space) && spaceButtonPressed == 2)
        {

            rb.AddForce(throwDirection.normalized * throwStrength, ForceMode2D.Impulse);
            rb.AddTorque(-torque, ForceMode2D.Force);
            spaceButtonPressed = 0;
        }
    }
}
