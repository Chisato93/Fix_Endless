using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    protected AudioSource _audio;
    public List<AudioClip> clips;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void StopAudio()
    {
        _audio.Stop();
    }

    public void PlayAudio()
    {
        _audio.Play();
    }

    public void SetSoundVolume(float volume)
    {
        _audio.volume = volume;
    }
}
