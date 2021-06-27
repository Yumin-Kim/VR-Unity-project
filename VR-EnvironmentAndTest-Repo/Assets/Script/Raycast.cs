using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EventValid
{
    public  bool event_Trigger;
    public bool event_1;
}

public class Raycast : MonoBehaviour
{
    #region Private
    private bool triggerDown;
    private bool granCube;
    private bool matchCube = false;
    private EventValid getTrigger = new EventValid();
    private Transform Cube;
    #endregion
    [SerializeField]
    public GameObject box,parent,parentHand;
    Rigidbody boxCollider;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) triggerDown = true;
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) triggerDown = false;
        if (triggerDown)
        {
            Debug.Log(triggerDown);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 15f))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name== "71_1(Clone)")
                {
                    hit.transform.position = transform.position + transform.forward * 1f;
                }
                //catch cube
                if (hit.collider.CompareTag("cube_1")&& !matchCube) 
                { 
                    hit.transform.position = transform.position + transform.forward * 4f;
                    granCube = true;
                }
                if (hit.collider.CompareTag("puzzle_1") && granCube)
                {
                    box.transform.position = hit.transform.position;
                    box.transform.rotation = Quaternion.Euler(0, 0, 0);
                    box.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    hit.transform.position = new Vector3(0, 0, 0);
                    matchCube = true;
                 }
                if (hit.collider.CompareTag("cube_2") && getTrigger.event_1) hit.transform.position = transform.position + transform.forward * 3f;
                if (hit.collider.CompareTag("cube_3")) hit.transform.position = transform.position + transform.forward * 3f;
            }
        }
    }


}
