using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class GoogleSheetManager : MonoBehaviour
{

    public const string URL = "https://script.google.com/macros/s/AKfycbx48kLf9APCitSpBCsHpsB_h9qEdO4W2GmDEf1iqOEu_JEsfoQjBsRlddtXrvfO6ZRp/exec";

    public GoogleData GD;

    private void Awake()
    {
        Act();
    }

    private void Act()
    {
        GetCoupon();
#if UNITY_EDITOR
        Register("Ŭ���̾�Ʈ �׽�Ʈ ���̵�");
#elif PLATFORM_IOS
        Register(Social.localUser.id);
#endif
    }




    public void Register(string id)
    {
        if (id == "")
        {
            Debug.Log("�α��ο� �����߽��ϴ�!");
            return;
        }

        WWWForm form = new WWWForm();
        form.AddField("order", "register");
        form.AddField("id", id);
        form.AddField("time", DateTime.Now.ToString());
        form.AddField("device", SystemInfo.deviceModel);

        StartCoroutine(RegisterSet(form));
    }


    public void Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "login");
        form.AddField("id", "11");

        StartCoroutine(Post(form));
    }

    public void SetValue(string text)
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "setValue");
        form.AddField("value", text);

        StartCoroutine(Post(form));
    }

    public void GetValue()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "getValue");

        StartCoroutine(Post(form));
    }


    public void GetCoupon()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "getCoupon");

        StartCoroutine(Post(form));
    }


    public void SetCoupon()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "setCoupon");

        StartCoroutine(Post(form));
    }

    public void SetCouponState(string text)
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "setCouponState");

#if UNITY_EDITOR
        form.AddField("id", "Ŭ���̾�Ʈ �׽�Ʈ ���̵�");
#elif PLATFORM_IOS
        form.AddField("id", Social.localUser.id);
#endif
        form.AddField("couponState", text);

        StartCoroutine(Post(form));
    }

    public void GetCouponState()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "getCouponState");
#if UNITY_EDITOR
        form.AddField("id", "Ŭ���̾�Ʈ �׽�Ʈ ���̵�");
#elif PLATFORM_IOS
        form.AddField("id", Social.localUser.id);
#endif

        StartCoroutine(GetCouponState(form));
    }

    IEnumerator RegisterSet(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) // �ݵ�� using�� ����Ѵ�
        {
            yield return www.SendWebRequest();

            if (www.isDone)
            {
                Response(www.downloadHandler.text);
            }
            else print("���� ������ �����ϴ�.");
        }
    }

    IEnumerator Post(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) // �ݵ�� using�� ����Ѵ�
        {
            yield return www.SendWebRequest();

            if (www.isDone) Response(www.downloadHandler.text);
            else print("���� ������ �����ϴ�.");
        }
    }


    //IEnumerator GetCoupon(WWWForm form)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) // �ݵ�� using�� ����Ѵ�
    //    {
    //        yield return www.SendWebRequest();
    //
    //        if (www.isDone)
    //        {
    //            MiniGameManager.Instance.remainingCoupons = int.Parse(www.downloadHandler.text);
    //            print(MiniGameManager.Instance.remainingCoupons);
    //        }
    //
    //        else print("���� ������ �����ϴ�.");
    //    }
    //}

    IEnumerator GetCouponState(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) // �ݵ�� using�� ����Ѵ�
        {
            yield return www.SendWebRequest();

            if (www.isDone)
            {
                Response(www.downloadHandler.text);
            }

            else print("���� ������ �����ϴ�.");
        }
    }

    void Response(string json)
    {
        if (string.IsNullOrEmpty(json)) return;

        GD = JsonUtility.FromJson<GoogleData>(json);

        if (GD.result == "ERROR")
        {
            print(GD.order + "�� ������ �� �����ϴ�. ���� �޽��� : " + GD.msg);
            if (GD.order == "register")
            {
                if (GD.msg == "�̹� �����ϴ� �г����Դϴ�")
                {
                    GetCouponState();
                }
            }
            return;
        }
        else
        {
            if (GD.order == "register")
            {
                SetCouponState("���� ����");
            }
        }

        print(GD.order + "�� �����߽��ϴ�. �޽��� : " + GD.msg);

        if (GD.order == "getCouponState")
        {
            MiniGameManager.Instance.couponState = GD.msg;
            print(MiniGameManager.Instance.couponState);
        }
        if(GD.order == "getCoupon")
        {
            MiniGameManager.Instance.remainingCoupons = int.Parse(GD.msg);
            print(MiniGameManager.Instance.remainingCoupons);
        }
    }




}
