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

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // rb.AddForce(throwDirection.normalized * throwStrength, ForceMode2D.Impulse);
            rb.AddTorque(torque, ForceMode2D.Force);
        }
    }

}
