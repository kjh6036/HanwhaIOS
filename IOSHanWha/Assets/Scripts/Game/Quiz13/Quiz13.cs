using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz13 : MonoBehaviour
{
    [SerializeField] private GameObject Clear_Button = null;

    // Update is called once per frame
    void Update()
    {
        if(MiniGameManager.Instance.moveTextCount >= 2)
        {
            Clear_Button.SetActive(true);
        }
    }
}
