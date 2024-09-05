using System.Collections;
using UnityEngine;

public class Coin : InteractableObject
{
    private readonly int _distance;
    private SoundController _audioManager;
    private GameUIController _gameUI;

    public void Init(SoundController audioManager, GameUIController gameUI)
    {
        _audioManager = audioManager;
        _gameUI = gameUI;

        OnInteract += () => _audioManager.PlaySEAudio(SEType.Coin);
        OnInteract += _gameUI.SetGoldText;
        OnInteract += () => GameManager.instance.GetGold(GetRandomCoin());
    }

    int GetRandomCoin()
    {
        // 거리/100 +1, 거리 /100 * 2 +1;
        return Random.Range(1, 2);
    }
}
