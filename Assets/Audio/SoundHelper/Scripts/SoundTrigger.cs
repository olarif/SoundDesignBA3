using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    private bool hasPlayed = false;
    public bool loop = false;

    private BoxCollider _boxCollider;

    private void OnTriggerEnter(Collider other)
    {
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