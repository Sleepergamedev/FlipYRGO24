using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    //variabler
    public int metresFlown;
    public bool notFlipped;
    public bool isFlipped180;
    public bool isFlipped90;
    public bool isFlipped270;
    public bool isGameOver = false;
    public float timeToEnd;
    [SerializeField] Rigidbody2D rb;
    private float timer;
    private bool startCount;
    private TableShoot tableShoot;
    private bool hasLanded = false;


        private void Start()
    {
        tableShoot = FindFirstObjectByType<TableShoot>();
    }

    void Update()
    {
        metresFlown = Mathf.RoundToInt(transform.position.x);

        if (tableShoot.hasShot)
        {
            CheckForZeroVelocity();
        }


        if (tableShoot.hasShot)
        {
            if (transform.position.x > 0 && rb.velocity.x <= 0f)
            {
                startCount = true;
            }
           
        }
        if (startCount)
        {
            timer += 1 * Time.deltaTime;
        }
        
        if (transform.position.x > 0 && rb.velocity.x <= 0 && timer >= timeToEnd)
        {
            isGameOver = true;
            startCount = true;
        }

    }

    private void CheckForZeroVelocity()
    {
        if (rb.velocity.x <= 0)
        {
            CheckSide();
        }
    }

    private void CheckSide()
    {
        if (transform.localEulerAngles.z >= 89 && transform.localEulerAngles.z <= 91 && !isFlipped90)
        {
            isFlipped90 = true;
            startCount = true;
        }

        if (transform.localEulerAngles.z >= 179 && transform.localEulerAngles.z <= 181 && !isFlipped180)
        {
            isFlipped180 = true;
            startCount = true;
        }
        if (transform.localEulerAngles.z >= 269 && transform.localEulerAngles.z <= 271 && !isFlipped270)
        {
            isFlipped270 = true;
            startCount = true;
        }
        if (transform.localEulerAngles.z >= 0 && transform.localEulerAngles.z <= 5 && !notFlipped)
        {
            notFlipped = true;
            startCount = true;
        }
    }

}
