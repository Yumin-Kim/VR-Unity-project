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
    public static List<GameObject> DestoryObjectList;
    
    void Start()
    {
        //파일 Resource에서 로드
        ob = Resources.LoadAll<GameObject>("3DObject"); // 모든 객체 로드
        DestoryObjectList = new List<GameObject>();
        audioClips = Resources.LoadAll<AudioClip>("Music");
        TextureCollect = Resources.LoadAll<Texture>("Images"); 
        for (int i = 0; i < TextureCollect.Length; i++)
        {
            Debug.Log(">>>" + TextureCollect[i]);
        }
        /*
        bgm = Resources.Load<AudioClip>("1_볼견");
        Debug.Log(bgm);
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = bgm;
        audio.volume = 1.0f; //0.0f ~ 1.0f사이의 숫자로 볼륨을 조절
        audio.Play();
        */
        n_ChangeVariable = false;
        G_Count = 0;
        ChangeImageBool = true;
        InstanceGameObject(G_Count);

    }


    private void DestoryGameObject(int index)
    {
        for (int i = index; i < (index + 4); i++)
        {
            Destroy(DestoryObjectList[i]);
        }
        n_ChangeVariable = true;
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (CheckBox.checkBox1Valid && CheckBox2.checkBox2Vaild)
        //if (CheckBox2.checkBox2Vaild)
        {
            if (G_Count == 0)
            {
                DestoryGameObject(G_Count);
            }
            else
            {
                DestoryGameObject(G_Count * 4 );
            }
            ChangeImageBool = false;
        }
        if (n_ChangeVariable)
        {
            G_Count++;
            ChangeImageBool = true;
            CheckBox.checkBox1Valid = false;
            CheckBox2.checkBox2Vaild = false;
            n_ChangeVariable = false;
            InstanceGameObject((G_Count * 4));
        }
    }
    //게임 오브젝트마다 해당하는 노래 추가
    private void InstanceGameObject(int counter)
    {
        float XAxis = -1.5f, YAxis = 0.5f, ZAxis = 2;
        for (int i = counter; i < counter + 4; i++)
        {
            ob[i].transform.position = new Vector3(XAxis, YAxis, ZAxis);
            instanceOfGameObject = Instantiate(ob[i]);
            collide = instanceOfGameObject.AddComponent<BoxCollider>();
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
