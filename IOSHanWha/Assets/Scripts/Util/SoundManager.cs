using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;

    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    [SerializeField] AudioClip[] BGMClip; // ����� �ҽ��� ����.
    [SerializeField] AudioClip[] audioClip; // ����� �ҽ��� ����.

    Dictionary<string, AudioClip> audioClipsDic;
    AudioSource sfxPlayer;
    AudioSource bgmPlayer;

    private void Awake()
    {
        if (Instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            Instance = this; //���ڽ��� instance�� �־��ݴϴ�.
        }
    }

    private void Start()
    {
        if (bgmPlayer != null)
        {
            bgmPlayer.Play();
        }
        AwakeAfter();
    }

    void AwakeAfter()
    {
        sfxPlayer = GetComponent<AudioSource>();

        audioClipsDic = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in audioClip)
        {
            audioClipsDic.Add(a.name, a);
        }
    }

    public void SetupBGM(int index)
    {
        if (BGMClip == null) return;

        if(bgmPlayer == null)
        {
            GameObject child = new GameObject("BGM");
            child.transform.SetParent(transform);
            bgmPlayer = child.AddComponent<AudioSource>();
        }
        bgmPlayer.clip = BGMClip[index];
        bgmPlayer.volume = masterVolumeBGM;
        bgmPlayer.loop = true;
        bgmPlayer.Play();
    }

    // �� �� ��� : ���� �Ű������� ����
    public void PlaySound(string a_name, float a_volume = 1f)
    {
        if (audioClipsDic.ContainsKey(a_name) == false)
        {
            Debug.Log(a_name + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[a_name], a_volume * masterVolumeSFX);
    }

    // �������� �� �� ��� : ���� �Ű������� ����
    public void PlayRandomSound(string[] a_nameArray, float a_volume = 1f)
    {
        string l_playClipName;

        l_playClipName = a_nameArray[Random.Range(0, a_nameArray.Length)];

        if (audioClipsDic.ContainsKey(l_playClipName) == false)
        {
            Debug.Log(l_playClipName + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[l_playClipName], a_volume * masterVolumeSFX);
    }

    // �����Ҷ��� ���ϰ��� GameObject�� �����ؼ� �����Ѵ�. ���߿� �ɼǿ��� ���� ũ�� �����ϸ� �̰� ���� �����ؼ� �ٲ�����.
    public GameObject PlayLoopSound(string a_name)
    {
        if (audioClipsDic.ContainsKey(a_name) == false)
        {
            Debug.Log(a_name + " is not Contained audioClipsDic");
            return null;
        }

        GameObject l_obj = new GameObject("LoopSound");
        AudioSource source = l_obj.AddComponent<AudioSource>();
        source.clip = audioClipsDic[a_name];
        source.volume = masterVolumeSFX;
        source.loop = true;
        source.Play();
        return l_obj;
    }

    // �ַ� ���� ����� ������ ����.
    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    #region �ɼǿ��� ��������
    public void SetVolumeSFX(float a_volume)
    {
        masterVolumeSFX = a_volume;
    }

    public void SetVolumeBGM(float a_volume)
    {
        masterVolumeBGM = a_volume;
        bgmPlayer.volume = masterVolumeBGM;
    }
    #endregion


}
