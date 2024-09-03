using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected event Action OnInteract;

    private const float _durationTime = 3f;

    private void OnEnable()
    {
        Invoke("ExistForDuration", _durationTime);
    }
    private void OnDisable()
    {
        CancelInvoke("ExistForDuration");
    }

    private void Notify()
    {
        OnInteract?.Invoke();
    }

    private void ExistForDuration()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.PLAYER))
        {
            InteractItem();
        }
    }

    protected void InteractItem() {
        Notify();
        Destroy(this.gameObject);
    }
}
