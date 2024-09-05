using UnityEngine;

public class Floor : MonoBehaviour
{
    public FloorType floor_type;
    public Transform next_Floor_Spawn_Point;

    float destroy_Time = 5f;
    const int max_Coin_Count = 4;

    public GameObject[] items;
    const int COIN = 0, ROCK = 1, OXYGEN = 2;

    public delegate void FloorDestroyedHandler(Floor floor);
    public static event FloorDestroyedHandler OnFloorDestroyed;

    private void Start()
    {
        SetItem();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Tags.PLAYER))
        {
            Invoke("FloorDestroy", destroy_Time);
        }
    }
    private void FloorDestroy()
    {
        OnFloorDestroyed?.Invoke(this);
        Destroy(gameObject);
    }

    void SetItem()
    {
        if(floor_type != FloorType.CORNER && floor_type != FloorType.START_FLOOR)
        {
            ItemType rnd = (ItemType)Random.Range(0, (int)ItemType.TOTAL);

            ItemSpawnPoint item_spawn = GetComponentInChildren<ItemSpawnPoint>();

            if (rnd == ItemType.COIN)
            {
                int rndcnt = Random.Range(3, max_Coin_Count);

                for (int i = 0; i < rndcnt; i++)
                {
                    int rnd_spawn = Random.Range(0, item_spawn.item_Spawn_Point.Count);
                    Vector3 spawnPosition = item_spawn.item_Spawn_Point[rnd_spawn] + transform.position;
                    Instantiate(items[COIN], spawnPosition, Quaternion.identity, this.transform);
                    item_spawn.item_Spawn_Point.RemoveAt(rnd_spawn);
                }
            }
            else if (rnd == ItemType.ROCK)
            {
                int rnd_spawn = Random.Range(0, item_spawn.item_Spawn_Point.Count);
                Vector3 spawnPosition = item_spawn.item_Spawn_Point[rnd_spawn] + transform.position;
                Instantiate(items[ROCK], spawnPosition, Quaternion.identity, this.transform);
            }
            else
            {
                int rnd_spawn = Random.Range(0, item_spawn.item_Spawn_Point.Count);
                Vector3 spawnPosition = item_spawn.item_Spawn_Point[rnd_spawn] + transform.position;
                Instantiate(items[OXYGEN], spawnPosition, Quaternion.identity, this.transform);
            }
        }
    }
}
