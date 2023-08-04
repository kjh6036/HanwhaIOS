using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARChara : MonoBehaviour
{
    [SerializeField] private AR AR_Canvas = null;

    [SerializeField] private GameObject Speech_Bubble_Panel = null;
    [SerializeField] private GameObject Target_Panel = null;

    [SerializeField] private GameObject Accept_Button = null;
    [SerializeField] private GameObject Fake_Target_Panel = null;

    public void AnimFinEvent()
    {
        Speech_Bubble_Panel.SetActive(true);
        Accept_Button.SetActive(true);
    }

    public void AcceptButton()
    {
        Target_Panel.SetActive(true);
        Speech_Bubble_Panel.SetActive(false);
        Accept_Button.SetActive(false);
        Fake_Target_Panel.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");

        AR_Canvas.isFake = false;
    }
}
