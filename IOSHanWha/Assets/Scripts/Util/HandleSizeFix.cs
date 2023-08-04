using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleSizeFix : MonoBehaviour
{
    [SerializeField] private Scrollbar bar = null;

    private void Update()
    {
        Resize();
    }

    public void Resize()
    {
        bar.size = 0.05f;
    }

}
