using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> Values;
    private Queue<GameObject> poolList = new Queue<GameObject>();

    [SerializeField] private int _generateCount = 3;
    private const int _atLeastCount =5;

    private void Awake()
    {
        Init(_generateCount);
    }

    private void Init(int generateCount)
    {
        List<GameObject> tempList = new List<GameObject>();

        for (int i = 0; i < Values.Count; i++)
        {
            for (int j = 0; j < generateCount; j++)
            {
                tempList.Add(Values[i]);
            }
        }

        Shuffle(tempList);

        for (int i = 0; i < tempList.Count; i++)
        {
            GameObject obj = Instantiate(tempList[i], this.transform);  
            obj.name = tempList[i].name;  
            obj.SetActive(false); 
            poolList.Enqueue(obj);  
        }
    }

    private void Shuffle(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            GameObject temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    public void PushObject(GameObject newObject)
    {
        newObject.SetActive(false);
        poolList.Enqueue(newObject);
    }

    public GameObject PullObject()
    {
        if (poolList.Count <= _atLeastCount)  
        {
            Init(_generateCount);
        }

        GameObject obj = poolList.Dequeue(); 
        obj.SetActive(true);
        return obj;
    }

}
