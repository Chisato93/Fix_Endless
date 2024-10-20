using UnityEngine;
using UnityEngine.Playables;
public class GameManager : Singleton<GameManager>
{
    public bool IsFirstGame { get; set; } = true;
    public bool isLive;
    int goal = 3;
    int per_sec;
    int time_count;
    public int best_goal { get; set; } = 9999;
    public int Gold { get; set; } = 0;


    public GameObject go_Cinema;
    public GameObject go_Main;
    public void EndCinma()
    {
        //go_Cinema.SetActive(false);
        // go_Main.SetActive(true);

    }
    public void InitGame()
    {
        per_sec = 1;
        time_count = 0;

        current_Breathe = maxBreathe;

        InvokeRepeating("TImePerSecond", 0, per_sec);
    }


    public void ShowScene()
    {
        if (!IsFirstGame) 
            EndCinma();
        else 
            StartCinema();
    }

    public void StartCinema()
    {
        go_Main.SetActive(false);
        go_Cinema.SetActive(true);
    }

    public void GetGold(int gold)
    {
        Gold += gold;
    }
    public void GetOxgyn(int oxgyn)
    {
        current_Breathe += oxgyn;
    }

    void TImePerSecond()
    {
        if (isLive)
        {
            current_Breathe -= per_sec;
            if (current_Breathe <= 0)
            {
                Dead();
            }
            goal -= per_sec;
            if (goal <= 0)
            {
                Time.timeScale = 0f;
                goal = 0;
                GameClear();
            }


            BreatheGage();
            //if (GameUI.instance is null) return;
            //GameUI.instance.SetDistText(goal);

            time_count++;
            if (time_count >= 10)
            {
                time_count = 0;
                per_sec++;
            }
        }
        else
            CancelInvoke("TImePerSecond");
    }

    GameObject player = null;
    const int delay_Time = 2;
    public void Dead()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        isLive = false;
        player.GetComponent<PlayerAnimation>().Death();

        Invoke("GameOver", delay_Time);
    }

    const int maxBreathe = 200;
    int current_Breathe;

    public void GetBreathe(int amt)
    {
        current_Breathe += amt;
        if (current_Breathe >= maxBreathe) current_Breathe = maxBreathe;
        BreatheGage();
    }
    public void BreatheGage()
    {
        float gage = (float)current_Breathe / maxBreathe;
    }
    public float GetBreathGage()
    {
        return (float)current_Breathe / maxBreathe;
    }
    void GameOver()
    {
        DataManager.Instance.SaveData();

        Destroy(player);

        if (best_goal >= goal) best_goal = goal;

        // GameUI.instance.GameOver_UI(goal, best_goal);
    }
    void GameClear()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        player.SetActive(false);

        DataManager.Instance.SaveData();

        FindObjectOfType<Ending_TimeLine>().OpenTimeLine();
    }

}
