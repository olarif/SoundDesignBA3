using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] new GameObject light;
    private bool flashActive = true;

    void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("FlashlightOn");
        //light.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(!flashActive)
            {
                light.gameObject.SetActive(true);
                flashActive = true;
                FindObjectOfType<AudioManager>().PlaySound("FlashlightOn");
            }else
            {
                light.gameObject.SetActive(false);
                flashActive = false;
                FindObjectOfType<AudioManager>().PlaySound("FlashlightOff");
            }
        }
    }
}
