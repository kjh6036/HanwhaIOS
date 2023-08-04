using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPostAnim : MonoBehaviour
{

    public void AnimFinEvent()
    {
        gameObject.GetComponent<Button>().interactable = true;
    }
}
