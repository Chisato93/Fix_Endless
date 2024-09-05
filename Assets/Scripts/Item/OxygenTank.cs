using System.Collections;
using UnityEngine;

public class OxygenTank : InteractableObject
{
    const int oxygen_amount =30;

    private SoundController _audioManager;
    private GameUIController _gameUI;

    public void Init(SoundController audioManager, GameUIController gameUI)
    {
        _audioManager = audioManager;
        _gameUI = gameUI;

        OnInteract += () => _audioManager.PlaySEAudio(SEType.Oxygen);
        OnInteract += _gameUI.SetOxygen;
        OnInteract += () => GameManager.instance.GetOxgyn(oxygen_amount);
    }

}
