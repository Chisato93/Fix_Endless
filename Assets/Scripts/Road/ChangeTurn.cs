using UnityEngine;

public class ChangeTurn : InteractableObject
{
    private PlayerRun _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerRun>();
    }
    protected override void RegisterEvents()
    {
        OnInteract += _player.SetTurn;
    }

    protected override void UnregisterEvents()
    {
        OnInteract -= _player.SetTurn;
    }
}
