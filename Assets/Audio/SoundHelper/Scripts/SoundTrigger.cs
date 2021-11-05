using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class SoundTrigger : MonoBehaviour
{

    [SerializeField] private AudioSource soundSource;
    private bool hasPlayed = false;
    public bool loop = false;

    public UnityEvent m_MyEvent;

    private BoxCollider _boxCollider;

    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_MyEvent.Invoke();

        if (!other.CompareTag("Player")) return;

        if (!hasPlayed)
        {
            if (soundSource != null)
            {
                soundSource.Play();

                if (loop)
                {
                    hasPlayed = false;
                } else
                {
                    hasPlayed = true;
                }
            }
        }

        //Don't play sound if it has already played.
        if (hasPlayed)
            return;
    }

    private void OnDrawGizmosSelected()
    {
        if (_boxCollider == null)
            _boxCollider = GetComponent<BoxCollider>();

        Gizmos.color = new Color(0f, 0.5f, 0.5f, 0.5f);
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(_boxCollider.center, _boxCollider.size);
    }
}