using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private List<Vector3> item_Spawn_Point = new List<Vector3>();
    [SerializeField] private List<GameObject> itemPrefabs;
    private List<GameObject> items = new List<GameObject>();
    private GameObject onItem;
    private const int range = 4;
 
    private void Awake()
    {
        GenerateSpawnPoint();
        GenerateItem();
    }

    private void OnEnable()
    {
        if (!IsSpawnItem())
            return;

        int randomIndex = Random.Range(0, items.Count);
        onItem = items[randomIndex];
        onItem.transform.localPosition = GetRandomPosition();
        onItem.SetActive(true);

    }
    private void OnDisable()
    {
        if (onItem == null)
            return;

        onItem.SetActive(false);
        onItem.transform.position = Vector3.zero;
        onItem = null;
    }

    private bool IsSpawnItem()
    {
        return Random.value < 0.4f;
    }

    private void GenerateItem()
    {
        for(int i = 0; i < itemPrefabs.Count; i++)
        {
            GameObject item = Instantiate(itemPrefabs[i]);
            item.transform.SetParent(this.transform);
            item.name = itemPrefabs[i].name;
            item.SetActive(false);
            items.Add(item);
        }
    }

    private void GenerateSpawnPoint()
    {
        for (int y = -range; y <= range; y += range)
        {
            for (int x = -range; x <= range; x += range)
            {
                Vector3 spawn_Point = new Vector3(y, 0, x);
                item_Spawn_Point.Add(spawn_Point);
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        return item_Spawn_Point[Random.Range(0,item_Spawn_Point.Count)];
    }
}
