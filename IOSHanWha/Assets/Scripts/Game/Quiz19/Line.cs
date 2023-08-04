using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Line : MonoBehaviour
{ 
    [SerializeField] private Quiz19 quiz = null;
    [SerializeField] private Canvas canvas;
    private BoxCollider col = null;
    public CanvasScaler canvasScaler;

    private float lineWidth = 1.0f;
    private LineRenderer lr;
    private Vector3[] linePoints = new Vector3[2];

    public GameObject connectedProduct = null;
    private RaycastHit hit;

    [SerializeField] private bool mouseButton = false;

    public List<GameObject> DisConnect_List = null;

    public int index = 1;
    public bool isConnect = false;
    public int max_Connet_Count = 2;
    public int stack = 0;

    [SerializeField] private Camera My_Camera = null;
    private void Awake()
    {
        col = GetComponent<BoxCollider>();
    }
    private void OnMouseDown()
    {
        mouseButton = true;
    }
    private void OnMouseUp()
    {
        if (stack >= max_Connet_Count)
            return;

        mouseButton = false;
        lr.enabled = false;

        Ray ray = My_Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject != this.gameObject)
            {
                for(int i = 0; i < DisConnect_List.Count; i++)
                {
                    if(hit.transform.gameObject == DisConnect_List[i])
                    {
                        connectedProduct = null; /* 빈 공간 hit */
                        return;
                    }
                }

                connectedProduct = hit.collider.gameObject;

                lr.enabled = true;

                /* 선택된 오브젝트에 라인 연결 */
                linePoints[1] = hit.collider.gameObject.transform.position;

                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, hit.transform.position);

                col.enabled = false;
                quiz.SetStack(index, hit.transform.GetComponent<Line>().index);

                return;
            }

            if (hit.collider.gameObject == this.gameObject)
            {
                if (connectedProduct == null) return;
            }
        }

        connectedProduct = null; /* 빈 공간 hit */

    }

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        lr.material.color = Color.blue;
        lr.widthMultiplier = lineWidth;
        linePoints[0] = transform.position; /* 첫번째 점의 위치는 gameobject */
        lr.positionCount = linePoints.Length;
 
    }

    void Update()
    {
        if (stack >= max_Connet_Count)
            return;
        if (mouseButton)
        {
            lr.enabled = true;

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 99.0f;
            mousePos = My_Camera.ScreenToWorldPoint(mousePos);

            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, mousePos);
        }
    }


    
}
