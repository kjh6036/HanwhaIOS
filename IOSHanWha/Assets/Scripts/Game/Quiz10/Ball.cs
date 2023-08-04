using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private PlayerPin Player_Pin = null;
    [SerializeField] private Pin[] Pin_Array = null;
    [HideInInspector] public RectTransform rect = null;
    private float speed = 515.0f;
    private int stack = 0;

    private bool flip = false;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void OnDisable()
    {
        foreach (Pin anim in Pin_Array)
        {
            anim.animator.ResetTrigger("Anim0");
            anim.animator.SetTrigger("Idle");
            anim.rectTransform.anchoredPosition = (Vector2.right * anim.rectTransform.anchoredPosition.x) + (Vector2.down * 300.0f);
            anim.IsJump = false;
        }

        Player_Pin.animator.ResetTrigger("Anim0");
        Player_Pin.animator.SetTrigger("Idle");
        Player_Pin.rectTransform.anchoredPosition = (Vector2.right * Player_Pin.rectTransform.anchoredPosition.x) + (Vector2.down * 300.0f);

        stack = 0;
        ChangeSpeed(515.0f, false);
        rect.anchoredPosition = Vector2.left * 1299.0f + Vector2.up * rect.anchoredPosition.y;
    }

    private void Update()
    {
        if (MiniGameManager.Instance.Defeat_Panel.gameObject.activeSelf)
        {
            foreach(Pin anim in Pin_Array)
            {
                anim.animator.ResetTrigger("Anim0");
                anim.animator.SetTrigger("Idle");
                anim.rectTransform.anchoredPosition = (Vector2.right * anim.rectTransform.anchoredPosition.x) + (Vector2.down * 300.0f);
                anim.IsJump = false;
            }
            Player_Pin.animator.ResetTrigger("Anim0");
            Player_Pin.animator.SetTrigger("Idle");
            Player_Pin.rectTransform.anchoredPosition = (Vector2.right * Player_Pin.rectTransform.anchoredPosition.x) + (Vector2.down * 300.0f);

            stack = 0;
            ChangeSpeed(515.0f, false);
            rect.anchoredPosition = Vector2.left * 1299.0f + Vector2.up * rect.anchoredPosition.y;

            return;
        }

        //===

        if (rect.anchoredPosition.x <= 1300.0f && flip)
        {
            rect.anchoredPosition += Vector2.left * speed * Time.deltaTime;
        }
        else if (rect.anchoredPosition.x >= -1300.0f && flip == false)
        {
            rect.anchoredPosition += Vector2.right * speed * Time.deltaTime;
        }
        if(Mathf.Abs(rect.anchoredPosition.x) >= 1300.0f)
        {
            switch (stack)
            {
                case 0:
                    ChangeSpeed(635.0f, true);
                    rect.anchoredPosition = Vector2.right * 1290.0f + Vector2.up * rect.anchoredPosition.y;
                    stack++;
                    foreach (Pin anim in Pin_Array)
                    {
                        anim.IsJump = false;
                    }
                    break;
                case 1:
                    ChangeSpeed(740.0f, true);
                    rect.anchoredPosition = Vector2.right * 1290.0f + Vector2.up * rect.anchoredPosition.y;
                    stack++;
                    foreach (Pin anim in Pin_Array)
                    {
                        anim.IsJump = false;
                    }
                    break;
                case 2:
                    ChangeSpeed(855.0f, false);
                    rect.anchoredPosition = Vector2.left * 1290.0f + Vector2.up * rect.anchoredPosition.y;
                    stack++;
                    foreach (Pin anim in Pin_Array)
                    {
                        anim.IsJump = false;
                    }
                    break;
                case 3:
                    ChangeSpeed(1295.0f, true);
                    rect.anchoredPosition = Vector2.right * 1290.0f + Vector2.up * rect.anchoredPosition.y;
                    stack++;
                    foreach (Pin anim in Pin_Array)
                    {
                        anim.IsJump = false;
                    }
                    break;
                case 4:
                    MiniGameManager.Instance.GoToMain(8);
                    MiniGameManager.Instance.clear_Game_List.Add(8);
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangeSpeed(float speed, bool flip)
    {
        this.speed = speed;
        this.flip = flip;
    }


    private void OnTriggerEnter(Collider other)
    {
        MiniGameManager.Instance.SetDefeatPanel();
    }

}
