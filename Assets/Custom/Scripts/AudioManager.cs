using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; // Exit if an instance already exists
        }

        DontDestroyOnLoad(gameObject);
        CreateSoundsArray();
    }

    private void CreateInstance()
    {
        
    }

    private void CreateSoundsArray()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.Clip;

            sound.source.volume = sound.vol;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    
}
