using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.panStereo = s.panStereo;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }
}
