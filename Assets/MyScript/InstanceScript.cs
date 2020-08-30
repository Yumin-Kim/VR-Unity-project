using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstanceScript : MonoBehaviour
{
    // Start is called before the first frame update
    private OVRGrabbable grab;
    private BoxCollider collide;
    private GameObject instanceOfGameObject;
    private AudioSource audioSourece;
    private bool n_ChangeVariable;
    private List<GameObject> DestoryObjectList;
    private GameObject[] images;
    private AudioClip[] audioClips;
    private int Checkofindex;
    private int audioCoutVariable = 1;
    private int audioCout = 0;
    private float fDestroyTime = 1f;
    private float fTickTime;

    public static bool CheckButtonTrigger;
    public static int G_Count;
    public static Texture[] TextureCollect;
    public static bool ChangeImageBool;
    public static GameObject[] ob;
    public static GameObject[] ob1;


    void Start()
    {
        //파일 Resource에서 로드
        ob = Resources.LoadAll<GameObject>("3DObj"); // 모든 객체 로드
        DestoryObjectList = new List<GameObject>();
        audioClips = Resources.LoadAll<AudioClip>("Music");
        for (int i = 0; i < audioClips.Length; i++)
        {
            Debug.Log(audioClips[i].name);
        }
        TextureCollect = Resources.LoadAll<Texture>("Images");
        CheckButtonTrigger = false;
        Checkofindex = 0;
        n_ChangeVariable = false;
        G_Count = 0;
        ChangeImageBool = true;
        InstanceGameObject(G_Count);
        // ContactConfirmScript.checkBox1Valid = true;


    }
    /// <summary>
    /// update 문에서 참일때 쓰레드 생성 하여 descsoty하기 전에 lock걸고 동작후에 다른 동작 할  수 있게끔 
    /// </summary>


    private bool DestoryGameObject(int index)
    {
        Checkofindex = 0;
        if (index != 0)
        {
            Checkofindex = G_Count * 4;
        }
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
        if (CheckButtonTrigger)
        {
            if (ContactConfirmScript.checkBox1Valid && ContactConfirm2Script.checkBox2Valid && ContactConfirm3Script.checkBox3Valid && ContactConfirm4Script.checkBox4Valid)
            //if (ContactConfirmScript.checkBox1Valid)
            {
                Hello = true;
                Hello1 = true;
                ChangeImageBool = false;
                CheckButtonTrigger = false;
                ContactConfirmScript.checkBox1Valid = false;
                ContactConfirm2Script.checkBox2Valid = false;
                ContactConfirm3Script.checkBox3Valid = false;
                ContactConfirm4Script.checkBox4Valid = false;
                //ContactConfirmScript.checkBox1Valid = true;

            }

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
        if (G_Count != 0)
        {
            audioCoutVariable++;
            audioCout++;
        }
        float XAxis = -1.5f, YAxis = 0.5f, ZAxis = 2;
        for (int i = counter; i < counter + 4; i++)
        {
            if (ZAxis > 0.4f)
            {
                ZAxis = -0.5f;
            }
            else
            {
                ZAxis = 0.5f;

            }
            ob[i].transform.position = new Vector3(XAxis, YAxis, ZAxis);
            instanceOfGameObject = Instantiate(ob[i]);
            instanceOfGameObject.transform.localScale = new Vector3(50f, 50f, 50f);
            collide = instanceOfGameObject.AddComponent<BoxCollider>();
            audioSourece = instanceOfGameObject.AddComponent<AudioSource>();
            instanceOfGameObject.AddComponent<Rigidbody>().useGravity = true;
            //audioSourece.clip = audioClips[i];
            //audioSourece.volume = 1.0f;
            grab = instanceOfGameObject.AddComponent<OVRGrabbable>();
            grab.CustomGrabCollider(collide);
            DestoryObjectList.Add(instanceOfGameObject);
            XAxis++;
        }
        /*
                Debug.Log("Instance >>");
                Debug.Log("Instance >>"+DestoryObjectList.Count);
                */
        Debug.Log("Instance >>" + audioCout);
        for (int i = audioCout * 5; i < (audioCout * 5) + 5; i++)
        {
            Debug.Log(i + ">>>>>>>>>count");
            if (i < (audioCout * 5) + 4)
            {
                if (G_Count == 0)
                {
                    DestoryObjectList[i].GetComponent<AudioSource>().clip = audioClips[i];
                    DestoryObjectList[i].GetComponent<AudioSource>().volume = 1.0f;
                }
                else
                {
                    Debug.Log(i - audioCout);
                    DestoryObjectList[i - audioCout].GetComponent<AudioSource>().clip = audioClips[i];
                    DestoryObjectList[i - audioCout].GetComponent<AudioSource>().volume = 1.0f;
                }
            }
            else
            {
                GameObject.Find("Cube (3)").GetComponent<AudioSource>().clip = audioClips[i];
            }
        }

    }

}
