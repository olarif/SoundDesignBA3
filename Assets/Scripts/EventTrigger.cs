using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent m_MyEvent;
    private bool hasPlayed = false;
    public bool loop = false;

    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            if (!other.CompareTag("Player")) return;
            m_MyEvent.Invoke();

            if (loop)
            {
                hasPlayed = false;
            }
            else
            {
                hasPlayed = true;
            }
        }

        
    }
}
