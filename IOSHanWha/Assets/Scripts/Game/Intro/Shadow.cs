using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shadow : MonoBehaviour
{
    [SerializeField] private Image My_Image = null;
    [SerializeField] private GameObject[] My_Text_Array = null;

    [SerializeField] private Sprite[] Spirte_Array = null;

    [SerializeField] private Button Cut_Scene_Button = null;

    [SerializeField] private GameObject Tutorial_Panel = null;
    [SerializeField] private GameObject Chara = null;

    private int index = 0;

    public void AnimFinEvent()
    {
        Cut_Scene_Button.interactable = true;
        gameObject.SetActive(false);
    }

    public void AnimEvent()
    {
        Cut_Scene_Button.interactable = false;

        if (index >= 5)
        {
            SoundManager.Instance.SetupBGM(0);
            Tutorial_Panel.SetActive(true);
            Tutorial_Panel.transform.parent.gameObject.SetActive(true);
            Chara.SetActive(false);

            My_Image.transform.parent.gameObject.SetActive(false);

            return;
        }

        My_Image.sprite = Spirte_Array[index + 1];
        My_Text_Array[index].SetActive(false);
        index++;
        if (index < 5)
        {
            My_Text_Array[index].SetActive(true);
        }
    }

}
