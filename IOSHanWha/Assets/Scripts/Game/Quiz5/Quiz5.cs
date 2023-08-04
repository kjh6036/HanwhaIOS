using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz5 : MonoBehaviour
{
    [SerializeField] private PoolingObject Gold_Bar = null;
    [SerializeField] private PoolingObject Shit = null;
    [SerializeField] private Basket Basket = null;

    private ObjectPool<PoolingObject> gold_Bar_Pool = null;
    private ObjectPool<PoolingObject> shit_Pool = null;

    [SerializeField] private PoolingObject[] Gold_Bar_Prepared = null;
    [SerializeField] private PoolingObject[] Shit_Prepared = null;

    private float timer = 0.0f;

    private void Awake()
    {
        gold_Bar_Pool = new ObjectPool<PoolingObject>();
        shit_Pool= new ObjectPool<PoolingObject>();

        for(int i = 0; i < Gold_Bar_Prepared.Length; i++)
        {
            gold_Bar_Pool.RegisterRecyclableObject(Gold_Bar_Prepared[i]);
        }
        for (int i = 0; i < Shit_Prepared.Length; i++)
        {
            shit_Pool.RegisterRecyclableObject(Shit_Prepared[i]);
        }
    }

    private void OnEnable()
    {
        Basket.goldBar_Stack = 0;
    }

    private void Update()
    {
        if (MiniGameManager.Instance.Defeat_Panel.gameObject.activeSelf)
        {
            Basket.goldBar_Stack = 0;
            return;
        }

        timer += Time.deltaTime;
        if(timer >= 0.6f)
        {
            timer = 0.0f;
            int percentage = Random.Range(0, 11);

            if (percentage >= 3)
                ShitSpawn(2300.0f);
            else
                GoldBarSpawn(2300.0f);
        }
    }

    public PoolingObject GoldBarSpawn(float PosY)
    {
        PoolingObject poolingObject = gold_Bar_Pool.GetRecycledObject(checkCanRecycle: true) ?? gold_Bar_Pool.RegisterRecyclableObject(Instantiate(Gold_Bar));

        poolingObject.transform.SetParent(gameObject.transform);

        RectTransform rect = poolingObject.GetComponent<RectTransform>();

        rect.localScale = Vector3.one;

        rect.sizeDelta = new Vector2(244.0f, 232.0f);

        rect.localEulerAngles = Vector3.zero;

        poolingObject.gameObject.SetActive(true);

        float percentage = Random.Range(-1100.0f, 1100.0f);

        rect.localPosition = new Vector3(percentage, PosY, 0.0f);

        return poolingObject;
    }

    public PoolingObject ShitSpawn(float PosY)
    {
        PoolingObject poolingObject = shit_Pool.GetRecycledObject(checkCanRecycle: true) ?? shit_Pool.RegisterRecyclableObject(Instantiate(Shit));

        poolingObject.transform.SetParent(gameObject.transform);

        RectTransform rect = poolingObject.GetComponent<RectTransform>();

        rect.localScale = Vector3.one;

        rect.sizeDelta = new Vector2(200.0f, 366.0f);

        rect.localEulerAngles = Vector3.zero;

        poolingObject.gameObject.SetActive(true);

        float percentage = Random.Range(-1100.0f, 1110.0f);

        rect.localPosition = new Vector3(percentage, PosY, 0.0f);

        return poolingObject;
    }

}
