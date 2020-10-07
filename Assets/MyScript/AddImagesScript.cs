using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddImagesScript : MonoBehaviour
{
    
    void Update()
    {
                if(InstanceScript.ChangeImageBool)
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = InstanceScript.TextureCollect[InstanceScript.G_Count];
                }
    }
}
