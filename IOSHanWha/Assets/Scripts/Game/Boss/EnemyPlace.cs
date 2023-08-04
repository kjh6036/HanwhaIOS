using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlace : BaseInstance
{
    [HideInInspector] public BaseInstance card = null;
    [HideInInspector] public CardPlace[] CardPlace_Array = null;

    [SerializeField] private Image image = null;

    private Animator animator = null;

    [SerializeField] private Boss My_Boss = null;

    public Bar My_Bar = null;

    public bool IsDead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        IsDead = false;
    }


    public void SetCard(BaseInstance card)
    {
        this.card = card;
        hp = card.hp;
        origin_hp = card.origin_hp;
        damage = card.damage;
        mySprite = card.mySprite;
        image.sprite = mySprite;

        My_Bar.maxBar = origin_hp;
        My_Bar.bar = hp;
        My_Bar.SetBar();
    }

    public void Hit(int damage)
    {
        hp -= damage;
        My_Bar.bar = hp;
        My_Bar.SetBar();
        if (hp <= 0)
        {
            Die();
            return;
        }
        animator.SetTrigger("Hit");
    }

    public void HitAnimFin()
    {
        animator.SetTrigger("Idle");
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        MiniGameManager.Instance.clear_Game_List.Add(My_Boss.BossIndex + 18);
        IsDead = true;
    }

    private void DieAnimFin()
    {
        if (My_Boss.BossIndex >= 4)
        {
            gameObject.SetActive(false);
            My_Boss.gameObject.SetActive(false);
            MiniGameManager.Instance.Ending();
            return;
        }
        gameObject.SetActive(false);
        My_Boss.Get_Card_Panel.SetActive(true);
        My_Boss.gameObject.SetActive(false);
    }
}
