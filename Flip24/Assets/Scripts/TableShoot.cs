using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class TableShoot : MonoBehaviour
{

    [SerializeField] float throwStrength;
    public Vector2 throwDirection;
    [SerializeField] Rigidbody2D rb;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(throwDirection.normalized * throwStrength, ForceMode2D.Impulse);
        }
    }

}
