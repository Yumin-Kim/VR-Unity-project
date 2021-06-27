using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAttributeTree : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform StartPointTransform = null;

    public GameObject StartPoint = null;
    public int ListIndex = 0;
    public bool ChangeRotate = false;

    public static bool StartLogic = false;

    // Start is called before the first frame update
    void Start()
    {
        StartPointTransform = StartPoint.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (StartLogic)
        {
            if (this.gameObject.tag == "BigTree")
            {
                InstaceJikji.ContactedListObject[ListIndex].GetComponent<Transform>().position = StartPointTransform.position;
                if (ChangeRotate)
                    InstaceJikji.ContactedListObject[ListIndex].GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.gameObject.tag == "Templ")
            {

                if (SectionValid.ValidPrefabObject)
                {
                    InstaceJikji.PrefabListObject[ListIndex].AddComponent<Rigidbody>();
                    InstaceJikji.PrefabListObject[ListIndex].GetComponent<Rigidbody>().useGravity = false;
                    InstaceJikji.PrefabListObject[ListIndex].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    InstaceJikji.PrefabListObject[ListIndex].GetComponent<Transform>().position = StartPointTransform.position;
                    if (ChangeRotate)
                    {
                        InstaceJikji.PrefabListObject[ListIndex].GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
                    }
                }
            }
            else
            {
                if (!SectionValid.validRig)
                {
                    InstaceJikji.instanteListObject[ListIndex].GetComponent<Transform>().position = StartPointTransform.position;
                    if (ChangeRotate)
                    {
                        InstaceJikji.instanteListObject[ListIndex].GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
                    }
                }
            }
        }
    }
}
