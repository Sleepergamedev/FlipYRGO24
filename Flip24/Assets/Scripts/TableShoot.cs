using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class TableShoot : MonoBehaviour
{

    [SerializeField] float throwStrength;
    public Vector3 throwDirection;
    [SerializeField] Rigidbody2D rb;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.AddForce(throwDirection.normalized * throwStrength, ForceMode2D.Impulse);
            Debug.Log("Shoot table");
        }
    }

}
