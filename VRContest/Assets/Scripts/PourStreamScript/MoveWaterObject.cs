using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWaterObject : MonoBehaviour
{
    private Transform m_position = null;
    private Renderer m_Material = null;

    public static bool CheckMove = false;
    public static bool StopAnimat = false;
    public static bool MatchAStep4 = false;




    public bool Valid = false;
    public static int num = 0;
    public GameObject StartPoint = null;
    public GameObject SteelObject = null;
    public OnTriggerResset ScriptOnTrigger = null;
    public GameObject bowl = null;
    public GameObject PrevBowl = null;

    // Start is called before the first frame update
    void Start()
    {
        m_position = StartPoint.GetComponent<Transform>();
        m_Material = this.gameObject.GetComponent<Renderer>();
        m_Material.material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        /* Debug.Log(CheckMove);
         if (CheckMove)
         {
             this.transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
         }
         if (CheckReset)
         {
             CheckReset = false;
         }
         if (Step4Move)
         {
         }
         if (MatchAStep4)
         {
             this.transform.position = m_position.position;
             m_Material.material.color = Color.red;
             this.transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
             num = 10;
         }
         if(m_Material.material.color == Color.red)
         {
             if (Valid)
             {
                 StopPour = false;
             }
         }*/
       /* if (!MatchAStep4)
        {
       */     if (!StopAnimat)
            {
                if (CheckMove)
                {
                    this.transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
                }
            }
        //}
        if (MatchAStep4)
        {
            if (m_Material.material.color == Color.red && CheckMove)
            {
                this.transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Step4Section")
        {
            this.transform.position = m_position.position;
            m_Material.material.color = Color.red;
            PrevBowl.SetActive(false);
            bowl.SetActive(true);
            CheckMove = false;
            MatchAStep4 = true;
            StopAnimat = true;
        }
        if (other.gameObject.name == "HammerH")
        {
            OnTriggerResset.startPoint = true;
        }
    }

}
