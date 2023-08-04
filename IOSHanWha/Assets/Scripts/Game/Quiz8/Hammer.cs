using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hammer : MonoBehaviour
{
    [SerializeField] private GameObject Card = null;
    private Button my_Button = null;

    private RectTransform m_RectTransform = null;
    private Vector2 origin_Pos = Vector2.zero;

    private Animator animator = null;
    public float speed = 200.0f;

    void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        origin_Pos = m_RectTransform.anchoredPosition;

        my_Button = GetComponent<Button>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        m_RectTransform.anchoredPosition = origin_Pos;
        my_Button.interactable = true;
        animator.SetTrigger("Set");
        Card.SetActive(true);
        speed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_RectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;
    }

    public void TouchButton()
    {
        speed = 0.0f;
        animator.SetTrigger("Anim0");
        my_Button.interactable = false;
        Card.SetActive(false);
    }
}
