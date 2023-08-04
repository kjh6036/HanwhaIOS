using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GachaAnim : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private RectTransform Pipe = null;
    [SerializeField] private Canvas canvas;

    [SerializeField] private Image Panel = null;
    [SerializeField] private Sprite[] Panel_Sprite_Array = null;

    [SerializeField] private GameObject Effect_Anim = null;

    [SerializeField] private GachaCardAnim GachaCardAnim = null;

    [SerializeField] private ClearAnim Clear_Anim = null;

    private Animator animator = null;

    private float BeginPos = 0.0f;
    private float prePosY = 0.0f;

    private bool IsPrepared = true;
    private bool IsCharged = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GachaCardAnim.sprites = MiniGameManager.Instance.GetCard();
        GachaCardAnim.SetCard();
        animator.enabled = false;
        IsPrepared = true;
        BeginPos = 0.0f;
        prePosY = 0.0f;
        IsCharged = false;

        // ==

        Clear_Anim.Activate();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsPrepared)
        {
            Panel.sprite = Panel_Sprite_Array[1];
            BeginPos = (eventData.position.y / canvas.scaleFactor);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsPrepared)
        {
            if (prePosY != eventData.position.y)
            {
                prePosY = (eventData.position.y / BeginPos * 800.0f);
            }

            Pipe.localScale = Vector3.one
                + Vector3.up * Mathf.Clamp(-1.0f - (prePosY / canvas.scaleFactor / 4500.0f * -5.0f), -0.7f, 0.0f)
                + -Vector3.right * Mathf.Clamp(-1.0f - (prePosY / canvas.scaleFactor / 4500.0f * -5.0f), -0.7f, 0.0f);

            if(Mathf.Approximately(Pipe.localScale.x, 1.7f))
            { 
                IsCharged = true;
            }
            else
            {
                IsCharged = false;
            }
        }

    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsPrepared && IsCharged)
        {
            IsPrepared = false;
            Pipe.localScale = Vector3.one;
            animator.enabled = true;
            animator.SetTrigger("Anim0");
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySound("Item_Get");
        }
        else
        {
            Panel.sprite = Panel_Sprite_Array[0];
            Pipe.localScale = Vector3.one;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void AnimEvent()
    {
        Effect_Anim.gameObject.SetActive(true);
    }
}
