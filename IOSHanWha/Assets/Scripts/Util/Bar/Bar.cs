using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    // 채움 상태를 변경할 Image 컴포넌트를 참조할 변수
    [SerializeField] private Image _FillBarImage = null;

    public float bar = 0.0f;
    public float maxBar = 0.0f;

    // 체력을 설정합니다.
    public void SetBar()
    {
        // 최대 체력에 맞춰 체력을 채우며, 0 미만의 값이나 
        // 최대 체력의 값을 넘지 못하도록 합니다.
        _FillBarImage.fillAmount = Mathf.Clamp(
            bar / maxBar,
            0.0f,
            maxBar);
    }
}
