using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerBarController : MonoBehaviour
{
    public Slider powerBar;
    public float powerBarSpeed;
    public float setPower;
    TableShoot shootScript;

    // Start is called before the first frame update
    void Start()
    {
        shootScript = FindFirstObjectByType<TableShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        powerBar.value += powerBarSpeed * 2 * Time.deltaTime;
        if (powerBar.value >= powerBar.maxValue || powerBar.value <= powerBar.minValue)
        {
            powerBarSpeed = -powerBarSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && shootScript.spaceButtonPressed == 0)
        {
            setPower = powerBar.value / 3;
            Debug.Log(setPower);
            shootScript.throwStrength = setPower;
            powerBarSpeed = 0;

        }

    }
}
