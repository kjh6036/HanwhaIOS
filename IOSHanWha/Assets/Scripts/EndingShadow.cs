using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingShadow : MonoBehaviour
{
    [SerializeField] private EndingPanel EndingPanel = null;
    public Animator animator;

    private void Awake()
    {
        animator.GetComponent<Animator>();
    }

    public void AnimEvent()
    {
        EndingPanel.ChangeScene();
    }

    public void AnimFinEvent()
    {
        gameObject.SetActive(false);
    }
}
