using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource SEaudio;
    public AudioSource BGMaudio;

    public List<AudioClip> se_Clips;
    public List<AudioClip> bgm_Clips;

    const int exception = -1, coin = 0, dead = 1, oxygen = 2, tvsound = 3;

    public void PlayEffectSound(ItemType type)
    {
        // 타입에 맞는 소리
        int seindex = GetType(type);
        if (seindex == exception)
            return;

        SEaudio.clip = se_Clips[seindex];
        SEaudio.Play();
    }

    int GetType(ItemType type)
    {
        switch (type)
        {
            case ItemType.COIN:
                return coin;
            case ItemType.OXYGEN:
                return oxygen;
            default:
                return exception;
        }
    }
}
