using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR : MonoBehaviour
{
    [SerializeField] private GameObject Target_Image = null;
    [SerializeField] private Button AR_Button = null;

    [SerializeField] private GameObject Canvas = null;
    [SerializeField] private GameObject Main_Panel = null;

    [SerializeField] private GameObject AR_Camera = null;
    [SerializeField] private GameObject Main_Camera = null;

    [SerializeField] private GameObject Fake_Target_Panel = null;

    public bool isLoaded = false;
    public bool isFake = false;

    private int index = 0;

    

    public void FindTarget(int index)
    {
        if (MiniGameManager.Instance.clear_Game_List.Contains(index))
        {
            Target_Image.SetActive(false);
            Fake_Target_Panel.SetActive(true);
            isFake = true;
            return;
        }

        if (isLoaded == false)
            return;

        if (isFake)
            return;

        this.index = index;
        Target_Image.SetActive(false);
        AR_Button.gameObject.SetActive(true);

        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void OffAR()
    {
        MiniGameManager.Instance.OFFAR(index);
        Target_Image.SetActive(true);
        AR_Button.gameObject.SetActive(false);

        Canvas.SetActive(true);
        gameObject.SetActive(false);

        AR_Camera.SetActive(false);
        Main_Camera.SetActive(true);
        Fake_Target_Panel.SetActive(false);

        SoundManager.Instance.PlaySound("UI_Click");
    }


    public void MainButton()
    {
        Target_Image.SetActive(true);
        AR_Button.gameObject.SetActive(false);

        Canvas.SetActive(true);
        Main_Panel.SetActive(true);
        gameObject.SetActive(false);

        AR_Camera.SetActive(false);
        Main_Camera.SetActive(true);
        Fake_Target_Panel.SetActive(false);

        SoundManager.Instance.PlaySound("UI_Click");
    }

}
