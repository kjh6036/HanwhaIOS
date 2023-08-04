using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz7 : MonoBehaviour
{
    [SerializeField] private Column Column_Prefab = null;
    private ObjectPool<Column> column_Pool = null;

    [SerializeField] private Column[] Column_Prepared = null;

    [SerializeField] private RectTransform Plane_Rect = null;
    private Vector2 origin_Pos = Vector2.zero;

    private float timer = -1.0f;
    private int column_Created = 0;

    private float flapHeight = 0.0f;

    private void Awake()
    {
        column_Pool = new ObjectPool<Column>();
        Plane_Rect.localEulerAngles = Vector3.zero;
        origin_Pos = Plane_Rect.anchoredPosition;

        for(int i = 0; i < Column_Prepared.Length; i++)
        {
            column_Pool.RegisterRecyclableObject(Column_Prepared[i]);
        }
    }

    private void OnEnable()
    {
        Plane_Rect.anchoredPosition = origin_Pos;
        Plane_Rect.localScale = Vector3.one;
        Plane_Rect.localEulerAngles = Vector3.zero;
        timer = -1.0f;
        flapHeight = 0.0f;
        column_Created = 0;
    }


    void Update()
    {
        if (MiniGameManager.Instance.Defeat_Panel.gameObject.activeSelf)
        {
            Plane_Rect.anchoredPosition = Vector2.left * 400.0f * Time.deltaTime;
            Plane_Rect.localScale = Vector3.one;
            Plane_Rect.localEulerAngles = Vector3.zero;
            MiniGameManager.Instance.passCount = 0;
            column_Created = 0;
            flapHeight = 0.0f;
            timer = -3.0f;
            return;
        }

        flapHeight -= Time.deltaTime * 300.0f;

        if (Input.GetMouseButtonDown(0))
        {
            PlaneMove();
        }

        RotatePlane();

        CreateColumn();

        if(Plane_Rect.anchoredPosition.y <= -2200.0f || Plane_Rect.anchoredPosition.y >= 2200.0f)
        {
            MiniGameManager.Instance.SetDefeatPanel();
        }

        if (MiniGameManager.Instance.passCount >= 40)
        {
            MiniGameManager.Instance.GoToMain(5);
            MiniGameManager.Instance.clear_Game_List.Add(5);
        }
    }

    private void PlaneMove()
    {
        flapHeight = 500.0f;
    }

    private void RotatePlane()
    {
        Plane_Rect.anchoredPosition += Vector2.up * flapHeight * Time.deltaTime;
    }


    private void CreateColumn()
    {
        timer += Time.deltaTime;
        if(timer >= 1.0f && column_Created < 20)
        {
            column_Created++;
            timer = 0.0f;
            ColumnSpawn(1200.0f, true);
            ColumnSpawn(1200.0f, false);
        }
    }

    public Column ColumnSpawn(float PosX, bool isUpper)
    {
        Column column = column_Pool.GetRecycledObject(checkCanRecycle: true) ?? column_Pool.RegisterRecyclableObject(Instantiate(Column_Prefab));

        column.transform.SetParent(gameObject.transform);
        column.transform.SetAsFirstSibling();

        RectTransform rect = column.GetComponent<RectTransform>();

        rect.localScale = Vector3.one;

        rect.sizeDelta = new Vector2(321.0f, 2432.0f);

        column.gameObject.SetActive(true);

        float percentage = 0.0f;

        if (isUpper)
        {
            rect.localEulerAngles = Vector3.forward * 180.0f;
            percentage = Random.Range(-1600.0f, -2500.0f);
        }
        else
        {
            rect.localEulerAngles = Vector3.forward;
            percentage = Random.Range(1600.0f, 2500.0f);
        }
        
        rect.localPosition = new Vector3(PosX, percentage, 0.0f);

        return column;
    }
}
