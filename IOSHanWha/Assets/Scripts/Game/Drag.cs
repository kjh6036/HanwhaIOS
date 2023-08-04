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
        // 이전 이동과 비교해서 얼마나 이동했는지를 보여줌
        // 캔버스의 스케일과 맞춰야 하기 때문에
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
