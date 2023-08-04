using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Post : MonoBehaviour
{
    public void PostActive()
    {
        gameObject.GetComponent<Button>().interactable = true;
    }
}
