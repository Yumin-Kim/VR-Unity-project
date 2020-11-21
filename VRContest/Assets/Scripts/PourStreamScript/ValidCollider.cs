using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidCollider : MonoBehaviour
{
    public MoveWaterObject moveWaterObject = null;


/*    public MoveWaterObject text
    {
        get { return move; }
    }
*/
    // Start is called before the first frame update
    void Start()
    {
        moveWaterObject = new MoveWaterObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "liquid")
        {
            Debug.Log(other.gameObject.name);
            MoveWaterObject.CheckMove = true;
        }
        else
            MoveWaterObject.CheckMove = false;

    }

}
