using UnityEngine;

public class Wall : InteractableObject
{
    protected override void RegisterEvents()
    {
        OnInteract += HandlePlayerInteraction;
    }

    protected override void UnregisterEvents()
    {
        OnInteract -= HandlePlayerInteraction;
    }
    private void HandlePlayerInteraction()
    {
        PlayerInteract playerInteract = FindObjectOfType<PlayerInteract>();
        if (playerInteract != null)
        {
            playerInteract.Dead();
        }
    }
}
