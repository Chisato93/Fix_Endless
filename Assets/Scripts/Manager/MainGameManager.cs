using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public GameObject cinematicPanel;
    public GameObject shopPanel;

    void Start()
    {
        if (GameManager.Instance.IsFirstGame)
        {
            ShowCinematic();
        }
        else
        {
            ShowMainMenu();
        }
    }

    void ShowCinematic()
    {
        cinematicPanel.SetActive(true);
        GameManager.Instance.IsFirstGame = false;
    }

    void ShowMainMenu()
    {
        shopPanel.SetActive(true);
    }

    public void PurchaseItem(int itemPrice)
    {
        if (GameManager.Instance.Gold >= itemPrice)
        {
            GameManager.Instance.Gold -= itemPrice;
            // 아이템 착용 로직 추가
        }
    }
}
