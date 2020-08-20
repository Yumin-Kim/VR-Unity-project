using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VrGrabber;
public class InstanceScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cc;
    Rigidbody aa;
    BoxCollider dd;
    OVRGrabbable grab;
    private BoxCollider collide;
    void Start()
    {
        float a = -1.5f, b = 0.5f, c = 2;
        GameObject[] ob = Resources.LoadAll<GameObject>("3DObject"); // 모든 객체 로드
        for (int i = 0; i < ob.Length; i++)
        {
            Vector3 position = new Vector3(a, b, c);
            /*
            ob[i].AddComponent<OVRGrabbable>();
            
            //ob[i].AddComponent<OVRGrabbable>();
            dd = cc.AddComponent<BoxCollider>();
            dd.enabled = true;
            */
            cc = Instantiate(ob[i]);
            collide = cc.AddComponent<BoxCollider>();
            grab = cc.AddComponent<OVRGrabbable>();
            cc.AddComponent<Rigidbody>().useGravity = true;
            grab.CustomGrabCollider(collide);
            //cc.AddComponent<Rigidbody>().useGravity = true;
            //Collider[] newGrabPoints = new Collider[1];
            //newGrabPoints[0] = collide;
            //Instantiate(ob[i]);
            a++;
        }

    }
    public void CustomGrabCollider(Collider collider)
    {
        grab.m_grabPoints = new Collider[1] { collider };
    }

    public static T Create<T>(GameObject gameObject) where T : MonoBehaviour
    {
        return gameObject.AddComponent<T>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
