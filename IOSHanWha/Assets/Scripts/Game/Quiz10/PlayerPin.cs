using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPin : MonoBehaviour
{
    [HideInInspector] public RectTransform rectTransform = null;
    [HideInInspector] public Animator animator = null;
    

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Anim0");
            animator.ResetTrigger("Idle");
        }
        //if (Input.touchCount > 0)
        //{
        //    switch (Input.GetTouch(0).phase)
        //    {
        //        case TouchPhase.Began:
        //            animator.SetTrigger("Anim0");
        //            break;
        //        case TouchPhase.Ended:
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }

    private void AnimFinEvent()
    {
        animator.ResetTrigger("Anim0");
        animator.SetTrigger("Idle");
    }
}

