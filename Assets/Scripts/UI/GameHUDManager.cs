using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDManager : MonoBehaviour
{
    public static GameHUDManager instance;
    private void Awake()
    {
        instance = this;
    }
    public TMP_Text score_text;

    public void SetDistText(int dist)
    {
        score_text.text = dist.ToString("#,##0");
    }

    public Image breathe_bar;
    public void Breathe_Bar_Gage(float gage)
    {
        breathe_bar.fillAmount = gage;
    }

    public GameObject result_panel;
    public TMP_Text result_Score_text;
    public TMP_Text best_Score_text;
    
    public void GameOver_UI(int dist, int best)
    {
        result_Score_text.text = dist.ToString("#,##0") + " m";
        best_Score_text.text = best.ToString("#,##0") + " m";
        result_panel.SetActive(true);
    }

    public TMP_Text gold_text;

    public void SetGoldText()
    {
        gold_text.text = GameManager.instance.Gold.ToString("#,##0");
    }
}
