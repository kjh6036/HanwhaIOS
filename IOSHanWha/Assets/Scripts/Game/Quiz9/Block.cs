using System;
using UnityEngine;

public class Block : MonoBehaviour, IObjectPoolable
{
    public bool canRecyclable { get; set; } = true;

    public Action OnRecycleStartSignature { get; set; }

    public Action OnRecycleFinishSignature { get; set; }

    private RectTransform rectTransform = null;
    private bool isLanding = false;

    private Rigidbody rig = null;


    private void Awake()
    {
        MiniGameManager.Instance.object_List.Add(gameObject);
        rectTransform = GetComponent<RectTransform>();
        rig = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        isLanding = false;
        canRecyclable = false;
        rig.WakeUp();
    }

    private void OnDisable()
    {
        canRecyclable = true;
        rig.velocity = Vector3.zero;
        rig.angularVelocity = Vector3.zero;
        rig.Sleep();
    }

    private void Update()
    {

        if(rectTransform.anchoredPosition.y <= -3000.0f)
        {
            MiniGameManager.Instance.SetDefeatPanel();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isLanding == false)
        {
            isLanding = true;
            MiniGameManager.Instance.blockCount++;
        }
    }
}
