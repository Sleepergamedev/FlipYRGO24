using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animatorJudge1;
    [SerializeField] Animator animatorJudge2;
    private ValueManager valueScript;
    void Start()
    {
        valueScript = FindFirstObjectByType<ValueManager>();
    }

    void Update()
    {
        if (valueScript.notFlipped && isActiveAndEnabled)
        {
            animatorJudge1.Play("Judge1X");
            animatorJudge2.Play("judge2 x");
        }
        else if (isActiveAndEnabled)
        {
            animatorJudge1.Play("Judge1o");
            animatorJudge2.Play("judge2 o");
        }
    }
}
