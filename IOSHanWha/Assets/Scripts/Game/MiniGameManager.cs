using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoogleData
{
    public string order, result, msg, value;
}

public class MiniGameManager : MonoBehaviour
{

    public static MiniGameManager Instance = null;

    public GameObject Main_Scene = null;

    public int scene_Index = 0;

    public List<int> clear_Game_List = null;
    public GameObject[] Scene_Array = null;

    public DefeatPanel Defeat_Panel = null;

    [SerializeField] private CountPanel Count_Panel = null;
    [SerializeField] private GameObject Gacha_Panel = null;
    [SerializeField] private GameObject Ending_Panel = null;
    [SerializeField] private GoogleSheetManager My_GPGSBinder = null;

    public List<GameObject> object_List = null;

    public int passCount = 0;
    public int blockCount = 0;
    public int moveTextCount = 0;

    public Card[] Card_Array = null;
    public List<Card> Having_Card_List = null;

    public Card[] Boss_Array = null;

    public bool IsFirstRun = true;

    public string couponState = "";

    public int remainingCoupons = 0;



    private void Awake()
    {
        if (Instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            Instance = this; //내자신을 instance로 넣어줍니다.
            object_List = new List<GameObject>();
            clear_Game_List = new List<int>();
            Having_Card_List = new List<Card>();

            if (PlayerPrefs.GetInt("ClearedGame1") == 0)
            {
                return;
            }
            else
            {
                IsFirstRun = false;
            }

            for (int i = 0; i < 25; i++)
            {
                if (PlayerPrefs.GetInt("ClearedGame" + i) == 0)
                    continue;

                clear_Game_List.Add(PlayerPrefs.GetInt("ClearedGame" + i) - 1);
                int temp = (PlayerPrefs.GetInt("ClearedGame" + i) - 1) * 2;
                Having_Card_List.Add(Card_Array[temp]);
                Having_Card_List.Add(Card_Array[temp + 1]);
            }
        }
    }

    public void GoToMain(int index)
    {
        if (index <= -1)
        {
            SoundManager.Instance.SetupBGM(0);
            Gacha_Panel.SetActive(false); 
            Main_Scene.SetActive(false);
            Main_Scene.SetActive(true);
            return;
        }


        Gacha_Panel.SetActive(true);

        Scene_Array[index]?
           .gameObject.SetActive(false);

        Main_Scene.SetActive(false);
        Main_Scene.SetActive(true);
    }

    public void BackToMain(int index)
    {
        SoundManager.Instance.PlaySound("UI_Click");
        SoundManager.Instance.SetupBGM(0);

        Scene_Array[index].SetActive(false);
        Main_Scene.SetActive(false);
        Main_Scene.SetActive(true);

        if (object_List.Count == 0)
            return;
        foreach (GameObject ob in object_List)
        {
            if (ob.activeSelf)
            {
                ob.SetActive(false);
            }
        }
    }

    public void SceneChange(int index)
    {
        if (clear_Game_List.Contains(index))
            return;
        scene_Index = index;
        Count_Panel.gameObject.SetActive(true);
        SoundManager.Instance.StopBGM();
    }

    public void Ending()
    {
        Ending_Panel.SetActive(true);
        SoundManager.Instance.SetupBGM(1);
    }

    public void OFFAR(int index)
    {
        if (clear_Game_List.Contains(index))
        {
            Main_Scene.SetActive(true);
            return;
        }
        scene_Index = index;
        Count_Panel.gameObject.SetActive(true);
    }

    public void SetDefeatPanel()
    {
        switch (scene_Index)
        {
            case 0:
            case 1:
            case 2:
                Defeat_Panel.IsHint = false;
                break;
            case 3:
                Defeat_Panel.SetHintText("피할 수 없을 땐 과감하게 욕심을 버려야 해!\n침착함이 생명이라구!");
                Defeat_Panel.IsHint = true;
                break;
            case 4:
                Defeat_Panel.IsHint = false;
                break;
            case 5:
                Defeat_Panel.SetHintText("고도를 유지하는 것이 관건이야!\n비행기가 어느정도 떨어졌을 때\n터치를 하면 고도를 유지하기 쉬워!");
                Defeat_Panel.IsHint = true;
                break;
            case 6:
                Defeat_Panel.IsHint = false;
                break;
            case 7:
                Defeat_Panel.SetHintText("벽돌을 5개 받아낸 뒤 5초를 버텨야해!\n너무 어려우면 다른 물약을 찾으러 가는 것도 방법이지!");
                Defeat_Panel.IsHint = true;
                break;
            case 8:
                Defeat_Panel.SetHintText("타이밍이 생명이야!\n너무 빨라도 안 되고\n너무 느려도 안 돼!\n리듬을 타면 쉽게 할 수 있을 거야");
                Defeat_Panel.IsHint = true;
                break;
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
                Defeat_Panel.IsHint = false;
                break;
            case 15:
                Defeat_Panel.SetHintText("이 금도끼가 네 것이냐~?\n이 은도끼가 네 것이냐~?\n\n만물의 진가는 겉모습만으론\n드러나지 않는 법이야.");
                Defeat_Panel.IsHint = true;
                break;
            case 16:
            case 17:
                Defeat_Panel.IsHint = false;
                break;
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
                Defeat_Panel.SetHintText("마법의 물약이 모자란 것 같아!\n퀴즈를 풀면 더 많은 마법의 물약을 얻을 수 있어!");
                Defeat_Panel.IsHint = true;
                break;
        }
        Defeat_Panel?.gameObject.SetActive(true);
    }

    public void DefeatePanelButton()
    {
        Defeat_Panel?.gameObject.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");
        SoundManager.Instance.SetupBGM(0);

        foreach (GameObject ob in Scene_Array)
        {
            if (ob.activeSelf)
            {
                ob.SetActive(false);
                ob.SetActive(true);
            }
        }

        if (object_List.Count == 0)
            return;
        foreach (GameObject ob in object_List)
        {
            if (ob.activeSelf)
            {
                ob.SetActive(false);
            }
        }
    }

    public void DefeatPanelToMainButton()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        SoundManager.Instance.SetupBGM(0);

        if (object_List.Count != 0)
        {
            foreach (GameObject ob in object_List)
            {
                if (ob.activeSelf)
                {
                    ob.SetActive(false);
                }
            }
        }

        foreach (GameObject ob in Scene_Array)
        {
            if (ob.activeSelf)
                ob.SetActive(false);
        }

        Main_Scene.SetActive(false);
        Main_Scene.SetActive(true);
        Defeat_Panel?.gameObject.SetActive(false);
    }

    public List<Card> GetCard()
    {
        PlayerPrefs.SetInt("ClearedGame" + scene_Index, scene_Index + 1);

        List<Card> cards = new List<Card>();

        int temp = scene_Index * 2;

        for (int i = 0; i < 2; i++)
        {
            if (Having_Card_List.Count == Card_Array.Length)
            {
                return null;
            }
            if (i != 0)
            {
                temp += 1;
            }

            cards.Add(Card_Array[temp]);
            Having_Card_List.Add(Card_Array[temp]);

        }
        return cards;
    }

    public void SetCoupon()
    {
        remainingCoupons--;
        My_GPGSBinder.SetCoupon();
    }

    public void SetCouponState(string text)
    {
        My_GPGSBinder.SetCouponState(text);
    }

    public void GetCoupon()
    {
        My_GPGSBinder.GetCoupon();
    }

    public void GetCouponState()
    {
        My_GPGSBinder.GetCouponState();
    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < clear_Game_List.Count; i++)
        {
            PlayerPrefs.SetInt("ClearedGame" + i, clear_Game_List[i] + 1);
        }
    }


}
