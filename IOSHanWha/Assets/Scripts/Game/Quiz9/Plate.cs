using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plate : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler
{
    [HideInInspector]public RectTransform rectTransform;
    [SerializeField] private Canvas canvas;

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

}
