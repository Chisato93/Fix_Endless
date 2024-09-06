using UnityEngine;

public class ChangeTurn : MonoBehaviour, IInteractable
{
    public void Interact(GameObject player)
    {
        player.GetComponent<PlayerRun>().SetTurn();
    }
}
