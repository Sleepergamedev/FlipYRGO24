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
    public float setPower;
    TableShoot shootScript;

    private float initialFillWidth;


    // Start is called before the first frame update
    void Start()
    {
        shootScript = FindFirstObjectByType<TableShoot>();
        initialFillWidth = fillRect.rect.width;
        fillImage.type = Image.Type.Filled;
        fillImage.fillMethod = Image.FillMethod.Horizontal;
        fillImage.fillOrigin = (int)Image.OriginHorizontal.Left;
    }

    // Update is called once per frame
    void Update()
    {
        powerBar.value += powerBarSpeed * 2 * Time.deltaTime;
        if (powerBar.value >= powerBar.maxValue || powerBar.value <= powerBar.minValue)
        {
            powerBarSpeed = -powerBarSpeed;
        }

        float fillAmount = (powerBar.value - powerBar.minValue) / (powerBar.maxValue - powerBar.minValue);
        fillImage.fillAmount = fillAmount;

        if (Input.GetKeyDown(KeyCode.Space) && shootScript.spaceButtonPressed == 0)
        {
            Debug.Log("space");
            setPower = powerBar.value / 3;
            Debug.Log(setPower);
            shootScript.throwStrength = setPower;
            powerBarSpeed = 0;
            shootScript.spaceButtonPressed = 1;
            powerBar.gameObject.SetActive(false);

        }

    }
}
