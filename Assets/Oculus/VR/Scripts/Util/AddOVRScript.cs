using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOVRScript :  OVRGrabber
{
    protected OVRGrabber m_grabbedBy = null;

    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
   if (other.gameObject.name == "01-1(Clone)")
        {
            base.GrabEnd();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
