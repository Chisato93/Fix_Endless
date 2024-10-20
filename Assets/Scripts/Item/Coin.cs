using System.Collections;
using UnityEngine;

public class Coin : DisappearObject
{
    private readonly int _distance;
    private GameUIController _gameUI;

    private void Start()
    {
        _gameUI = FindObjectOfType<GameUIController>();
    }

    protected override void RegisterEvents()
    {
        OnInteract += _gameUI.SetGoldText;
        OnInteract += () => SoundController.Instance.PlaySEAudio(SEType.Coin);
        OnInteract += () => GameManager.Instance.GetGold(GetRandomCoin());
    }

    protected override void UnregisterEvents()
    {
        OnInteract -= _gameUI.SetGoldText;
        OnInteract -= () => SoundController.Instance.PlaySEAudio(SEType.Coin);
        OnInteract -= () => GameManager.Instance.GetGold(GetRandomCoin());
    }

    int GetRandomCoin()
    {
        // 거리/100 +1, 거리 /100 * 2 +1;
        return Random.Range(1, 2);
    }

}
