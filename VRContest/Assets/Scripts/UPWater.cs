using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPWater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveWaterObject.num == 10)
        {
            this.transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
        }
    }
}
