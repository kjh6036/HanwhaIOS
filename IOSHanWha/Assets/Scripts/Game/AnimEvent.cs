using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimEvent : MonoBehaviour
{
    [SerializeField] private Image CardAnim = null;
    [SerializeField] private Sprite Fire_Sprite = null;

    public void FireAnimFinEvent()
    {
        gameObject.GetComponent<Image>().raycastTarget = false;
    }

    public void FireAnimEvent()
    {
        CardAnim.sprite = Fire_Sprite;
    }

    public void WaterAnimEvent()
    {
        gameObject.SetActive(false);
    }

    public void CardAnimEvent()
    {
        CardAnim.raycastTarget = true;
    }
}
