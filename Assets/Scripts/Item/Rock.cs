﻿using UnityEngine;

public class Rock : DisappearObject
{
    protected override void RegisterEvents()
    {
        OnInteract += () => SoundController.Instance.PlaySEAudio(SEType.Dead);
        OnInteract += HandlePlayerInteraction;
    }

    protected override void UnregisterEvents()
    {
        OnInteract -= () => SoundController.Instance.PlaySEAudio(SEType.Dead);
        OnInteract -= HandlePlayerInteraction;
    }
    private void HandlePlayerInteraction()
    {
        PlayerInteract playerInteract = FindObjectOfType<PlayerInteract>();
        if (playerInteract != null)
        {
            playerInteract.Dead();
        }
    }

}
