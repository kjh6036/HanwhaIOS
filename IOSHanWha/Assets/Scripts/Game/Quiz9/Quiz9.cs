using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quiz9 : MonoBehaviour
{
    [SerializeField] private RectTransform Plate = null;
    [SerializeField] private Block Block = null;
    [SerializeField] private TextMeshProUGUI Anim_Text = null;


    private ObjectPool<Block> block_Pool = null;
    [SerializeField] private Block[] Block_Prepared = null;

    private float timer = 0.0f;

    private float count = 5.0f;

    private void Awake()
    {
        block_Pool = new ObjectPool<Block>();
        for(int i = 0; i < Block_Prepared.Length; i++)
        {
            block_Pool.RegisterRecyclableObject(Block_Prepared[i]);
        }
    }

    private void OnEnable()
    {
        timer = 0.0f;
        count = 5.0f;
        MiniGameManager.Instance.blockCount = 0;
        Anim_Text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (MiniGameManager.Instance.Defeat_Panel.gameObject.activeSelf)
        {
            MiniGameManager.Instance.blockCount = 0;
            Plate.anchoredPosition = Vector2.down * 1000.0f;
            timer = 0.0f;
            count = 5.0f;
            Anim_Text.gameObject.SetActive(false);
            return;
        }

        timer += Time.deltaTime;
        if(timer >= 2.0f)
        {
            timer = 0.0f;
            BlockSpawn(2300.0f);
        }
        if(MiniGameManager.Instance.blockCount >= 5)
        {
            count -= Time.deltaTime;
            Anim_Text.gameObject.SetActive(true);
            Anim_Text.text = ((int)count).ToString();
        }
        if(count <= 0.0f)
        {
            MiniGameManager.Instance.GoToMain(7);
            MiniGameManager.Instance.clear_Game_List.Add(7);
        }
    }


    public Block BlockSpawn(float PosY)
    {
        Block poolingObject = block_Pool.GetRecycledObject(checkCanRecycle: true) ?? block_Pool.RegisterRecyclableObject(Instantiate(Block));

        poolingObject.transform.SetParent(gameObject.transform);
        poolingObject.transform.SetAsFirstSibling();

        RectTransform rect = poolingObject.GetComponent<RectTransform>();

        rect.localEulerAngles = Vector3.zero;

        rect.localScale = Vector3.one;

        rect.sizeDelta = new Vector2(700.0f, 300.0f);

        poolingObject.gameObject.SetActive(true);

        float percentage = Random.Range(-810.0f, 810.0f);

        rect.localPosition = new Vector3(percentage, PosY, 0.0f);

        return poolingObject;
    }
}
