using System.IO;
using UnityEditor.TerrainTools;
using UnityEngine;
using static GameManager;

struct Data
{
    public bool firstGame;
    public int best_dist;
    public int gold;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }

    private void Start()
    {
        LoadData();

        GameManager.instance.ShowScene();
    }

    public void SaveData()
    {
        Data playerData = new Data
        {
            firstGame = GameManager.instance.FirstGame,
            best_dist = GameManager.instance.best_goal,
            gold = GameManager.instance.Gold,
        };

        // PlayerData ��ü�� JSON ���ڿ��� ��ȯ
        string jsonString = JsonUtility.ToJson(playerData, true);

        // ���� ��� ����
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
        string secrete_data = System.Convert.ToBase64String(bytes);

        // JSON ���ڿ��� ���Ͽ� ����E
        File.WriteAllText(path, secrete_data);

        Debug.Log("Data saved to: " + path);
    }

    public void LoadData()
    {

        // ���� ��� ����
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");

        // ������ �����ϴ���EȮ��
        if (File.Exists(path))
        {
            // ���Ͽ��� JSON ���ڿ� �б�E
            string jsonString = File.ReadAllText(path);

            byte[] bytes = System.Convert.FromBase64String(jsonString);
            string data = System.Text.Encoding.UTF8.GetString(bytes);

            // JSON ���ڿ��� PlayerData ��ü�� ��ȯ
            Data playerData = JsonUtility.FromJson<Data>(data);

            if (GameManager.instance != null)
            {
                GameManager.instance.FirstGame = playerData.firstGame;
                GameManager.instance.best_goal = playerData.best_dist;
                GameManager.instance.Gold = playerData.gold;

                MainHUDManager.instacne.SetGold();
            }

        }
    }
}
