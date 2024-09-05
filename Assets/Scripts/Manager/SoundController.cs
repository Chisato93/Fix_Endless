using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    [SerializeField] private AudioSource seAudio;
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private List<bgmSound> bgmSound;
    [SerializeField] private List<seSound> seSound;

    public void StopAudio()
    {
        // 쓸일없어보임
        seAudio.Stop();
        bgmAudio.Stop();
    }

    public void PlaySEAudio(SEType type)
    {
        AudioClip clip = seSound.FirstOrDefault(s => s.type == type).clip;
        seAudio.clip = clip;
        seAudio.Play();
    }

    public void SetBgm(string sceneName)
    {
        string clipName = sceneName + "BGM";
        AudioClip nextclip = bgmSound.FirstOrDefault(s => s.name == clipName).clip;
        bgmAudio.clip = nextclip;
        bgmAudio.Play();
    }

    public void SetSoundVolume(float volume)
    {
        seAudio.volume = volume;
        bgmAudio.volume = volume;
    }
}
