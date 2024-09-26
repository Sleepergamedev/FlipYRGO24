using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleScreenMover : MonoBehaviour
{
    // Start is called before the first frame update
    float yTransform;
    void Start()
    {
        yTransform = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, yTransform * ((Mathf.Sin(Time.time) + 1) / 2) / 30 + 10.3f, transform.position.z);
    }
}
