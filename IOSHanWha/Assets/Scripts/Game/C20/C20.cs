using UnityEngine;


public class C20 : MonoBehaviour
{
    [SerializeField] private GameObject Main = null;

    public void GameStartButton()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        SoundManager.Instance.SetupBGM(0);
        Main.SetActive(true);
        gameObject.SetActive(false);
    }

}
