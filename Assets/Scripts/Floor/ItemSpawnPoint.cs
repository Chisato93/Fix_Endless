using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    public List<Vector3> item_Spawn_Point;

    const int range = 4;

    private void Awake()
    {
        for(int y = -range; y <= range; y+= range)
        {
            for(int x = -range; x <= range; x+= range)
            {
                Vector3 spawn_Point = new Vector3(y, 0, x);
                item_Spawn_Point.Add(spawn_Point);
            }
        }
    }
}
