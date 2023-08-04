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
        Register("클라이언트 테스트 아이디");
#elif PLATFORM_IOS
        Register(Social.localUser.id);
#endif
    }




    public void Register(string id)
    {
        if (id == "")
        {
            Debug.Log("로그인에 실패했습니다!");
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
        form.AddField("id", "클라이언트 테스트 아이디");
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
        form.AddField("id", "클라이언트 테스트 아이디");
#elif PLATFORM_IOS
        form.AddField("id", Social.localUser.id);
#endif

        StartCoroutine(GetCouponState(form));
    }

    IEnumerator RegisterSet(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) // 반드시 using을 써야한다
        {
            yield return www.SendWebRequest();

            if (www.isDone)
            {
                Response(www.downloadHandler.text);
            }
            else print("웹의 응답이 없습니다.");
        }
    }

    IEnumerator Post(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) // 반드시 using을 써야한다
        {
            yield return www.SendWebRequest();

            if (www.isDone) Response(www.downloadHandler.text);
            else print("웹의 응답이 없습니다.");
        }
    }


    //IEnumerator GetCoupon(WWWForm form)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) // 반드시 using을 써야한다
    //    {
    //        yield return www.SendWebRequest();
    //
    //        if (www.isDone)
    //        {
    //            MiniGameManager.Instance.remainingCoupons = int.Parse(www.downloadHandler.text);
    //            print(MiniGameManager.Instance.remainingCoupons);
    //        }
    //
    //        else print("웹의 응답이 없습니다.");
    //    }
    //}

    IEnumerator GetCouponState(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) // 반드시 using을 써야한다
        {
            yield return www.SendWebRequest();

            if (www.isDone)
            {
                Response(www.downloadHandler.text);
            }

            else print("웹의 응답이 없습니다.");
        }
    }

    void Response(string json)
    {
        if (string.IsNullOrEmpty(json)) return;

        GD = JsonUtility.FromJson<GoogleData>(json);

        if (GD.result == "ERROR")
        {
            print(GD.order + "을 실행할 수 없습니다. 에러 메시지 : " + GD.msg);
            if (GD.order == "register")
            {
                if (GD.msg == "이미 존재하는 닉네임입니다")
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
                SetCouponState("쿠폰 없음");
            }
        }

        print(GD.order + "을 실행했습니다. 메시지 : " + GD.msg);

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
