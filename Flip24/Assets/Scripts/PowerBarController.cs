using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class PowerBarController : MonoBehaviour
{
    public Slider powerBar; 
    public float powerBarSpeed;
    public float setPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powerBar.value += powerBarSpeed *2 *Time.deltaTime;
        if (powerBar.value >= powerBar.maxValue || powerBar.value <= powerBar.minValue)
        {
            powerBarSpeed = -powerBarSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            setPower = powerBar.value;
            powerBarSpeed = 0; 
            
        }

    }
}
