using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaceJikji : MonoBehaviour
{
    public static GameObject[] Jikji;

    public static int G_Number = 0;
    public static GameObject instanteObject;
    public static GameObject ContatedinstanceObject;
    public static GameObject PrefabInstanceObject;

    public static List<GameObject> instanteListObject { get; private set; }
    public static List<GameObject> ContactedListObject = null;
    public static List<GameObject> PrefabListObject = null;

    // Start is called before the first frame update
    void Start()
    {
        Jikji = Resources.LoadAll<GameObject>("3DObj");
   //     JikjiPrefabs = Resources.LoadAll<GameObject>("3DObj");
        CreatJikji(G_Number);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void CreatJikji(int validNumber)
    {
        instanteListObject = new List<GameObject>();
        ContactedListObject = new List<GameObject>();
        PrefabListObject = new List<GameObject>();
        Rigidbody rigidbody;
        for (int i = validNumber; i < validNumber+ 4; i++)
        {
            //관상용
            instanteObject = Instantiate(Jikji[i]);
            //체험용
            ContatedinstanceObject = Instantiate(Jikji[i]);
            //실질적으로 다룰 객체
            PrefabInstanceObject = Instantiate(Jikji[i]);
            /*rigidbody = instanteObject.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
            instanteObject.AddComponent<BoxCollider>();*/
            PrefabInstanceObject.AddComponent<BoxCollider>();
            PrefabInstanceObject.GetComponent<BoxCollider>().enabled = false;
            PrefabInstanceObject.transform.localScale = new Vector3(30, 30, 30);
            PrefabListObject.Add(PrefabInstanceObject);
            instanteObject.transform.localScale = new Vector3(25, 25, 25);
            instanteListObject.Add(instanteObject);
            ContatedinstanceObject.transform.localScale = new Vector3(50, 50, 50);
            ContactedListObject.Add(ContatedinstanceObject);
        }

        AddAttributeTree.StartLogic= true;
    }

   

}
