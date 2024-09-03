using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : SoundController
{
    const int exception = -1, coin = 0, dead = 1, oxygen = 2, tvsound = 3;

    public void PlayEffectSound(ItemType type)
    {
        SetAudioClip(type);
        PlayAudio();
    }

    private void SetAudioClip(ItemType type)
    {
        switch (type)
        {
            case ItemType.COIN:
                _audio.clip = clips[coin];
                break;
            case ItemType.OXYGEN:
                _audio.clip = clips[oxygen];
                break;
            default:
                break;
        }
    }

}
