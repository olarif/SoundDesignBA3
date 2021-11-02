using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTrigger : MonoBehaviour
{
    public GameObject flashlight;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("SetActive", 2.5f);
            
        }
    }

    void SetActive()
    {
        flashlight.SetActive(true);
    }
}
