using System;
using System.Collections;
using System.Collections.Specialized;
using System.Threading.Tasks;
using UnityEngine;

public class Road : MonoBehaviour, IInteractable
{
    public FloorType roadType;
    public Transform nextFloorSpawnPoint;

    public event Action OnEnterRoad;

    private const float _destroyTime = 5f;

    private void Start()
    {
        OnEnterRoad += FloorDestroy;
    }

    public void Interact(GameObject player)
    {
        StartCoroutine(Notify());
    }

    private IEnumerator Notify()
    {
        yield return new WaitForSeconds(_destroyTime);
        OnEnterRoad?.Invoke();
    }
    private void FloorDestroy()
    {
        Destroy(gameObject);
    }

}
