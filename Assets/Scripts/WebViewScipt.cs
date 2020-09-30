using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebViewScipt : MonoBehaviour
{
    private WebViewObject webViewObject;
    // Start is called before the first frame update
    void Start()
    {
        StartWebView();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Application.platform == RuntimePlatform.Android) {
        if (Input.GetKey(KeyCode.Escape))
        {                    // 뒤 로 가 기, esc 버 튼 
            Destroy(webViewObject);
            return;
        }
        //}
    }

    public void StartWebView()
    {

        string strUrl = "https://sanctacrux.tistory.com/669";

        webViewObject = (new GameObject("WebviewPanel")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) => {
            Debug.Log(string.Format("CallFromJS[{0}]", msg));
        });

        webViewObject.LoadURL(strUrl);
        webViewObject.SetVisibility(true);
        webViewObject.SetMargins(50, 50, 50, 50);
    }
}
