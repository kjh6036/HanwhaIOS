using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefeatPanelAnim : MonoBehaviour
{

    [SerializeField] private Animator Speech_Bubble_Anim = null;
    [SerializeField] private Animator Chara_Anim = null;

    [SerializeField] private TextMeshProUGUI hint_Text = null;


    [SerializeField] private GameObject[] Button_Object_Array = null;

    public void SpeechAnimFinEvent()
    {
        Button_Object_Array[0].SetActive(true);
        Button_Object_Array[1].SetActive(true);
    }

    public void CharaAnimFinEvent()
    {
        Speech_Bubble_Anim.gameObject.SetActive(true);
    }

    public void TextAnimFinEvent()
    {
        Chara_Anim.gameObject.SetActive(true);
    }

    public void SetHintText(string text)
    {
        hint_Text.text = text;
    }
}
