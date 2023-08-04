using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touchable : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    private RectTransform rectTransform = null;

    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject Card_Button = null;

    [SerializeField] private Camera My_Camera = null;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void OnDrag(PointerEventData eventData)
    {

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
        RaycastHit hit;
#if UNITY_EDITOR
        Ray ray = My_Camera.ScreenPointToRay(Input.mousePosition);

#elif UNITY_ANDROID

        Ray ray = My_Camera.ScreenPointToRay(Input.GetTouch(0).position);
#endif
        int mask = (1 << 6);

        Physics.Raycast(ray, out hit, Mathf.Infinity, mask);
        if (hit.transform?.name == "TargetPos")
        {
            rectTransform.anchoredPosition = hit.transform.GetComponent<RectTransform>().anchoredPosition;
            Card_Button.SetActive(true);
        }
    }
}
