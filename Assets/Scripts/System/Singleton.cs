using UnityEngine;

public class Singleton <T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (Instance == null)
            {
                GameObject obj;
                obj = FindObjectOfType<T>().gameObject;
                if (obj == null)
                {
                    obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                }
                else
                {
                    instance = obj.GetComponent<T>();
                }
            }
            return Instance;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
