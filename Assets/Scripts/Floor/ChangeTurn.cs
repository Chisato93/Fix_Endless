using UnityEngine;

public class ChangeTurn : InteractableObject
{
    private PlayerRun _player;

    private void Start()
    {
        OnInteract += _player.SetTurn;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER))
        {
            _player = other.GetComponent<PlayerRun>();
            InteractItem();
        }
    }

    protected override void InteractItem()
    {
        base.InteractItem();
    }
}
