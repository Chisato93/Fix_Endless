using System.Collections;
using UnityEngine;

public class OxygenTank : InteractableObject
{
    const int oxygen_amount =30;

    private AudioManager _audioManager;
    private GameUI _gameUI;

    public void Init(AudioManager audioManager, GameUI gameUI)
    {
        _audioManager = audioManager;
        _gameUI = gameUI;

        OnInteract += () => _audioManager.PlayEffectSound(ItemType.OXYGEN);
        OnInteract += _gameUI.Breathe_Bar_Gage;
        OnInteract += () => GameManager.instance.GetOxgyn(oxygen_amount);
    }

}
