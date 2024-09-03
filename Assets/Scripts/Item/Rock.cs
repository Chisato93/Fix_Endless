using UnityEngine;

public class Rock : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(Tags.PLAYER))
        {
            GameManager.instance.Dead();
        }
    }
}
