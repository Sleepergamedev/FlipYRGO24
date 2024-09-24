using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    //variabler
    public int metresFlown;
    public bool isFlipped180;
    public bool isFlipped90;
    public bool isFlipped270;
    [SerializeField] Rigidbody2D rb;




    void Update()
    {
        //if satser som ändra de värderna som ska sparas när bordet står still förutom i början
        if (transform.position.x > 0 && rb.velocity.x <= 0f)
        {
            metresFlown = Mathf.RoundToInt(transform.position.x);
        }
        if (transform.localEulerAngles.z >= 179 && transform.localEulerAngles.z <= 181 && isFlipped180 == false && rb.velocity.x <= 0)
        {
            isFlipped180 = true;
        }
        if (transform.localEulerAngles.z >= 89 && transform.localEulerAngles.z <= 91 && isFlipped90 == false && rb.velocity.x <= 0)
        {
            isFlipped90 = true;
        }
        if (transform.localEulerAngles.z >= 269 && transform.localEulerAngles.z <= 271 && isFlipped270 == false && rb.velocity.x <= 0)
        {
            isFlipped270 = true;
        }
        else
        {

        }


    }
}
