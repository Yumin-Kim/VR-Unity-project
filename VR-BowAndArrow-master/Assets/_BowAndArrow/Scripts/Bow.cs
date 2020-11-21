using System;
using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Assets")]
    public GameObject m_ArrowPrefab = null;
    
    [Header("Assets")]
    public float m_GrabThreshold = 0.15f;
    public Transform m_Start = null;
    public Transform m_End = null;
    public Transform m_Sokect = null;

    private Transform m_Pullinghand = null;
    private Arrow m_CurrentArrow = null;
    private Animator m_Animator = null;

    private float m_PullValue = 0.0f;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(CreateArrow(0.0f));
    }

    private IEnumerator CreateArrow(float waritTime)
    {
        //Wait
        yield return null;

        //Create
        GameObject arrrowObject = Instantiate(m_ArrowPrefab, m_Sokect);

        //Orient
        arrrowObject.transform.localPosition = new Vector3(0, 0, 0.425f);
        arrrowObject.transform.localEulerAngles = Vector3.zero;
        //Set
        m_CurrentArrow = arrrowObject.GetComponent<Arrow>();
    }

    private void Update()
    {
        if (!m_Pullinghand || !m_CurrentArrow)
            return;
        m_PullValue = CalculatePull(m_Pullinghand);
        m_PullValue = Mathf.Clamp(m_PullValue, 0.0f,1.0f) ;

        m_Animator.SetFloat("Blend", m_PullValue);

    }

    private float CalculatePull(Transform pullHand)
    {
        Vector3 direction = m_End.position - m_Start.position;
        float magnitude = direction.magnitude;

        direction.Normalize();
        Vector3 differnece = pullHand.position - m_Start.position;

        return Vector3.Dot(differnece, direction) / magnitude;

    }

    public void Pull(Transform hand)
    {
        float distacne = Vector3.Distance(hand.position, m_Start.position);

        if (distacne > m_GrabThreshold)
            return;
        m_Pullinghand = hand;
    }
    
    public void Release()
    {
        if (m_PullValue > 0.25f)
            FireArrow();
        m_Pullinghand = null;

        m_PullValue = 0.0f;
        m_Animator.SetFloat("Blend", 0);

        if (!m_CurrentArrow)
            StartCoroutine(CreateArrow(0.25f));
    }

    private void FireArrow()
    {
        m_CurrentArrow.Fire(m_PullValue);
        m_CurrentArrow = null;

    }
        
}


