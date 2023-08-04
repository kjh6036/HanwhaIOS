using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAnim : MonoBehaviour
{
    public void Activate()
    {
        transform.parent.gameObject.SetActive(true);
    }

    public void AnimEventFin()
    {
        transform.parent.gameObject.SetActive(false);
        SoundManager.Instance.SetupBGM(4);
    }
}
