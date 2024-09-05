using System.Collections;
using UnityEngine;

public class OxygenTank : InteractableObject
{
    const int oxygen_amount =30;
    [SerializeField]private GameUIController _gameUI;

    private void Start()
    {
        OnInteract += _gameUI.SetOxygen;
        OnInteract += () => SoundController.Instance.PlaySEAudio(SEType.Oxygen);
        OnInteract += () => GameManager.instance.GetOxgyn(oxygen_amount);
    }


    protected override void InteractItem()
    {
        base.InteractItem();
        Destroy(this.gameObject);
    }
}
