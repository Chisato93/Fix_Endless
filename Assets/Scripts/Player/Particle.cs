using UnityEngine;
public class Particle : MonoBehaviour
{
    private PlayerInteract playerInteract;
    [SerializeField] private ParticleSystem deathParticle;

    private void Start()
    {
        playerInteract = GetComponent<PlayerInteract>();
        playerInteract.OnPlayerDeath += PlayParticle;
    }

    public void PlayParticle()
    {
        if (deathParticle != null)
        {
            deathParticle.Play();
        }
    }
}
