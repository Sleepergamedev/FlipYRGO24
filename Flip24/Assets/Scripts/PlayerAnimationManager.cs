using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;
    CameraScript cameraScript;

    void Start()
    {
        cameraScript = FindFirstObjectByType<CameraScript>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == -2.1 && cameraScript.launchReady)
        {
            animator.Play("MainCharacterThrow");
        }
    }
}
