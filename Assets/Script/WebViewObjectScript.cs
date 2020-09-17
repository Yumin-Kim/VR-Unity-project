using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebViewObjectScript : MonoBehaviour
{
    // Start is called before the first frame update

    private WebViewObject webViewObject;
    void Start()
    {
        startWebView();
    }

    private void startWebView()
    {
        string NaverUrl = "https://www.naver.com";
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) =>
        {
            Debug.Log(string.Format("CallForm[{0}]", msg));
        });
        webViewObject.LoadURL(NaverUrl);
        webViewObject.SetVisibility(true);
        webViewObject.SetMargins(50, 50, 50, 50);
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.GetKey(KeyCode.Escape))
            {
                Destroy(webViewObject);
                return;
            }
        }


    }
}
