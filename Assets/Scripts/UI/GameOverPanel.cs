using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : UIPanel
{
    [SerializeField] private TMP_Text currentDistanceText;
    [SerializeField] private TMP_Text bestDistanceText;
    private DistanceTextController curDistController;
    private DistanceTextController bestDistController;

    private void Start()
    {
        curDistController = new DistanceTextController(currentDistanceText);
        bestDistController = new DistanceTextController(bestDistanceText);
    }

    // 게임오버되면 수치 호출
    private void UpdateCurrentDistanceText(int amt)
    {
        curDistController.UpdateText(amt);
    }
    private void UpdateBsetDistanceText(int amt)
    {
        bestDistController.UpdateText(amt);
    }

    public void BackToMainScene()
    {
        SceneManager.LoadScene(SceneName.MAIN_SCENE);
    }
}
