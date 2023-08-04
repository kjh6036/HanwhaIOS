using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour, IObjectPoolable
{
    public bool canRecyclable { get; set; } = true;

    public Action OnRecycleStartSignature { get; set; }

    public Action OnRecycleFinishSignature { get; set; }

    private Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.SetTrigger("Anim");
        MiniGameManager.Instance.object_List.Add(gameObject);
        canRecyclable = false;
    }

    private void OnDisable()
    {
        canRecyclable = true;
    }

    public void AnimEventFin()
    {
        gameObject.SetActive(false);
    }

}
