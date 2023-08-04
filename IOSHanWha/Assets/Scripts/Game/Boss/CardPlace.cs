using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPlace : BaseInstance, IPointerDownHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    private Animator animator = null;
    [SerializeField] private Image image = null;

    [HideInInspector] public BaseInstance card = null;
    [HideInInspector] public EnemyPlace enemyPlace = null;

    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;

    public bool drop_Stop = false;

    [SerializeField] private Camera My_Camera = null;
    [SerializeField] private Boss My_Boss = null;

    public Vector2 origin_Pos = Vector2.zero;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
        origin_Pos = rectTransform.anchoredPosition;
    }

    private void OnEnable()
    {
        rectTransform.localScale = Vector2.one;
        animator.ResetTrigger("Attack");
        drop_Stop = false;
        image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    }

    private void OnDisable()
    {
        image.color = new Color32(255, 255, 255, 255);
        animator.ResetTrigger("Attack");
    }

    public void SetCard(BaseInstance card)
    {
        this.card = card;
        hp = card.hp;
        damage = card.damage;
        mySprite = card.mySprite;
        image.overrideSprite = mySprite;
        animator.SetTrigger("Idle");
    }


    public void Attack()
    {
        if (enemyPlace == null) return;

        animator.SetTrigger("Attack");
        drop_Stop = true;
    }

    private void AttackAnimEvent()
    {
        if (enemyPlace == null) return;

        gameObject.SetActive(false);
        My_Boss.ReinforceCard();
    }

    private void AttackAnimFin()
    {
        if (enemyPlace == null) return;

        gameObject.SetActive(false);
        My_Boss.ReinforceCard();
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (drop_Stop)
            return;
        // 이전 이동과 비교해서 얼마나 이동했는지를 보여줌
        // 캔버스의 스케일과 맞춰야 하기 때문에

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (rectTransform.anchoredPosition.x >= 800.0f)
        {
            rectTransform.anchoredPosition = new Vector2(799.0f, rectTransform.anchoredPosition.y);
        }
        else if (rectTransform.anchoredPosition.x <= -800.0f)
        {
            rectTransform.anchoredPosition = new Vector2(-799.0f, rectTransform.anchoredPosition.y);
        }
        if (rectTransform.anchoredPosition.y >= 2400.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 2399.0f);
        }
        else if (rectTransform.anchoredPosition.y <= -2400.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -2399.0f);
        }



    }

    public void OnDrop(PointerEventData eventData)
    {

    }


    public void OnPointerDown(PointerEventData eventData)
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
        Physics.Raycast(ray, out hit, Mathf.Infinity);


        if (hit.transform?.tag == "Boss")
        {
            int rand = UnityEngine.Random.Range(0, 4);
            SoundManager.Instance.PlaySound("Potion" + rand);
            enemyPlace.Hit(damage);
            image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 0.0f / 255.0f);
            gameObject.SetActive(false);
            My_Boss.EffectSpawn(rectTransform.anchoredPosition);
            My_Boss.ReinforceCard();
        }
        else
        {
            rectTransform.anchoredPosition = origin_Pos;
        }
    }


}
