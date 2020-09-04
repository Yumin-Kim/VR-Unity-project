using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRchildClass : OVRGrabber
{
    // Start is called before the first frame update
    public void EndGrabChildMethod()
    {
        base.CheckForGrabOrRelease(0.35f);
    }
    public void Debbuf()
    {
        Debug.Log("Hello");
    }
}
