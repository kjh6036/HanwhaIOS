using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private RectTransform Ball_Rect = null;

    [HideInInspector] public RectTransform rectTransform = null;
    [HideInInspector] public Animator animator = null;

    public bool IsJump = false;
    public bool IsPlayer = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(Ball_Rect.anchoredPosition, rectTransform.anchoredPosition) <= 450.0f && animator.GetCurrentAnimatorStateInfo(0).IsName("Pin_Anim") == false && IsJump == false)
        {
            if (IsPlayer)
            {
                animator.SetTrigger("Anim0");
                animator.ResetTrigger("Idle");
                IsJump = true;
            }
            else
            {
                animator.SetTrigger("Anim1");
                animator.ResetTrigger("Idle");
                IsJump = true;
            }
        }
    }

    private void AnimFinEvent()
    {
        animator.ResetTrigger("Anim0");
        animator.SetTrigger("Idle");
    }

    private void ComAnimFinEvent()
    {
        animator.ResetTrigger("Anim1");
        animator.SetTrigger("Idle");
    }
}
