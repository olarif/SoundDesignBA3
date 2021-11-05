using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HouseManager : MonoBehaviour
{

    public AudioMixer mixer;

    public void GoInside()
    {
        mixer.SetFloat("OutsideVolume", -80f);
        mixer.SetFloat("HouseVolume", -15f);
    }

    public void Goutside()
    {
        mixer.SetFloat("OutsideVolume", 0f);
        mixer.SetFloat("HouseVolume", -80f);
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
