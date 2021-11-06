using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerDoor : MonoBehaviour
{

    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    [SerializeField] private bool leaveTrigger = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                myDoor.Play("DoorOpen", 0, 0.0f);
                gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().PlaySound("DoorOpen");
            } 
            else if (closeTrigger)
            {
                myDoor.Play("DoorClose", 0, 0.0f);
                gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().PlaySound("DoorClose");
                FindObjectOfType<HouseManager>().GoInside();
            } else if (leaveTrigger)
            {
                FindObjectOfType<HouseManager>().GoOutside();
            }
        }
    }
}
