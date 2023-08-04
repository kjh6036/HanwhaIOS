using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] private Button Intro_Post = null;
    [SerializeField] private GameObject Open_Post = null;

    [SerializeField] private Image My_Image = null;
    [SerializeField] private GameObject[] My_Text_Array = null;

    [SerializeField] private GameObject Shadow = null;

    [SerializeField] private Sprite[] Spirte_Array = null;

    [SerializeField] private GameObject Gra = null;

    private int index = -1;

    private void OnEnable()
    {
        SoundManager.Instance.SetupBGM(1);
    }


    public void GetPost()
    {
        Intro_Post.gameObject.SetActive(false);
        Intro_Post.interactable = false;

        Open_Post.SetActive(true);
    }




    public void ChangeScene()
    {
        Gra.SetActive(true);

        if (index == -1)
        {
            My_Image.sprite = Spirte_Array[0];
            My_Text_Array[0].SetActive(true);
            My_Image.gameObject.SetActive(true);
            My_Image.GetComponent<Button>().interactable = true;
            Open_Post.SetActive(false);
            index++;
        }
        else
        {
            Shadow.gameObject.SetActive(true);
            index++;
        }

    }


}
