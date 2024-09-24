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
    CameraScript cameraScript; 
    


    private void Start()
    {
        cameraScript = FindFirstObjectByType<CameraScript>();
        
    }
    void Update()
    {
        //if sats för att skjuta iväg spelaren beroende på spelarens input
        if (spaceButtonPressed == 2 && cameraScript.launchReady)
        {
            
            rb.AddForce(throwDirection.normalized * throwStrength, ForceMode2D.Impulse);
            rb.AddTorque(-torque, ForceMode2D.Force);
            spaceButtonPressed = 0;
        }
    }
}
