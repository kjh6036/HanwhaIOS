using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;

    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    [SerializeField] AudioClip[] BGMClip; // 오디오 소스들 지정.
    [SerializeField] AudioClip[] audioClip; // 오디오 소스들 지정.

    Dictionary<string, AudioClip> audioClipsDic;
    AudioSource sfxPlayer;
    AudioSource bgmPlayer;

    private void Awake()
    {
        if (Instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            Instance = this; //내자신을 instance로 넣어줍니다.
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

    // 한 번 재생 : 볼륨 매개변수로 지정
    public void PlaySound(string a_name, float a_volume = 1f)
    {
        if (audioClipsDic.ContainsKey(a_name) == false)
        {
            Debug.Log(a_name + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[a_name], a_volume * masterVolumeSFX);
    }

    // 랜덤으로 한 번 재생 : 볼륨 매개변수로 지정
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

    // 삭제할때는 리턴값은 GameObject를 참조해서 삭제한다. 나중에 옵션에서 사운드 크기 조정하면 이건 같이 참조해서 바뀌어야함.
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

    // 주로 전투 종료시 음악을 끈다.
    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    #region 옵션에서 볼륨조절
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
