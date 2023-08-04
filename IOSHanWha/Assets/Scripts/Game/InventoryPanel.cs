using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private GameObject Main_Camera = null;
    [SerializeField] private GameObject AR_Camera = null;

    [SerializeField] private GameObject My_Canvas = null;
    [SerializeField] private GameObject AR_Canvas = null;

    [SerializeField] private GameObject Target_Scene = null;

    [SerializeField] private GameObject[] Potion_Image_Array = null;

    private void OnEnable()
    {

        int index = 0;

        if (MiniGameManager.Instance.Having_Card_List.Count == 0)
            return;

        for (int i = 0; i < MiniGameManager.Instance.Card_Array.Length; i++)
        {
            if (MiniGameManager.Instance.Card_Array[i] == MiniGameManager.Instance.Having_Card_List[index])
            {
                Potion_Image_Array[i].SetActive(true);
                index++;

                if (MiniGameManager.Instance.Having_Card_List.Count <= index)
                {

                    break;
                }
                i = 0;
            }
        }
    }

    public void MainButton()
    {
        MiniGameManager.Instance.Main_Scene.SetActive(true);
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void ARButton()
    {
        gameObject.SetActive(false);

        Main_Camera.SetActive(false);
        AR_Camera.SetActive(true);

        My_Canvas.SetActive(false);
        AR_Canvas.SetActive(true);

        Target_Scene.SetActive(true);
        SoundManager.Instance.PlaySound("UI_Click");
    }


}
