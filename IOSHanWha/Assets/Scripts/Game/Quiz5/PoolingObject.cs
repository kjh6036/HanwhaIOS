using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : MonoBehaviour, IObjectPoolable
{
    public bool canRecyclable { get; set; } = true;

    public Action OnRecycleStartSignature { get; set; }

    public Action OnRecycleFinishSignature { get; set; }

    private RectTransform m_RectTransform;

    private float speed = 300.0f;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        MiniGameManager.Instance.object_List.Add(gameObject);
    }

    private void OnEnable()
    {
        canRecyclable = false;
        speed = UnityEngine.Random.Range(250.0f, 350.0f);
    }

    private void OnDisable()
    {
        canRecyclable = true;
    }

    private void Update()
    {
        m_RectTransform.anchoredPosition += Vector2.down * speed * Time.deltaTime;
        if(m_RectTransform.anchoredPosition.y <= -3000.0f)
            gameObject.SetActive(false);
    }
}
