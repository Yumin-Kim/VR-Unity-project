using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartMusicScript : MonoBehaviour
{
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GrabVolumeBig" || other.gameObject.name == "RightHandAnchor")
        {
            anim.Play();
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
