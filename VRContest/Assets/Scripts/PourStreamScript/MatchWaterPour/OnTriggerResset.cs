using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerResset : MonoBehaviour
{
    private GameObject[] HalfCylinder = null;

    private int Counter = 0;
    public static bool startPoint = false;
    private float timer1;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (startPoint)
        {
            HalfCylinder = GameObject.FindGameObjectsWithTag("HalfCylinder");
            Debug.Log(HalfCylinder[0]);
            Counter++;
            timer1 += Time.deltaTime;
            HalfCylinder[0].transform.Translate(Vector3.down * 0.2f * Time.deltaTime);
            HalfCylinder[1].transform.Translate(Vector3.down * 0.2f * Time.deltaTime);
        }
        if (timer1 >= 1f)
        {
            startPoint = false;
            timer1 = 0;
        }
        if (Counter == 30)
        {
            HalfCylinder[0].gameObject.SetActive(false);
            HalfCylinder[1].gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MatchCylinder")
        {
            //3구역 제어 
            MoveWaterObject.StopAnimat = true;
            //움직임 제어
            MoveWaterObject.CheckMove = false;
            //4구역
            if (other.gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                Debug.Log("Red materail");
                MoveWaterObject.MatchAStep4 = false;
            }
        }
    }
}
