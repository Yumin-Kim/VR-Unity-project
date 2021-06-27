using UnityEngine;

public class MatchPuzzle : MonoBehaviour
{
    EventValid triggerEvent = new EventValid();
    Rigidbody myRigid;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "puzzle_1")
        {
            triggerEvent.event_1 = true;
            transform.position = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
