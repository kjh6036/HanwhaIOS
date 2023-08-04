using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountPanel : MonoBehaviour
{
    [SerializeField] private Sprite[] Sprite_Array = null;
    [SerializeField] private Image Vil_Image = null;
    [SerializeField] private Image Chara_Image = null;

    [SerializeField] private TextMeshProUGUI Count_Text = null;

    public bool IsPororoVil = false;

    private void OnEnable()
    {
        //if(MiniGameManager.Instance.scene_Index >= 16 && MiniGameManager.Instance.scene_Index <= 19)
        //{
        //    IsPororoVil = true;
        //}

        if (IsPororoVil)
        {
            Chara_Image.gameObject.SetActive(true);
            Vil_Image.gameObject.SetActive(true);
            Count_Text.gameObject.SetActive(false);
        }
        else
        {
            Chara_Image.gameObject.SetActive(false);
            Vil_Image.gameObject.SetActive(false);
            Count_Text.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        IsPororoVil = false;

        if (MiniGameManager.Instance == null)
            return;

        if (MiniGameManager.Instance?.scene_Index < 17)
        {
            SoundManager.Instance?.SetupBGM(2);
        }
        else
        {
            SoundManager.Instance?.SetupBGM(3);
        }
    }

    public void AnimEvent3()
    {
        Count_Text.text = "3";
    }

    public void AnimEvent2()
    {
        Count_Text.text = "2";
    }

    public void AnimEvent1()
    {
        Count_Text.text = "1";
    }

    public void AnimEventFin()
    {
        gameObject.SetActive(false);
        MiniGameManager.Instance.Scene_Array[MiniGameManager.Instance.scene_Index]?.gameObject.SetActive(true);
    }
}
