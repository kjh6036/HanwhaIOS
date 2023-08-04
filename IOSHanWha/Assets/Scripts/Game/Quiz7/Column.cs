using System;
using UnityEngine;

public class Column : MonoBehaviour, IObjectPoolable
{
    public bool canRecyclable { get; set; } = true;

    public Action OnRecycleStartSignature { get; set; }

    public Action OnRecycleFinishSignature { get; set; }

    private RectTransform m_RectTransform;

    public bool isPass = false;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        MiniGameManager.Instance.object_List.Add(gameObject);
    }

    private void OnEnable()
    {
        isPass = false;
        canRecyclable = false;
    }

    private void OnDisable()
    {
        canRecyclable = true;
    }

    private void Update()
    {
        m_RectTransform.anchoredPosition += Vector2.left * 400.0f * Time.deltaTime;
        if (m_RectTransform.anchoredPosition.x <= -1600.0f)
            gameObject.SetActive(false);
        if (m_RectTransform.anchoredPosition.x <= -550.0f && isPass == false)
        {
            MiniGameManager.Instance.passCount++;
            isPass = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plane")
        {
            MiniGameManager.Instance.SetDefeatPanel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
        {
            MiniGameManager.Instance.SetDefeatPanel();
        }
    }
}
