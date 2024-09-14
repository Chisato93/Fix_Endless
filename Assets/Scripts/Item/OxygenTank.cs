using System.Collections;
using UnityEngine;

public class OxygenTank : InteractableObject
{
    const int oxygen_amount =30;

    private SoundEffect _audioManager;
    private GameUI _gameUI;

    public void Init(SoundEffect audioManager, GameUI gameUI)
    {
<<<<<<< Updated upstream
        _audioManager = audioManager;
        _gameUI = gameUI;

        OnInteract += () => _audioManager.PlayEffectSound(ItemType.OXYGEN);
        OnInteract += _gameUI.Breathe_Bar_Gage;
        OnInteract += () => GameManager.instance.GetOxgyn(oxygen_amount);
    }

=======
        OnInteract += _gameUI.SetOxygen;
        OnInteract += () => SoundController.Instance.PlaySEAudio(SEType.Oxygen);
        // OnInteract += () => GameManager.instance.GetOxgyn(oxygen_amount);
    }

    protected override void UnregisterEvents()
    {
        OnInteract -= _gameUI.SetOxygen;
        OnInteract -= () => SoundController.Instance.PlaySEAudio(SEType.Oxygen);
        // OnInteract -= () => GameManager.instance.GetOxgyn(oxygen_amount);
    }

>>>>>>> Stashed changes
}
