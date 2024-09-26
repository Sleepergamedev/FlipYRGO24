using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerBarController : MonoBehaviour
{
    public RectTransform fillRect;
    public Slider powerBar;
    public Image fillImage;
    public float powerBarSpeed = 1;
    float powerBarFill;
    public float setPower;
    public float powerDivider;
    float powerBarRaw;
    TableShoot shootScript;
    [SerializeField] AnimationCurve powerBarCurve;
    private float initialFillWidth;

    void Start()
    {
        shootScript = FindFirstObjectByType<TableShoot>();
        initialFillWidth = fillRect.rect.width;
        fillImage.type = Image.Type.Filled;
        fillImage.fillMethod = Image.FillMethod.Horizontal;
        fillImage.fillOrigin = (int)Image.OriginHorizontal.Left;
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
            setPower = powerBar.value / powerDivider;
            shootScript.throwStrength = setPower;
            powerBarSpeed = 0;
            shootScript.spaceButtonPressed = 1;
            powerBar.gameObject.SetActive(false);
        }
    }
}

  
