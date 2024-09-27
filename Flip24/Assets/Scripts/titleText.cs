using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleText : MonoBehaviour
{
    float yTransform;
    void Start()
    {
        yTransform = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, yTransform * ((Mathf.Sin(Time.time) + 1) / 2) / 30 + 13.3f, transform.position.z);
    }
}
