using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    Vector3 originalPos; 

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);  
    }

    // Update is called once per frame
    void Update()
    {
        float posX = transform.position.x;
        
        posX = Mathf.Clamp(transform.position.x, 0, 20); 
        
        if (transform.position.x >= 20)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
    }
}
