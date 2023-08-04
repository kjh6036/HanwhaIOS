using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour
{
    [HideInInspector] public RectTransform rect = null;

    public int stack = 0;
    public int index = 0;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
}
