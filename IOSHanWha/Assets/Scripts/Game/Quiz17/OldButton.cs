using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldButton : MonoBehaviour
{
    public void ButtonClick()
    {
        MiniGameManager.Instance.SetDefeatPanel();
    }
}
