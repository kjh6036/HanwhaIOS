using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouponPanel : MonoBehaviour
{

    [SerializeField] private GameObject Coupon_Image = null;
    [SerializeField] private GameObject Main_Button = null;

    [SerializeField] private GameObject Warn_Panel = null;
    [SerializeField] private GameObject Empty_Panel = null;

    [SerializeField] private GameObject Loading_Panel = null;
    private float timer = 0.0f;


    private void OnEnable()
    {
        MiniGameManager.Instance.GetCoupon();
        MiniGameManager.Instance.GetCouponState();
    }

    private void OnDisable()
    {
        Loading_Panel.SetActive(true);
        timer = 0.0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5.0f)
        {
            Loading_Panel.SetActive(false);
        }
    }

    public void MainButton()
    {
        MiniGameManager.Instance.Main_Scene.SetActive(true);
        gameObject.SetActive(false);
        Warn_Panel.SetActive(false);
        Empty_Panel.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void CouponButton()
    {
        if (MiniGameManager.Instance.couponState == "쿠폰 보유 중")
        {
            SoundManager.Instance.PlaySound("UI_Click");
            Warn_Panel.SetActive(true);
        }
        else
        {
            SoundManager.Instance.PlaySound("UI_Click");
            Empty_Panel.SetActive(true);
        }
    }

    public void WarnQuitButton()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        Warn_Panel.SetActive(false);
    }

    public void WarnButton()
    {
        MiniGameManager.Instance.SetCouponState("상품 수령");
        MiniGameManager.Instance.SetCoupon();
        MiniGameManager.Instance.GetCouponState();
        MiniGameManager.Instance.GetCoupon();
        gameObject.SetActive(false);
        MainButton();
    }


    public void EmptyQuitButton()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        Empty_Panel.SetActive(false);
    }

}
