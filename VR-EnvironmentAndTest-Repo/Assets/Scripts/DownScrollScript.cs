using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownScrollScript : MonoBehaviour
{
    private BrowserView browserscript = null;
    // Start is called before the first frame update
    void Start()
    {
        browserscript = new BrowserView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        browserscript.InvokeScrollDown();
    }
}
