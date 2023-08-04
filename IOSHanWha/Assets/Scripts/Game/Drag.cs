using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;

    public bool drop_Stop = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }



    public void OnDrag(PointerEventData eventData)
    {
        if (drop_Stop)
            return;
        // ���� �̵��� ���ؼ� �󸶳� �̵��ߴ����� ������
        // ĵ������ �����ϰ� ����� �ϱ� ������
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (rectTransform.anchoredPosition.x >= 700.0f)
        {
            rectTransform.anchoredPosition = new Vector2(699.0f, rectTransform.anchoredPosition.y);
        }
        else if(rectTransform.anchoredPosition.x <= -700.0f)
        {
            rectTransform.anchoredPosition = new Vector2(-699.0f, rectTransform.anchoredPosition.y);
        }
        if(rectTransform.anchoredPosition.y >= 1800.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 1799.0f);
        }
        else if (rectTransform.anchoredPosition.y <= -1800.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -1799.0f);
        }

    }


    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }

}
