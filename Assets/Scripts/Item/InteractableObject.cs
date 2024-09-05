using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    protected event Action OnInteract;

    private void OnEnable()
    {
        RegisterEvents();
    }

    private void OnDisable()
    {
        UnregisterEvents();
    }

    protected virtual void RegisterEvents() { }
    protected virtual void UnregisterEvents() { }

    public void Interact(GameObject player)
    {
        Notify();
    }

    protected virtual void Notify()
    {
        OnInteract?.Invoke();
    }

}
