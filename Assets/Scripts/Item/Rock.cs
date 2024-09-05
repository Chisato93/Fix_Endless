using UnityEngine;

public class Rock : InteractableObject
{
    private PlayerBehaviour _player;

    private void Start()
    {
        OnInteract += _player.Death;
        OnInteract += () => SoundController.Instance.PlaySEAudio(SEType.Dead);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER))
        {
            _player = other.GetComponent<PlayerBehaviour>();
            InteractItem();
        }
    }

    protected override void InteractItem()
    {
        base.InteractItem();
        Destroy(this.gameObject);
    }
}
