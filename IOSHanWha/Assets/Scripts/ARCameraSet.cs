using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCameraSet : MonoBehaviour
{
    [SerializeField] private GameObject Main_Camera = null;
    [SerializeField] private GameObject AR_Camera = null;
    [SerializeField] private GameObject Main_Panel = null;
    [SerializeField] private AR ar = null;


    [SerializeField] private GameObject[] Image_Target_Array = null;

    private float timer = 0.0f;



    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5.0f)
        {
            Main_Camera.SetActive(true);
            ar.isLoaded = true;
            ar.gameObject.SetActive(false);
            Main_Panel.SetActive(false);

            for(int i = 0; i < Image_Target_Array.Length; i++)
            {
                Image_Target_Array[i].SetActive(true);
            }

            AR_Camera.SetActive(false);
            this.enabled = false;
        }

    }



}
