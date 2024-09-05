using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private List<T> Values;
    private Queue<T> poolList = new Queue<T>();

    private const int _generateCount =5;
    private const int _atLeastCount =5;

    private void Start()
    {
        Init();

        Shuffle();
    }
    private void Init()
    {
        for (int i = 0; i < Values.Count; i++)
        {
            for (int j = 0; j < _generateCount; j++)
            {
                T obj = Instantiate(Values[i], this.transform);
                obj.name = Values[i].name;
                obj.gameObject.SetActive(false);
                poolList.Enqueue(obj);
            }
        }
    }
    private void Shuffle()
    {
        List<T> temp = new List<T>(poolList);

        for (int i = 0; i < temp.Count; i++)
        {
            int randomIndex = Random.Range(i, temp.Count);
            T tempItem = temp[i];
            temp[i] = temp[randomIndex];
            temp[randomIndex] = tempItem;
        }

        poolList.Clear();
        foreach (T obj in temp)
        {
            poolList.Enqueue(obj);
        }
    }

    public void PushObject(GameObject newObject)
    {
        T value = newObject.GetComponent<T>();

        newObject.SetActive(false);
        poolList.Enqueue(value);

        if (poolList.Count < _atLeastCount)
            Init();
    }

    public GameObject PullObject()
    {
        if (poolList.Count == 0)  
        {
            Init();
        }

        T obj = poolList.Dequeue(); 
        obj.gameObject.SetActive(true);
        return obj.gameObject;
    }

}
