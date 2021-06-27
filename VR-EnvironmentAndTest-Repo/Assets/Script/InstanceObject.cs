using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceObject : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cc;
    Rigidbody aa;
    Collider dd;
    void Start()
    {
        float a = -1.5f, b = 0.5f, c = 2;
        GameObject[] ob = Resources.LoadAll<GameObject>("3DObject"); // 모든 객체 로드
        for (int i = 0; i < ob.Length; i++)
        {
            ob[i].transform.position = new Vector3(a, b, c);
            ob[i].transform.localScale = new Vector3(50, 50, 50);
            cc = Instantiate(ob[i]);
            cc.AddComponent<Rigidbody>().useGravity = true;
            dd = cc.AddComponent<BoxCollider>();
            dd.enabled = true;
            
            a++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
