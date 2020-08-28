using OculusSampleFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VrGrabber;

public class InstanceScript : MonoBehaviour
{
    // Start is called before the first frame update
    private OVRGrabbable grab;
    private BoxCollider collide;
    private GameObject instanceOfGameObject;
    private AudioSource audioSourece;
    private bool n_ChangeVariable;

    public static int G_Count;
    public GameObject[] images;
    public AudioClip[] audioClips;
    public static Texture[] TextureCollect;
    public static bool ChangeImageBool;
    public static GameObject[] ob;
    public static GameObject[] ob1;
    public static List<GameObject> DestoryObjectList;

    private int Checkofindex;
    private int random;

    void Start()
    {
        //파일 Resource에서 로드
        ob = Resources.LoadAll<GameObject>("3DObject"); // 모든 객체 로드
        ob1 = Resources.LoadAll<GameObject>("3DObj"); // 모든 객체 로드
        DestoryObjectList = new List<GameObject>();
        audioClips = Resources.LoadAll<AudioClip>("Music");
        TextureCollect = Resources.LoadAll<Texture>("Images");
        int a = 0;
        for (int i = 0; i < ob1.Length; i++)
        {
            a = Int32.Parse(ob1[i].name.Split('_')[0]);
            Debug.Log(">>>" + a);
        }

        Checkofindex = 0;
        n_ChangeVariable = false;
        G_Count = 0;
        ChangeImageBool = true;
        InstanceGameObject(G_Count);
        /*
                ContactConfirmScript.checkBox1Valid = true;
                ContactConfirm2Script.checkBox2Valid = true;
                ContactConfirm3Script.checkBox3Valid = true;
                ContactConfirm4Script.checkBox4Valid = true;
                */
    }
    /// <summary>
    /// update 문에서 참일때 쓰레드 생성 하여 descsoty하기 전에 lock걸고 동작후에 다른 동작 할  수 있게끔 
    /// </summary>

    private float fDestroyTime = 1f;
    private float fTickTime;
    private bool DestoryGameObject(int index)
    {
        Checkofindex = 0;
        if (index != 0)
        {
            Checkofindex = G_Count * 4;
        }
        Debug.Log(Checkofindex + ">>>>>>");
        for (int i = Checkofindex; i < (Checkofindex + 4); i++)
        {
            //Destroy(DestoryObjectList[i],0.1f);
            DestoryObjectList[i].SetActive(false);
        }
        return true;
    }

    private bool asd;
    float timer;
    float timer1;

    bool Hello;
    bool Hello1;
    // Update is called once per frame
    private void LateUpdate()
    {
        if (Hello)
        {
            timer += Time.deltaTime;
        }
        if (Hello1)
        {
            timer1 += Time.deltaTime;
        }
        Debug.Log(" timer    : " + timer + " seconds");
        if (ContactConfirmScript.checkBox1Valid && ContactConfirm2Script.checkBox2Valid && ContactConfirm3Script.checkBox3Valid && ContactConfirm4Script.checkBox4Valid)
        {
            Hello = true;
            Hello1 = true;
            ChangeImageBool = false;
            
            ContactConfirmScript.checkBox1Valid = false;
            ContactConfirm2Script.checkBox2Valid = false;
            ContactConfirm3Script.checkBox3Valid = false;
            ContactConfirm4Script.checkBox4Valid = false;
        }
        if (timer1 > 1f)
        {
            Hello1 = false;
            timer1 = 0;
            DestoryGameObject(G_Count);
            ChangeImageBool = true;
            G_Count++;
        }
        if (timer > 1.5f)
        {
            Hello = false;
            timer = 0f;
            InstanceGameObject((G_Count * 4));
        }

    }
    //게임 오브젝트마다 해당하는 노래 추가
    private void InstanceGameObject(int counter)
    {
        Debug.Log(counter);
        float XAxis = -1.5f, YAxis = 0.5f, ZAxis = 2;
        for (int i = counter; i < counter + 4; i++)
        {
            //random = Random.Range(-2,2);
            //random * 0.2f *
            if (ZAxis > 0.4f)
            {
                ZAxis = -0.5f;
            }
            else
            {
                ZAxis = 0.5f;

            }
            ob[i].transform.position = new Vector3(XAxis, YAxis, ZAxis);
            //ob[i].transform.localScale= new Vector3(0.5f, 0.5f, 0.5f);
            instanceOfGameObject = Instantiate(ob[i]);
            instanceOfGameObject.transform.localScale = new Vector3(50f, 50f, 50f);
            collide = instanceOfGameObject.AddComponent<BoxCollider>();
            //collide.size = new Vector3();
            audioSourece = instanceOfGameObject.AddComponent<AudioSource>();
            instanceOfGameObject.AddComponent<Rigidbody>().useGravity = true;
            audioSourece.clip = audioClips[i];
            audioSourece.volume = 1.0f;
            grab = instanceOfGameObject.AddComponent<OVRGrabbable>();
            grab.CustomGrabCollider(collide);
            DestoryObjectList.Add(instanceOfGameObject);
            XAxis++;
        }

    }

}
