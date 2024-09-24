using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Camera settings")]
    public float smoothSpeed = 0.125f;
    public Camera mainCamera;
    private Vector3 originalPosition;
    private float originalSize;
    Vector3 cameraOffset = new Vector3(0, 0, -10);
    public bool launchReady;

    [Header("Camera Zoom Specs")]
    public float zoomFactor = 1.5f;
    public float shakeDuration = 2f;
    public float shakeIntensity = 0.1f;
    bool isShaking = false;

    //private 
    TableShoot shootScript;

    // Start is called before the first frame update
    void Start()
    {
        shootScript = FindFirstObjectByType<TableShoot>();
        mainCamera.transform.position = transform.position + cameraOffset;
        originalPosition = mainCamera.transform.position;
        originalSize = mainCamera.orthographicSize;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isShaking && shootScript.spaceButtonPressed == 2)
        {
            TriggerZoomAndShake();
        }
    }

    private void FixedUpdate()
    {
        //Controlls the smoothness of the main camera. Small delay of start.


        if (!isShaking)
        {
            Vector2 smoothFollow = Vector2.Lerp(mainCamera.transform.position, transform.position, smoothSpeed);
            mainCamera.transform.position = smoothFollow;

        }

    }

    void TriggerZoomAndShake()
    {
        isShaking = true;
        StartCoroutine(ZoomAndShakeCoroutine());
    }

    IEnumerator ZoomAndShakeCoroutine()
    {
        float elapsedTime = 0;
        float startSize = mainCamera.orthographicSize;
        float targetSize = startSize / zoomFactor;

        while (elapsedTime < shakeDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(startSize, targetSize, elapsedTime / shakeDuration);
            elapsedTime += Time.deltaTime;


            float currentIntensity = shakeIntensity * (elapsedTime / shakeDuration);

            mainCamera.transform.position = originalPosition + Random.insideUnitSphere * currentIntensity;

            yield return null;
        }
        elapsedTime = 0;

        Vector3 shakePosition = mainCamera.transform.position;

        while (elapsedTime < 0.4f)
        {
            launchReady = true;
            mainCamera.orthographicSize = Mathf.Lerp(targetSize, originalSize, elapsedTime / 0.5f);
            mainCamera.transform.position = Vector3.Lerp(shakePosition, originalPosition, elapsedTime / 0.5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.orthographicSize = originalSize;
        mainCamera.transform.position = originalPosition;
        isShaking = false;

    }
}






