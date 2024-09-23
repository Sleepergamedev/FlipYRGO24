using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    Vector2 cameraOffset = new Vector2(0.4f, 0.2f);
    Rigidbody2D rb;
    float timeElapsed;
    float delay = 0.2f; 

    public float smoothSpeed = 0.125f;

    TableShoot shootScript; 
    // Start is called before the first frame update
    void Start()
    {
        shootScript = FindFirstObjectByType<TableShoot>();
        mainCamera.transform.position = transform.position + (Vector3)cameraOffset;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        //Controlls the smoothness of the main camera. Small delay of start.
        
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= delay)
        {
            Vector2 smoothFollow = Vector2.Lerp(mainCamera.transform.position, transform.position, smoothSpeed);
            mainCamera.transform.position = smoothFollow;
        }
        
       
        
    }
}






