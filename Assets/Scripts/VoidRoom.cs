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
            FindObjectOfType<HouseManager>().MuteAll();
            panel.SetActive(true);
            isActive = true;
            Invoke("Reactivate", 5f);
        }

        //Invoke("Growl", 5f);
    }

    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<HouseManager>().UnmuteAll();
        isActive = false;
    }

    void Growl()
    {
        FindObjectOfType<AudioManager>().PlaySound("Growl");
    }

    void Reactivate()
    {
        panel.SetActive(false);
    }
}
