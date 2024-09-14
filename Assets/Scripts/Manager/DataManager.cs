using System.IO;
using UnityEngine;

struct Data
{
    public bool firstGame;
    public int best_dist;
    public int gold;
}

public class DataManager
{
    private const string fileName = "SaveData.json";

    public void SaveData()
    {
        Data resourceData = new Data
        {
            firstGame = GameManager.Instance.isFirstGame,
            best_dist = GameManager.Instance.bestDistance.BestDistance,
            gold = GameManager.Instance.gold.Gold,
        };

        string jsonString = JsonUtility.ToJson(resourceData, true);

        string path = Path.Combine(Application.persistentDataPath, fileName);

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
        string secrete_data = System.Convert.ToBase64String(bytes);

        File.WriteAllText(path, secrete_data);
    }

    public void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);

            byte[] bytes = System.Convert.FromBase64String(jsonString);
            string data = System.Text.Encoding.UTF8.GetString(bytes);

            Data resourceData = JsonUtility.FromJson<Data>(data);

            if (GameManager.Instance != null)
            {
                GameManager.Instance.isFirstGame = resourceData.firstGame;
                GameManager.Instance.bestDistance.BestDistance = resourceData.best_dist;
                GameManager.Instance.gold.Gold = resourceData.gold;
            }
        }
        else
            Debug.Log("로드할 데이터가 없습니다.");
    }
}
