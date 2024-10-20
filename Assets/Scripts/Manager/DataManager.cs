using System.IO;
using UnityEngine;

public struct Data
{
    public bool firstGame;
    public int best_dist;
    public int gold;
}

public class DataManager : Singleton<DataManager>
{
    private void Start()
    {
        LoadData();
        GameManager.Instance.ShowScene();
    }

    public void SaveData()
    {
        Data playerData = new Data
        {
            firstGame = GameManager.Instance.IsFirstGame,
            best_dist = GameManager.Instance.best_goal,
            gold = GameManager.Instance.Gold
        };

        string jsonString = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
        string secrete_data = System.Convert.ToBase64String(bytes);
        File.WriteAllText(path, secrete_data);

        Debug.Log("Data saved to: " + path);
    }

    public void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");

        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            byte[] bytes = System.Convert.FromBase64String(jsonString);
            string data = System.Text.Encoding.UTF8.GetString(bytes);
            Data playerData = JsonUtility.FromJson<Data>(data);

            if (GameManager.Instance != null)
            {
                GameManager.Instance.IsFirstGame = playerData.firstGame;
                GameManager.Instance.best_goal = playerData.best_dist;
                GameManager.Instance.Gold = playerData.gold;
            }
        }
        else
        {
            Debug.Log("No save data found");
        }
    }
}
