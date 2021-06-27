using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBowl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // left - down
        //right - forward
        this.transform.Translate(Vector3.down * 0.2f * Time.deltaTime);
    }
}
