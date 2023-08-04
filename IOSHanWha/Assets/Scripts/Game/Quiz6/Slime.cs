using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime : MonoBehaviour
{
    [SerializeField] private RectTransform Button_Pos = null;
    [SerializeField] private RectTransform Staff_Pos = null;

    private RectTransform rectTransform = null;
    private Vector2 origin_Pos = Vector2.zero;
    private bool isDead = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        origin_Pos = rectTransform.anchoredPosition;
    }

    private void OnEnable()
    {
        rectTransform.anchoredPosition = origin_Pos;
        RestartButton();
    }

    void Update()
    {
        if (isDead)
            return;

        rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, Button_Pos.anchoredPosition, 170.0f * Time.deltaTime);
        rectTransform.localScale += Vector3.one * Time.deltaTime * 0.1f;
        if(Vector2.Distance(rectTransform.anchoredPosition, Button_Pos.anchoredPosition) <= 20.0f)
        {
            transform.parent.gameObject.SetActive(false);
            MiniGameManager.Instance.GoToMain(4);
            MiniGameManager.Instance.clear_Game_List.Add(4);
        }
    }

    public void AttackButton()
    {
        isDead = true;
        gameObject.GetComponent<Image>().color = new Color(1.0f / 1.0f, 1.0f / 1.0f, 1.0f / 1.0f, 0.0f / 1.0f);
        Staff_Pos.gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        foreach (GameObject ob in MiniGameManager.Instance.object_List)
        {
            if (ob.activeSelf)
            {
                ob.SetActive(false);
            }
        }

        isDead = false;
        gameObject.GetComponent<Image>().color = new Color(1.0f / 1.0f, 1.0f / 1.0f, 1.0f / 1.0f, 1.0f / 1.0f);
        rectTransform.anchoredPosition = new Vector2(-500.0f, 700.0f);
        rectTransform.localScale = Vector2.one;
        Staff_Pos.gameObject.SetActive(false);
    }
}
