using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingPanel : MonoBehaviour
{
    [SerializeField] private Sprite[] Image_Array = null;
    [SerializeField] private Image My_Image = null;

    [SerializeField] private EndingShadow My_Shadow = null;
    [SerializeField] private GameObject Coupon_Image = null;
    [SerializeField] private GameObject Main_Button = null;

    [SerializeField] private GameObject Warn_Panel = null;

    [SerializeField] private TextMeshProUGUI My_Text = null;

    private int index = 0;

    private void OnEnable()
    {
        MiniGameManager.Instance.SetCouponState("쿠폰 보유 중");
        MiniGameManager.Instance.GetCouponState();
        MiniGameManager.Instance.GetCoupon();
    }

    public void EndingButton()
    {
        if (index >= 4)
        {
            return;
        }

        My_Shadow.gameObject.SetActive(true);
    }

    public void ChangeScene()
    {
        if (index >= 4)
        {
            return;
        }
        My_Image.sprite = Image_Array[index];
        index++;

        if (index >= 4 && MiniGameManager.Instance.remainingCoupons > 0 && MiniGameManager.Instance.couponState == "쿠폰 없음")
        {
            My_Text.text = "프론트에서 상품을 수령하세요!";
            Coupon_Image.SetActive(true);
            Main_Button.SetActive(true);
        }
        else if (index >= 4 && (MiniGameManager.Instance.remainingCoupons <= 0 || MiniGameManager.Instance.couponState != "쿠폰 보유 중"))
        {
            Main_Button.SetActive(true);
        }
    }

    public void MainButton()
    {
        MiniGameManager.Instance.GoToMain(-1);
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySound("UI_Click");
    }

    public void CouponButton()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        Warn_Panel.SetActive(true);
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


}
