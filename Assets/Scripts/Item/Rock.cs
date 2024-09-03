using UnityEngine;

public class Rock : InteractableObject
{
    private PlayerRunning _player;

    public void Init(PlayerRunning player)
    {
        _player = player;

        OnInteract += player.Death;
    }
}
