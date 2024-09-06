using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameOverPanel gameOverPanel;
    [SerializeField] private SettingPanel settingPanel;

    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private Image oxygenImage;

    private PlayerInteract playerInteract;
    private GoldTextController goldTextController;
    private DistanceTextController distanceTextController;
    private OxygenSlideController oxygenSlideController;

    private void Start()
    {
        playerInteract = FindObjectOfType<PlayerInteract>();
        playerInteract.OnPlayerDeath += ActiveGameOverPanel;

        goldTextController = new GoldTextController(goldText);
        distanceTextController = new DistanceTextController(distanceText);
        oxygenSlideController = new OxygenSlideController(oxygenImage);
    }

    public void SetGoldText()
    {
        // 게임매니저 인스턴스 말고 바꿀방법 있으면 생각해보기.
        int 임시 = 1;
        goldTextController.UpdateText(임시);
    }
    public void SetDistanceText()
    {
        int 임시 = 1;
        distanceTextController.UpdateText(임시);
    }
    public void SetOxygen()
    {
        float 임시 = 1f;
        oxygenSlideController.SetSlide(임시);
    }

    public void ActiveGameOverPanel()
    {
        if (!gameOverPanel.gameObject.activeSelf)
            gameOverPanel.ActiveOn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !settingPanel.gameObject.activeSelf)
            settingPanel.ActiveOn();
    }
}
