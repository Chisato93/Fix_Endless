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
        OnInteract += () => GameManager.instance.GetGold(GetRandomCoin());
    }

    int GetRandomCoin()
    {
        // 거리/100 +1, 거리 /100 * 2 +1;
        return Random.Range(1, 2);
    }
}
