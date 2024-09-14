using System.Collections;
using UnityEngine;

public class Coin : InteractableObject
{
    private readonly int _distance;
    private SoundEffect _audioManager;
    private GameUI _gameUI;

    public void Init(SoundEffect audioManager, GameUI gameUI)
    {
        _audioManager = audioManager;
        _gameUI = gameUI;

        OnInteract += () => _audioManager.PlayEffectSound(ItemType.COIN);
        OnInteract += _gameUI.SetGoldText;
<<<<<<< Updated upstream
        OnInteract += () => GameManager.instance.GetGold(GetRandomCoin());
    }

=======
        OnInteract += () => SoundController.Instance.PlaySEAudio(SEType.Coin);
        OnInteract += () => GameManager.Instance.gold.AddGold(GetRandomCoin());
    }

    protected override void UnregisterEvents()
    {
        OnInteract -= _gameUI.SetGoldText;
        OnInteract -= () => SoundController.Instance.PlaySEAudio(SEType.Coin);
        OnInteract -= () => GameManager.Instance.gold.AddGold(GetRandomCoin());
    }

>>>>>>> Stashed changes
    int GetRandomCoin()
    {
        // 거리/100 +1, 거리 /100 * 2 +1;
        return Random.Range(1, 2);
    }
}
