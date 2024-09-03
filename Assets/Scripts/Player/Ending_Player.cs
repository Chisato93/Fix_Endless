using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Player : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER))
        {
            Debug.Log("1");
            other.GetComponent<Ending_Player>().anim.SetTrigger("Carried");

            anim.SetTrigger("Holding");

            GetComponent<Collider>().isTrigger = false;
        }
    }
    void SetDying()
    {
        anim.SetTrigger("Dying");
    }
}
