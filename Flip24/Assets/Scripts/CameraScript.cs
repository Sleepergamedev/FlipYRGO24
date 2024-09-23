using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    Vector2 cameraOffset = new Vector2(0.4f, 0.2f);
    Rigidbody2D rb;

    public float smoothSpeed = 0.125f; 
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.transform.position = transform.position + (Vector3)cameraOffset;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
        }

    }

    private void FixedUpdate()
    {
       Vector2 smoothFollow = Vector2.Lerp(mainCamera.transform.position, transform.position, smoothSpeed);
       mainCamera.transform.position = smoothFollow;
       
        
    }
}






