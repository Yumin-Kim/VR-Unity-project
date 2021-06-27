using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartMusicScript : MonoBehaviour
{
    private Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

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
