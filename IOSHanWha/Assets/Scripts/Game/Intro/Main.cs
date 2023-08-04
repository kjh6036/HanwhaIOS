using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject Intro_Scene = null;
    [SerializeField] private GameObject Map = null;

    [SerializeField] private GameObject Main_Camera = null;
    [SerializeField] private GameObject AR_Camera = null;

    [SerializeField] private GameObject My_Canvas = null;
    [SerializeField] private GameObject AR_Canvas = null;

    [SerializeField] private GameObject Target_Scene = null;

    [SerializeField] private GameObject Setting_Panel = null;
    [SerializeField] private GameObject Warn_Panel = null;

    [SerializeField] private GameObject Game_Main_Panel = null;

    [SerializeField] private GameObject Inventory_Panel = null;

    [SerializeField] private GameObject Coupon_Panel = null;


    public void MainButton()
    {
        if (MiniGameManager.Instance.IsFirstRun)
        {
            Intro_Scene.SetActive(true);
            gameObject.SetActive(false);
            SoundManager.Instance.PlaySound("UI_Click");
            SoundManager.Instance.SetupBGM(1);
        }
        else
        {
            gameObject.SetActive(false);
            Game_Main_Panel.SetActive(true);
            SoundManager.Instance.PlaySound("UI_Click");
            SoundManager.Instance.SetupBGM(0);
        }
    }

    public void MapButton()
    {
        Map.SetActive(true);
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void InventoryButton()
    {
        Inventory_Panel.SetActive(true);
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void CouponButton()
    {
        Coupon_Panel.SetActive(true);
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void ARActivate()
    {
        Main_Camera.SetActive(false);
        AR_Camera.SetActive(true);

        My_Canvas.SetActive(false);
        AR_Canvas.SetActive(true);

        gameObject.SetActive(false);

        Target_Scene.SetActive(true);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void ApplicationQuitButton()
    {
        Application.Quit();
    }

    public void SettingButton()
    {
        Setting_Panel.SetActive(true);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void SettingQuitButton()
    {
        Setting_Panel.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void WarnButton()
    {
        Warn_Panel.SetActive(true);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void WarnQuitButton()
    {
        Warn_Panel.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    
    public void ResetButton()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        PlayerPrefs.DeleteAll();
    }
}
