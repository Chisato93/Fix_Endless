using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    private List<Road> roadList = new List<Road>();

    [SerializeField] private GameObject startRoad;
    [SerializeField] private ObjectPool roadObjectPool;

    private const int maxRoadCount = 9;

    private void Start()
    {
        StartCoroutine(GenerateRoad());
    }

    private IEnumerator GenerateRoad()
    {
        while (roadList.Count <= maxRoadCount)
        {
            if (roadList.Count <= 0)
            {
                Road road = Instantiate(startRoad, this.transform).GetComponent<Road>();
                road.OnEnterRoad += () => OnRoadDisappear(road);
                roadList.Add(road);

                yield return null;
            }

            AddRoad();

            yield return null;
        }
    }

    public void OnRoadDisappear(Road road)
    {
        if (road == null)
            return;

        roadList.Remove(road);
        roadObjectPool.PushObject(road.gameObject);
        AddRoad();
    }

    private void AddRoad()
    {
        GameObject roadObj = roadObjectPool.PullObject();
        Road road = roadObj.GetComponent<Road>();

        if (road.roadType == FloorType.CORNER && IsDoubleCornerRoad())
            roadObjectPool.PushObject(roadObj);
        else
        {
            Transform spawnTR = roadList[roadList.Count - 1].nextFloorSpawnPoint;
            roadObj.transform.SetPositionAndRotation(spawnTR.position, spawnTR.rotation);
            road.OnEnterRoad += () => OnRoadDisappear(road);
            roadList.Add(road);
        }
    }

    bool IsDoubleCornerRoad()
    {
        if (roadList.Count < 1)
            return false;

        int lastIndex = roadList.Count - 1;
        bool isLastCorner = roadList[lastIndex].roadType == FloorType.CORNER;

        return isLastCorner;
    }
}
