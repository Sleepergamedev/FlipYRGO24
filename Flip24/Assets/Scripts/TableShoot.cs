using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class TableShoot : MonoBehaviour
{

    public float throwStrength;
    public float torque;
    public Vector3 throwDirection;
    [SerializeField] Rigidbody2D rb;
    int test = 5;

    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.S))

        
        {
            // rb.AddForce(throwDirection.normalized * throwStrength, ForceMode2D.Impulse);
            rb.AddTorque(torque, ForceMode2D.Force);
        }
    }

}
