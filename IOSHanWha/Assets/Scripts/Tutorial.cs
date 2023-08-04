using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Bubble_Text = null;
    private Button my_Button = null;

    private int index = 0;

    private void Awake()
    {
        my_Button = GetComponent<Button>();
    }

    public void ButtonActive()
    {
        my_Button.interactable = true;
    }

    public void TutorialAnimFin()
    {
        gameObject.SetActive(false);
    }


    public void TutorialButton()
    {
        if (index == 0)
        {
            Bubble_Text.text = "너의 실력이 어느 정도인지\n테스트를 해봐야겠어";
        }
        else if(index == 1)
        {
            Bubble_Text.text = "2가지의 퀴즈를 맞추면\n널 내 조수로 인정해주지!";
        }
        else if(index == 2)
        {
            gameObject.SetActive(false);
            MiniGameManager.Instance.SceneChange(0);
        }
        else if(index == 3)
        {
            Bubble_Text.text = "제법인걸?\n이렇게 퀴즈를 풀면\n마법의 물약을 얻을 수 있어";
        }
        else if (index == 4)
        {
            Bubble_Text.text = "마법의 물약은\n한화리조트 곳곳에\n숨겨져 있지";
        }
        else if (index == 5)
        {
            Bubble_Text.text = "나와 함께\n마법의 물약을 모아\n괴도 갈매기를 무찌르고\n쿼카 공주를 구출하자!";
        }
        else if (index == 6)
        {
            gameObject.SetActive(false);
        }
        index++;
    }
}
