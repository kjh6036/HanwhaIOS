using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaCardAnim : MonoBehaviour
{
    private Animator animator;
    public Image Potion_Image = null;

    [SerializeField] private TextMeshProUGUI Button_Text = null;
    [SerializeField] private GameObject Shine_Panel = null;

    [SerializeField] private Image Card_Image = null;
    public List<Card> sprites = null;

    private int draw_Count = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Button_Text.text = "카드 뽑기";
        if (sprites.Count <= 1)
        {
            Button_Text.text = "메인으로";
        }
    }

    public void SetCard()
    {
        Card_Image.sprite = sprites[0]?.mySprite;
    }

    public void AnimEvent()
    {
        Potion_Image.gameObject.SetActive(true);
    }

    public void AnimFinEvent()
    {
        Potion_Image.gameObject.SetActive(false);
    }

    public void DrawButton()
    {
        SoundManager.Instance.PlaySound("UI_Click");

        if (draw_Count >= sprites.Count - 1 && MiniGameManager.Instance.scene_Index < 1)
        {
            MiniGameManager.Instance.scene_Index++;
            MiniGameManager.Instance.SceneChange(MiniGameManager.Instance.scene_Index);

            transform.parent.gameObject.SetActive(false);
            transform.parent.parent.gameObject.SetActive(false);
            Shine_Panel.SetActive(false);
            animator.SetTrigger("Anim1");
            draw_Count = 0;
            return;
        }
        else if(draw_Count >= sprites.Count - 1)
        {
            MiniGameManager.Instance.GoToMain(-1);
            transform.parent.gameObject.SetActive(false);
            Shine_Panel.SetActive(false);
            animator.SetTrigger("Anim1");
            draw_Count = 0;
            return;
        }

        draw_Count++;

        if (draw_Count >= sprites.Count - 1)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            Card_Image.sprite = sprites[1].mySprite;
            animator.SetTrigger("Anim1");
            Shine_Panel.SetActive(true);
            Button_Text.text = "메인으로";
        }
    }

}
