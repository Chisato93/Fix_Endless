using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] private SettingPanel settingPanel;

    public void OnStartButtonClicked()
    {
        // TODO => 로딩창 만들기
        SoundController.Instance.SetBgm(SceneName.GAME_SCENE);
        SceneController.Instance.LoadScene(SceneType.Game);
    }

    public void OnCinemaButtonClicked()
    {
        SceneController.Instance.LoadScene(SceneType.Cinema);
    }
    public void OnShopButtonClicked()
    {
        SceneController.Instance.LoadScene(SceneType.Shop);
    }

    public void OnSettingsButtonClicked()
    {
        GameObject settingObject = settingPanel.gameObject;

        if (!settingObject.activeSelf)
            settingPanel.ActiveOn();
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
