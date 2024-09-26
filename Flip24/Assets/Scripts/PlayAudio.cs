using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip hitHurt;
    private Rigidbody2D rb;

    private AudioSource audioSrc;

    bool fadingIn = false;
    bool fadingOut = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
        audioSrc.loop = true;
    }

    void Update()
    {
        int speed = Mathf.Abs(Mathf.RoundToInt(rb.velocity.x + rb.velocity.y));

        if (speed >= 25 && !audioSrc.isPlaying)
        {
            audioSrc.Play();
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
        else if (speed < 15 && audioSrc.isPlaying)
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

        audioSrc.volume = 0.0f;

        float maxVol = 0.25f;
        float fadeSeconds = 0.75f;

        for (float x = 0.0f; x <= fadeSeconds; x += Time.deltaTime)
        {
            audioSrc.volume = Mathf.Lerp(0, maxVol, x / fadeSeconds);
            yield return null;
        }
        fadingIn = false;
    }

    //Fade out the swoosh sound, because it's nice
    private IEnumerator VolumeFadeOut()
    {
        fadingOut = true;

        float volume = audioSrc.volume;
        float fadeSeconds = 0.5f;

        for (float x = 0.0f; x <= fadeSeconds; x += Time.deltaTime)
        {
            audioSrc.volume = Mathf.Lerp(volume, 0, x / fadeSeconds);
            yield return null;
        }
        fadingOut = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (rb.velocity.x >= 5)
        {
            audioSrc.loop = false;

            //Stop these Coroutines to be completely 
            //sure volume is 1 for the collision sound.
            StopCoroutine(VolumeFadeOut());
            StopCoroutine(VolumeFadeIn());

            audioSrc.volume = 1.0f;
            audioSrc.pitch = Random.Range(0.5f, 1.5f);
            audioSrc.PlayOneShot(hitHurt);
        }
    }
}
