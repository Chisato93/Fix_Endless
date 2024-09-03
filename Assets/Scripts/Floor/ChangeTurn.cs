using UnityEngine;

public class ChangeTurn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Tags.PLAYER))
        {
            other.GetComponent<PlayerRunning>().canTurn = true;
            GetComponent<Collider>().enabled = false;
        }
    }
}
