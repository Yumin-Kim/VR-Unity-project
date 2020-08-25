using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject a;
    public static bool checkBox1Valid;
    private bool transformVar;
    private PhysicMaterial physicMaterial;
    private Material newMat11;
    protected OVRGrabbable m_grabbedObj = null;
    int num;

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRayCast();
    }

    public float grabEnd = 0.35f;
    private void CheckRayCast()
    {
        float ab = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        checkBox1Valid = false;
        if (ab <= grabEnd)
        //if (OVRGrabber.CheckThisGrab)
        {
            if (Physics.Raycast(transform.position, transform.up, out hit))
            {
                if (hit.distance < 0.7f)
                {
                    a = hit.collider.gameObject;
                    num = (InstanceScript.G_Count * 4) % 4;
                    if (InstanceScript.G_Count > 0)
                    {
                        num = InstanceScript.G_Count * 4;
                    }
                    if (hit.collider.gameObject.name.Split('(')[0] == InstanceScript.ob[num].name)
                    {
                        physicMaterial = Resources.Load("NotBonce", typeof(PhysicMaterial)) as PhysicMaterial;
                        newMat11 = Resources.Load("DEV_Orange", typeof(Material)) as Material;
                        a.GetComponent<Collider>().material = physicMaterial;
                        a.GetComponent<Renderer>().material = newMat11;
                        checkBox1Valid = true;
                    }
                    else
                    {
                        newMat11 = Resources.Load("MaterialA", typeof(Material)) as Material;
                        physicMaterial = Resources.Load("Bonce", typeof(PhysicMaterial)) as PhysicMaterial;
                        a.GetComponent<Collider>().material = physicMaterial;
                        a.GetComponent<Renderer>().material = newMat11;
                        a.transform.position = hit.transform.position + new Vector3(0, 0, 0.65f);
                    }

                }

            }
        }

    }
}

