using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefeatPanel : MonoBehaviour
{

    [SerializeField] private Animator Speech_Bubble_Anim = null;
    [SerializeField] private Animator Chara_Anim = null;
    [SerializeField] private Animator Text_Animator = null;

    [SerializeField] private TextMeshProUGUI hint_Text = null;


    [SerializeField] private GameObject[] Button_Object_Array = null;

    public bool IsHint = false;
    [SerializeField] private GameObject No_Hint_Text = null;

    private void OnEnable()
    {
        if (IsHint)
        {
            Text_Animator.gameObject.SetActive(true);
            No_Hint_Text.gameObject.SetActive(false);
            Button_Object_Array[2].SetActive(false);
        }
        else if(IsHint && MiniGameManager.Instance.scene_Index > 2)
        {
            No_Hint_Text.gameObject.SetActive(true);
            Button_Object_Array[0].SetActive(true);
            Button_Object_Array[1].SetActive(true);
            Button_Object_Array[2].SetActive(false);
        }
        else if(MiniGameManager.Instance.scene_Index <= 2)
        {
            Button_Object_Array[0].SetActive(false);
            Button_Object_Array[1].SetActive(false);
            Button_Object_Array[2].SetActive(true);
        }
        
    }


    private void OnDisable()
    {
        Speech_Bubble_Anim.gameObject.SetActive(false);
        Chara_Anim.gameObject.SetActive(false);
        Text_Animator.gameObject.SetActive(false);

        Button_Object_Array[0].SetActive(false);
        Button_Object_Array[1].SetActive(false);
    }

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
