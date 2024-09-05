using UnityEngine;
public class Particle : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticle;

    public void PlayParticle()
    {
        if (deathParticle != null)
        {
            deathParticle.Play();
        }
    }
}
