using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz1 : MonoBehaviour
{
    [SerializeField] private Animator Card_Anim = null;

    [SerializeField] private Animator Fire_Anim = null;

    [SerializeField] private Animator Water_Anim = null;


    private void Update()
    {
        if(Vector2.Distance(Fire_Anim.transform.position, Water_Anim.transform.position) <= 5.0f)
        {
            Card_Anim.gameObject.SetActive(true);
            gameObject.GetComponent<Quiz1>().enabled = false;
            Water_Anim.GetComponent<Image>().raycastTarget = false;
            Water_Anim.GetComponent<Drag>().drop_Stop = true;
            Fire_Anim.SetTrigger("Anim0");
            Water_Anim.SetTrigger("Anim0");
            Card_Anim.SetTrigger("Anim0");
            Water_Anim.transform.position = Fire_Anim.transform.position + (Vector3.one * 5.0f) - (Vector3.back * 5.0f);
        }
    }
}
