using TMPro;
using UnityEngine;

public class MainHUDManager : MonoBehaviour
{
    public static MainHUDManager instacne;
    public TMP_Text gold;

    private void Awake()
    {
        instacne = this;
    }

    private void Start()
    {
        SetGold();
    }

    public void SetGold()
    {
        gold.text = GameManager.instance.Gold.ToString();
    }
}
