using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    public static SoundBox instance;
    AudioSource audioSource;
    private void Awake()
    {
        if (FindObjectsOfType<SoundBox>().Length > 1 && instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShot(NamesOfSound name)
    {
     
        audioSource.PlayOneShot(GetAudioClip(name));
    }
    public void PlayIfDontPlay(NamesOfSound name)
    {
        if (!audioSource.isPlaying) PlayOneShot(name);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    AudioClip GetAudioClip(NamesOfSound name)
    {
        return Resources.Load<AudioClip>("Sounds/" + name.ToString());
    }
}
