using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    [SerializeField] string AudioFile;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (AudioFile != null)
            {
                FindObjectOfType<AudioManager>().PlaySound(AudioFile);
            }
        }
    }
}
