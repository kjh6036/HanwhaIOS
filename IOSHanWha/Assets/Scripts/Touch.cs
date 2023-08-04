using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private int CurrentFingerID = -1;

    private bool IsTouched = false;
    private Vector2 OldMouse = Vector2.zero;

    private Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Drag();
    }


    private void Drag()
    {
        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    TouchStart();
                    break;
                case TouchPhase.Ended:
                    if (Input.GetTouch(0).fingerId == CurrentFingerID)
                        TouchEnd();
                    break;
                default:
                    break;
            }
        }
    }

    void TouchStart()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
             IsTouched = true;
             OldMouse = Input.GetTouch(0).position;
             CurrentFingerID = Input.GetTouch(0).fingerId;
        }
    }


    protected void TouchEnd()
    {
        if (IsTouched)
        {
            if ((OldMouse - Input.GetTouch(0).position).magnitude <= 1250.0f)
            {
                IsTouched = false;
                OldMouse = Vector3.zero;
                CurrentFingerID = -1;
                return;
            }
            else
            {
                animator.SetTrigger("Drag");
            }

        }
    }
}
