using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{

    [SerializeField] private Tutorial Tuto_Panel = null;


    public void Clear(int index)
    {
        MiniGameManager.Instance.clear_Game_List.Add(index);
        MiniGameManager.Instance.GoToMain(index);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void TutorialEnd(int index)
    {
        Tuto_Panel.gameObject.SetActive(true);
        Tuto_Panel.TutorialButton();
        MiniGameManager.Instance.GoToMain(index);
        MiniGameManager.Instance.clear_Game_List.Add(index);
        SoundManager.Instance.PlaySound("UI_Click");
    }


    public void TutorialClear(int index)
    {
        MiniGameManager.Instance.clear_Game_List.Add(index);
        SoundManager.Instance.PlaySound("UI_Click");
    }
}
