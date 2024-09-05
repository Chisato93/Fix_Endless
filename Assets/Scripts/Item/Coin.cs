using System.Collections;
using UnityEngine;

public class Coin : InteractableObject
{
    private readonly int _distance;
    [SerializeField] private GameUIController _gameUI;

    private void Start()
    {
        OnInteract += _gameUI.SetGoldText;
        OnInteract += () => SoundController.Instance.PlaySEAudio(SEType.Coin);
        OnInteract += () => GameManager.instance.GetGold(GetRandomCoin());
    }

    int GetRandomCoin()
    {
        // 거리/100 +1, 거리 /100 * 2 +1;
        return Random.Range(1, 2);
    }

    protected override void InteractItem()
    {
        base.InteractItem();
        Destroy(this.gameObject);
    }
}
