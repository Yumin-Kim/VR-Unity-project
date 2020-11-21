using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnButton : MonoBehaviour
{

    public Transform JikjiPositoin = null;
    public GameObject JikjiSets = null;

    private Transform JikjiSetsPosition = null;
    // Start is called before the first frame update
    void Start()
    {
        JikjiSetsPosition = JikjiSets.transform.GetChild(InstaceJikji.G_Number +1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GrabVolumeBig" || other.gameObject.name == "RightHandAnchor" || other.gameObject.name == "LeftHandAnchor")
        {
            for (int i = 0; i < InstaceJikji.PrefabListObject.Count; i++)
            {
                InstaceJikji.PrefabListObject[i].SetActive(false);
            }
            JikjiSetsPosition.GetComponent<Transform>().position = JikjiPositoin.GetComponent<Transform>().position;
        }
    }

}
