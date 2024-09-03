using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] floors;
    public GameObject[] floors_corner;
    public List<Floor> floor_list;

    int straight_floor = 0;
    int random_floor = 0;

    const int corner_min = 4;
    const int corner_max = 9;

    private void Start()
    {
        Floor.OnFloorDestroyed += RemoveDestroyedFloor;

        // 현픸E바닥에서 다음 바닥의 생성 위치를 가져온다. 
        SetRandomFloor();
        if (floor_list.Count == 0) return;
        for(int i = 0; i < 9; i++)
        {
            CreateFloor();
        }
    }

    private void CreateFloor()
    {
        if(GameManager.instance.isLive)
        {
            if(straight_floor >= random_floor)
            {
                CreateConrerFloor();
                straight_floor = 0;
                SetRandomFloor();
            }
            else
            {
                CreateNoramlFloor();
                straight_floor++;
            }
        }
    }
    void SetRandomFloor()
    {
        random_floor = Random.Range(corner_min, corner_max);
    }

    private void CreateNoramlFloor()
    {
        Transform tr = floor_list[floor_list.Count-1].GetComponent<Floor>().next_Floor_Spawn_Point;
        int r = Random.Range(0, floors.Length);
        GameObject go = Instantiate(floors[r], tr.position, tr.rotation, this.transform);
        Floor go_floor = go.GetComponent<Floor>();
        floor_list.Add(go_floor);
    }

    private void CreateConrerFloor()
    {
        Transform tr = floor_list[floor_list.Count - 1].GetComponent<Floor>().next_Floor_Spawn_Point;
        int r = Random.Range(0, floors_corner.Length);
        GameObject go = Instantiate(floors_corner[r], tr.position, tr.rotation, this.transform);
        Floor go_floor = go.GetComponent<Floor>();
        floor_list.Add(go_floor);
    }

    private void RemoveDestroyedFloor(Floor destroyedFloor)
    {
        if (floor_list.Contains(destroyedFloor))
        {
            CreateFloor();
            floor_list.Remove(destroyedFloor);
        }
    }

    private void OnDestroy()
    {
        // 이벤트 구독 해제
        Floor.OnFloorDestroyed -= RemoveDestroyedFloor;
    }
}
