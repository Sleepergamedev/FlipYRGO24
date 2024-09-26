using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class PowerBarController : MonoBehaviour
{
    public RectTransform fillRect;
    public Slider powerBar;
    public Image fillImage;
    public GameObject sweetSpot; 
    public float powerBarSpeed = 1;
    float powerBarFill;
    public float setPower;
    public float powerMultiplier = 50;
    float powerBarRaw;
    float elapsedTime; 
    TableShoot shootScript;
    [SerializeField] AnimationCurve powerBarCurve;
    private float initialFillWidth;

    bool hasElapsed; 

    void Start()
    {
        shootScript = FindFirstObjectByType<TableShoot>();
        initialFillWidth = fillRect.rect.width;
        fillImage.type = Image.Type.Filled;
        fillImage.fillMethod = Image.FillMethod.Horizontal;
        fillImage.fillOrigin = (int)Image.OriginHorizontal.Left;
        sweetSpot.SetActive(false);
    }

    void Update()
    {
        powerBarRaw += powerBarSpeed * Time.deltaTime;

        
        powerBarRaw = Mathf.Clamp(powerBarRaw, 0f, 1f);

        float curvedValue = powerBarCurve.Evaluate(powerBarRaw);

        // Set the power bar value
        powerBar.value = Mathf.Lerp(powerBar.minValue, powerBar.maxValue, curvedValue);

        // Reverse direction 
        if (powerBarRaw >= 1f || powerBarRaw <= 0f)
        {
            powerBarSpeed = -powerBarSpeed;
        }

        
        fillImage.fillAmount = (powerBar.value - powerBar.minValue) / (powerBar.maxValue - powerBar.minValue);

        
        if (Input.GetKeyDown(KeyCode.Space) && shootScript.spaceButtonPressed == 0)
        {
            setPower = powerBar.value * powerMultiplier;
            shootScript.throwStrength = setPower;
            powerBarSpeed = 0;
            shootScript.spaceButtonPressed = 1;
            
            
        }
        if (shootScript.spaceButtonPressed == 2) 
        {
            powerBar.gameObject.SetActive(false);
        }
   

        if (setPower >= 45)
        {
            elapsedTime += Time.deltaTime;  
            
            if (elapsedTime <= 0.3f)
            {
                sweetSpot.SetActive(true);
                sweetSpot.transform.localScale += Vector3.one * 2 * Time.deltaTime;
                sweetSpot.transform.eulerAngles += new Vector3(0, 0, 1) * 100 * Time.deltaTime;

            }

             
            else if (elapsedTime >= 0.31f)
            {
                
                sweetSpot.SetActive(false);
                
            }

        }

        }
    }


  
