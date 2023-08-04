using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz14 : MonoBehaviour
{
    [SerializeField] private GameObject Animal = null;
    [SerializeField] private GameObject Sleeping_Animal = null;
    [SerializeField] private FireWood[] Fire_Wood_Array = null;
    [SerializeField] private Button clear_Button = null;

    public void GetFireWood()
    {
        Animal.SetActive(false);
        Sleeping_Animal.SetActive(true);
        clear_Button.gameObject.SetActive(true);
        //clear_Button.GetComponent<Animator>().SetTrigger("Anim0");

        for (int i = 0; i < Fire_Wood_Array.Length; i++)
        {
            Fire_Wood_Array[i].drop_Stop = true;
        }
    }
}
