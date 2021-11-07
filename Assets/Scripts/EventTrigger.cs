using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent entryEvent;
    public UnityEvent exitEvent;
    private bool hasPlayed = false;
    public bool loop = false;

    void Start()
    {
        if (entryEvent == null)
            entryEvent = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            if (!other.CompareTag("Player")) return;
            entryEvent.Invoke();

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

    private void OnTriggerExit(Collider other)
    {
        if (!hasPlayed)
        {
            if (!other.CompareTag("Player")) return;
            exitEvent.Invoke();

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
