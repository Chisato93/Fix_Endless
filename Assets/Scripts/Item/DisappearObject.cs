using UnityEngine;

public class DisappearObject : InteractableObject
{
    private const float _durationTime = 3f;

    private void OnEnable()
    {
        Invoke("ExistForDuration", _durationTime);
    }
    private void OnDisable()
    {
        CancelInvoke("ExistForDuration");
    }
    private void ExistForDuration()
    {
        this.gameObject.SetActive(false);
    }

    protected override void Notify()
    {
        base.Notify();
        DestroyGameObject();
    }
    protected void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }

}
