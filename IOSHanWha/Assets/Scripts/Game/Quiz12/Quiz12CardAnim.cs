using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz12CardAnim : MonoBehaviour
{
    public void AnimFinEvent()
    {
        gameObject.GetComponent<Button>().interactable = true;
        gameObject.GetComponent<Animator>().ResetTrigger("Anim0");
        gameObject.GetComponent<Animator>().SetTrigger("Idle");
    }
}
