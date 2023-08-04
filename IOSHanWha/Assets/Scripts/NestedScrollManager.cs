using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NestedScrollManager : MonoBehaviour, IEndDragHandler, IDragHandler
{
    [SerializeField] private Scrollbar My_Scrollbar = null;

    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    private float distance, targetPos = 0.0f;
    private bool isDrag = false;

    private void Start()
    {
        distance = 1.0f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
    }

    private void Update()
    {
        if (isDrag == false) My_Scrollbar.value = Mathf.Lerp(My_Scrollbar.value, targetPos, 0.1f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;

        for(int i = 0; i < SIZE; i++)
        {
            if(My_Scrollbar.value < pos[i] + distance * 0.5f && My_Scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetPos = pos[i];
            }
        }
    }

}
