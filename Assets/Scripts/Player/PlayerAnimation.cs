using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    ParticleSystem effect;
    AudioSource dead_sound;

    private void Awake()
    {
        effect = GetComponentInChildren<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();
        dead_sound = GetComponent<AudioSource>();
    }

    public void Dead()
    {
        effect.Play();
        anim.SetTrigger("Dead");
        dead_sound.Play();
    }

    void Streching()
    {
        anim.SetTrigger("Cinema");
    }

    public void Carried()
    {
        Debug.Log("C");
        anim.SetTrigger("Carried");
    }

    public void Holding()
    {
        Debug.Log("h");
        anim.SetTrigger("Holding");
    }

    public void Dying()
    {
        Debug.Log("d");
        anim.SetTrigger("Dying");
    }

}
