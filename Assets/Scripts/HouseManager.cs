using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HouseManager : MonoBehaviour
{

    public AudioMixer mixer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void MuteOutside()
    {
        mixer.SetFloat("OutsideVolume", -80f);
    }

    public void UnmuteOutside()
    {
        mixer.SetFloat("OutsideVolume", -30f);
    }
    public void MuteAll()
    {
        mixer.SetFloat("MasterVolume", -80f);
    }

    public void UnmuteAll()
    {
        mixer.SetFloat("MasterVolume", 0f);
    }

}
