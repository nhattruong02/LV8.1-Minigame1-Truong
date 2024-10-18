using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] Sound[] _sounds;
    [SerializeField] AudioSource _audio;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayOneShot(string name)
    {
        Sound sound = Array.Find(_sounds, x => x.name == name);
        if (sound == null)
        {

        }
        else
        {
            _audio.clip = sound.clip;
            _audio.PlayOneShot(sound.clip);
        }
    }
}
