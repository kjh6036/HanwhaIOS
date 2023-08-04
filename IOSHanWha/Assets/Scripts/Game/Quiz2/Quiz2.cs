using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz2 : MonoBehaviour
{
    private int touch_Count = 0;
    [SerializeField] private Animator Box = null;

    public void Touch()
    {
        touch_Count++;
        Box.SetTrigger("Anim0");
        if(touch_Count >= 10)
        {
            Box.gameObject.SetActive(false);
        }
    }
}
