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
        if (Instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            Instance = this; //���ڽ��� instance�� �־��ݴϴ�.
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
                Defeat_Panel.SetHintText("���� �� ���� �� �����ϰ� ����� ������ ��!\nħ������ �����̶�!");
                Defeat_Panel.IsHint = true;
                break;
            case 4:
                Defeat_Panel.IsHint = false;
                break;
            case 5:
                Defeat_Panel.SetHintText("���� �����ϴ� ���� �����̾�!\n����Ⱑ ������� �������� ��\n��ġ�� �ϸ� ���� �����ϱ� ����!");
                Defeat_Panel.IsHint = true;
                break;
            case 6:
                Defeat_Panel.IsHint = false;
                break;
            case 7:
                Defeat_Panel.SetHintText("������ 5�� �޾Ƴ� �� 5�ʸ� ���߾���!\n�ʹ� ������ �ٸ� ������ ã���� ���� �͵� �������!");
                Defeat_Panel.IsHint = true;
                break;
            case 8:
                Defeat_Panel.SetHintText("Ÿ�̹��� �����̾�!\n�ʹ� ���� �� �ǰ�\n�ʹ� ������ �� ��!\n������ Ÿ�� ���� �� �� ���� �ž�");
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
                Defeat_Panel.SetHintText("�� �ݵ����� �� ���̳�~?\n�� �������� �� ���̳�~?\n\n������ ������ �Ѹ��������\n�巯���� �ʴ� ���̾�.");
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
                Defeat_Panel.SetHintText("������ ������ ���ڶ� �� ����!\n��� Ǯ�� �� ���� ������ ������ ���� �� �־�!");
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
