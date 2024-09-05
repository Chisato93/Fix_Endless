using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Death()
    {
        anim.SetTrigger(AnimatorParams.DEATH);
    }

    void Streching()
    {
        anim.SetTrigger(AnimatorParams.STRECHING);
    }

    public void Carried()
    {
        anim.SetTrigger(AnimatorParams.CARRY);
    }

    public void Holding()
    {
        anim.SetTrigger(AnimatorParams.HOLD);
    }

    public void Dying()
    {
        anim.SetTrigger(AnimatorParams.DIE);
    }
    public void Idle()
    {
        anim.SetTrigger(AnimatorParams.IDLE);
    }
    public void Run()
    {
        anim.SetTrigger(AnimatorParams.RUN);
    }

}