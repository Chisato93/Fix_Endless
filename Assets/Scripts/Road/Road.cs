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

    //public GameObject[] items;
    //const int COIN = 0, ROCK = 1, OXYGEN = 2;
    //const int max_Coin_Count = 4;

    //void SetItem()
    //{
    //    if (roadType != FloorType.CORNER && roadType != FloorType.START_FLOOR)
    //    {
    //        ItemType rnd = (ItemType)Random.Range(0, (int)ItemType.TOTAL);

    //        ItemSpawnPoint item_spawn = GetComponentInChildren<ItemSpawnPoint>();

    //        if (rnd == ItemType.COIN)
    //        {
    //            int rndcnt = Random.Range(3, max_Coin_Count);

    //            for (int i = 0; i < rndcnt; i++)
    //            {
    //                int rnd_spawn = Random.Range(0, item_spawn.item_Spawn_Point.Count);
    //                Vector3 spawnPosition = item_spawn.item_Spawn_Point[rnd_spawn] + transform.position;
    //                Instantiate(items[COIN], spawnPosition, Quaternion.identity, this.transform);
    //                item_spawn.item_Spawn_Point.RemoveAt(rnd_spawn);
    //            }
    //        }
    //        else if (rnd == ItemType.ROCK)
    //        {
    //            int rnd_spawn = Random.Range(0, item_spawn.item_Spawn_Point.Count);
    //            Vector3 spawnPosition = item_spawn.item_Spawn_Point[rnd_spawn] + transform.position;
    //            Instantiate(items[ROCK], spawnPosition, Quaternion.identity, this.transform);
    //        }
    //        else
    //        {
    //            int rnd_spawn = Random.Range(0, item_spawn.item_Spawn_Point.Count);
    //            Vector3 spawnPosition = item_spawn.item_Spawn_Point[rnd_spawn] + transform.position;
    //            Instantiate(items[OXYGEN], spawnPosition, Quaternion.identity, this.transform);
    //        }
    //    }
    // }
}
