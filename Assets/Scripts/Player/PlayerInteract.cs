using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public event Action OnPlayerDeath;

    private void OnTriggerEnter(Collider other)
    {
        HandleInteraction(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleInteraction(collision.gameObject);
    }

    private void HandleInteraction(GameObject other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact(this.gameObject);
        }
    }

    public void Dead()
    {
        OnPlayerDeath?.Invoke();
    }
}
