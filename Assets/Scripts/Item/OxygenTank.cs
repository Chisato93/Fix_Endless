using System.Collections;
using UnityEngine;

public class OxygenTank : DisappearObject
{ 
    const int oxygen_amount =30;
    private GameUIController _gameUI;

    private void Start()
    {
        _gameUI = FindObjectOfType<GameUIController>();
    }

    protected override void RegisterEvents()
    {
        OnInteract += _gameUI.SetOxygen;
        OnInteract += () => SoundController.Instance.PlaySEAudio(SEType.Oxygen);
        OnInteract += () => GameManager.Instance.GetOxgyn(oxygen_amount);
    }

    protected override void UnregisterEvents()
    {
        OnInteract -= _gameUI.SetOxygen;
        OnInteract -= () => SoundController.Instance.PlaySEAudio(SEType.Oxygen);
        OnInteract -= () => GameManager.Instance.GetOxgyn(oxygen_amount);
    }

}
