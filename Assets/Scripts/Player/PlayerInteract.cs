using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameOverPanel gameOverPanel;
    private PlayerAnimation playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();
    }

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
        SoundController.Instance.PlaySEAudio(SEType.Dead);
        particle.Play();
        playerAnim.Death();
        gameOverPanel.ActiveOn();
    }
}
