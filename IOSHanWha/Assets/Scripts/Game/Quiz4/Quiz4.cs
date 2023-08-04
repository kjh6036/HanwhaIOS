using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz4 : MonoBehaviour
{
    [SerializeField] private Image Vivid_Key_Image = null;
    [SerializeField] private Image Vague_Key_Image = null;
    [SerializeField] private Scrollbar Scroll_Bar = null;

    private const float CORRECT_VALUE = 0.76f;
    private float value = 0.0f;

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        value = Scroll_Bar.value;
        Mathf.Clamp(value, 0.0f, 1.72f);



        if(value <= CORRECT_VALUE)
        {
            Vivid_Key_Image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, Mathf.InverseLerp(0.0f, CORRECT_VALUE, value));
            Vague_Key_Image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, Mathf.InverseLerp(CORRECT_VALUE, 0.0f, value));
        }
        else

        {
            Vivid_Key_Image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 1.0f - Mathf.InverseLerp(0.0f, CORRECT_VALUE, value - CORRECT_VALUE));
            Vague_Key_Image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 1.0f - Mathf.InverseLerp(CORRECT_VALUE, 0.0f, value - CORRECT_VALUE));
        }

       

        if (value >= CORRECT_VALUE - 0.09f && value <= CORRECT_VALUE + 0.09f)
        {
            Vivid_Key_Image.raycastTarget = true;
            Vague_Key_Image.raycastTarget = false;
        }
        else
        {
            Vivid_Key_Image.raycastTarget = false;
            Vague_Key_Image.raycastTarget = true;
        }
    }


}
