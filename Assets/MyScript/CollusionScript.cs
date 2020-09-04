using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollusionScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody a;
    void Start()
    {
        a = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        a.AddForce(new Vector3(0, 0, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Material newMat = Resources.Load("DEV_Orange", typeof(Material)) as Material;
        other.gameObject.GetComponent<Renderer>().material = newMat;
        OVRchildClass grab = new OVRchildClass();
    }
}
