using UnityEngine;

public class DisappearObject : InteractableObject
{
    private const float _durationTime = 5f;

    protected override void Notify()
    {
        base.Notify();
        DestroyGameObject();
    }
    protected void DestroyGameObject()
    {
        gameObject.SetActive(false);
    }

}
