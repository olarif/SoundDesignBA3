using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class VoidRoom : MonoBehaviour
{
    public PlayableDirector playable;
    public GameObject panel;
    private bool isActive;

    private void Start()
    {
        panel.SetActive(false);
        isActive = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        playable.Play();

        if (!isActive)
        {
            FindObjectOfType<HouseManager>().VoidMute();
            panel.SetActive(true);
            isActive = true;
            Invoke("Reactivate", 5f);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        playable.Stop();
        FindObjectOfType<HouseManager>().VoidUnmute();
        isActive = false;
    }

    void Reactivate()
    {
        panel.SetActive(false);
    }
}
