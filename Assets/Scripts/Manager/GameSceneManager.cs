using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public int oxygen = 100;
    public int oxygenDecreaseRate = 5;
    public int distanceToGoal = 100;
    public int currentDistance = 0;

    private bool isAlive = true;

    void Start()
    {
        InvokeRepeating("DecreaseOxygen", 1f, 1f);
    }

    void DecreaseOxygen()
    {
        if (isAlive)
        {
            oxygen -= oxygenDecreaseRate;
            if (oxygen <= 0)
            {
                Die();
            }
        }
    }

    public void CollectOxygen(int amount)
    {
        oxygen += amount;
        if (oxygen > 100) oxygen = 100;
    }

    public void MoveForward(int distance)
    {
        currentDistance += distance;
        distanceToGoal -= distance;

        if (distanceToGoal <= 0)
        {
            GameClear();
        }
    }

    void Die()
    {
        isAlive = false;
        CancelInvoke("DecreaseOxygen");
        ShowResultScreen();
    }

    void GameClear()
    {
        CancelInvoke("DecreaseOxygen");
        ShowResultScreen();
    }

    void ShowResultScreen()
    {
        int currentScore = currentDistance;
        if (currentScore > GameManager.Instance.best_goal)
        {
            GameManager.Instance.best_goal = currentScore;
            DataManager.Instance.SaveData();
        }

        // 결과 화면 출력 로직 추가
    }
}
