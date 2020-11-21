using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRCustomGrabbable : OVRGrabbable
{
    // Start is called before the first frame update
    
    void Start()
    {
        base.Start();
    }
    
    virtual public void CustomGrabCollider(Collider collider)
    {
        base.m_grabPoints = new Collider[1] { collider };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    void Awake()
    {
        Collider collider = this.GetComponent<Collider>();

        if (m_grabPoints == null)
        {
            CustomGrabCollider(collider);
        }
        if (m_grabPoints.Length == 0)
        {
            // Get the collider from the grabbable
            /*
           if (collider == null)
           {
               throw new ArgumentException("Grabbables cannot have zero grab points and no collider -- please add a grab point or collider.");
           }
           */
            // Create a default grab point
            m_grabPoints = new Collider[1] { collider };
        }
    }

}
