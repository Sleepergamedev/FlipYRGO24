using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class PowerBarController : MonoBehaviour
{
    public RectTransform fillRect;
    public Slider powerBar;
    public Image fillImage;
    public GameObject sweetSpot;
    public TMP_Text powerFeedback;
    public float powerBarSpeed = 1;
    float powerBarFill;
    public float setPower;
    public float powerMultiplier = 50;
    float powerBarRaw;
    private bool startCount;
    float elapsedTime;
    TableShoot shootScript;
    [SerializeField] AnimationCurve powerBarCurve;
    [SerializeField] AnimationCurve sweetSpotCurve;
    [SerializeField] AnimationCurve sweetSpotColorCurve;
    [SerializeField] Gradient sweetSpotGradient; 
    private float initialFillWidth;
    private AngleScript angleScript;

    float changeColorSpeed = 1; 
    bool hasElapsed;
    bool isIndicating;

    void Start()
    {
        shootScript = FindFirstObjectByType<TableShoot>();
        initialFillWidth = fillRect.rect.width;
        fillImage.type = Image.Type.Filled;
        fillImage.fillMethod = Image.FillMethod.Horizontal;
        fillImage.fillOrigin = (int)Image.OriginHorizontal.Left;
        sweetSpot.SetActive(false);
        angleScript = FindFirstObjectByType<AngleScript>();
    }

    void Update()
    {
        powerBarRaw += powerBarSpeed * Time.deltaTime;

        if (startCount)
        {
            angleScript.inputCooldown += 1 * Time.deltaTime;
        }


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
            isIndicating = true;
            startCount = true;

        }
        UpdateFeedback();


    }

    private void UpdateFeedback()
    {
        if (!isIndicating) return;

        string feedbackText = GetFeedBackText();
        ShowFeedBack(feedbackText);
    }


    private string GetFeedBackText()
    {
        float powerPercentage = setPower / (float)powerMultiplier;
        if (powerPercentage < 0.3f) return "Mediocre!";
        if (powerPercentage < 0.5) return "OK...";
        if (powerPercentage < 0.75) return "Better...";
        if (powerPercentage < 0.8) return "Nice!";
        if (powerPercentage < 0.98) return "WoW!";
        if (powerPercentage < 0.99999999) return "Epic!";
        if (powerPercentage == 1) return "Insane!!"; 

        return string.Empty;
    }
    private void ShowFeedBack(string text)
    {
        if (string.IsNullOrEmpty(text)) return;
        powerFeedback.text = text;
        sweetSpot.SetActive(true );
        powerFeedback.enabled = true;
        StartCoroutine(ChangeTextColor() );
        sweetSpot.transform.localScale += Vector3.one * Time.deltaTime;

        StartCoroutine(HideFeedbackAfterDelay(0.5f));
    }

    private IEnumerator ChangeTextColor()
    {
        float elapsedTime = 0; 
        while (powerFeedback.enabled)
        {
            elapsedTime += Time.deltaTime * changeColorSpeed;
            float colorIndex = Mathf.PingPong(elapsedTime, 1f);
            powerFeedback.color = sweetSpotGradient.Evaluate(colorIndex);
            yield return null; 
        }
    }
    private IEnumerator HideFeedbackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        sweetSpot.SetActive(false);
        powerFeedback.enabled=false;
        isIndicating = false;
    }

    //if (shootScript.spaceButtonPressed == 2)
    //{
    //    powerBar.gameObject.SetActive(false);
    //}


    //if (setPower < powerMultiplier * 0.3f && isIndicating)
    //{
    //    elapsedTime += Time.deltaTime;

    //    if (elapsedTime <= 0.3f)
    //    {
    //        sweetSpot.SetActive(true);
    //        sweetSpot.transform.localScale += Vector3.one * 3 * Time.deltaTime;
    //        powerFeedback.text = "Mediocre!";


    //    }


    //    else if (elapsedTime >= 0.31f)
    //    {

    //        sweetSpot.SetActive(false);

    //    }

    //}



    //if (setPower <= powerMultiplier * 0.5 && setPower >= powerMultiplier * 0.3 && isIndicating)
    //{
    //    elapsedTime += Time.deltaTime;

    //    if (elapsedTime <= 0.3f)
    //    {
    //        sweetSpot.SetActive(true);
    //        sweetSpot.transform.localScale += Vector3.one * 3 * Time.deltaTime;
    //        powerFeedback.text = "OK...";


    //    }


    //    else if (elapsedTime >= 0.31f)
    //    {

    //        sweetSpot.SetActive(false);

    //    }

    //}

    //if (setPower >= powerMultiplier * 0.98 && isIndicating)
    //{
    //    elapsedTime += Time.deltaTime;

    //    if (elapsedTime <= 0.3f)
    //    {
    //        sweetSpot.SetActive(true);
    //        sweetSpot.transform.localScale += Vector3.one * 3 * Time.deltaTime;
    //        powerFeedback.text = "Nice!";


    //    }


    //    else if (elapsedTime >= 0.31f)
    //    {

    //        sweetSpot.SetActive(false);

    //    }

    //}
}



