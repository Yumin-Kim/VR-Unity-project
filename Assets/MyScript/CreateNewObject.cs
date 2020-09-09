using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewObject : MonoBehaviour
{
    // Start is called before the first frame update
    InstanceScript newObject = null;
    void Start()
    {
        GameObject[] ob2 = Resources.LoadAll<GameObject>("3DObj");
        Debug.Log(ob2[2]);
        Instantiate(ob2[2],this.transform);
        Instantiate(ob2[5],this.transform);
        //asd.transform.position = new Vector3(10f, 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
