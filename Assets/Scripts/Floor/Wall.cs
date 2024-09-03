using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(Tags.PLAYER))
        {
            GameManager.instance.Dead();
        }
    }
}
