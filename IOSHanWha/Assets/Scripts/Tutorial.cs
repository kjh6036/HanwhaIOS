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
            Bubble_Text.text = "���� �Ƿ��� ��� ��������\n�׽�Ʈ�� �غ��߰ھ�";
        }
        else if(index == 1)
        {
            Bubble_Text.text = "2������ ��� ���߸�\n�� �� ������ ����������!";
        }
        else if(index == 2)
        {
            gameObject.SetActive(false);
            MiniGameManager.Instance.SceneChange(0);
        }
        else if(index == 3)
        {
            Bubble_Text.text = "�����ΰ�?\n�̷��� ��� Ǯ��\n������ ������ ���� �� �־�";
        }
        else if (index == 4)
        {
            Bubble_Text.text = "������ ������\n��ȭ����Ʈ ������\n������ ����";
        }
        else if (index == 5)
        {
            Bubble_Text.text = "���� �Բ�\n������ ������ ���\n���� ���ű⸦ �����\n��ī ���ָ� ��������!";
        }
        else if (index == 6)
        {
            gameObject.SetActive(false);
        }
        index++;
    }
}
