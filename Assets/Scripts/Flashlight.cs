using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] new GameObject light;
    private bool flashActive = false;

    void Start()
    {
        light.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(!flashActive)
            {
                light.gameObject.SetActive(true);
                flashActive = true;
            }else
            {
                light.gameObject.SetActive(false);
                flashActive = false;
            }
        }
    }
}
