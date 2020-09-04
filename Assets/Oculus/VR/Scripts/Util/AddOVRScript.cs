using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOVRScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "01-1(Clone)")
        {
            /*
                        Material newMat = Resources.Load("DEV_Orange", typeof(Material)) as Material;
                        collision.gameObject.GetComponent<Renderer>().material = newMat;
                        collision.gameObject.GetComponent<OVRGrabbable>().enabled = false; 
                        OVRchildClass grab = new OVRchildClass();
                        grab.EndGrabChildMethod();
                        grab.Debbuf();
                        */
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }
}
