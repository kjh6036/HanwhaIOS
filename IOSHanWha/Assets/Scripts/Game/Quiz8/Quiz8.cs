using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz8 : MonoBehaviour
{
    [SerializeField] private RectTransform Hammer_Rect = null;
    [SerializeField] private GameObject Card = null;
    [SerializeField] private RectTransform Barrel_Rect = null;

    private void OnEnable()
    {
        Card.SetActive(true);
    }


    public void ReStartButton()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        Hammer_Rect.anchoredPosition = Vector2.up * 700.0f;
        Hammer_Rect.anchoredPosition = Vector2.right * 500.0f;

        Barrel_Rect.anchoredPosition = Vector2.down * 800.0f;
        Card.SetActive(true);
        Hammer_Rect.GetComponent<Animator>().SetTrigger("Set");
        Hammer_Rect.GetComponent<Hammer>().speed = 200.0f;
        Hammer_Rect.GetComponent<Button>().interactable = true;
    }
}
