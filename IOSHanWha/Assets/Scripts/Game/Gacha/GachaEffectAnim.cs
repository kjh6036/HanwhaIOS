using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaEffectAnim : MonoBehaviour
{

    [HideInInspector] public Animator animator = null;
    [SerializeField] private GameObject Result_Panel = null;
    [SerializeField] private GameObject Effect_Panel = null;
    [SerializeField] private GameObject Shine_Panel = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void AnimFinEvent()
    {
        Effect_Panel.SetActive(false);
        Shine_Panel.SetActive(true);
    }

    public void ShineAnimEvent()
    {
        Result_Panel.SetActive(true);
    }

    public void ShineAnimFinEvent()
    {
        Shine_Panel.SetActive(false);
    }
}
