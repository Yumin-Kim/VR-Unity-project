using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionValid : MonoBehaviour
{
    MoveWaterObject moveWaterObject = null;
    public GameObject EndPoint = null;
    public GameObject TreePoint = null;
    public GameObject moveObject = null;
    public GameObject PoulObject = null;
    public GameObject jikjiTree = null;
    public Material m_mesh = null;
    public GameObject CupName = null;
    //public GameObject MatchObject = null;
    //public OVRCustomGrabbable Grabbable = null;
    public static bool validRig = false;
    public static bool ValidPrefabObject = false;

    private Transform JikjiColumn = null;
    private Transform[] jikjiTrees = null;
    private GameObject[] CupCollider = null;
    // Start is called before the first frame update
    void Start()
    {
        moveWaterObject = moveObject.GetComponent<MoveWaterObject>();
        JikjiColumn = jikjiTree.transform.FindChild("Cube").FindChild("Tree");
        CupCollider = GameObject.FindGameObjectsWithTag("CupCollider");
        EnableCollider(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        OVRCustomGrabbable grabbable = null;
        if (other.gameObject.name == "PlayerController")
        {
            EndPoint.GetComponent<Transform>().position = PoulObject.GetComponent<Transform>().position;
            jikjiTree.GetComponent<Transform>().position = TreePoint.GetComponent<Transform>().position;
            if (this.gameObject.tag != "Step5")
            {
                MoveWaterObject.MatchAStep4 = true;
                moveWaterObject.Valid = true;
                EnableCollider(true);
                CupName.gameObject.SetActive(true);
                jikjiTree.SetActive(false);
                for (int i = 0; i < InstaceJikji.instanteListObject.Count; i++)
                {
                    InstaceJikji.instanteListObject[i].SetActive(false);
                }
            }
            else if (this.gameObject.tag == "Step5")
            {
                GameObject[] jikjiTag = null;
                ValidPrefabObject = true;
                EnableCollider(false);
                JikjiColumn.GetComponent<MeshRenderer>().material = m_mesh;
                for (int i = 0; i < JikjiColumn.childCount; i++)
                {
                    JikjiColumn.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = m_mesh;
                }
                
                GameObject.Find("cupShape").SetActive(false);
                jikjiTag = GameObject.FindGameObjectsWithTag("HalfCup");
                for (int i = 0; i < jikjiTag.Length; i++)
                {
                    jikjiTag[i].SetActive(false);
                }
                moveWaterObject.GetComponent<MeshRenderer>().enabled = false;
            }
            if (this.gameObject.tag == "Step6")
            {
                print("Step6 Section");
                for (int i = 0; i < InstaceJikji.PrefabListObject.Count; i++)
                {
                    BoxCollider boxCollider = null;
                    InstaceJikji.PrefabListObject[i].GetComponent<Rigidbody>().useGravity = true;
                    InstaceJikji.PrefabListObject[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                    boxCollider = InstaceJikji.PrefabListObject[i].gameObject.GetComponent<BoxCollider>();
                    boxCollider.enabled = true;
                    grabbable = InstaceJikji.PrefabListObject[i].gameObject.AddComponent<OVRCustomGrabbable>();
                    grabbable.CustomGrabCollider(boxCollider);
                }
            }
        }

    }

    private void EnableCollider(bool ColliderEnable)
    {
        for (int i = 0; i < CupCollider.Length; i++)
        {
            CupCollider[i].GetComponent<CapsuleCollider>().enabled = ColliderEnable;
        }
    }


}
