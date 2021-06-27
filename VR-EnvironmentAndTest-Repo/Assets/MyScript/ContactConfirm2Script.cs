using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactConfirm2Script : MonoBehaviour
{
    public static bool checkBox2Valid;
    private Material newMat11;
    int num;

    void Start()
    {
        num = 0;
    }


    void OnTriggerEnter(Collider col)
    {
        num = (InstanceScript.G_Count * 4) % 4+1;
        if (InstanceScript.G_Count > 0)
        {
            num = InstanceScript.G_Count * 4 + 1;
        }
            if (col.gameObject.name.Split('(')[0] == InstanceScript.ob[num].name)
            {
                newMat11 = Resources.Load("DEV_Orange", typeof(Material)) as Material;
                col.GetComponent<Renderer>().material = newMat11;
                col.gameObject.GetComponent<Rigidbody>().useGravity = false;
                col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                col.gameObject.transform.position = this.gameObject.transform.position + new Vector3(-0.2f, -0.15f, -0.15f);
                col.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                checkBox2Valid = true;
            }
            else
            {
                newMat11 = Resources.Load("MaterialA", typeof(Material)) as Material;
                col.GetComponent<Renderer>().material = newMat11;
            }
    }
}
