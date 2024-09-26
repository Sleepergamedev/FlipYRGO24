using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private Rigidbody2D rb;

    private AudioSource[] audioSources;
    private AudioSource swoosh;
    private AudioSource collision;

    bool fadingIn = false;
    bool fadingOut = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSources = GetComponents<AudioSource>();

        swoosh = audioSources[0];
        collision = audioSources[1];

        swoosh.loop = true;
    }

    void Update()
    {
        int speed = Mathf.Abs(Mathf.RoundToInt(rb.velocity.x + rb.velocity.y));

        if (speed >= 25 && !swoosh.isPlaying)
        {
            swoosh.Play();

            if (fadingOut)
            {
                fadingOut = false;
                StopCoroutine(VolumeFadeOut());
            }
            if (!fadingIn)
            {
                StartCoroutine(VolumeFadeIn());
            }

        }
        else if (speed < 15 && swoosh.isPlaying)
        {
            if (fadingIn)
            {
                fadingIn = false;
                StopCoroutine(VolumeFadeIn());
            }

            if (!fadingOut)
            {
                StartCoroutine(VolumeFadeOut());
            }
        }
    }

    //Fade in the swoosh sound, so it doesn't suddenly blast your ears
    private IEnumerator VolumeFadeIn()
    {
        fadingIn = true;

        swoosh.volume = 0.0f;

        float maxVol = 0.25f;
        float fadeSeconds = 0.75f;

        for (float x = 0.0f; x <= fadeSeconds; x += Time.deltaTime)
        {
            swoosh.volume = Mathf.Lerp(0, maxVol, x / fadeSeconds);
            yield return null;
        }
        fadingIn = false;
    }

    //Fade out the swoosh sound, because it's nice
    private IEnumerator VolumeFadeOut()
    {
        fadingOut = true;

        float volume = swoosh.volume;
        float fadeSeconds = 0.5f;

        for (float x = 0.0f; x <= fadeSeconds; x += Time.deltaTime)
        {
            swoosh.volume = Mathf.Lerp(volume, 0, x / fadeSeconds);
            yield return null;
        }
        fadingOut = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        swoosh.Stop();

        if (rb.velocity.x >= 5 && !collision.isPlaying)
        {
            collision.pitch = Random.Range(0.5f, 1.5f);

            collision.Play();
        }
    }
}
