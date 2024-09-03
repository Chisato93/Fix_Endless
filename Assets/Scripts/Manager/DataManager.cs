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

        // PlayerData 객체를 JSON 문자열로 변환
        string jsonString = JsonUtility.ToJson(playerData, true);

        // 파일 경로 설정
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
        string secrete_data = System.Convert.ToBase64String(bytes);

        // JSON 문자열을 파일에 저픸E
        File.WriteAllText(path, secrete_data);

        Debug.Log("Data saved to: " + path);
    }

    public void LoadData()
    {

        // 파일 경로 설정
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");

        // 파일이 존재하는햨E확인
        if (File.Exists(path))
        {
            // 파일에서 JSON 문자열 읽콅E
            string jsonString = File.ReadAllText(path);

            byte[] bytes = System.Convert.FromBase64String(jsonString);
            string data = System.Text.Encoding.UTF8.GetString(bytes);

            // JSON 문자열을 PlayerData 객체로 변환
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
