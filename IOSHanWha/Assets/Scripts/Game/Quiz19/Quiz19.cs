using System;
using UnityEngine;

public class Quiz19 : MonoBehaviour
{
    [SerializeField] private GameObject Card_Button = null;
    [SerializeField] private GameObject[] Line_Object_Array = null;

    [Serializable]
    public class _2dArray
    {
        public Line[] arr = new Line[3];
    }

    public _2dArray[] lines = new _2dArray[5];

    private int stack = 0;

    private void OnEnable()
    {
        for (int i = 0; i< Line_Object_Array.Length; i++)
        {
            Line_Object_Array[i].SetActive(true);
        }
    }

    private void OnDisable()
    {
        for(int i = 0; i < Line_Object_Array.Length; i++)
        {
            if(Line_Object_Array[i])
                Line_Object_Array[i]?.SetActive(false);
        }
    }

    public void SetStack(int index, int connected_Index)
    {
        for(int i = 0; i < lines[index].arr.Length; i++)
        {
            lines[index].arr[i].stack++;
            for(int j = 0; j < lines[connected_Index].arr.Length; j++)
            {
                lines[index].arr[i].DisConnect_List.Add(lines[connected_Index].arr[j].gameObject);
                lines[connected_Index].arr[j].DisConnect_List.Add(lines[index].arr[i].gameObject);
                if(i >= lines[index].arr.Length - 1)
                {
                    lines[connected_Index].arr[j].stack++;
                }
            }
        }
        stack++;
        if(stack >= 6)
        {
            Card_Button.SetActive(true);
        }
    }
}
