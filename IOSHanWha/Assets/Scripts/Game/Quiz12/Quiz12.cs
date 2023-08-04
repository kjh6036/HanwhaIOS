using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz12 : MonoBehaviour
{
    public Fish[] fish_Array = null;
    public Beaker[] beaker_Array = null;
    public Button clear_Button = null;

    [SerializeField] private GameObject BackToTheMain_Button = null;

    public int stack = 0;
    public int[] type_Array = new int[3];

    private void Update()
    {
        if(stack >= 6)
        {
            clear_Button.GetComponent<Animator>().SetTrigger("Anim0");
            gameObject.GetComponent<Quiz12>().enabled = false;
            BackToTheMain_Button.SetActive(false);
        }
    }
}
