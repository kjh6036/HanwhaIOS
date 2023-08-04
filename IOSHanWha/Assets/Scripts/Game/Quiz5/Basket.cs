using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Basket : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;

    [HideInInspector] public int goldBar_Stack = 0;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += new Vector2(eventData.delta.x / canvas.scaleFactor, 0.0f);
        if (rectTransform.anchoredPosition.x >= 810.0f)
        {
            rectTransform.anchoredPosition = new Vector2(809.0f, rectTransform.anchoredPosition.y);
        }
        else if (rectTransform.anchoredPosition.x <= -810.0f)
        {
            rectTransform.anchoredPosition = new Vector2(-809.0f, rectTransform.anchoredPosition.y);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shit")
        {
            MiniGameManager.Instance.SetDefeatPanel();
            goldBar_Stack = 0;
            other.gameObject.SetActive(false);
        }
        else if(other.tag == "GoldBar")
        {
            other.gameObject.SetActive(false);
            goldBar_Stack++;
            if (goldBar_Stack >= 3)
            {
                MiniGameManager.Instance.GoToMain(3);
                MiniGameManager.Instance.clear_Game_List.Add(3);
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
