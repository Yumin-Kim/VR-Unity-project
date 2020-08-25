using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddImagesScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Texture image;

    void Start()
    {
        //image = Resources.Load("Images/3_유유상종", typeof(Texture)) as Texture;
        //gameObject.GetComponent<Renderer>().material.mainTexture = image;

    }

    // Update is called once per frame
    void Update()
    {
        if(InstanceScript.ChangeImageBool)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = InstanceScript.TextureCollect[InstanceScript.G_Count];
        }
    }
}
