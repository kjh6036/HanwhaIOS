using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz17 : MonoBehaviour
{
    [SerializeField] private GameObject Old_Post = null;

    private void OnEnable()
    {
        Old_Post.SetActive(true);
    }

}
