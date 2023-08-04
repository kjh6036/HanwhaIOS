using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonText : MonoBehaviour
{
    [SerializeField] private GameObject Card_Button = null;

    public void ButtonClick()
    {
        Card_Button.SetActive(true);
    }
}
