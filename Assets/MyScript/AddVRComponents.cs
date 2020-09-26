using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVRComponenets : MonoBehaviour
{
    public bool freeMoving = false;
    public bool useGravity = false;
    private BoxCollider collide;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ab = Resources.Load<GameObject>("Cube");
        Instantiate(ab);
        collide = gameObject.AddComponent<BoxCollider>();

        Rigidbody rB = gameObject.AddComponent<Rigidbody>();
        if (!freeMoving)
        {
            rB.drag = Mathf.Infinity;
            rB.angularDrag = Mathf.Infinity;
        }
        if (!useGravity)
        {
            rB.useGravity = false;
        }

        OVRGrabbable grab = gameObject.AddComponent<OVRGrabbable>();
        Collider[] newGrabPoints = new Collider[1];
        newGrabPoints[0] = collide;
        grab.enabled = true;
        //grab.CustomGrabCollider(collide);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
