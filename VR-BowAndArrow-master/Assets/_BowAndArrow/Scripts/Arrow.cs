using TMPro;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float m_Speed = 2000.0f;
    public Transform m_Tip = null;

    private Rigidbody m_Rigidbody = null;
    private bool m_InStopped = true;
    private Vector3 mLastPosition = Vector3.zero;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (m_InStopped)
            return;
        m_Rigidbody.MoveRotation(Quaternion.LookRotation(m_Rigidbody.velocity, transform.up));
        if (Physics.Linecast(mLastPosition, m_Tip.position))
        {
            Stop();
        }

        mLastPosition = m_Tip.position;
    }

    private void Stop()
    {
        m_InStopped = true;

        m_Rigidbody.isKinematic = true;
        m_Rigidbody.useGravity = false;

    }

    public void Fire(float pullValue)
    {
        m_InStopped = false;
        transform.parent = null;

        m_Rigidbody.isKinematic = false;
        m_Rigidbody.useGravity = true;
        m_Rigidbody.AddForce(transform.forward * (pullValue * m_Speed));

        Destroy(gameObject, 5.0f);

    }

}
