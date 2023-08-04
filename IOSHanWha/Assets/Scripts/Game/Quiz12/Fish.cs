using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fish : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    [SerializeField] private Quiz12 quiz = null;

    private RectTransform rectTransform;
    private Vector2 origin_Pos = Vector2.zero;

    [SerializeField] private Canvas canvas;

    [SerializeField] private Camera My_Camera = null;

    public bool drop_Stop = false;
    public int index = 0;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        origin_Pos = rectTransform.anchoredPosition;
    }



    public void OnDrag(PointerEventData eventData)
    {
        if (drop_Stop)
            return;
        // 이전 이동과 비교해서 얼마나 이동했는지를 보여줌
        // 캔버스의 스케일과 맞춰야 하기 때문에
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (rectTransform.anchoredPosition.x >= 860.0f)
        {
            rectTransform.anchoredPosition = new Vector2(859.0f, rectTransform.anchoredPosition.y);
        }
        else if (rectTransform.anchoredPosition.x <= -860.0f)
        {
            rectTransform.anchoredPosition = new Vector2(-809.0f, rectTransform.anchoredPosition.y);
        }
        if (rectTransform.anchoredPosition.y >= 1900.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 1899.0f);
        }
        else if (rectTransform.anchoredPosition.y <= -1900.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -1899.0f);
        }

    }


    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (drop_Stop)
            return;
        RaycastHit hit;
#if UNITY_EDITOR
        Ray ray = My_Camera.ScreenPointToRay(Input.mousePosition);
#elif UNITY_ANDROID

        Ray ray = My_Camera.ScreenPointToRay(Input.GetTouch(0).position);
#endif
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (hit.transform?.tag == "Beaker")
        {
            Beaker beaker = hit.transform.GetComponent<Beaker>();
            if (beaker.stack == 0 && quiz.type_Array[index] > 0)
            {
                rectTransform.anchoredPosition = new Vector2(beaker.rect.anchoredPosition.x, beaker.rect.anchoredPosition.y - 200.0f);
                beaker.index = index;
                beaker.stack++;
                quiz.stack++;
                quiz.type_Array[index]--;
                drop_Stop = true;
            }
            else if (beaker.stack == 1 && beaker.index == index)
            {
                rectTransform.anchoredPosition = new Vector2(beaker.rect.anchoredPosition.x, beaker.rect.anchoredPosition.y + 200.0f);
                beaker.stack++;
                quiz.stack++;
                drop_Stop = true;
            }
            else
            {
                rectTransform.anchoredPosition = origin_Pos;
            }
        }
        else
        {
            rectTransform.anchoredPosition = origin_Pos;
        }



    }
}
