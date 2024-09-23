using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    Vector2 cameraOffset = new Vector2(0.4f, 0.2f);
    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.transform.position = transform.position + (Vector3)cameraOffset;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = Vector2.Lerp(mainCamera.transform.position, transform.position, 0.8f) * Time.deltaTime;
        rb.AddForce(new Vector2(2,2), ForceMode2D.Impulse);

    }
}
