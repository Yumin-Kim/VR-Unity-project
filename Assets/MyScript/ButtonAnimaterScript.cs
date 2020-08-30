using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimaterScript : MonoBehaviour
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
        if (!ContactConfirmScript.checkBox1Valid || !ContactConfirm2Script.checkBox2Valid || !ContactConfirm3Script.checkBox3Valid || !ContactConfirm4Script.checkBox4Valid)
        {
            InstanceScript.CheckButtonTrigger = false;
        }
        else
        {
            anim.Play();
            InstanceScript.CheckButtonTrigger = true;
        }
    }

}
