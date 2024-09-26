using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (rb.velocity.x >= 5)
        {
        GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1.5f);
        GetComponent<AudioSource>().Play();
        }
    }
}
