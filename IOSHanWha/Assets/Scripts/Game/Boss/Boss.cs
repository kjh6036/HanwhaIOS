using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] private List<BaseInstance> card_List = null;

    [SerializeField] private CardPlace[] CardPlace_Array = null;
    [SerializeField] private Vector2[] CardPos_Array = null;
    public EnemyPlace My_EnemyPlace = null;

    public int BossIndex = 0;

    public GameObject Get_Card_Panel = null;

    public float origin_timer = 60.0f;
    public float timer = 0.0f;
    [SerializeField] private TextMeshProUGUI Timer_Text = null;

    [SerializeField] private EffectObject My_EffectObject = null;
    private ObjectPool<EffectObject> Effect_Pool = null;

    private void Awake()
    {
        card_List = new List<BaseInstance>();
        Effect_Pool = new ObjectPool<EffectObject>();

        My_EnemyPlace.card = MiniGameManager.Instance.Boss_Array[BossIndex];
        My_EnemyPlace.CardPlace_Array = CardPlace_Array;

        CardPos_Array = new Vector2[5];
        for (int i = 0; i < CardPlace_Array.Length; i++)
        {
            CardPos_Array[i] = CardPlace_Array[i].GetComponent<RectTransform>().anchoredPosition;
        }

    }

    private void OnEnable()
    {
        ResetBoss();
    }

    private void OnDisable()
    {
        for (int i = 0; i < CardPlace_Array.Length; i++)
        {
            if (CardPlace_Array[i] != null && CardPlace_Array[i].gameObject.activeSelf)
                CardPlace_Array[i].gameObject.SetActive(false);
        }

        card_List.Clear();
    }

    private void Update()
    {
        if (MiniGameManager.Instance.Defeat_Panel.gameObject.activeSelf)
        {
            timer = origin_timer;
            My_EnemyPlace.SetCard(My_EnemyPlace.card);
            return;
        }
        timer -= Time.deltaTime;
        Timer_Text.text = timer.ToString("N2");

        if (timer <= 0.0f)
        {
            MiniGameManager.Instance.SetDefeatPanel();
        }

    }




    public void ReinforceCard()
    {
        for (int i = 0; i < CardPlace_Array.Length; i++)
        {
            if (CardPlace_Array[i].gameObject.activeSelf == false && i != CardPlace_Array.Length - 1)
            {
                for (int j = i; j < CardPlace_Array.Length - 1; j++)
                {
                    CardPlace tempCP = CardPlace_Array[j];

                    CardPlace_Array[j] = CardPlace_Array[j + 1];
                    CardPlace_Array[j + 1] = tempCP;
                }
            }
        }

        for (int i = 0; i < CardPlace_Array.Length; i++)
        {
            CardPlace_Array[i].GetComponent<RectTransform>().anchoredPosition = CardPos_Array[i];
        }

        int temp = 0;
        for (int i = 0; i < CardPlace_Array.Length; i++)
        {
            int index = i;


            CardPlace_Array[index].origin_Pos = CardPos_Array[index];

            if (CardPlace_Array[index].gameObject.activeSelf == false)
            {
                temp++;
                if(card_List.Count != 0)
                {
                    int rand = UnityEngine.Random.Range(0, card_List.Count);
                    CardPlace_Array[index].SetCard(card_List[rand]);
                    CardPlace_Array[index].enemyPlace = My_EnemyPlace;
                    card_List.RemoveAt(rand);
                    CardPlace_Array[index].gameObject.SetActive(true);
                }
            }

            if (card_List.Count == 0 && temp >= CardPlace_Array.Length && My_EnemyPlace.IsDead == false) 
            {
                MiniGameManager.Instance.SetDefeatPanel();
            }
        }
    }

    private void ResetBoss()
    {
        timer = origin_timer;

        My_EnemyPlace.card = MiniGameManager.Instance.Boss_Array[BossIndex];
        My_EnemyPlace.SetCard(My_EnemyPlace.card);

        for (int i = 0; i < MiniGameManager.Instance.Having_Card_List.Count; i++)
        {
            card_List.Add(MiniGameManager.Instance.Having_Card_List[i]);
        }

        for (int i = 0; i < CardPlace_Array.Length; i++)
        {
            if (i >= card_List.Count)
            {
                CardPlace_Array[i].gameObject.SetActive(false);
            }
            else
            {
                CardPlace_Array[i].gameObject.SetActive(true);
            }
        }

        List<int> temps = new List<int>();

        for (int i = 0; i < Mathf.Clamp(MiniGameManager.Instance.Having_Card_List.Count, 0, 5); i++)
        {
            int rand = UnityEngine.Random.Range(0, card_List.Count);

            if (temps.Contains(rand))
            {
                i--;
                continue;
            }
            else
            {
                temps.Add(rand);
            }
            CardPlace_Array[i].SetCard(card_List?[rand]);
            CardPlace_Array[i].enemyPlace = My_EnemyPlace;
        }

        for(int i = 0; i < temps.Count; i++)
        {
            card_List.Remove(MiniGameManager.Instance.Having_Card_List[temps[i]]);
        }
    }


    public EffectObject EffectSpawn(Vector2 pos)
    {
        EffectObject effectObject = Effect_Pool.GetRecycledObject(checkCanRecycle: true) ?? Effect_Pool.RegisterRecyclableObject(Instantiate(My_EffectObject));

        effectObject.transform.SetParent(CardPlace_Array[0].transform.parent);

        RectTransform rect = effectObject.GetComponent<RectTransform>();

        rect.localScale = Vector2.one * 4.0f;

        rect.sizeDelta = new Vector2(603.0f, 604.0f);

        rect.localEulerAngles = Vector3.zero;

        rect.anchoredPosition = pos;

        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0.0f);

        effectObject.gameObject.SetActive(true);

        return effectObject;
    }
}
